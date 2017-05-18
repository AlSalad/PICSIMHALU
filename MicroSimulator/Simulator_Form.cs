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

        private readonly SerialPort _com1Port = new SerialPort("COM1", 9600);

        private int _w; //test
        private int _l;
        private int _f;

        private int _tmr0Value;
        private int _circles;
        private double _prescaleCircle;
        private double _runtime;

        private int _statusReg;
        private int _programCounter;

        private bool _stop;

        // ReSharper disable once FieldCanBeMadeReadOnly.Local --> Stack wird beschrieben
        private Stack<int> _stack = new Stack<int>();
        private string[] _codeList;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="val"></param>
        private void SetIncton(int val)
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
        /// 
        /// </summary>
        public SimulatorForm()
        {
            _com1Port.Open();
            _com1Port.DataReceived += MyDataReceivedHandler;
            InitializeComponent();
            Timer_Takt.Interval = 2000;
            Timer_Takt.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            dataGridView_RegA.Rows.Add("TRIS", "I", "I", "I", "I", "I", "I", "I", "I");
            dataGridView_RegA.Rows.Add("Bits", 0, 0, 0, 0, 0, 0, 0, 0);

            dataGridView_RegB.Rows.Add("TRIS", "I", "I", "I", "I", "I", "I", "I", "I");
            dataGridView_RegB.Rows.Add("Bits", 0, 0, 0, 0, 0, 0, 0, 0);
        }
        #endregion

    #region Serielle Schnittstelle

        private void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var indata = _com1Port.ReadExisting();
            var port = indata.Split(';')[0];
            var bit = 8 - ToInt32(indata.Split(';')[1]);
            var row = ToInt32(indata.Split(';')[2]);
            var opt = indata.Split(';')[3];

            switch (port)
            {
                case "A":
                    dataGridView_RegA[bit, row].Value = opt;
                    break;
                case "B":
                    dataGridView_RegB[bit, row].Value = opt;
                    break;
            }
        }

        private void Timer_Takt_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView_RegA.Rows[0].Cells)
            {
                //wenn 1 dann 0, wenn 0 dann 1
                if (cell.Value.ToString() == "T")
                    dataGridView_RegA[cell.ColumnIndex, 1].Value = dataGridView_RegA[cell.ColumnIndex, 1].Value.ToString() == "1" ? "0" : "1";
            }

            foreach (DataGridViewCell cell in dataGridView_RegB.Rows[0].Cells)
            {
                //wenn 1 dann 0, wenn 0 dann 1
                if (cell.Value.ToString() == "T")
                    dataGridView_RegB[cell.ColumnIndex, 1].Value = dataGridView_RegB[cell.ColumnIndex, 1].Value.ToString() == "1" ? "0" : "1";
            }
        }      
        #endregion

    #region Converter ---------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="cmdValue"></param>
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
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0001_1000_0000)
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
        /// 
        /// </summary>
        /// <param name="val"></param>
        private void SetZeroFlag(int val)
        {
            //Zero Flag
            if (val == 0)
                _statusReg = _statusReg | 4;
            else
                _statusReg = _statusReg & ~4 & 0x000000FF;
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        private void Nop()
        {
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
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
            _circles = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
        private void Movlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _l;
            text_W.Text = _w.ToString("X");
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
        private void Movwf(int cmdReg)
        {
            if (cmdReg == 0)
                cmdReg = ReadReg(0x04);

            _f = _w;
            WriteReg(cmdReg);
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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

            if (fReg != 1)
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
        private void Iorlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w | _l;
            SetZeroFlag(_w);
            text_W.Text = _w.ToString("X");
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
        private void Andlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w & _l;
            SetZeroFlag(_w);
            text_W.Text = _w.ToString("X");
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
        private void Xorlw(int cmdLit)
        {
            _l = cmdLit;
            _w = _w ^ _l;

            SetZeroFlag(_w);

            text_W.Text = _w.ToString("X");
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Clrw()
        {
            _w = 0;
            //Zero Flag = 1
            _statusReg = _statusReg | 4;
            text_W.Text = _w.ToString("X");
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
            if (result != 0) return;
            _circles = 2;
            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
            if (result != 0) return;
            _circles = 2;
            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
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
            _circles = 1;
        }

        /// <summary>
        /// 
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
            _circles = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
        private void Btfsc(int cmdReg)
        {
            var fReg = cmdReg & 127;

            //wenn Register Indirekt angefragt, hole Daten aus FSR, ansonsten normal
            _f = ReadReg(fReg == 0 ? ReadReg(0x04) : fReg);

            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int) Math.Pow(2, fBits);
            _circles = 1;

            if ((_f & bitValue) != 0) return;

            _circles = 2;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdReg"></param>
        private void Btfss(int cmdReg)
        {
            var fReg = cmdReg & 127;
            //wenn Register Indirekt angefragt, hole Daten aus FSR, ansonsten normal
            _f = ReadReg(fReg == 0 ? ReadReg(0x04) : fReg);

            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);

            _circles = 1;
            if ((_f & bitValue) != bitValue) return;
            _circles = 2;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
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
                        _circles = 2;
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
        /// 
        /// </summary>
        private void ReturnToCall()
        {
            _circles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLit"></param>
        private void Retlw(int cmdLit)
        {
            _circles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            _l = cmdLit;
            _w = _l;
            text_W.Text = _w.ToString("X");          
        }

        private void Retfie()
        {
            _circles = 2;
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            var intcon = GetIntcon() | 128;

            SetIncton(intcon);
        }
        #endregion

    #region Button Control -------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            ResetParam();
            //CmdInput.Items.Clear();
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\workspace\\MicroSimulator\\MicroSimulator\\Tests",
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
                Timer_0.Interval = 4000 / quartz * ReadTmrPrescaler();
            }
            catch (FormatException)
            {return;}
                
            Timer_prog.Start();
            Timer_0.Start();
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
        /// 
        /// </summary>
        private void ResetParam()
        {
            _w = 0;
            _stop = true;
            text_W.Text = _w.ToString();
            _programCounter = 0;
            _statusReg = 0;
            _circles = 0;
            _tmr0Value = 0;
            _runtime = 0;
            _prescaleCircle = 0;
            text_Pc.Text = _programCounter.ToString();
            textBox_CarryFlag.Text = @"0";
            textBox_ZeroFlag.Text = @"0";
            text_DC.Text = @"0";
            text_Tmr0.Text = @"0";
            text_Runtime.Text = @"0";
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
        /// 
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

            var cmd = dataGridView_prog.CurrentRow.Cells[2].Value.ToString();

            if (cmd != "") HandleCmd(cmd);

            try
            {
                var quartz = int.Parse(textBox_Quarz.Text);
                if (quartz == 0) return;
                var d = 4000.0 / quartz;
                _runtime = _runtime + _circles / d;
                text_Runtime.Text = _runtime.ToString(CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            { return; }

            SetTmr0();
            WatchdogTimer();
            WriteStatusReg();
            WriteFlags();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckInterrupt()
        {
            if ((GetIntcon() & 0b1010_0000) != 0b1010_0000) return;

            var intcon = GetIntcon() & 0b1101_1111;
            SetIncton(intcon);

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
            _circles = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_Takt_TextChanged(object sender, EventArgs e)
        {
            Timer_Takt.Stop();
            if (string.IsNullOrEmpty(text_Takt.Text)) return;
            Timer_Takt.Interval = ToInt32(text_Takt.Text);
            Timer_Takt.Start();
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
        /// 
        /// </summary>
        /// <returns></returns>
        private int CheckIfPrescale()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(1)) continue;
                var value = row.Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(value)) return ToInt32(value);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        private void SetTmr0()
        {
            var intcon = GetIntcon();

            text_Tmr0.BackColor = Color.White;

            int prescaleopt;
            if (CheckIfPrescale() == 0) prescaleopt = ReadTmrPrescaler() * 2;
            else prescaleopt = 1;

            var prescaler = (double)_circles / prescaleopt;
            _prescaleCircle += prescaler;
            if (_prescaleCircle >= 1.0)
            {
                _tmr0Value += _circles;
                _prescaleCircle = 0;
            }

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
        /// 
        /// </summary>
        private void WatchdogTimer()
        {
            text_WatchDogTimer.BackColor = Color.White;
            int prescaleopt;
            if (CheckIfPrescale() == 1)
                prescaleopt = ReadTmrPrescaler() * 18000;
            else prescaleopt = 18000;

            var runtime = ToDouble(text_Runtime.Text);

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

    #endregion

    }
}
