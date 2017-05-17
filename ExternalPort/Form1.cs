using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace ExternalPort
{
    public partial class FormSchnittstelle : Form
    {
        SerialPort _port = new SerialPort("COM2", 9600);
        public FormSchnittstelle()
        {          
            _port.Open();
            InitializeComponent();

            button_A0.BackColor = Color.White;
            button_A1.BackColor = Color.White;
            button_A2.BackColor = Color.White;
            button_A3.BackColor = Color.White;
            button_A4.BackColor = Color.White;
            button_A5.BackColor = Color.White;
            button_A6.BackColor = Color.White;
            button_A7.BackColor = Color.White;

        }

        private void button_A0_Click(object sender, EventArgs e)
        {
            if (button_A0.BackColor == Color.White)
            {
                _port.Write("A;0;0;O");
                button_A0.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A0.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;0;0;T");
                button_A0.BackColor = Color.IndianRed;
                return;
            }

            if (button_A0.BackColor == Color.IndianRed)
            {
                _port.Write("A;0;0;I");
                button_A0.BackColor = Color.White;
            }
        }

        private void button_A1_Click(object sender, EventArgs e)
        {
            if (button_A1.BackColor == Color.White)
            {
                _port.Write("A;1;0;O");
                button_A1.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A1.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;1;0;T");
                button_A1.BackColor = Color.IndianRed;
                return;
            }

            if (button_A1.BackColor == Color.IndianRed)
            {
                _port.Write("A;1;0;I");
                button_A1.BackColor = Color.White;
            }
        }
    }
}
