﻿using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace MicroSimulator
{
    public class SerialConnection
    {
        private SerialPort _comPort;
        private SimulatorForm simForm;

        public SerialConnection()
        {
            var timerSync = new Timer();
            timerSync.Tick += TimerSyncOnTick;
            timerSync.Interval = 500;
            timerSync.Enabled = true;
        }

        private void TimerSyncOnTick(object sender, EventArgs eventArgs)
        {
            if (_comPort == null) return;
            if (!_comPort.IsOpen) return;

            SendData();
            RecieveData();
        }


        public void Connect(SimulatorForm sm)
        {
            _comPort = new SerialPort
            {
                PortName = "COM1",
                BaudRate = 4800,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };

            try
            {
                _comPort.Open();
                simForm = sm;
            }
            catch (Exception)
            {
                _comPort = null;
            }
        }

        public void Disconnect()
        {
            if (_comPort == null) return;
            _comPort.Close();
            _comPort = null;
        }

        private void SendData()
        {
            var trisA = EncodeByte((uint)simForm.GetTrisA());
            var portA = EncodeByte((uint)simForm.GetPortA());
            var trisB = EncodeByte((uint)simForm.GetTrisB());
            var portB = EncodeByte((uint)simForm.GetPortB());

            var send = trisA + portA + trisB + portB;

            Send_RS232(send);
        }

        private void Send_RS232(string txt)
        {
            if (txt != string.Empty)
            {
                _comPort.Write(txt + '\r');
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
                    simForm.SetPortA(v.Item1);
                    simForm.SetPortB(v.Item2);
                }
            }

            x = ReadDataSegment();
        }

        private string EncodeByte(uint b)
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

            if (_comPort.BytesToRead >= 5)
            {
                char? c = null;

                var idx = 5;
                while (c != '\r' && idx > 0)
                {
                    c = (char)_comPort.ReadByte();

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
