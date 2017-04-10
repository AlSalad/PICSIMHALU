using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        public string[] CodeList;

        public SimulatorForm()
        {
            InitializeComponent();
        }
        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RunLine()
        {
            
        }

        public string Hex2Bin(string value)
        {
            return Convert.ToString(Convert.ToInt32(value, 16), 2).PadLeft(value.Length * 4, '0');
        }

        public int Bin2Dec(string value)
        {
           return Convert.ToInt32(value, 2);
        }

        private void CmdHandler(string cmd)
        {
            var bin = Hex2Bin(cmd).Substring(2);

            if (bin.StartsWith("1100"))
                Movlw(bin.Substring(7));

            if (bin.StartsWith("111000"))
                Iorlw(bin.Substring(7));

            if (bin.StartsWith("111001"))
                Andlw(bin.Substring(7));

            if(bin.StartsWith("111010"))
                Xorlw(bin.Substring(7));





        }
        private void Goto(int cmdLit)
        {
            var searchValue = ("00" + cmdLit);

            dataGridView_prog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView_prog.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                    
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void Movlw(string cmdLit)
        {        
            L = Bin2Dec(cmdLit);
            W = L;
            text_W.Text = W.ToString();
        }

        private void Iorlw(string cmdLit)
        {
            L = Bin2Dec(cmdLit);
            W = W | L;
            text_W.Text = W.ToString();
        }

        private void Andlw(string cmdLit)
        {
            L = Bin2Dec(cmdLit);
            W = W & L;
            text_W.Text = W.ToString();
        }

        private void Xorlw(string cmdLit)
        {
            L = Bin2Dec(cmdLit);
            W = W ^ L;
            text_W.Text = W.ToString();
        }

        private void Sublw(int cmdLit)
        {
            L = cmdLit;
            W = L - W;
            text_W.Text = W.ToString();
        }

        private void Addlw(int cmdLit)
        {
            L = cmdLit;
            W = L + W;
            text_W.Text = W.ToString();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
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
                        RegexCmd();
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

        private void RegexCmd()
        {
            var rgxCmd = new Regex("[0-9A-F]{4} [0-9A-F]{4}");
            var rgxCmdReadable = new Regex("[0-9a-fA-F]{5}[ ]*[a-z]* [0-9a-zA-Z]*");
            var rgxLoop = new Regex("[0-9A-F]{5}  [0-9a-zA-Z]*");
            foreach (var codeLine in CodeList)
            {
                if (rgxLoop.Match(codeLine).Success)
                {
                    var loop = rgxLoop.Match(codeLine).Value.Substring(7);
                    if(loop!="")
                        dataGridView_prog.Rows.Add("", "", loop, "");
                }


                if (rgxCmd.Match(codeLine).Success)
                {
                    var cmd = rgxCmd.Match(codeLine).Value.Substring(5, 4);
                    var cmdReadable = rgxCmdReadable.Match(codeLine).Value.Substring(16);
                    dataGridView_prog.Rows.Add(rgxCmd.Match(codeLine).Value.Substring(0, 4), cmd, cmdReadable);
                }

                

                //MessageBox.Show(rgx.Match(codeLine).Value);
            }
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void Execute()
        {
            if (dataGridView_prog.CurrentRow == null) return;

            var cmd = dataGridView_prog.CurrentRow.Cells[1].Value.ToString();

            if(cmd!="") CmdHandler(cmd);

            if (dataGridView_prog.CurrentRow == null) return;

            dataGridView_prog.CurrentCell =
                    dataGridView_prog
                    .Rows[Math.Min(dataGridView_prog.CurrentRow.Index + 1, dataGridView_prog.Rows.Count - 1)]
                    .Cells[dataGridView_prog.CurrentCell.ColumnIndex];
            dataGridView_prog.Rows[dataGridView_prog.CurrentCell.RowIndex].Selected = true;
        }
    }
}
