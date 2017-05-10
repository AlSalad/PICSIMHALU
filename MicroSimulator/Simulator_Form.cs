using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroSimulator.Properties;
using static System.Convert;

namespace MicroSimulator
{  
    public partial class SimulatorForm : Form
    {
        public int W = 0; //test
        public int L = 0;
        public int F = 0;

        public int StatusReg = 0;
        public int ProgramCounter = 0;
        public int Wert1 = 0;
        public int Wert2 = 0;
        Stack<int> _stack = new Stack<int>();
        public string[] CodeList;

        public SimulatorForm()
        {
            InitializeComponent();
        }

        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            dataGridView_RegA.Rows.Add("TRIS", "i", "i", "i", "i", "i", "i", "i", "i");
            dataGridView_RegA.Rows.Add("Bits", 0, 0, 0, 0, 0, 0, 0, 0);

            dataGridView_RegB.Rows.Add("TRIS", "i", "i", "i", "i", "i", "i", "i", "i");
            dataGridView_RegB.Rows.Add("Bits", 0, 0, 0, 0, 0, 0, 0, 0);
        }

        #region Converter ---------------------

        public string Hex2Bin(string value)
        {
            return Convert.ToString(ToInt32(value, 16), 2).PadLeft(value.Length * 4, '0');
        }

        public int Bin2Dec(string value)
        {
           return ToInt32(value, 2);
        }

        public int Hex2Int(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        }

        #endregion

        private void HandleCmd(string cmdValue)
        {
            var cmd = Hex2Int(cmdValue);

            //movelw
            if ((cmd & 0b11_1100_0000_0000) == 0b11_0000_0000_0000)
            {
                Movlw(cmd & 255);
            }

            //movwf
            if ((cmd & 0b11_1111_1000_0000) == 0b00_0000_1000_0000)
            {
                Movwf(cmd & 127);
            }

            //movf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1000_0000_0000)
            {
                Movf(cmd & 255);
            }

            //andlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1001_0000_0000)
            {
                Andlw(cmd & 255);
            }

            //andwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0101_0000_0000)
            {
                Andwf(cmd & 255);
            }

            //iorlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1000_0000_0000)
            {
                Iorlw(cmd & 255);
            }

            //iorwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0100_0000_0000)
            {
                Iorwf(cmd & 255);
            }

            //sublw
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1100_0000_0000)
            {
                Sublw(cmd & 255);
            }

            //sublw
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0010_0000_0000)
            {
                Subwf(cmd & 255);
            }

            //addlw
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1110_0000_0000)
            {
                Addlw(cmd & 255);
            }

            //addwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0111_0000_0000)
            {
                Addwf(cmd & 255);
            }

            //Xorlw
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1010_0000_0000)
            {
                Xorlw(cmd & 255);
            }

            //Xorwf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0110_0000_0000)
            {
                Xorwf(cmd & 255);
            }

            //Clrf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0001_1000_0000)
            {
                Clrf(cmd & 127);
            }

            //Clrw
            if ((cmd & 0b11_1111_1000_0000) == 0b00_0001_0000_0000)
            {
                Clrw();
            }

            //Comf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1001_0000_0000)
            {
                Comf(cmd & 255);
            }

            //Incf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1010_0000_0000)
            {
                Incf(cmd & 255);
            }

            //Incfsz
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1111_0000_0000)
            {
                Incfsz(cmd & 255);
            }

            //Decf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0011_0000_0000)
            {
                Decf(cmd & 255);
            }

            //Decf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1011_0000_0000)
            {
                Decfsz(cmd & 255);
            }

            //Swapf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1110_0000_0000)
            {
                Swapf(cmd & 255);
            }

            //Rlf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1101_0000_0000)
            {
                Rlf(cmd & 255);
            }

            //Rrf
            if ((cmd & 0b11_1111_0000_0000) == 0b00_1100_0000_0000)
            {
                Rrf(cmd & 255);
            }

            //bcf
            if ((cmd & 0b11_1100_0000_0000) == 0b01_0000_0000_0000)
            {
                Bcf(cmd & 0b00_0011_1111_1111);
            }

            //bsf
            if ((cmd & 0b11_1100_0000_0000) == 0b01_0100_0000_0000)
            {
                Bsf(cmd & 0b00_0011_1111_1111);
            }

            //btfsc
            if ((cmd & 0b11_1100_0000_0000) == 0b01_1000_0000_0000)
            {
                Btfsc(cmd & 0b00_0011_1111_1111);
            }

            //btfss
            if ((cmd & 0b11_1100_0000_0000) == 0b01_1100_0000_0000)
            {
                Btfss(cmd & 0b00_0011_1111_1111);
            }

            //GoTo
            if ((cmd & 0b11_1000_0000_0000) == 0b10_1000_0000_0000)
            {
                Goto(cmd & 0b00011111111111);
            }

            //Call
            if ((cmd & 0b11_1000_0000_0000) == 0b10_0000_0000_0000)
            {
                CallSub(cmd & 0b00011111111111);
            }

            //Retlw
            if ((cmd & 0b11_1100_0000_0000) == 0b11_0100_0000_0000)
            {
                Retlw(cmd & 255);
            }

            //return
            if (cmd == 0b00_0000_0000_1000)
            {
                ReturnToCall();
            }
        }

        private void SetZeroFlag(int val)
        {
            //Zero Flag
            if (val == 0)
                StatusReg = StatusReg | 4;
            else
                StatusReg = StatusReg & ~4 & 0x000000FF;      
        }

        private void WriteStatusReg()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(3)) continue;
                row.Cells[2].Value = StatusReg.ToString("X");
                return;
            }
        }

        private void WriteFlags()
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (!Hex2Int(row.Cells[1].Value.ToString()).Equals(3)) continue;

                var value = row.Cells[2].Value;

                if (value != null && (string) value != "")
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

        private void WriteReg(int cmdReg)
        {
            var i = 2;
            if ((StatusReg & 32) == 32)
                i = 3;

            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(cmdReg))
                {
                    row.Cells[i].Value = F.ToString("X");
                    return;
                }
            }
            if(i == 2)
                dataGridView_Register.Rows.Add("", cmdReg.ToString("X"), F.ToString("X"), "");
            if(i == 3)
                dataGridView_Register.Rows.Add("", cmdReg.ToString("X"), "", F.ToString("X"));

        }

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

        #region Commands -------------------



        private void Goto(int cmdLit)
        {
            var hexVal = cmdLit.ToString("X");
            var searchString = hexVal.PadLeft(4, '0');

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchString))
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

        }

        private void Movlw(int cmdLit)
        {
            L = cmdLit;
            W = L;
            text_W.Text = W.ToString("X");
        }

        private void Movwf(int cmdReg)
        {
            if (cmdReg == 0)
                cmdReg = ReadReg(0x04);

            F = W;
            WriteReg(cmdReg);
        }

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
                F = result;
                WriteReg(fReg);

            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Iorlw(int cmdLit)
        {
            L = cmdLit;
            W = W | L;
            SetZeroFlag(W);
            text_W.Text = W.ToString("X");
        }

        private void Iorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;

            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            var result = F | W;
           
            SetZeroFlag(result);

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }

            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Andlw(int cmdLit)
        {
            L = cmdLit;
            W = W & L;
            SetZeroFlag(W);
            text_W.Text = W.ToString("X");
        }

        private void Andwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fOpt = cmdReg & 128;

            if (fOpt == 128)
            {
                F = W & F;
                SetZeroFlag(F);
                WriteReg(fReg);
            }

            if (fOpt == 0)
            {
                W = W & F;
                SetZeroFlag(W);
                text_W.Text = W.ToString("X");
            }
        }

        private void Xorlw(int cmdLit)
        {
            L = cmdLit;
            W = W ^ L;

            SetZeroFlag(W);

            text_W.Text = W.ToString("X");
        }

        private void Xorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fOpt = cmdReg & 128;

            var result = F ^ W;
            SetZeroFlag(result);

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Sublw(int cmdLit)
        {
            L = cmdLit;
            var highLBits = L & 240;
            var highWBits = W & 240;

            //DigitCarry
            if (highLBits - highWBits < 16) StatusReg = StatusReg  | 2;
            else StatusReg = StatusReg & ~2 & 0x000000FF;

            if (L - W < 0)
            {
                W = 256 + (L - W);
                //CarryFlag = 0
                StatusReg = StatusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                StatusReg = StatusReg & ~4 & 0x000000FF;
            }
            else
            {
                W = L - W;
                //CarryFlag = 1;
                StatusReg = StatusReg | 1;
                //Zero Flag = 1;
                if (W == 0)
                    StatusReg = StatusReg | 4;
            }

            text_W.Text = W.ToString("X");
        }

        private void Subwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            var highFBits = F & 240;
            var highWBits = W & 240;

            //DigitCarry
            if (highFBits - highWBits < 16) StatusReg = StatusReg | 2;
            else StatusReg = StatusReg & ~2 & 0x000000FF;

            int result;

            //Berechnung
            if (F - W < 0)
            {
                result = 256 + F - W;
                //CarryFlag = 0
                StatusReg = StatusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                StatusReg = StatusReg & ~4 & 0x000000FF;
            }          
            else
            {
                result = F - W;
                //CarryFlag = 1
                StatusReg = StatusReg | 1;
                //Zero Flag = 1
                if (result == 0)
                    StatusReg = StatusReg | 4;
            }

            //Ausgabe
            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }      
        }

        private void Addlw(int cmdLit)
        {
            L = cmdLit;
            var lowLBits = cmdLit & 15;
            var lowWBits = W & 15;

            //DigitCarry
            if (lowLBits + lowWBits > 15) StatusReg = StatusReg | 2; 
            else StatusReg = StatusReg & ~2 & 0x000000FF; 

            if (L + W > 255)
            {
                W = (L+W) - 256;

                //CarryFlag = 1
                StatusReg = StatusReg | 1;
                //Zero Flag = 1
                if (W == 0) 
                    StatusReg = StatusReg | 4;
            }
            else
            {
                W = L + W;
                //CarryFlag = 0
                StatusReg = StatusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                StatusReg = StatusReg & ~4 & 0x000000FF;
            }

            text_W.Text = W.ToString("X");
        }

        private void Addwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }             
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var lowFBits = F & 15;
            var lowWBits = W & 15;
            int result;

            //DigitCarry
            if (lowFBits + lowWBits > 15) StatusReg = StatusReg | 2;
            else StatusReg = StatusReg & ~2 & 0x000000FF;

            //Berechnung
            if (F + W > 255)
            {
                result = F + W - 256;
                //CarryFlag = 1
                StatusReg = StatusReg | 1;
                //Zero Flag = 1
                if (W == 0)
                    StatusReg = StatusReg | 4;
            }
            else
            {
                result = F + W;
                //CarryFlag = 0
                StatusReg = StatusReg & ~1 & 0x000000FF;
                //Zero Flag = 0
                StatusReg = StatusReg & ~4 & 0x000000FF;
            }

            //Speicherort
            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }           
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }

        }

        private void Clrf(int cmdReg)
        {
            if (cmdReg == 0) { 
                F = ReadReg(ReadReg(0x04));
                cmdReg = ReadReg(0x04);
            }
            else
                F = ReadReg(cmdReg);
            F = 0;
            WriteReg(cmdReg);
            //Zero Flag = 1
            StatusReg = StatusReg | 4;
        }

        private void Clrw()

        {
            W = 0;
            //Zero Flag = 1
            StatusReg = StatusReg | 4;
            text_W.Text = W.ToString("X");
        }

        private void Comf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fOpt = cmdReg & 128;
            int result;

            result = (int) (~F & 0x000000FF);
            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);

            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Incf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;           
            var result = F + 1;
            
            if (result > 255)
                result = 0;

            SetZeroFlag(result);

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Incfsz(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var result = F + 1;

            if (result > 255)
                result = 0;

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }

            if (result != 0) return;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        private void Decf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var result = F - 1;
            SetZeroFlag(result);

            if (result < 0)
                result = 255;

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }

        }

        private void Decfsz(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
                F = ReadReg(ReadReg(0x04));
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;

            var result = F - 1;

            if (result < 0)
                result = 255;

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }

            if (result != 0) return;

            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        private void Swapf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fOpt = cmdReg & 128;
            
            var upperNibble = F & 0b1111_0000;
            var lowerNibble = F & 0b0000_1111;
            upperNibble = upperNibble >> 4;
            lowerNibble = lowerNibble << 4;

            var result= upperNibble | lowerNibble;

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Rlf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fOpt = cmdReg & 128;
            var currCf = StatusReg & 1;

            if ((F & 128) == 128) StatusReg = StatusReg | 1;
            else   StatusReg = StatusReg & ~1 & 0x000000FF; 

            var shiftResult = (F << 1) & 255;

            var result = shiftResult | currCf;             

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Rrf(int cmdReg)
        {

            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }             
            else
                F = ReadReg(fReg);

            var fOpt = cmdReg & 128;
            int result;

            var currCf = StatusReg & 1;

            if ((F & 1) == 1)StatusReg = StatusReg | 1;
            else StatusReg = StatusReg & ~1 & 0x000000FF;

            var shiftResult = F >> 1;

            if (currCf == 1)
                result = shiftResult | 128;
            else
                result = shiftResult;   

            if (fOpt == 128)
            {
                F = result;
                WriteReg(fReg);
            }
            if (fOpt == 0)
            {
                W = result;
                text_W.Text = W.ToString("X");
            }
        }

        private void Bcf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);
            
            F= F & (~bitValue & 0x000000FF);

            WriteReg(fReg);
            if (fReg == 3) StatusReg = F;
        }

        private void Bsf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
            {
                F = ReadReg(ReadReg(0x04));
                fReg = ReadReg(0x04);
            }
            else
                F = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = Math.Pow(2, fBits);

            F = F | (int)bitValue;
            WriteReg(fReg);
            if (fReg == 3) StatusReg = F;
        }

        private void Btfsc(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
                F = ReadReg(ReadReg(0x04));
            else
                F = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);


            if ((F & bitValue) == 0)
            {
                if (dataGridView_prog.CurrentRow != null)
                    dataGridView_prog.CurrentCell =
                        dataGridView_prog
                            .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                            .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
            }
        }

        private void Btfss(int cmdReg)
        {
            var fReg = cmdReg & 127;
            if (fReg == 0)
                F = ReadReg(ReadReg(0x04));
            else
                F = ReadReg(fReg);
            var fBits = (cmdReg & 0b00_0011_1000_0000) >> 7;
            var bitValue = (int)Math.Pow(2, fBits);

            if ((F & bitValue) == bitValue)
            {
                if (dataGridView_prog.CurrentRow != null)
                    dataGridView_prog.CurrentCell =
                        dataGridView_prog
                            .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                            .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
                dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
            }
        }

        private void CallSub(int cmdLit)
        {
            _stack.Push(ProgramCounter);
            var hexVal = cmdLit.ToString("X");
            var searchString = hexVal.PadLeft(4, '0');

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchString))
                    {
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

        private void ReturnToCall()
        {
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        private void Retlw(int cmdLit)
        {
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            L = cmdLit;
            W = L;
            text_W.Text = W.ToString("X");

            _stack.Pop();
        }
        #endregion

        private void ResetParam()
        {
            W = 0;
            text_W.Text = W.ToString();
            ProgramCounter = 0;
            StatusReg = 0;
            text_Pc.Text = ProgramCounter.ToString();
            textBox_CarryFlag.Text = "0";
            textBox_ZeroFlag.Text = "0";
            text_DC.Text = "0";
            F = 0;

            if (dataGridView_Register.CurrentRow == null) return;
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                row.Cells[2].Value = "";
                row.Cells[3].Value = "";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Open_Click(object sender, EventArgs e)
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
                Stream customStream;
                if ((customStream = openFileDialog.OpenFile()) == null) return;

                using (customStream)
                {                
                    using (var reader = new StreamReader(customStream))
                    {
                        dataGridView_prog.Rows.Clear();
                        dataGridView_Register.Rows.Clear();
                        text_path.Text = openFileDialog.FileName;
                        CodeList = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        FillDataTable();
                        //RegexCmd();
                    }
                }
            }
            catch (Exception ex){MessageBox.Show(Resources.read_error + ex.Message); }
        }

        public IEnumerable<string> ReadLines(Func<Stream> streamProvider,
                                     Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        private void FillDataTable()
        {
            foreach (var codeLine in CodeList)
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

                dataGridView_prog.Rows.Add(idValue, cmdValue, cmdOperatorValue, loop);
            }

        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            Execute();
            if (dataGridView_prog.CurrentRow != null)
                dataGridView_prog.CurrentCell =
                    dataGridView_prog
                        .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                        .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            
        }

        private void Execute()
        {
            if (dataGridView_prog.CurrentRow == null) return;

            ProgramCounter = dataGridView_prog.CurrentRow.Index;
            text_Pc.Text = ProgramCounter.ToString();

            var cmd = dataGridView_prog.CurrentRow.Cells[1].Value.ToString();

            if (cmd != "") HandleCmd(cmd);

            WriteStatusReg();
            WriteFlags();

        }

        private void button_Reset_Click(object sender, EventArgs e)
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
}
