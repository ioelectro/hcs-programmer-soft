using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Globalization;

namespace Programmer
{
    public partial class Form1 : Form
    {
        public void print_log(string str)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            rtb.AppendText("\r" + time + ": " + str);
            rtb.ScrollToCaret();
        }

        private void update_serial_port_list()
        {
            cb_port.Items.Clear();
            foreach (string str_getPortsName in SerialPort.GetPortNames())
            {
                cb_port.Items.Add(str_getPortsName);
            }
            print_log("Com ports reloaded");
        }

        public Form1()
        {
            InitializeComponent();
            update_serial_port_list();
        }


        private void btn_update_port_Click(object sender, EventArgs e)
        {
            update_serial_port_list();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (btn_connect.Text == "Connect")
            {
                try
                {
                    serial_port.PortName = cb_port.Text;

                    serial_port.Open();

                    cb_port.Enabled = false;
                    btn_update_port.Enabled = false;

                    btn_connect.Text = "Disconect";
                    print_log("Connected to " + serial_port.PortName);
                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    print_log("ERROR! " + err.Message);
                }
            }
            else
            {


                serial_port.Close();

                btn_connect.Text = "Connect";

                cb_port.Enabled = true;
                btn_update_port.Enabled = true;
                print_log("Disconected");
            }
        }

        static Random random = new Random();
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }


        private void btn_gen_Click(object sender, EventArgs e)
        {
            tb_key.Text = GetRandomHexNumber(16);
            print_log("KEY Generated "+tb_key.Text);
        }

        private void tb_key_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }

        private void btn_gen_ser_Click(object sender, EventArgs e)
        {
            tb_ser.Text = GetRandomHexNumber(8);
            print_log("SER Generated " + tb_ser.Text);
        }

        private void tb_ser_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }
    }
}
