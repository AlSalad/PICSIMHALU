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
        public int W = 0;
        public int L = 0;
        public int F = 0;
        public int ZeroFlag = 0;
        public int CarryFlag = 0;
        public int DigitCarry = 0;
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
            if ((cmd & 0b11_1111_0000_0000) == 0b00_0001_0000_0000)
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

        #region Commands -------------------

        private void WriteReg(int cmdReg)
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(cmdReg))
                {
                    row.Cells[2].Value = F.ToString("X");
                }
            }
        }

        private int ReadReg(int cmdReg)
        {
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                if (Hex2Int(row.Cells[1].Value.ToString()).Equals(cmdReg))
                {
                    return Hex2Int(row.Cells[2].Value.ToString());
                }
            }
            return 0;
        }

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
            F = W;
            WriteReg(cmdReg);
        }

        private void Movf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;

            var result = ReadReg(fReg);

            ZeroFlag = result == 0 ? 1 : 0;

            if (fOpt == 128)
            {
                F = result;
                WriteReg(cmdReg);

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
            ZeroFlag = W == 0 ? 1 : 0;
            text_W.Text = W.ToString("X");
        }

        private void Iorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            var result = F | W;
            ZeroFlag = result == 0 ? 1 : 0;

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
            ZeroFlag = W == 0 ? 1 : 0;
            text_W.Text = W.ToString("X");
        }

        private void Andwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;

            F = ReadReg(fReg);

            if (fOpt == 128)
            {
                F = W & F;
                ZeroFlag = F == 0 ? 1 : 0;
                WriteReg(fReg);
            }

            if (fOpt == 0)
            {
                W = W & F;
                ZeroFlag = W == 0 ? 1 : 0;
                text_W.Text = W.ToString("X");
            }
        }

        private void Xorlw(int cmdLit)
        {
            L = cmdLit;
            W = W ^ L;

            ZeroFlag = W == 0 ? 1 : 0;

            text_W.Text = W.ToString("X");
        }

        private void Xorwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);

            var result = F ^ W;
            ZeroFlag = result == 0 ? 1 : 0;

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
            var b = L - W;
            if (L - W < 0)
            {
                W = 255 + (L - W);
                CarryFlag = 0;
            }
            else
            {
                W = L - W;
                CarryFlag = 1;
                ZeroFlag = W == 0 ? 1 : 0;

                DigitCarry = 1;
                text_DC.Text = DigitCarry.ToString();
            }

            textBox_CarryFlag.Text = CarryFlag.ToString();
            text_W.Text = W.ToString("X");
        }

        private void Subwf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);

            int result;

            //Berechnung
            if (F - W < 0)
            {
                result = 256 + F - W;
                CarryFlag = 0;
            }          
            else
            {
                result = F - W;
                CarryFlag = 1;
                ZeroFlag = result == 0 ? 1 : 0;

                if (F > 15 & result <= 15) DigitCarry = 1;
                else DigitCarry = 0;
            }

            textBox_CarryFlag.Text = CarryFlag.ToString();

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
            if (L + W > 255)
            {
                W = (L+W) - 256;
                CarryFlag = 1;
                textBox_CarryFlag.Text = CarryFlag.ToString();
            }
            else if (L + W > 127)
            {
                W = L + W;
                DigitCarry = 1;
                text_DC.Text = DigitCarry.ToString();
            }
            else if (L + W == 255)
                W = 0;
            else
            {
                W = L + W;
                DigitCarry = 0;
                text_DC.Text = DigitCarry.ToString();
                CarryFlag = 0;
                textBox_CarryFlag.Text = CarryFlag.ToString();
            }


            text_W.Text = W.ToString("X");
        }

        private void Addwf(int cmdReg)

        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;
            int result;            
            F = ReadReg(fReg);

            //Berechnung
            if (F + W > 255)
            {
                result = F + W - 255;
                CarryFlag = 1;
                ZeroFlag = 0;
            }
            else if (F + W == 256)
            {
                result = 0;
                ZeroFlag = 1;
            }
            else
            {
                result = F + W;
                ZeroFlag = 0;
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
            F = 0;
            WriteReg(cmdReg);
            ZeroFlag = 1;
        }

        private void Clrw()
        {
            W = 0;
            ZeroFlag = 1;
            text_W.Text = W.ToString("X");
        }

        private void Comf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;

            F = ReadReg(fReg);
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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            var result = F + 1;
            
            if (result > 255)
                result = 0;

            ZeroFlag = result == 0 ? 1 : 0;

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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            var result = F - 1;
            ZeroFlag = result == 0 ? 1 : 0;

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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            
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
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            var currCf = CarryFlag;

            CarryFlag = (F & 128) == 128 ? 1 : 0;

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

            textBox_CarryFlag.Text = CarryFlag.ToString();
        }

        private void Rrf(int cmdReg)
        {
            var fReg = cmdReg & 127;
            var fOpt = cmdReg & 128;
            F = ReadReg(fReg);
            int result;

            var currCf = CarryFlag;

            if ((F & 1) == 1)
            {
                CarryFlag = 1;
            }
            else
            {
                CarryFlag = 0;
            }

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
            textBox_CarryFlag.Text = CarryFlag.ToString();
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
            text_Pc.Text = ProgramCounter.ToString();
            CarryFlag = 0;
            textBox_CarryFlag.Text = CarryFlag.ToString();
            ZeroFlag = 0;
            textBox_ZeroFlag.Text = CarryFlag.ToString();
            DigitCarry = 0;
            text_DC.Text = DigitCarry.ToString();
            F = 0;

            if (dataGridView_Register.CurrentRow == null) return;
            foreach (DataGridViewRow row in dataGridView_Register.Rows)
            {
                row.Cells[2].Value = "";
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
                    dataGridView_Register.Rows.Add(cmdOperatorValue.Substring(0, 9).Trim(), cmdOperatorValue.Substring(13, 2).Trim());

                var loop = codeLine.Substring(27, 9).Trim();

                if (idValue == "" && cmdValue == "" && cmdOperatorValue == "" && loop == "") continue;

                dataGridView_prog.Rows.Add(idValue, cmdValue, cmdOperatorValue, loop);
            }

        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            Execute();
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

            if (cmd!="") HandleCmd(cmd);

            textBox_ZeroFlag.Text = ZeroFlag.ToString();
            text_DC.Text = DigitCarry.ToString();

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
