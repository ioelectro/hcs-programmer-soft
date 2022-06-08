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
        bool vbat_sel = true;
        bool ovr_set = true;
        bool bsl_0 = false, bsl_1 = false;

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
            cb_br.SelectedIndex = 0;
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

        private void hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }

        private void tb_key_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        private void tb_ser_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        private void tb_sync_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        public void check_msb_ser()
        {
            if (tb_ser.Text.Length == 8)
            {
                int nser = 0, ser = int.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
                if (cb_timer.Checked)
                {
                    nser = (int)(ser | 0x80000000);
                }
                else
                {
                    nser = (int)(ser & 0x7fffffff);
                }
                tb_ser.Text = Convert.ToString(nser, 16).ToUpper();

                if (cb_dis_auto.Checked)
                {
                    int sser = int.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
                    sser = sser & 0x3ff;
                    tb_dis.Text = Convert.ToString(sser, 16).ToUpper();
                }
            }
        }

        private void btn_gen_ser_Click(object sender, EventArgs e)
        {
            tb_ser.Text = GetRandomHexNumber(8);
            check_msb_ser();

            print_log("SER Generated " + tb_ser.Text);
        }

        private void tb_seed_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        private void rb_9or12v_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_9or12v.Checked)
            {
                vbat_sel = true;
            }
        }

        private void rb_6v_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_6v.Checked)
            {
                vbat_sel = false;
            }
        }

        private void cb_ovr_set_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_ovr_set.Checked)
            {
                ovr_set = true;
            }
            else
            {
                ovr_set = false;
            }
        }

        private void tb_dis_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        private void cb_dis_auto_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_dis_auto.Checked)
            {
                tb_dis.Enabled = false;
                check_msb_ser();            
            }
            else
            {
                tb_dis.Enabled = true;
            }
        }

        private void tb_ser_TextChanged(object sender, EventArgs e)
        {
            check_msb_ser();
        }

        private void cb_timer_CheckedChanged(object sender, EventArgs e)
        {
            check_msb_ser();
        }

        private void tb_dis_TextChanged(object sender, EventArgs e)
        {
            if (tb_dis.Text.Length == 3) tb_dis.Text = tb_dis.Text.ToUpper();
        }

        private void tb_key_TextChanged(object sender, EventArgs e)
        {
            if (tb_key.Text.Length == 16) tb_key.Text=tb_key.Text.ToUpper();
        }

        private void cb_br_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cb_br.SelectedIndex)
            {
                case 0: bsl_0 = false;bsl_1 = false;break;
                case 1: bsl_0 = true; bsl_1 = false; break;
                case 2: bsl_0 = false; bsl_1 = true; break;
                case 3: bsl_0 = true; bsl_1 = true; break;
                default:break;
            }
        }
    }
}
