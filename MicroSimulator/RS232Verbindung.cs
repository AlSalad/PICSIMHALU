using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using MicroSimulator;

namespace PIC_Simulator.PIC
{
    class Rs232Verbindung
    {
        private SerialPort ComPort;
        private SimulatorForm _simulator;
        private TextBox TextBox;
        //private Form1 Fenster;

        private Timer timer;

        public Rs232Verbindung()
        {
            timer = new Timer();
            timer.Tick += TimerOnTick;
            timer.Interval = 500;
            timer.Enabled = true;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (ComPort == null) return;
            if (!ComPort.IsOpen) return;

            SendData();
            RecieveData();
        }


        public void Connect(string port)
        {
            ComPort = new SerialPort
            {
                PortName = "COM1",
                BaudRate = 4800,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };

            try
            {
                ComPort.Open();
            }
            catch (Exception)
            {
                ComPort = null;
                return;
            }

            ComPort = null;
        }

        public void Disconnect()
        {
            if (ComPort == null) return;
            ComPort.Close();
            ComPort = null;
        }

        private void SendData()
        {
            //var portA = encodeByte(_simulator.);
            //var trisA = encodeByte(_simulator.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_A));
            //var portB = encodeByte(_simulator.GetRegisterOhneBank(PICProgramm.ADDR_PORT_B));
            //var trisB = encodeByte(_simulator.GetRegisterOhneBank(PICProgramm.ADDR_TRIS_B));

            //var send = t_a + p_a + t_b + p_b;

            //Send_RS232(send);
        }

        private void Send_RS232(string txt)
        {
            if (txt != string.Empty)
            {
                ComPort.Write(txt + '\r');
            }
        }

        private void RecieveData()
        {
            var x = ReadDataSegment();

            if (x == string.Empty) return;

            if (x.Length == 4)
            {
                var v = decodeBytes(x);

                if (v != null)
                {
                    //_simulator.SetRegisterOhneBank(PICProgramm.ADDR_PORT_A, v.Item1);
                    //_simulator.SetRegisterOhneBank(PICProgramm.ADDR_PORT_B, v.Item2);
                }
            }

            x = ReadDataSegment();
        }

        private string encodeByte(uint b)
        {
            char c1 = (char)(0x30 + ((b & 0xF0) >> 4));
            char c2 = (char)(0x30 + (b & 0x0F));

            return "" + c1 + c2;
        }

        private Tuple<uint, uint> decodeBytes(string s)
        {
            var i0 = s[0] - 0x30;
            var i1 = s[1] - 0x30;
            var i2 = s[2] - 0x30;
            var i3 = s[3] - 0x30;

            if (i0 >= 0 && i1 >= 0 && i2 >= 0 && i3 >= 0 && i0 <= 0xF && i1 <= 0xF && i2 <= 0xF && i3 <= 0xF)
            {
                uint a = (((uint)i0 & 0x0F) << 4) | ((uint)i1 & 0x0F);
                uint b = (((uint)i2 & 0x0F) << 4) | ((uint)i3 & 0x0F);

                return Tuple.Create(a, b);
            }
            else
            {
                return null;
            }
        }

        private string ReadDataSegment()
        {
            var s = "";

            if (ComPort.BytesToRead >= 5)
            {
                char? c = null;

                var idx = 5;
                while (c != '\r' && idx > 0)
                {
                    c = (char)ComPort.ReadByte();

                    s += c;

                    idx--;
                }

                if (idx <= 0 && c != '\r')
                {
                    return null;
                }
            }
            else
            {
                return string.Empty;
            }

            return s.Trim('\r');
        }

    }
}
