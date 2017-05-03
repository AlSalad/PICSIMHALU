using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public int ZeroFlag = 0;
        public int CarryFlag = 0;
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

            dataGridView_RegTab.Rows.Add("00h", "INDF", "--------");
            dataGridView_RegTab.Rows.Add("01h", "TMR0", "xxxxxxxx");
            dataGridView_RegTab.Rows.Add("02h", "PCL", "00000000");
            dataGridView_RegTab.Rows.Add("03h", "STATUS", "00011000");
            dataGridView_RegTab.Rows.Add("04h", "FSR", "xxxxxxxx");
            dataGridView_RegTab.Rows.Add("05h", "PORTA", "---xxxxx");
            dataGridView_RegTab.Rows.Add("06h", "PortB", "xxxxxxxx");
            dataGridView_RegTab.Rows.Add("07h", "-", "-");
            dataGridView_RegTab.Rows.Add("08h", "EEDATA", "xxxxxxxx");
            dataGridView_RegTab.Rows.Add("09h", "EEADR", "xxxxxxxx");
            dataGridView_RegTab.Rows.Add("0Ah", "PCLATH", "---00000");
            dataGridView_RegTab.Rows.Add("0Bh", "INTCON", "0000000x");
        }

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

        private void HandleCmd(string cmdValue)
        {
            var cmd = Hex2Int(cmdValue);

            //MOVE
            if ((cmd & 0b11_1100_0000_0000) == 0b11_0000_0000_0000)
            {
                Movlw(cmd & 255);
            }

            //UND
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1001_0000_0000)
            {
                Andlw(cmd & 255);
            }

            //Inklusiv ODER
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1000_0000_0000)
            {
                Iorlw(cmd & 255);
            }

            //Subtrahieren
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1100_0000_0000)
            {
                Sublw(cmd & 255);
            }

            //Addieren
            if ((cmd & 0b11_1110_0000_0000) == 0b11_1110_0000_0000)
            {
                Addlw(cmd & 255);
            }

            //XOR
            if ((cmd & 0b11_1111_0000_0000) == 0b11_1010_0000_0000)
            {
                Xorlw(cmd & 255);
            }

            if ((cmd & 0b11_1000_0000_0000) == 0b10_1000_0000_0000)
            {
                Goto(cmd & 0b00011111111111);
            }

            if ((cmd & 0b11_1000_0000_0000) == 0b10_0000_0000_0000)
            {
                CallSub(cmd & 0b00011111111111);
            }

            if ((cmd & 0b11_1100_0000_0000) == 0b11_0100_0000_0000)
            {
                Retlw(cmd & 255);
            }

            if (cmd == 0b00_0000_0000_1000)
            {
                ReturnToCall();
            }

        }

        private void ReturnToCall()
        {
            dataGridView_prog.CurrentCell =
                dataGridView_prog
                    .Rows[_stack.Peek()]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;

            _stack.Pop();
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

        #region Commands -------------------

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

        private void Iorlw(int cmdLit)
        {
            L = cmdLit;
            W = W | L;
            text_W.Text = W.ToString("X");
        }

        private void Andlw(int cmdLit)
        {
            L = cmdLit;
            W = W & L;
            text_W.Text = W.ToString("X");
        }

        private void Xorlw(int cmdLit)
        {
            L = cmdLit;
            W = W ^ L;
            text_W.Text = W.ToString("X");
        }

        private void Sublw(int cmdLit)
        {
            L = cmdLit;
            var b = L - W;
            if (L - W < 0)
            {
                W = 255 - (L - W);

                CarryFlag = 0;
            }
            else
            {
                W = L - W;
                CarryFlag = 1;
            }

            textBox_CarryFlag.Text = CarryFlag.ToString();
            text_W.Text = W.ToString("X");
        }

        private void Addlw(int cmdLit)
        {
            L = cmdLit;
            if (L + W > 255)
            {
                W = (L-W) - 255;
                CarryFlag = CarryFlag ^ 1;

                textBox_CarryFlag.Text = CarryFlag.ToString();

            }
            else if (L + W == 256)
            {
                W = 0;
            }
            else
            {
                W = L + W;
            }
            

            text_W.Text = W.ToString("X");
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

            if(cmd!="") HandleCmd(cmd);

            if (W == 0) ZeroFlag = 1;
            else ZeroFlag = 0;

            textBox_ZeroFlag.Text = ZeroFlag.ToString();

            if (dataGridView_prog.CurrentRow == null) return;

        }

        private void text_Pc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
