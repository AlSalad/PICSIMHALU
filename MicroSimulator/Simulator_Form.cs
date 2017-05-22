using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using MicroSimulator.Properties;
using static System.Convert;

namespace MicroSimulator
{  
    public partial class SimulatorForm : Form
    {
        #region Global fields ---------------------

        //Klassenaufruf Verbindung mit Hardware
        private SerialConnection _sc;
        //Arbeitsregister
        private int _w;
        //Literal
        private int _l;
        //Register f
        private int _f;

        //Letzter RA0 wert für Flankenauswertung
        private string LastRa0TmrVal { get; set; }
        private string LastB0Val { get; set; }

        //Tmr0 Zählerstand
        private int _tmr0Value;
        

        //Durchläufe von Befehlen
        private int _cycles;
        //Durchlauf für Berechnung von Prescaler
        private double _prescaleCircle;
        //Laufzeitzähler
        private double _runtime;
        
        //Statusregister in Variable
        private int _statusReg;
        //Programmcounter
        private int _programCounter;

        //Stop für Programm START/STOP
        private bool _stop;
        
        // ReSharper disable once FieldCanBeMadeReadOnly.Local --> Stack wird beschrieben
        private Stack<int> _stack = new Stack<int>();

        //Inhalt von Testfile
        private string[] _codeList;

        /// <summary>
        /// Erhalte Wert von Intconregister
        /// </summary>
        /// <returns></returns>
        private int GetIntcon()
        {
            // ReSharper disable once LoopCanBeConvertedToQuery --> Übersichtlicher
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(11)) continue;
                var value = row.Cells[2].Value;
                if (value != null) return Hex2Int(value.ToString());
            }
            return 0;
        }
        /// <summary>
        /// Schreibe Wert von Intconregister
        /// </summary>
        /// <param name="val">Wert der in Intcon geschrieben wird</param>
        private void SetIntcon(int val)
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(11))
                    row.Cells[2].Value = val.ToString("X");
            }
        }
        #endregion

        #region Load Forms ---------------------
        /// <summary>
        /// Form wird geladen, Serial Connection wird erstellt, Timer für Takt gestartet
        /// </summary>
        public SimulatorForm()
        {
            InitializeComponent();
            _sc = new SerialConnection();
            Timer_Takt.Interval = 2000;
            Timer_Takt.Start();
        }
        #endregion

        #region Serielle Schnittstelle
        /// <summary>
        /// Com1 Verbindung wird geöffnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Connect_Click(object sender, EventArgs e)
        {
            _sc.Connect(this);
        }

        /// <summary>
        /// Werte von Buttons zu TrisA werden zu Int umgewandelt
        /// </summary>
        /// <returns>TrisA als Integer</returns>
        public int GetTrisA()
        {
            var result = 0;
            for (var i = 0; i <= 4; i++)
            {
                var trisNameA = "button_A" + i;

                //if input => 1
                if (Controls[trisNameA].BackColor == Color.White)
                {
                    result += (int)Math.Pow(2, i);
                }

            }

            return result;
        }

        /// <summary>
        /// Werte von Buttons zu TrisB werden zu Int umgewandelt
        /// </summary>
        /// <returns>TrisB als Integer</returns>
        public int GetTrisB()
        {
            var result = 0;
            for (var i = 0; i <= 7; i++)
            {
                var trisNameB = "button_B" + i;

                //if input => 1
                if (Controls[trisNameB].BackColor == Color.White)
                    result += (int)Math.Pow(2, i);

            }

            return result;
        }

        /// <summary>
        /// Werte von Buttons zu PortA werden zu Int umgewandelt
        /// </summary>
        /// <returns>PortA als Integer</returns>
        public int GetPortA()
        {
            var result = 0;
            for (var i = 0; i <= 7; i++)
            {
                var portNameA = "button_bit_A" + i;

                //if input => 1
                if (Controls[portNameA].Text == "1")
                    result += (int)Math.Pow(2, i);
            }
            return result;
        }

        /// <summary>
        /// Werte von Buttons zu PortB werden zu Int umgewandelt
        /// </summary>
        /// <returns>PortB als Integer</returns>
        public int GetPortB()
        {
            var result = 0;
            for (var i = 0; i <= 7; i++)
            {
                var portNameB = "button_bit_B" + i;

                //if input => 1
                if (Controls[portNameB].Text == "1")
                    result += (int)Math.Pow(2, i);
            }
            return result;
        }

        /// <summary>
        /// PortA als Integer wird auf Buttonreihe übertragen
        /// </summary>
        /// <param name="value">PortA als Integer</param>
        public void SetPortA(uint value)
        {
            for (var i = 0; i <= 4; i++)
            {
                var bitValue = (int) Math.Pow(2, i);
                var portNameA = "button_bit_A" + i;

                //if input => 1
                if ((value & bitValue) == bitValue)
                    Controls[portNameA].Text = "1";
                else
                    Controls[portNameA].Text = "0";
            }
        }

        /// <summary>
        /// PortB als Integer wird auf Buttonreihe übertragen
        /// </summary>
        /// <param name="value">PortB als Integer</param>
        public void SetPortB(uint value)
        {
            for (var i = 0; i <= 7; i++)
            {
                var bitValue = (int)Math.Pow(2, i);
                var portNameB = "button_bit_B" + i;

                //if input => 1
                if ((value & bitValue) == bitValue)
                    Controls[portNameB].Text = "1";
                else
                    Controls[portNameB].Text = "0";
            }
        }
        #endregion

        #region Converter ---------------------
        /// <summary>
        /// String Hex wird zu Integer umgewandelt
        /// </summary>
        /// <param name="value">Wert als Hex</param>
        /// <returns>Wert als Integer</returns>
        private static int Hex2Int(string value)
        {
            try
            {return int.Parse(value, NumberStyles.HexNumber);}
            catch (Exception)
            {return 0;}            
        }
        #endregion

        #region Handle Commands -------------------
        /// <summary>
        /// Abfrage für jeden Befehl mittels Bitüberprüfung
        /// </summary>
        /// <param name="cmdValue">Hexwert vom Befehl</param>
        private void HandleCmd(string cmdValue)
        {
            var cmd = Hex2Int(cmdValue);

            if ((cmd & 0b11_1111_1001_1111) == 0b00_0000_0000_0000)
                Nop();

            //movlw
            if ((cmd & 0b11_1100_0000_0000) == 0b11_0000_0000_0000)
                Movlw(cmd & 255);

            //movwf
            if ((cmd & 0b11_1111_1000_0000) == 0b00_0000_1000_0000)
                Movwf(cmd & 127);

            //movf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1000_0000_0000)
                Movf(cmd & 255);

            //andlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1001_0000_0000)
                Andlw(cmd & 255);

            //andwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0101_0000_0000)
                Andwf(cmd & 255);

            //iorlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1000_0000_0000)
                Iorlw(cmd & 255);

            //iorwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0100_0000_0000)
                Iorwf(cmd & 255);

            //sublw
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1100_0000_0000)
                Sublw(cmd & 255);

            //sublw
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0010_0000_0000)
                Subwf(cmd & 255);

            //addlw
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1110_0000_0000)
                Addlw(cmd & 255);

            //addwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0111_0000_0000)
                Addwf(cmd & 255);

            //Xorlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1010_0000_0000)
                Xorlw(cmd & 255);

            //Xorwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0110_0000_0000)
                Xorwf(cmd & 255);

            //Clrf
            if ((cmd & 0b11_1111_1000_0000) == 0b00_0001_1000_0000)
                Clrf(cmd & 127);

            //Clrw
            if ((cmd & 0b11_1111_1000_0000) == 0b00_0001_0000_0000)
                Clrw();

            //Comf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1001_0000_0000)
                Comf(cmd & 255);

            //Incf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1010_0000_0000)
                Incf(cmd & 255);

            //Incfsz
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1111_0000_0000)
                Incfsz(cmd & 255);

            //Decf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0011_0000_0000)
                Decf(cmd & 255);

            //Decf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1011_0000_0000)
                Decfsz(cmd & 255);

            //Swapf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1110_0000_0000)
                Swapf(cmd & 255);

            //Rlf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1101_0000_0000)
                Rlf(cmd & 255);

            //Rrf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1100_0000_0000)
                Rrf(cmd & 255);

            //bcf
            if ((cmd & 0b11_1100_0000_0000) == 0b01_0000_0000_0000)
                Bcf(cmd & 0b00_0011_1111_1111);

            //bsf
            if ((cmd & 0b11_1100_0000_0000) == 0b01_0100_0000_0000)
                Bsf(cmd & 0b00_0011_1111_1111);

            //btfsc
            if ((cmd & 0b11_1100_0000_0000) == 0b01_1000_0000_0000)
                Btfsc(cmd & 0b00_0011_1111_1111);

            //btfss
            if ((cmd & 0b11_1100_0000_0000) == 0b01_1100_0000_0000)
                Btfss(cmd & 0b00_0011_1111_1111);

            //GoTo
            if ((cmd & 0b11_1000_0000_0000) == 0b10_1000_0000_0000)
                Goto(cmd & 0b00011111111111);

            //Call
            if ((cmd & 0b11_1000_0000_0000) == 0b10_0000_0000_0000)
                CallSub(cmd & 0b00011111111111);

            //Retlw
            if ((cmd & 0b11_1100_0000_0000) == 0b11_0100_0000_0000)
                Retlw(cmd & 255);

            //return
            if (cmd == 0b00_0000_0000_1000)
                ReturnToCall();

            if (cmd == 0b00_0000_0000_1001)
                Retfie();
        }
        #endregion

        #region Register control -------------------
        /// <summary>
        /// Wenn Wert von Berechnung 0 ist setze ZeroFlag, wenn nicht resete es
        /// </summary>
        /// <param name="val">Ergebnis einer Operations</param>
        private void SetZeroFlag(int val)
        {
            //Zero Flag
            if (val == 0)
                _statusReg = _statusReg | 4;
            else
                _statusReg = _statusReg & ~4 & 0x000000FF;
        }

        /// <summary>
        /// Schreibe das Status Register
        /// </summary>
        private void WriteStatusReg()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(3))
                    row.Cells[2].Value = _statusReg.ToString("X");

            }
        }

        /// <summary>
        /// Schreibe Werte von Statusregister in Flagboxen
        /// </summary>
        private void WriteFlags()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(3)) continue;

                var value = row.Cells[2].Value;

                if (value != null && (string)value != "")
                {
                    var status = Hex2Int(value.ToString());
                    var zeroFlag = (status & 4) == 0 ? 0 : 1;
                    var digitCarry = (status & 2) == 0 ? 0 : 1;
                    var carryFlag = (status & 1) == 0 ? 0 : 1;

                    textBox_ZeroFlag.Text = zeroFlag.ToString("X");
                    text_DC.Text = digitCarry.ToString("X");
                    textBox_CarryFlag.Text = carryFlag.ToString("X");
                }
            }

        }

        /// <summary>
        /// Schreibe das benutzteRegister
        /// Bank0 => i=2
        /// Bank1 => i=3
        /// </summary>
        /// <param name="cmdReg">Adresse von Register</param>
        private void WriteReg(int cmdReg)
        {
            var i = 2;
            if ((_statusReg & 32) == 32)
                i = 3;

            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(cmdReg)) continue;

                row.Cells[i].Value = _f.ToString("X");
                return;
            }
            if (i == 2)
                dataGridView_Register.Rows.Add("", cmdReg.ToString("X"), _f.ToString("X"), "");
            if (i == 3)
                dataGridView_Register.Rows.Add("", cmdReg.ToString("X"), "", _f.ToString("X"));

        }

        /// <summary>
        /// Lese aus Wert aus Register
        /// </summary>
        /// <param name="cmdReg">Adresse von Register</param>
        /// <returns>Wert von Register</returns>
        private int ReadReg(int cmdReg)
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(cmdReg)) continue;
                var value = row.Cells[2].Value;
                if (value != null && (string)value != "") return Hex2Int(value.ToString());
            }
            return 0;
        }
        #endregion

        #region Commands -------------------
        /// <summary>
        /// No operation, 1c
        /// </summary>
        private void Nop()
        {
            _cycles = 1;
        }

        /// <summary>
        /// Spring zu Adressenliteral, 2c
        /// </summary>
        /// <param name="cmdLit">Adresse</param>
        private void Goto(int cmdLit)
        {
            var hexVal = cmdLit.ToString("X");
            var searchString = hexVal.PadLeft(4, '0');

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchString))
                    {
                        dataGridView_prog.CurrentCell =
                            dataGridView_prog
                                .Rows[row.Index-2]
                                .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                        dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            _cycles = 2;
        }

        /// <summary>
        /// Literal in Arbeitsregister, 1c
        /// </summary>
        /// <param name="cmdLit">Literal</param>
        private void Movlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _l;
            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Arbeitsregister in Register f bewegen
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Movwf(int cmdReg)
        {
            if (cmdReg == 0)
                cmdReg = ReadReg(0x04);

            _f = _w;
            WriteReg(cmdReg);
            _cycles = 1;
        }

        /// <summary>
        /// Bewege Wert von f nach f oder w
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Movf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            int result;
            if (fReg == 0)
            {
                result = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                result = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            SetZeroFlag(result);

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);

            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Inklusiv oder von Literal und W, speichern in W
        /// </summary>
        /// <param name="cmdLit">Literal</param>
        private void Iorlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w | _l;
            SetZeroFlag(_w);
            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Inklusiv ODER von W und F, speichern in W oder F
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Iorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;

            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            var result = _f | _w;
           
            SetZeroFlag(result);

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }

            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// UND von L und W, speichern in W
        /// </summary>
        /// <param name="cmdLit">Literal L</param>
        private void Andlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w & _l;
            SetZeroFlag(_w);
            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// UND von W und F, speichern in W oder F
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Andwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fOpt = cmdReg & 128;

            if (fOpt == 128)
            {
                _f = _w & _f;
                SetZeroFlag(_f);
                WriteReg(fReg);
            }

            if (fOpt == 0)
            {
                _w = _w & _f;
                SetZeroFlag(_w);
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Exklusiv ODER von Literal und W, speichern in W
        /// </summary>
        /// <param name="cmdLit">Literal</param>
        private void Xorlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w ^ _l;

            SetZeroFlag(_w);

            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Exklusiv ODER von Wert von F und W, speichern in W oder F
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Xorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fOpt = cmdReg & 128;

            var result = _f ^ _w;
            SetZeroFlag(result);

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Subtraktion W von L, speicher in W
        /// </summary>
        /// <param name="cmdLit">Literal</param>
        private void Sublw(int cmdLit)
        {
            _l = cmdLit;
            var lowLBits = _l & 15;
            var lowWBits = _w & 15;

            //DigitCarry
            if (lowLBits + ((16-lowWBits)) > 15) _statusReg = _statusReg  | 2;
            else _statusReg = _statusReg & ~2 & 0x000000FF;

            if (_l - _w < 0)
            {
                _w = 256 + (_l - _w);
                //CarryFlag = 0
                _statusReg = _statusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                _statusReg = _statusReg & ~4 & 0x000000FF;
            }
            else
            {
                _w = _l - _w;
                //CarryFlag = 1;
                _statusReg = _statusReg | 1;
                //Zero Flag = 1;
                if (_w == 0)
                    _statusReg = _statusReg | 4;
            }

            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Subtraktion W von Wert von F, speichern in W oder F
        /// </summary>
        /// <param name="cmdReg">F</param>
        private void Subwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            var lowFBits = _f & 240;
            var lowWBits = _w & 240;

            //DigitCarry
            if (lowFBits + 16 - lowWBits > 15) _statusReg = _statusReg | 2;
            else _statusReg = _statusReg & ~2 & 0x000000FF;

            int result;

            //Berechnung
            if (_f - _w < 0)
            {
                result = 256 + _f - _w;
                //CarryFlag = 0
                _statusReg = _statusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                _statusReg = _statusReg & ~4 & 0x000000FF;
            }          
            else
            {
                result = _f - _w;
                //CarryFlag = 1
                _statusReg = _statusReg | 1;
                //Zero Flag = 1
                if (result == 0)
                    _statusReg = _statusReg | 4;
            }

            //Ausgabe
            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Addieren von L und W
        /// </summary>
        /// <param name="cmdLit">L</param>
        private void Addlw(int cmdLit)
        {
            _l = cmdLit;
            var lowLBits = cmdLit & 15;
            var lowWBits = _w & 15;

            //DigitCarry
            if (lowLBits + lowWBits > 15) _statusReg = _statusReg | 2; 
            else _statusReg = _statusReg & ~2 & 0x000000FF; 

            if (_l + _w > 255)
            {
                _w = (_l+_w) - 256;

                //CarryFlag = 1
                _statusReg = _statusReg | 1;
                //Zero Flag = 1
                if (_w == 0) 
                    _statusReg = _statusReg | 4;
            }
            else
            {
                _w = _l + _w;
                //CarryFlag = 0
                _statusReg = _statusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                _statusReg = _statusReg & ~4 & 0x000000FF;
            }

            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Addieren von Wert von F und W
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Addwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }             
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var lowFBits = _f & 15;
            var lowWBits = _w & 15;
            int result;

            //DigitCarry
            if (lowFBits + lowWBits > 15) _statusReg = _statusReg | 2;
            else _statusReg = _statusReg & ~2 & 0x000000FF;

            //Berechnung
            if (_f + _w > 255)
            {
                result = _f + _w - 256;
                //CarryFlag = 1
                _statusReg = _statusReg | 1;
                //Zero Flag = 1
                if (_w == 0)
                    _statusReg = _statusReg | 4;
            }
            else
            {
                result = _f + _w;
                //CarryFlag = 0
                _statusReg = _statusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                _statusReg = _statusReg & ~4 & 0x000000FF;
            }

            //Speicherort
            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }           
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Wert von F auf 0 setzen
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Clrf(int cmdReg)
        {
            if (cmdReg == 0) { 
                _f = ReadReg(ReadReg(0x04));
                cmdReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(cmdReg);
            _f = 0;
            WriteReg(cmdReg);
            //Zero Flag = 1
            _statusReg = _statusReg | 4;
            _cycles = 1;
        }

        /// <summary>
        /// Arbeitsregister auf 0 setzen
        /// </summary>
        private void Clrw()
        {
            _w = 0;
            //Zero Flag = 1
            _statusReg = _statusReg | 4;
            text_W.Text = _w.ToString("X");
            _cycles = 1;
        }

        /// <summary>
        /// Komplement von f, speichern in F oder W
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Comf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fOpt = cmdReg & 128;

            var result = ~_f & 0x000000FF;

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);

            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Inkrement von f, speichern in F oder w
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Incf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;           
            var result = _f + 1;
            
            if (result > 255)
                result = 0;

            SetZeroFlag(result);

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Inkrement von f, wenn 255->0 Überspringe nächste Zeile
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Incfsz(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var result = _f + 1;

            if (result > 255)
                result = 0;

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
            if (result != 0) return;
            _cycles = 2;
            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Dekrement von f, speichern in F oder W
        /// </summary>
        /// <param name="cmdReg">Register F</param>
        private void Decf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var result = _f - 1;
            SetZeroFlag(result);

            if (result < 0)
                result = 255;

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Dekrement von f, wenn 0->255 Überspringe nächste Zeile
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Decfsz(int cmdReg)
        {
            var fReg = cmdReg & 127;
            _f = ReadReg(fReg == 0 ? ReadReg(0x04) : fReg);

            var fOpt = cmdReg & 128;

            var result = _f - 1;

            if (result < 0)
                result = 255;

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
            if (result != 0) return;
            _cycles = 2;
            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Tausche oberes Halfbyte mit unterem halfbyte von Wert von f
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Swapf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fOpt = cmdReg & 128;
            
            var upperNibble = _f & 0b1111_0000;
            var lowerNibble = _f & 0b0000_1111;
            upperNibble = upperNibble >> 4;
            lowerNibble = lowerNibble << 4;

            var result= upperNibble | lowerNibble;

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Rotiere den Wert von f nach links durch das Carryflag
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Rlf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fOpt = cmdReg & 128;
            var currCf = _statusReg & 1;

            if ((_f & 128) == 128) _statusReg = _statusReg | 1;
            else   _statusReg = _statusReg & ~1 & 0x000000FF; 

            var shiftResult = (_f << 1) & 255;

            var result = shiftResult | currCf;             

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Rotiere den Wert von f nach rechts durch das Carryflag
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Rrf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }             
            else
                _f = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            int result;

            var currCf = _statusReg & 1;

            if ((_f & 1) == 1)_statusReg = _statusReg | 1;
            else _statusReg = _statusReg & ~1 & 0x000000FF;

            var shiftResult = _f >> 1;

            if (currCf == 1)
                result = shiftResult | 128;
            else
                result = shiftResult;   

            if (fOpt == 128)
            {
                _f = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                _w = result;
                text_W.Text = _w.ToString("X");
            }
            _cycles = 1;
        }

        /// <summary>
        /// Setze das jeweilige Bit auf 0 vom Register f
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Bcf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);

            _f = _f & ~bitValue & 0x000000FF;

            WriteReg(fReg);
            if (fReg == 3) _statusReg = _f;
            _cycles = 1;
        }

        /// <summary>
        /// Setze das jeweilige Bit auf 1 vom Register f
        /// </summary>
        /// <param name="cmdReg"></param>
        private void Bsf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                _f = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                _f = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = Math.Pow(2, fBits);

            _f = _f | (int)bitValue;
            WriteReg(fReg);
            if (fReg == 3) _statusReg = _f;
            _cycles = 1;
        }

        /// <summary>
        /// Bittest if set clear
        /// </summary>
        /// <param name="cmdReg">Register f</param>
        private void Btfsc(int cmdReg)
        {
            var fReg = cmdReg & 127;

            //wenn Register Indirekt angefragt, hole Daten aus FSR, ansonsten normal
            _f = ReadReg(fReg == 0 ? ReadReg(0x04) : fReg);

            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int) Math.Pow(2, fBits);
            _cycles = 1;

            if ((_f & bitValue) != 0) return;

            _cycles = 2;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Bit test if set skip
        /// </summary>
        /// <param name="cmdReg"></param>
        private void Btfss(int cmdReg)
        {
            var fReg = cmdReg & 127;
            //wenn Register Indirekt angefragt, hole Daten aus FSR, ansonsten normal
            _f = ReadReg(fReg == 0 ? ReadReg(0x04) : fReg);

            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);

            _cycles = 1;
            if ((_f & bitValue) != bitValue) return;
            _cycles = 2;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Springe in Subroutine
        /// </summary>
        /// <param name="cmdLit">Adresse an die gesprungen werden soll</param>
        private void CallSub(int cmdLit)
        {
            _stack.Push(_programCounter);
            var hexVal = cmdLit.ToString("X");
            var searchString = hexVal.PadLeft(4, '0');

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchString))
                    {
                        _cycles = 2;
                        dataGridView_prog.CurrentCell =
                            dataGridView_prog
                                .Rows[row.Index - 1]
                                .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                        dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Schau auf Stack, spring an diese Adresse
        /// </summary>
        private void ReturnToCall()
        {
            _cycles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Schau auf Stack, spring an diese Adresse und schreibe Literal in W
        /// </summary>
        /// <param name="cmdLit">Literal</param>
        private void Retlw(int cmdLit)
        {
            _cycles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            _l = cmdLit;
            _w = _l;
            text_W.Text = _w.ToString("X");          
        }

        /// <summary>
        /// Gehe aus Interupt subrouting, lese von Stack
        /// </summary>
        private void Retfie()
        {
            _cycles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            var intcon = GetIntcon() | 128;

            SetIntcon(intcon);
        }
        #endregion

        #region Button Control -------------------
        /// <summary>
        /// Öffne Test file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            ResetParam();
            //CmdInput.Items.Clear();
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D:\\Workspace\\PICSIMHALU\\Tests",
                Filter = @"*.LST|",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var customStream = openFileDialog.OpenFile();

                using (customStream)
                {                
                    using (var reader = new StreamReader(customStream))
                    {
                        dataGridView_prog.Rows.Clear();
                        dataGridView_Register.Rows.Clear();
                        text_path.Text = openFileDialog.FileName;
                        _codeList = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        FillDataTable();
                        dataGridView_prog.Rows[0].Selected = true;
                        //RegexCmd();
                    }
                }
            }
            catch (Exception ex){MessageBox.Show(Resources.read_error + ex.Message); }
        }

        /// <summary>
        /// Fülle Daten in Tabelle 
        /// </summary>
        private void FillDataTable()
        {
            foreach (var codeLine in _codeList)
            {
                var idValue = codeLine.Substring(0, 4).Trim();

                var cmdValue = codeLine.Substring(5, 4).Trim();

                var cmdOperatorValue = codeLine.Substring(36);                

                if (cmdOperatorValue.Contains(';'))
                    cmdOperatorValue = (cmdOperatorValue.Substring(0, cmdOperatorValue.IndexOf(";", StringComparison.Ordinal) + 1)).Trim().TrimEnd(';');

                if (cmdOperatorValue.Contains("equ"))
                    dataGridView_Register.Rows.Add(cmdOperatorValue.Substring(0, 9).Trim(), cmdOperatorValue.Substring(13).Trim().TrimEnd('h'));

                var loop = codeLine.Substring(27, 9).Trim();

                if (idValue == "" && cmdValue == "" && cmdOperatorValue == "" && loop == "") continue;

                dataGridView_prog.Rows.Add(null ,idValue, cmdValue, cmdOperatorValue, loop);
            }
        }

        /// <summary>
        /// Führe einen Befehl aus und gehe eine Zeile weiter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Step_Click(object sender, EventArgs e)
        {
            Execute();
            if (dataGridView_prog.CurrentRow != null)
            {
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
            }           
        }

        /// <summary>
        /// Starte Timer und führe Befehle alle ms aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (dataGridView_prog.CurrentRow != null && ToBoolean(dataGridView_prog.CurrentRow.Cells[0].Value))
            {
                Execute();
                if (dataGridView_prog.CurrentRow != null)
                    dataGridView_prog.CurrentCell =
                        dataGridView_prog
                            .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                            .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
            }
            Start();
        }

        /// <summary>
        /// Starte Timer für Program
        /// </summary>
        private void Start()
        {
            _stop = false;
            try
            {
                var quartz = int.Parse(textBox_Quarz.Text);

                if (quartz == 0) return;

                if (quartz > 4000) quartz = 4000;
                Timer_prog.Interval = 1;
                //Timer_0.Interval = 4000 / quartz * ReadTmrPrescaler();
            }
            catch (FormatException)
            {return;}
                
            Timer_prog.Start();
            //Timer_0.Start();
        }

        /// <summary>
        /// Wenn Stop button gedrückt wird, setzte Stop auf wahr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Stop_Click(object sender, EventArgs e) => _stop = true;

        /// <summary>
        /// Resetet alle Werte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Reset_Click(object sender, EventArgs e)
        {
            ResetParam();

            if (dataGridView_prog.CurrentRow == null) return;

            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[0]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// Öffnet PDF Hilfe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Koopa\Documents\DHBW\Semester 4\Rechnertechnik\Pflichtenheft_Rechnertechnik.pdf");
        }

        #endregion

        #region RunTime -------------------

        /// <summary>
        /// Setze alle Werte zurück auf Standard
        /// </summary>
        private void ResetParam()
        {
            _w = 0;
            _stop = true;
            text_W.Text = _w.ToString();
            _programCounter = 0;
            _statusReg = 0;
            _cycles = 0;
            _tmr0Value = 0;
            _runtime = 0;
            _prescaleCircle = 0;
            text_Pc.Text = _programCounter.ToString();
            textBox_CarryFlag.Text = @"0";
            textBox_ZeroFlag.Text = @"0";
            text_DC.Text = @"0";
            text_Tmr0.Text = @"0";
            text_Runtime.Text = @"0";
            text_Prescaler.Text = @"1 / 1";
            _f = 0;

            if (dataGridView_Register.CurrentRow == null) return;
            dataGridView_prog.Rows[0].Selected = true;

            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                row.Cells[2].Value = "";
                row.Cells[3].Value = "";
            }

            ResetRegValues();
        }

        /// <summary>
        /// Setze Werte von Register zurück
        /// </summary>
        private void ResetRegValues()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(0))
                    row.Cells[2].Value = "--------";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(1))
                    row.Cells[2].Value = "xxxxxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(2))
                    row.Cells[2].Value = "00000000";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(3))
                    row.Cells[2].Value = "00011xxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(4))
                    row.Cells[2].Value = "xxxxxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(5))
                    row.Cells[2].Value = "---xxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(6))
                    row.Cells[2].Value = "xxxxxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(8))
                    row.Cells[2].Value = "xxxxxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(9))
                    row.Cells[2].Value = "xxxxxxxx";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(10))
                    row.Cells[2].Value = "---00000";
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(11))
                    row.Cells[2].Value = "00000000";
            }
        }

        /// <summary>
        /// Führt Befehl aus
        /// </summary>
        private void Execute()
        {
            if (dataGridView_prog.CurrentRow == null) return;

            _programCounter = dataGridView_prog.CurrentRow.Index;
            text_Pc.Text = _programCounter.ToString();

            CheckInterrupt();

            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(1))
                    _tmr0Value = Hex2Int(row.Cells[2].Value.ToString());
            }

            var cmd = dataGridView_prog.CurrentRow.Cells[2].Value.ToString();

            if (cmd != "") HandleCmd(cmd);

            try
            {
                var quartz = int.Parse(textBox_Quarz.Text);
                if (quartz == 0) return;
                var d = 4000.0 / quartz;
                _runtime = _runtime + _cycles * d;
                text_Runtime.Text = _runtime.ToString(CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            { return; }

            SetTmr0Cyclewise();
            WatchdogTimer();
            WriteStatusReg();
            WriteFlags();
            _cycles = 0;
        }

        /// <summary>
        /// Schau ob Interrupt ausgelöst wurde
        /// </summary>
        private void CheckInterrupt()
        {
            if ((GetIntcon() & 0b1010_0000) != 0b1010_0000) return;

            var intcon = GetIntcon() & 0b1101_1111;
            SetIntcon(intcon);

            const string searchString = "0004";

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                _stack.Push(_programCounter);
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchString))
                    {
                        dataGridView_prog.CurrentCell =
                            dataGridView_prog
                                .Rows[row.Index - 2]
                                .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                        dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
                    }                   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            _cycles = 2;
        }

        /// <summary>
        /// Interrupt bei B0 = 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_bit_B0_TextChanged(object sender, EventArgs e)
        {
            var txt = (Button)sender;
            var intcon = GetIntcon();
            if (LastB0Val == "0" && txt.Text == "1")
            {               
                intcon = intcon | 2;
                SetIntcon(intcon);
            }
            // falling flank
            if (LastB0Val == "1" && txt.Text == "0")
            {
                intcon = intcon & 0b1111_1101;
                SetIntcon(intcon);
            }

            LastB0Val = button_bit_B0.Text;
        }

        /// <summary>
        /// Ändere Geschwindigkeit von Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_Takt_TextChanged(object sender, EventArgs e)
        {
            Timer_Takt.Stop();
            try
            {
                var takt = int.Parse(text_Takt.Text);
                if (takt == 0) return;

                Timer_Takt.Interval = ToInt32(text_Takt.Text);
                Timer_Takt.Start();
            }
            catch (FormatException)
            { }
        }
        #endregion

        #region Timer -------------------
        /// <summary>
        /// Program Timer läuft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_prog_Tick(object sender, EventArgs e)
        {
            Timer_prog.Stop();
            if (dataGridView_prog.CurrentRow != null && ToBoolean(dataGridView_prog.CurrentRow.Cells[0].Value)) _stop = true;
            if (_stop) return;

            Execute();
            if (dataGridView_prog.CurrentRow != null)
            {
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
                Start();
            }
        }

        /// <summary>
        /// Schau ob ein Prescaler gesetzt ist oder WDT aktiviert ist
        /// </summary>
        /// <returns>0 = kein Prescaler, 8 = WDT</returns>
        private int? CheckIfPrescale()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(1)) continue;
                var value = row.Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(value))
                    return Hex2Int(value) & 8;
            }
            return null;
        }

        /// <summary>
        /// Lese den Wert vom Prescaler aus
        /// </summary>
        /// <returns>Prescalerwert</returns>
        private int ReadTmrPrescaler()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(1)) continue;
                var value = row.Cells[3].Value.ToString();
                if (value == "") continue;
                if (value == "xxxxxxxx") continue;

                var prescalebits = Hex2Int(value) & 7;
                return (int)(Math.Pow(2, prescalebits));
            }
            return 1;
        }

        /// <summary>
        /// T0SE: TMR0 Source Edge Select bit
        /// 1 = Increment on high-to-low transition on RA4/T0CKI pin
        /// 0 = Increment on low-to-high transition on RA4/T0CKI pin
        /// </summary>
        /// <returns></returns>
        private int? ReadT0Se()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(1)) continue;
                var value = row.Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(value))
                    return Hex2Int(value) & 16;
            }
            return null;
        }

        /// <summary>
        /// T0CS: TMR0 Clock Source Select bit
        /// 1 = Transition on RA4/T0CKI pin
        /// 0 = Internal instruction cycle clock(CLKOUT)
        /// </summary>
        /// <returns></returns>
        private int? ReadT0Cs()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(1)) continue;
                var value = row.Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(value))
                    return Hex2Int(value) & 32;
            }
            return null;
        }

        /// <summary>
        /// Set Tmr0 from RA0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_bit_A4_TextChanged(object sender, EventArgs e)
        {
            if (ReadT0Cs() != 32) return;
            var txt = (Button)sender;

            //Check if prescaler is for wdt or for tmr0
            int prescaleopt;
            if (CheckIfPrescale() == 0) prescaleopt = ReadTmrPrescaler() * 2;
            else prescaleopt = 1;

            text_Prescaler.Text = @"1 / " + prescaleopt;

            var prescaler = 1.0 / prescaleopt;
            _prescaleCircle += prescaler;

            // rising flank
            if (LastRa0TmrVal == "0" && txt.Text == "1" && ReadT0Se() == 0)
            {  
                if (_prescaleCircle >= 1.0)
                {
                    _tmr0Value += 1;
                    _prescaleCircle = 0;
                }
            }

            // falling flank
            if (LastRa0TmrVal == "1" && txt.Text == "0" && ReadT0Se() == 16)
            {
                if (_prescaleCircle >= 1.0)
                {
                    _tmr0Value += 1;
                    _prescaleCircle = 0;
                }
            }

            SetTmr0Value();            
            LastRa0TmrVal = button_bit_A4.Text;
        }

        /// <summary>
        /// Setze Tmr0 abhängig von Programmlaufzeit
        /// </summary>
        private void SetTmr0Cyclewise()
        {
            if (ReadT0Cs() != 0) return;    

            text_Tmr0.BackColor = Color.White;

            int prescaleopt;
            if (CheckIfPrescale() == 0) prescaleopt = ReadTmrPrescaler() * 2;
            else prescaleopt = 1;

            text_Prescaler.Text = @"1 / " + prescaleopt;

            var prescaler = (double)_cycles / prescaleopt;
            _prescaleCircle += prescaler;

            if (_prescaleCircle >= 1.0)
            {
                _tmr0Value += _cycles;
                _prescaleCircle = 0;
            }

            SetTmr0Value();
        }

        /// <summary>
        /// Setze Werte von Tmr0
        /// </summary>
        private void SetTmr0Value()
        {
            var intcon = GetIntcon();
            if (_tmr0Value >= 256)
            {
                _tmr0Value = _tmr0Value - 256;

                text_Tmr0.BackColor = Color.Brown;

                intcon = GetIntcon() & 0b0010_0000;
            }

            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(1))
                    row.Cells[2].Value = _tmr0Value.ToString("X");

                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(11))
                    row.Cells[2].Value = intcon.ToString("X");
            }

            text_Tmr0.Text = Convert.ToString(_tmr0Value, 2).PadLeft(8, '0');
        }

        /// <summary>
        /// Setze WatchdogTimer, wenn Watchdogtimer erreicht, dann reset
        /// </summary>
        private void WatchdogTimer()
        {
            text_WatchDogTimer.BackColor = Color.White;
            int prescaleopt;
            if (CheckIfPrescale() == 8)
                prescaleopt = ReadTmrPrescaler() * 18000;
            else prescaleopt = 18000;

            var runtime = ToDouble(text_Runtime.Text);
            text_WatchDogTimer.Text = prescaleopt.ToString();

            if (runtime >= prescaleopt)
            {
                ResetParam();
                if (dataGridView_prog.CurrentRow == null) return;

                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[0]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
            }

        }

        /// <summary>
        /// Timer für Takt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Takt_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i <= 7; i++)
            {
                var optNameA = "button_A" + i;
                var optNameB = "button_B" + i;
                var bitNameA = "button_bit_A" + i;
                var bitNameB = "button_bit_B" + i;

                if (Controls[optNameA].BackColor == Color.IndianRed)
                    Controls[bitNameA].Text = Controls[bitNameA].Text == "1" ? "0" : "1";
                if (Controls[optNameB].BackColor == Color.IndianRed)
                    Controls[bitNameB].Text = Controls[bitNameB].Text == "1" ? "0" : "1";
            }
        }
        #endregion

        #region Register Port Tris A und B -------------------
        private void button_A0_Click(object sender, EventArgs e)
        {
            if (button_A0.BackColor == Color.White)
            {
                button_A0.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A0.BackColor == Color.CornflowerBlue)
            {
                button_A0.BackColor = Color.IndianRed;
                return;
            }

            if (button_A0.BackColor == Color.IndianRed)
            {
                button_A0.BackColor = Color.White;
            }
        }

        private void button_A1_Click(object sender, EventArgs e)
        {
            if (button_A1.BackColor == Color.White)
            {
                button_A1.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A1.BackColor == Color.CornflowerBlue)
            {
                button_A1.BackColor = Color.IndianRed;
                return;
            }

            if (button_A1.BackColor == Color.IndianRed)
            {
                button_A1.BackColor = Color.White;
            }
        }

        private void button_A2_Click(object sender, EventArgs e)
        {
            if (button_A2.BackColor == Color.White)
            {
                button_A2.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A2.BackColor == Color.CornflowerBlue)
            {
                button_A2.BackColor = Color.IndianRed;
                return;
            }

            if (button_A2.BackColor == Color.IndianRed)
            {
                button_A2.BackColor = Color.White;
            }

        }

        private void button_A3_Click(object sender, EventArgs e)
        {
            if (button_A3.BackColor == Color.White)
            {
                button_A3.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A3.BackColor == Color.CornflowerBlue)
            {
                button_A3.BackColor = Color.IndianRed;
                return;
            }

            if (button_A3.BackColor == Color.IndianRed)
            {
                button_A3.BackColor = Color.White;
            }

        }

        private void button_A4_Click(object sender, EventArgs e)
        {
            if (button_A4.BackColor == Color.White)
            {
                button_A4.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A4.BackColor == Color.CornflowerBlue)
            {
                button_A4.BackColor = Color.IndianRed;
                return;
            }

            if (button_A4.BackColor == Color.IndianRed)
            {
                button_A4.BackColor = Color.White;
            }

        }      

        //Bit teil von A
        private void button_bit_A0_Click(object sender, EventArgs e)
        {
            if (button_bit_A0.Text == "0")
            {
                button_bit_A0.Text = "1";
            }
            else
            {
                button_bit_A0.Text = "0";
            }
        }

        private void button_bit_A1_Click(object sender, EventArgs e)
        {
            if (button_bit_A1.Text == "0")
            {
                button_bit_A1.Text = "1";
            }
            else
            {
                button_bit_A1.Text = "0";
            }


        }

        private void button_bit_A2_Click(object sender, EventArgs e)
        {
            if (button_bit_A2.Text == "0")
            {
                button_bit_A2.Text = "1";
            }
            else
            {
                button_bit_A2.Text = "0";
            }

        }

        private void button_bit_A3_Click(object sender, EventArgs e)
        {
            if (button_bit_A3.Text == "0")
            {
                button_bit_A3.Text = "1";
            }
            else
            {
                button_bit_A3.Text = "0";
            }
        }

        private void button_bit_A4_Click(object sender, EventArgs e)
        {
            if (button_bit_A4.Text == "0")
            {
                button_bit_A4.Text = "1";
            }
            else
            {
                button_bit_A4.Text = "0";
            }
        }


        // Button B mit Farben

        private void button_B0_Click(object sender, EventArgs e)
        {

            if (button_B0.BackColor == Color.White)
            {
                button_B0.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B0.BackColor == Color.CornflowerBlue)
            {
                button_B0.BackColor = Color.IndianRed;
                return;
            }

            if (button_B0.BackColor == Color.IndianRed)
            {
                button_B0.BackColor = Color.White;
            }

        }

        private void button_B1_Click(object sender, EventArgs e)
        {

            if (button_B1.BackColor == Color.White)
            {
                button_B1.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B1.BackColor == Color.CornflowerBlue)
            {
                button_B1.BackColor = Color.IndianRed;
                return;
            }

            if (button_B1.BackColor == Color.IndianRed)
            {
                button_B1.BackColor = Color.White;
            }
        }

        private void button_B2_Click(object sender, EventArgs e)
        {
            if (button_B2.BackColor == Color.White)
            {
                button_B2.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B2.BackColor == Color.CornflowerBlue)
            {
                button_B2.BackColor = Color.IndianRed;
                return;
            }

            if (button_B2.BackColor == Color.IndianRed)
            {
                button_B2.BackColor = Color.White;
            }
        }

        private void button_B3_Click(object sender, EventArgs e)
        {
            if (button_B3.BackColor == Color.White)
            {
                button_B3.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B3.BackColor == Color.CornflowerBlue)
            {
                button_B3.BackColor = Color.IndianRed;
                return;
            }

            if (button_B3.BackColor == Color.IndianRed)
            {
                button_B3.BackColor = Color.White;
            }
        }

        private void button_B4_Click(object sender, EventArgs e)
        {
            if (button_B4.BackColor == Color.White)
            {
                button_B4.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B4.BackColor == Color.CornflowerBlue)
            {
                button_B4.BackColor = Color.IndianRed;
                return;
            }

            if (button_B4.BackColor == Color.IndianRed)
            {
                button_B4.BackColor = Color.White;
            }
        }

        private void button_B5_Click(object sender, EventArgs e)
        {
            if (button_B5.BackColor == Color.White)
            {
                button_B5.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B5.BackColor == Color.CornflowerBlue)
            {
                button_B5.BackColor = Color.IndianRed;
                return;
            }

            if (button_B5.BackColor == Color.IndianRed)
            {
                button_B5.BackColor = Color.White;
            }
        }

        private void button_B6_Click(object sender, EventArgs e)
        {
            if (button_B6.BackColor == Color.White)
            {
                button_B6.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B6.BackColor == Color.CornflowerBlue)
            {
                button_B6.BackColor = Color.IndianRed;
                return;
            }

            if (button_B6.BackColor == Color.IndianRed)
            {
                button_B6.BackColor = Color.White;
            }
        }

        private void button_B7_Click(object sender, EventArgs e)
        {
            if (button_B7.BackColor == Color.White)
            {
                button_B7.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B7.BackColor == Color.CornflowerBlue)
            {
                button_B7.BackColor = Color.IndianRed;
                return;
            }

            if (button_B7.BackColor == Color.IndianRed)
            {
                button_B7.BackColor = Color.White;
            }
        }


        //Bit Teil Button B

        private void button_bit_B0_Click(object sender, EventArgs e)
        {
            if (button_bit_B0.Text == "0")
            {
                button_bit_B0.Text = "1";
            }
            else
            {
                button_bit_B0.Text = "0";
            }
        }

        private void button_bit_B1_Click(object sender, EventArgs e)
        {
            if (button_bit_B1.Text == "0")
            {
                button_bit_B1.Text = "1";
            }
            else
            {
                button_bit_B1.Text = "0";
            }
        }

        private void button_bit_B2_Click(object sender, EventArgs e)
        {
            if (button_bit_B2.Text == "0")
            {
                button_bit_B2.Text = "1";
            }
            else
            {
                button_bit_B2.Text = "0";
            }
        }

        private void button_bit_B3_Click(object sender, EventArgs e)
        {
            if (button_bit_B3.Text == "0")
            {
                button_bit_B3.Text = "1";
            }
            else
            {
                button_bit_B3.Text = "0";
            }
        }

        private void button_bit_B4_Click(object sender, EventArgs e)
        {
            if (button_bit_B4.Text == "0")
            {
                button_bit_B4.Text = "1";
            }
            else
            {
                button_bit_B4.Text = "0";
            }
        }

        private void button_bit_B5_Click(object sender, EventArgs e)
        {
            if (button_bit_B5.Text == "0")
            {
                button_bit_B5.Text = "1";
            }
            else
            {
                button_bit_B5.Text = "0";
            }
        }

        private void button_bit_B6_Click(object sender, EventArgs e)
        {
            if (button_bit_B6.Text == "0")
            {

                button_bit_B6.Text = "1";
            }
            else
            {
                button_bit_B6.Text = "0";
            }
        }

        private void button_bit_B7_Click(object sender, EventArgs e)
        {
            if (button_bit_B7.Text == "0")
            {
                button_bit_B7.Text = "1";
            }
            else
            {
                button_bit_B7.Text = "0";
            }
        }

        #endregion
    }
}
