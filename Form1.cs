﻿/*
 HCS Programmer Soft
 By Liyanboy74

 https://github.com/liyanboy74
 https://github.com/liyanboy74/KeeLoq
 https://github.com/hnhkj/documents/tree/master/KEELOQ/docs
 https://github.com/ihydrad/Keeloq-decrypt/tree/master/readme
*/

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
        string RxData;
        bool vbat_sel = true;
        bool ovr_set = true;
        bool bsl_0 = false, bsl_1 = false;
        bool ser_pp = false;
        int dc = 10;
        int learn_mode = 0;

        int tim1_c = 0;
        int[] Data = new int[12];

        public void print_log(string str)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            str.Replace('\r', '\0');
            str.Replace('\n', '\0');
            rtb.AppendText(time + " " + str+ "\n");
            rtb.ScrollToCaret();
        }

        private void update_serial_port_list()
        {
            cb_port.Items.Clear();
            foreach (string str_getPortsName in SerialPort.GetPortNames())
            {
                cb_port.Items.Add(str_getPortsName);
            }
            print_log("COM Ports Reloaded");
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

        public void get_dev_ver()
        {

            tim1_c = 0;
            timer1.Start();
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
                    btn_write.Enabled = true;

                    get_dev_ver();
                }
                catch (Exception err)
                {
                    print_log("ERROR! " + err.Message);
                }
            }
            else
            {

                serial_port.Close();

                timer1.Stop();
                tim1_c = 0;

                btn_connect.Text = "Connect";

                cb_port.Enabled = true;
                btn_update_port.Enabled = true;
                print_log("Disconected");
                btn_write.Enabled = false;
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
                int nser = 0;
                int ser = 0;

                ser = int.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);

                if (cb_timer.Checked)
                {
                    nser = (int)(ser | 0x80000000);
                }
                else
                {
                    nser = (int)(ser & 0x7fffffff);
                }
                tb_ser.Text = nser.ToString("X").PadLeft(8, '0');

                if (cb_dis_auto.Checked)
                {
                    int sser = int.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
                    if(dc==10)
                    {
                        sser = sser & 0x3ff;
                        tb_dis.Text = sser.ToString("X").PadLeft(3, '0');
                    }
                    else if(dc==8)
                    {
                        sser = sser & 0xff;
                        tb_dis.Text = sser.ToString("X").PadLeft(2, '0');
                    }
                    else if (dc == 12)
                    {
                        sser = sser & 0xfff;
                        tb_dis.Text = sser.ToString("X").PadLeft(3, '0');
                    }

                }
            }
        }

        private void btn_gen_ser_Click(object sender, EventArgs e)
        {
            tb_ser.Text = GetRandomHexNumber(8);
            check_msb_ser();
            mc_clc();

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

        private void tb_sync_TextChanged(object sender, EventArgs e)
        {
            if(tb_sync.Text.Length==4)
            {
                tb_sync.Text = tb_sync.Text.ToUpper();
            }
        }

        private void tb_seed_TextChanged(object sender, EventArgs e)
        {
            if(tb_seed.Text.Length==8)
            {
                tb_seed.Text = tb_seed.Text.ToUpper();
            }
        }

        public void decode_data()
        {
            Int64 key = Int64.Parse(tb_key.Text, System.Globalization.NumberStyles.HexNumber);
            Int32 ser = Int32.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
            int seed = int.Parse(tb_seed.Text, System.Globalization.NumberStyles.HexNumber);
            int sync = int.Parse(tb_sync.Text, System.Globalization.NumberStyles.HexNumber);
            int dis = int.Parse(tb_dis.Text, System.Globalization.NumberStyles.HexNumber);


            Data[0] = (int)((key >> (16 * 0)) & 0xffff);
            Data[1] = (int)((key >> (16 * 1)) & 0xffff);
            Data[2] = (int)((key >> (16 * 2)) & 0xffff);
            Data[3] = (int)((key >> (16 * 3)) & 0xffff);

            Data[4] = sync;

            Data[5] = 0;

            Data[6] = (int)((ser >> (16 * 0)) & 0xffff);
            Data[7] = (int)((ser >> (16 * 1)) & 0xffff);

            Data[8] = (int)((seed >> (16 * 0)) & 0xffff);
            Data[9] = (int)((seed >> (16 * 1)) & 0xffff);

            Data[10] = 0;

            if (hCS200ToolStripMenuItem.Checked == true)
            {
                Data[11] = ((bsl_0 ? 1 : 0) << 13) | ((vbat_sel ? 1 : 0) << 12) | dis;
            }
            else
            {
                Data[11] = ((bsl_1 ? 1 : 0) << 14) | ((bsl_0 ? 1 : 0) << 13) | ((vbat_sel ? 1 : 0) << 12) | ((ovr_set ? 1 : 0) << 11) | ((ovr_set ? 1 : 0) << 10) | dis;
            }
         }

        public void write_data()
        {
            int i;
            string ptolog = "WRITE ";
            byte[] buffer = new byte[2];
            buffer[0] = (byte)'>';
            serial_port.Write(buffer, 0, 1);
            for (i = 0; i < 12; i++)
            {
                buffer[0] = (byte)((Data[i] >> 8) & 0xff);
                buffer[1] = (byte)((Data[i] >> 0) & 0xff);
                serial_port.Write(buffer, 0, 2);
                ptolog += string.Format("{0,2:X2}{1,2:X2} ", buffer[0], buffer[1]);
            }
            print_log(ptolog);
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            if (serial_port.IsOpen)
            {
                try
                {
                    decode_data();
                    write_data();
                }
                catch (Exception err)
                {
                    print_log("ERROR! " + err.Message);
                }
            }
            else print_log("ERROR! Serial Port not Open");
        }

        public void ser_pp_check()
        {
            uint ser = uint.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
            ser++;
            if (ser >= 0xffffffff) ser = 0;
            tb_ser.Text = ser.ToString("X").PadLeft(8,'0');
            check_msb_ser();
            print_log("SER Generated " + tb_ser.Text);
            mc_clc();
        }

        public void print_RxData_to_log(object sender, EventArgs e)
        {
            print_log(RxData);
            if (ser_pp)
            {
                if (RxData.Contains("Done"))
                {
                    ser_pp_check();
                }
            }
        }

        public void print_RxData_to_Warning(object sender, EventArgs e)
        {
            print_log("WARNING! " + RxData);
            MessageBox.Show(RxData, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void print_RxData_to_error(object sender, EventArgs e)
        {
            print_log("ERROR! " + RxData);
            MessageBox.Show(RxData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void print_RxData_to_info(object sender, EventArgs e)
        {
            print_log("INFO " + RxData);
            MessageBox.Show(RxData, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void print_device_version(object sender, EventArgs e)
        {
            print_log("DEVICE " + RxData);
            timer1.Stop();
        }

        private void serial_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int ch = serial_port.ReadByte();
            if (ch == '<')
            {
                RxData = serial_port.ReadLine();
                this.Invoke(new EventHandler(print_RxData_to_log));
            }
            else if(ch=='w')
            {
                RxData = serial_port.ReadLine();
                this.Invoke(new EventHandler(print_RxData_to_Warning));
            }
            else if (ch == 'i')
            {
                RxData = serial_port.ReadLine();
                this.Invoke(new EventHandler(print_RxData_to_info));
            }
            else if (ch == 'e')
            {
                RxData = serial_port.ReadLine();
                this.Invoke(new EventHandler(print_RxData_to_error));
            }
            else if (ch == '!')
            {

                RxData = serial_port.ReadLine();
                this.Invoke(new EventHandler(print_device_version));

            }
            else serial_port.ReadExisting();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tim1_c++;
            if(tim1_c%3==0)
            {
                try
                {
                    string TxData = "!";
                    serial_port.WriteLine(TxData);
                }
                catch (Exception err)
                {
                    print_log("ERROR! " + err.Message);
                }
            }

            if(tim1_c>11)
            {
                tim1_c = 0;
                timer1.Stop();
                print_log("WARNING! UNKNOWN Device");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ioelectro/hcs-programmer-soft");
        }

        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ioelectro.ir/contacts");
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ioelectro/hcs-programmer-soft/releases");
        }

        private void reportProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ioelectro/hcs-programmer-soft/issues");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Log File";

            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");

            if(saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();

                    for (int i = 0; i < rtb.Text.Length; i++)
                    {
                        fs.WriteByte((byte)rtb.Text[i]);
                    }

                    print_log("LOG Saved in " + fs.Name);
                    fs.Close();
                }
            }

        }

        private void tb_key_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_key.Copy();
                e.SuppressKeyPress = true;
            }
            else if(e.Control&&e.KeyCode==Keys.A)
            {
                tb_key.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_key.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_key.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void tb_ser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_ser.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tb_ser.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_ser.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_ser.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void tb_sync_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_sync.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tb_sync.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_sync.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_sync.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void tb_seed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_seed.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tb_seed.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_seed.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_seed.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void tb_dis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_dis.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tb_dis.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_dis.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_dis.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void tb_mf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                tb_mf.Copy();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                tb_mf.SelectAll();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                tb_mf.Paste();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                tb_mf.Cut();
                e.SuppressKeyPress = true;
            }
        }

        private void sERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sERToolStripMenuItem.Checked == false)
            {
                sERToolStripMenuItem.Checked = true;
                ser_pp = true;
            }
            else
            {
                sERToolStripMenuItem.Checked = false;
                ser_pp = false;
            }
        }

        void set_dc(int value)
        {
            dc = value;
            if(dc==12)
            {
                bitToolStripMenuItem2.Checked = true;
                bitToolStripMenuItem1.Checked = false;
                bitToolStripMenuItem.Checked = false;
            }
            else if(dc==10)
            {
                bitToolStripMenuItem2.Checked = false;
                bitToolStripMenuItem1.Checked = true;
                bitToolStripMenuItem.Checked = false;
            }
            else if(dc==8)
            {
                bitToolStripMenuItem2.Checked = false;
                bitToolStripMenuItem1.Checked = false;
                bitToolStripMenuItem.Checked = true;
            }

            if (cb_dis_auto.Checked) check_msb_ser();
        }
        private void bitToolStripMenuItem2_Click(object sender, EventArgs e) // 11Bit
        {
            set_dc(12);
        }


        private void bitToolStripMenuItem1_Click(object sender, EventArgs e) // 10 Bit
        {
            set_dc(10);
        }

        private void bitToolStripMenuItem_Click(object sender, EventArgs e) //8 Bit
        {
            set_dc(8);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learn_mode = 0;
            noneToolStripMenuItem.Checked = true;
            simpleLearningToolStripMenuItem.Checked = false;
            normalLearningToolStripMenuItem.Checked = false;
            secureLearnToolStripMenuItem.Checked = false;

            tb_mf.Enabled = false;
            btn_mc_clc.Enabled = false;
            btn_mc_gen.Enabled = false;


            tb_seed.Enabled = true;
            btn_gen_seed.Enabled = true;

            tb_key.Enabled = true;
            btn_gen_key.Enabled = true;
        }


        private void simpleLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learn_mode = 1;
            noneToolStripMenuItem.Checked = false;
            simpleLearningToolStripMenuItem.Checked = true;
            normalLearningToolStripMenuItem.Checked = false;
            secureLearnToolStripMenuItem.Checked = false;

            tb_mf.Enabled = false;
            btn_mc_clc.Enabled = false;
            btn_mc_gen.Enabled = false;


            tb_seed.Enabled = false;
            btn_gen_seed.Enabled = false;
            tb_seed.Text = "00000000";

            tb_key.Enabled = true;
            btn_gen_key.Enabled = true;
        }

        private void normalLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learn_mode = 2;
            noneToolStripMenuItem.Checked = false;
            simpleLearningToolStripMenuItem.Checked = false;
            normalLearningToolStripMenuItem.Checked = true;
            secureLearnToolStripMenuItem.Checked = false;

            tb_mf.Enabled = true;
            btn_mc_clc.Enabled = true;
            btn_mc_gen.Enabled = true;

            tb_seed.Enabled = false;
            btn_gen_seed.Enabled = false;
            tb_seed.Text = "00000000";

            tb_key.Enabled = false;
            btn_gen_key.Enabled = false;
        }

        private void secureLearnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learn_mode = 3;
            noneToolStripMenuItem.Checked = false;
            simpleLearningToolStripMenuItem.Checked = false;
            normalLearningToolStripMenuItem.Checked = false;
            secureLearnToolStripMenuItem.Checked = true;

            tb_mf.Enabled = true;
            btn_mc_clc.Enabled = true;
            btn_mc_gen.Enabled = true;


            tb_seed.Enabled = true;
            btn_gen_seed.Enabled = true;

            tb_key.Enabled = false;
            btn_gen_key.Enabled = false;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        const UInt16 KEELOQ_NROUNDS = 528;
        const UInt32 NLF_LOOKUP_CONSTANT = 0x3a5c742e;

        public UInt16 nlf(UInt16 d)
        {
            return (UInt16)(((UInt32)(NLF_LOOKUP_CONSTANT) >> d) & 0x1);
        }

        /*
        public UInt32 keeloq_encrypt(UInt64 key, UInt32 plaintext, UInt16 nrounds)
        {
            UInt32 ciphertext;
            UInt16 o, xor, nlf_input,i,k,ki;
            ciphertext = plaintext;
            for (i = 0; i < nrounds; i++)
            {
                nlf_input = (UInt16)(((ciphertext >> 31) & 0x1) << 4);
                nlf_input |= (UInt16)(((ciphertext >> 26) & 0x1) << 3);
                nlf_input |= (UInt16) (((ciphertext >> 20) & 0x1) << 2);
                nlf_input |= (UInt16)(((ciphertext >> 9) & 0x1) << 1);
                nlf_input |= (UInt16)((ciphertext >> 1) & 0x1);

                o = nlf(nlf_input);

                ki =(UInt16)( i % 64);

                k = (UInt16)(( key >> ki) & 0x1);

                xor = (UInt16)(k ^ ((ciphertext >> 16) & 0x1) ^ (ciphertext & 0x1) ^ o);
                ciphertext = (ciphertext >> 1) | ((UInt32)(xor) << 31);
            }
            return ciphertext;
        }
        */

        public UInt32 keeloq_decrypt(UInt64 key, UInt32 ciphertext, UInt16 nrounds)
        {
            UInt32 plaintext;
            UInt16 o, xor, nlf_input,i,k,ki;
            plaintext = ciphertext;
            for (i = 0; i < nrounds; i++)
            {
                nlf_input = (UInt16)(((plaintext >> 30) & 0x1) << 4);
                nlf_input |= (UInt16)(((plaintext >> 25) & 0x1) << 3);
                nlf_input |= (UInt16)(((plaintext >> 19) & 0x1) << 2);
                nlf_input |= (UInt16)(((plaintext >> 8) & 0x1) << 1);
                nlf_input |= (UInt16)(plaintext & 0x1);

                o = nlf(nlf_input);

                ki = (UInt16)((15 - i) % 64);

                k = (UInt16)((key >> ki) & 0x1);

                xor =(UInt16) (k ^ ((plaintext >> 31) & 0x1) ^ ((plaintext >> 15) & 0x1) ^ o);
                plaintext = (plaintext << 1) | xor;
            }
            return plaintext;
        }


        public ulong gen_normal_key(ulong mf_key,UInt32 ser)
        {
            ulong ret = 0;
            UInt32 temp;

            ser &= 0x0fffffff;// mask out function codes 

            temp = ser;
            temp |= 0x20000000;
            ret = keeloq_decrypt(mf_key, temp, KEELOQ_NROUNDS);

            temp = ser;
            temp |= 0x60000000;
            ret |= ((UInt64)keeloq_decrypt(mf_key,temp,KEELOQ_NROUNDS)<<32);

            return ret;
        }

        public ulong gen_secure_key(ulong mf_key,UInt32 seed,UInt32 ser)
        {
            ulong ret = 0;

            ret = keeloq_decrypt(mf_key, seed, KEELOQ_NROUNDS);
            ser &= 0x0fffffff;
            ret |= ((UInt64)keeloq_decrypt(mf_key, ser, KEELOQ_NROUNDS) << 32);

            return ret;
        }

        public void mc_clc()
        {
            if (learn_mode>1)
            {
                UInt64 mkey = UInt64.Parse(tb_mf.Text, System.Globalization.NumberStyles.HexNumber);
                UInt32 ser = UInt32.Parse(tb_ser.Text, System.Globalization.NumberStyles.HexNumber);
                UInt32 seed = UInt32.Parse(tb_seed.Text, System.Globalization.NumberStyles.HexNumber);

                ulong hash = 0;

                if (learn_mode==2)
                {
                    hash = gen_normal_key(mkey, ser);
                }
                else if(learn_mode==3)
                {
                    hash = gen_secure_key(mkey, seed,ser);
                }


                tb_key.Text = hash.ToString("X").PadLeft(16, '0');
                print_log("KEY Generated " + tb_key.Text);
            }
        }

        private void btn_mc_clc_Click(object sender, EventArgs e)
        {
            mc_clc();
        }

        private void btn_pp_Click(object sender, EventArgs e)
        {
            ser_pp_check();
        }

        private void tb_mf_KeyPress(object sender, KeyPressEventArgs e)
        {
            hex_KeyPress(sender, e);
        }

        private void tb_mf_TextChanged(object sender, EventArgs e)
        {
            if (tb_mf.Text.Length == 16) tb_mf.Text = tb_mf.Text.ToUpper();
        }

        private void btn_gen_seed_Click(object sender, EventArgs e)
        {
            tb_seed.Text = GetRandomHexNumber(8);
            print_log("SEED Generated " + tb_seed.Text);

            mc_clc();
            
        }

        private void btn_mc_gen_Click(object sender, EventArgs e)
        {
            tb_mf.Text = GetRandomHexNumber(16);
            print_log("Manufacturer Code Generated " + tb_mf.Text);
        }

        private void hCS301ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hCS301ToolStripMenuItem.Checked = true;
            hCS300ToolStripMenuItem.Checked = false;
            hCS200ToolStripMenuItem.Checked = false;

            cb_ovr_set.Checked = true;
            cb_ovr_set.Enabled = true;

            rb_9or12v.Text= "9 or 12 V";
            rb_6v.Text= "6 V";

            string[] obj = new string[] { "00 400uS ALL", "01 200uS 1 / 2", "10 100uS 1 / 2", "11 100uS  1 / 4" };
            cb_br.Items.Clear();
            cb_br.Items.AddRange(obj);
            cb_br.SelectedIndex = 0;

            set_dc(10);
        }

        private void hCS300ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hCS301ToolStripMenuItem.Checked = false;
            hCS300ToolStripMenuItem.Checked = true;
            hCS200ToolStripMenuItem.Checked = false;

            cb_ovr_set.Checked = true;
            cb_ovr_set.Enabled = true;

            rb_9or12v.Text = "5 or 6 V";
            rb_6v.Text = "3.0 V";

            string[] obj = new string[] { "00 400uS ALL", "01 200uS 1 / 2", "10 100uS 1 / 2", "11 100uS  1 / 4" };
            cb_br.Items.Clear();
            cb_br.Items.AddRange(obj);
            cb_br.SelectedIndex = 0;

            set_dc(10);
        }

        private void hCS200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hCS301ToolStripMenuItem.Checked = false;
            hCS300ToolStripMenuItem.Checked = false;
            hCS200ToolStripMenuItem.Checked = true;

            cb_ovr_set.Checked = false;
            cb_ovr_set.Enabled = false;

            rb_9or12v.Text = "9 or 12 V";
            rb_6v.Text = "6 V";

            string[] obj= new string[]{ "0 400uS ALL", "1 200uS 1 / 2" };
            cb_br.Items.Clear();
            cb_br.Items.AddRange(obj);
            cb_br.SelectedIndex = 0;

            set_dc(12);

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
