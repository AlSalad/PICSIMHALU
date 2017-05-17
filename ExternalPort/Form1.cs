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
            button_B0.BackColor = Color.White;
            button_B1.BackColor = Color.White;
            button_B2.BackColor = Color.White;
            button_B3.BackColor = Color.White;
            button_B4.BackColor = Color.White;
            button_B5.BackColor = Color.White;
            button_B6.BackColor = Color.White;
            button_B7.BackColor = Color.White;

        }

        // Button von A mit Farben

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

        private void button_A2_Click(object sender, EventArgs e)
        {
            if (button_A2.BackColor == Color.White)
            {
                _port.Write("A;2;0;O");
                button_A2.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A2.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;2;0;T");
                button_A2.BackColor = Color.IndianRed;
                return;
            }

            if (button_A2.BackColor == Color.IndianRed)
            {
                _port.Write("A;2;0;I");
                button_A2.BackColor = Color.White;
            }

        }

        private void button_A3_Click(object sender, EventArgs e)
        {
            if (button_A3.BackColor == Color.White)
            {
                _port.Write("A;3;0;O");
                button_A3.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A3.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;3;0;T");
                button_A3.BackColor = Color.IndianRed;
                return;
            }

            if (button_A3.BackColor == Color.IndianRed)
            {
                _port.Write("A;3;0;I");
                button_A3.BackColor = Color.White;
            }

        }

        private void button_A4_Click(object sender, EventArgs e)
        {
            if (button_A4.BackColor == Color.White)
            {
                _port.Write("A;4;0;O");
                button_A4.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A4.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;4;0;T");
                button_A4.BackColor = Color.IndianRed;
                return;
            }

            if (button_A4.BackColor == Color.IndianRed)
            {
                _port.Write("A;4;0;I");
                button_A4.BackColor = Color.White;
            }

        }

        private void button_A5_Click(object sender, EventArgs e)
        {
            if (button_A5.BackColor == Color.White)
            {
                _port.Write("A;5;0;O");
                button_A5.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A5.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;5;0;T");
                button_A5.BackColor = Color.IndianRed;
                return;
            }

            if (button_A5.BackColor == Color.IndianRed)
            {
                _port.Write("A;5;0;I");
                button_A5.BackColor = Color.White;
            }
        }

        private void button_A6_Click(object sender, EventArgs e)
        {
            if (button_A6.BackColor == Color.White)
            {
                _port.Write("A;6;0;O");
                button_A6.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A6.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;6;0;T");
                button_A6.BackColor = Color.IndianRed;
                return;
            }

            if (button_A6.BackColor == Color.IndianRed)
            {
                _port.Write("A;6;0;I");
                button_A6.BackColor = Color.White;
            }
        }

        private void button_A7_Click(object sender, EventArgs e)
        {
            if (button_A7.BackColor == Color.White)
            {
                _port.Write("A;7;0;O");
                button_A7.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_A7.BackColor == Color.CornflowerBlue)
            {
                _port.Write("A;7;0;T");
                button_A7.BackColor = Color.IndianRed;
                return;
            }

            if (button_A7.BackColor == Color.IndianRed)
            {
                _port.Write("A;7;0;I");
                button_A7.BackColor = Color.White;
            }
        }


        //Bit teil von A
        private void button_bit_A0_Click(object sender, EventArgs e)
        {
            if (button_bit_A0.Text == "0")
            {
                _port.Write("A;0;1;1");
                button_bit_A0.Text = "1";
            }
            else
            {
                _port.Write("A;0;1;0");
                button_bit_A0.Text = "0";
            }
        }

        private void button_bit_A1_Click(object sender, EventArgs e)
        {
            if (button_bit_A1.Text == "0")
            {
                _port.Write("A;1;1;1");
                button_bit_A1.Text = "1";
            }
            else
            {
                _port.Write("A;1;1;0");
                button_bit_A1.Text = "0";
            }


        }

        private void button_bit_A2_Click(object sender, EventArgs e)
        {
            if (button_bit_A2.Text == "0")
            {
                _port.Write("A;2;1;1");
                button_bit_A2.Text = "1";
            }
            else
            {
                _port.Write("A;2;1;0");
                button_bit_A2.Text = "0";
            }

        }

        private void button_bit_A3_Click(object sender, EventArgs e)
        {
            if (button_bit_A3.Text == "0")
            {
                _port.Write("A;3;1;1");
                button_bit_A3.Text = "1";
            }
            else
            {
                _port.Write("A;3;1;0");
                button_bit_A3.Text = "0";
            }
        }

        private void button_bit_A4_Click(object sender, EventArgs e)
        {
            if (button_bit_A4.Text == "0")
            {
                _port.Write("A;4;1;1");
                button_bit_A4.Text = "1";
            }
            else
            {
                _port.Write("A;4;1;0");
                button_bit_A4.Text = "0";
            }
        }

        private void button_bit_A5_Click(object sender, EventArgs e)
        {
            if (button_bit_A5.Text == "0")
            {
                _port.Write("A;5;1;1");
                button_bit_A5.Text = "1";
            }
            else
            {
                _port.Write("A;5;1;0");
                button_bit_A5.Text = "0";
            }

        }

        private void button_bit_A6_Click(object sender, EventArgs e)
        {
            if (button_bit_A6.Text == "0")
            {
                _port.Write("A;6;1;1");
                button_bit_A6.Text = "1";
            }
            else
            {
                _port.Write("A;6;1;0");
                button_bit_A6.Text = "0";
            }
        }

        private void button_bit_A7_Click(object sender, EventArgs e)
        {
            if (button_bit_A7.Text == "0")
            {
                _port.Write("A;7;1;1");
                button_bit_A7.Text = "1";
            }
            else
            {
                _port.Write("A;7;1;0");
                button_bit_A7.Text = "0";
            }
        }



        // Button B mit Farben

        private void button_B0_Click(object sender, EventArgs e)
        {

            if (button_B0.BackColor == Color.White)
            {
                _port.Write("B;0;0;O");
                button_B0.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B0.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;0;0;T");
                button_B0.BackColor = Color.IndianRed;
                return;
            }

            if (button_B0.BackColor == Color.IndianRed)
            {
                _port.Write("B;0;0;I");
                button_B0.BackColor = Color.White;
            }

        }

        private void button_B1_Click(object sender, EventArgs e)
        {

            if (button_B1.BackColor == Color.White)
            {
                _port.Write("B;1;0;O");
                button_B1.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B1.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;1;0;T");
                button_B1.BackColor = Color.IndianRed;
                return;
            }

            if (button_B1.BackColor == Color.IndianRed)
            {
                _port.Write("B;1;0;I");
                button_B1.BackColor = Color.White;
            }
        }

        private void button_B2_Click(object sender, EventArgs e)
        {
            if (button_B2.BackColor == Color.White)
            {
                _port.Write("B;2;0;O");
                button_B2.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B2.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;2;0;T");
                button_B2.BackColor = Color.IndianRed;
                return;
            }

            if (button_B2.BackColor == Color.IndianRed)
            {
                _port.Write("B;2;0;I");
                button_B2.BackColor = Color.White;
            }
        }

        private void button_B3_Click(object sender, EventArgs e)
        {
            if (button_B3.BackColor == Color.White)
            {
                _port.Write("B;3;0;O");
                button_B3.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B3.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;3;0;T");
                button_B3.BackColor = Color.IndianRed;
                return;
            }

            if (button_B3.BackColor == Color.IndianRed)
            {
                _port.Write("B;3;0;I");
                button_B3.BackColor = Color.White;
            }
        }

        private void button_B4_Click(object sender, EventArgs e)
        {
            if (button_B4.BackColor == Color.White)
            {
                _port.Write("B;4;0;O");
                button_B4.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B4.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;4;0;T");
                button_B4.BackColor = Color.IndianRed;
                return;
            }

            if (button_B4.BackColor == Color.IndianRed)
            {
                _port.Write("B;4;0;I");
                button_B4.BackColor = Color.White;
            }
        }

        private void button_B5_Click(object sender, EventArgs e)
        {
            if (button_B5.BackColor == Color.White)
            {
                _port.Write("B;5;0;O");
                button_B5.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B5.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;5;0;T");
                button_B5.BackColor = Color.IndianRed;
                return;
            }

            if (button_B5.BackColor == Color.IndianRed)
            {
                _port.Write("B;5;0;I");
                button_B5.BackColor = Color.White;
            }
        }

        private void button_B6_Click(object sender, EventArgs e)
        {
            if (button_B6.BackColor == Color.White)
            {
                _port.Write("B;6;0;O");
                button_B6.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B6.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;6;0;T");
                button_B6.BackColor = Color.IndianRed;
                return;
            }

            if (button_B6.BackColor == Color.IndianRed)
            {
                _port.Write("B;6;0;I");
                button_B6.BackColor = Color.White;
            }
        }

        private void button_B7_Click(object sender, EventArgs e)
        {
            if (button_B7.BackColor == Color.White)
            {
                _port.Write("B;7;0;O");
                button_B7.BackColor = Color.CornflowerBlue;
                return;
            }

            if (button_B7.BackColor == Color.CornflowerBlue)
            {
                _port.Write("B;7;0;T");
                button_B7.BackColor = Color.IndianRed;
                return;
            }

            if (button_B7.BackColor == Color.IndianRed)
            {
                _port.Write("B;7;0;I");
                button_B7.BackColor = Color.White;
            }
        }

       
        //Bit Teil Button B

        private void button_bit_B0_Click(object sender, EventArgs e)
        {
            if (button_bit_B0.Text == "0")
            {
                _port.Write("B;0;1;1");
                button_bit_B0.Text = "1";
            }
            else
            {
                _port.Write("B;0;1;0");
                button_bit_B0.Text = "0";
            }
        }

        private void button_bit_B1_Click(object sender, EventArgs e)
        {
            if (button_bit_B1.Text == "0")
            {
                _port.Write("B;1;1;1");
                button_bit_B1.Text = "1";
            }
            else
            {
                _port.Write("B;1;1;0");
                button_bit_B1.Text = "0";
            }
        }

        private void button_bit_B2_Click(object sender, EventArgs e)
        {
            if (button_bit_B2.Text == "0")
            {
                _port.Write("B;2;1;1");
                button_bit_B2.Text = "1";
            }
            else
            {
                _port.Write("B;2;1;0");
                button_bit_B2.Text = "0";
            }
        }

        private void button_bit_B3_Click(object sender, EventArgs e)
        {
            if (button_bit_B3.Text == "0")
            {
                _port.Write("B;3;1;1");
                button_bit_B3.Text = "1";
            }
            else
            {
                _port.Write("B;3;1;0");
                button_bit_B3.Text = "0";
            }
        }

        private void button_bit_B4_Click(object sender, EventArgs e)
        {
            if (button_bit_B4.Text == "0")
            {
                _port.Write("B;4;1;1");
                button_bit_B4.Text = "1";
            }
            else
            {
                _port.Write("B;4;1;0");
                button_bit_B4.Text = "0";
            }
        }

        private void button_bit_B5_Click(object sender, EventArgs e)
        {
            if (button_bit_B5.Text == "0")
            {
                _port.Write("B;5;1;1");
                button_bit_B5.Text = "1";
            }
            else
            {
                _port.Write("B;5;1;0");
                button_bit_B5.Text = "0";
            }
        }

        private void button_bit_B6_Click(object sender, EventArgs e)
        {
            if (button_bit_B6.Text == "0")
            {
                _port.Write("B;6;1;1");
                button_bit_B6.Text = "1";
            }
            else
            {
                _port.Write("B;6;1;0");
                button_bit_B6.Text = "0";
            }
        }

        private void button_bit_B7_Click(object sender, EventArgs e)
        {
            if (button_bit_B7.Text == "0")
            {
                _port.Write("B;7;1;1");
                button_bit_B7.Text = "1";
            }
            else
            {
                _port.Write("B;7;1;0");
                button_bit_B7.Text = "0";
            }
        }

        
    }
}
