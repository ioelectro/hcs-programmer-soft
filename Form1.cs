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

namespace Programmer
{
    public partial class Form1 : Form
    {
        private void update_serial_port_list()
        {
            cb_port.Items.Clear();
            foreach (string str_getPortsName in SerialPort.GetPortNames())
            {
                cb_port.Items.Add(str_getPortsName);
            }
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
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {


                serial_port.Close();

                btn_connect.Text = "Connect";

                cb_port.Enabled = Enabled;
                btn_update_port.Enabled = Enabled;
            }
        }
    }
}
