using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroSimulator.Properties;

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

        private static string ConvertToText(string cmd)
        {
            var cmdOp = cmd.Substring(0, 2);
            var cmdLit = Convert.ToInt32(cmd.Substring(2, 2),16);

            switch (cmdOp)
            {
                case "30":
                    //Movlw(cmdLit);
                    return "movlw";
                case "38":
                    //Iorlw(cmdLit);
                    return "iorlw";
                case "39":
                    //Andlw(cmdLit);
                    return "andlw";
                case "3A":
                    //Xorlw(cmdLit);
                    return "xorlw";
                case "3C":
                    //Sublw(cmdLit);
                    return "sublw";
                case "3E":
                    //Addlw(cmdLit);
                    return "addlw";
                default:
                    return "ERROR";
            }
        }

        private void Movlw(int cmdLit)
        {
            L = cmdLit;
            W = L;
            text_W.Text = W.ToString();
        }

        private void Iorlw(int cmdLit)
        {
            L = cmdLit;
            W = W | L;
            text_W.Text = W.ToString();
        }

        private void Andlw(int cmdLit)
        {
            L = cmdLit;
            W = W & L;
            text_W.Text = W.ToString();
        }

        private void Xorlw(int cmdLit)
        {
            L = cmdLit;
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
            var rgxCmd = new Regex("[0-9A-F]{4} [0-9A-F]{4}", RegexOptions.IgnoreCase);
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
                    dataGridView_prog.Rows.Add(rgxCmd.Match(codeLine).Value.Substring(0, 4), cmd, ConvertToText(cmd));
                }

                

                //MessageBox.Show(rgx.Match(codeLine).Value);
            }
        }

        private void btn_Step_Click(object sender, EventArgs e)
        {
            if (dataGridView_prog.CurrentRow == null) return;             
            var nrow = dataGridView_prog.CurrentCell.RowIndex;
            if (nrow >= dataGridView_prog.RowCount) return;

            dataGridView_prog.Rows[nrow].Selected = false;
            dataGridView_prog.Rows[++nrow].Selected = true;
        }

        private void btn_execute_Click(object sender, EventArgs e)
        {
            if (dataGridView_prog.CurrentRow != null)
            {
                var cmd = dataGridView_prog.CurrentRow.Cells[1].Value.ToString();

                MessageBox.Show(cmd);
            }
        }
    }
}
