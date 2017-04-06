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

        private void Simulator_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
 
            
        }

        private void CmdInput_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private string ConvertToText(string cmd)
        {
            var cmdOp = cmd.Substring(0, 2);
            var cmdLit = Convert.ToInt32(cmd.Substring(2, 2),16);

            switch (cmdOp)
            {
                case "30":
                    Movlw(cmdLit);
                    return "movlw";
                case "38":
                    Iorlw(cmdLit);
                    return "iorlw";
                case "39":
                    Andlw(cmdLit);
                    return "andlw";
                case "3A":
                    Xorlw(cmdLit);
                    return "xorlw";
                case "3C":
                    Sublw(cmdLit);
                    return "sublw";
                case "3E":
                    Addlw(cmdLit);
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
            Stream customStream = null;
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\workspace\\MicroSimulator\\MicroSimulator\\Tests",
                Filter = "*.LST|",
                FilterIndex = 2,
                RestoreDirectory = true
            };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((customStream = openFileDialog.OpenFile()) == null) return;

                    using (customStream)
                    {
                            
                        using (StreamReader reader = new StreamReader(customStream))
                        {
                            CodeList = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            RegexCmd();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
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
            string pattern = "[0-9A-F]{4} [0-9A-F]{4}";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (string codeLine in CodeList)
            {
                if (rgx.Match(codeLine).Success)
                {
                    dataGridView_prog.Rows.Add(rgx.Match(codeLine).Value.Substring(0, 4), rgx.Match(codeLine).Value.Substring(5, 4), "");
                    //MessageBox.Show(rgx.Match(codeLine).Value);
                }  
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
