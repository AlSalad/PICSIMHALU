using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSimulator
{
     
    public partial class SimulatorForm : Form
    {
        public int w = 0;
        public int l = 0;

        public SimulatorForm()
        {
            InitializeComponent();
        }

        private void Simulator_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            foreach (var cmd in CmdInput.Items)
            {
                MessageBox.Show(ConvertToText(cmd.ToString()), "Command");
                
            }
            
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
            l = cmdLit;
            w = l;
            text_W.Text = w.ToString();
        }

        private void Iorlw(int cmdLit)
        {
            l = cmdLit;
            w = w | l;
            text_W.Text = w.ToString();
        }

        private void Andlw(int cmdLit)
        {
            l = cmdLit;
            w = w & l;
            text_W.Text = w.ToString();
        }

        private void Xorlw(int cmdLit)
        {
            l = cmdLit;
            w = w ^ l;
            text_W.Text = w.ToString();
        }

        private void Sublw(int cmdLit)
        {
            l = cmdLit;
            w = l - w;
            text_W.Text = w.ToString();
        }

        private void Addlw(int cmdLit)
        {
            l = cmdLit;
            w = l + w;
            text_W.Text = w.ToString();
        }
    }
}
