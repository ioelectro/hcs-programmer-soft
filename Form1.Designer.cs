namespace Programmer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_auto = new System.Windows.Forms.Button();
            this.btn_write = new System.Windows.Forms.Button();
            this.cb_timer = new System.Windows.Forms.CheckBox();
            this.cb_dis_auto = new System.Windows.Forms.CheckBox();
            this.tb_dis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ovr_set = new System.Windows.Forms.CheckBox();
            this.tb_seed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_sync = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_gen_ser = new System.Windows.Forms.Button();
            this.tb_ser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_gen_key = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_update_port = new System.Windows.Forms.Button();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discriminationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportProblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serial_port = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_br = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb_6v = new System.Windows.Forms.RadioButton();
            this.rb_9or12v = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_auto);
            this.groupBox1.Controls.Add(this.btn_write);
            this.groupBox1.Controls.Add(this.cb_timer);
            this.groupBox1.Controls.Add(this.cb_dis_auto);
            this.groupBox1.Controls.Add(this.tb_dis);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cb_ovr_set);
            this.groupBox1.Controls.Add(this.tb_seed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_sync);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_gen_ser);
            this.groupBox1.Controls.Add(this.tb_ser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_gen_key);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_key);
            this.groupBox1.Location = new System.Drawing.Point(172, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main";
            // 
            // btn_auto
            // 
            this.btn_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_auto.Enabled = false;
            this.btn_auto.Location = new System.Drawing.Point(251, 169);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(75, 23);
            this.btn_auto.TabIndex = 3;
            this.btn_auto.Text = "Auto";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // btn_write
            // 
            this.btn_write.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_write.Enabled = false;
            this.btn_write.Location = new System.Drawing.Point(331, 169);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(75, 23);
            this.btn_write.TabIndex = 16;
            this.btn_write.Text = "Write";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // cb_timer
            // 
            this.cb_timer.AutoSize = true;
            this.cb_timer.Checked = true;
            this.cb_timer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_timer.Location = new System.Drawing.Point(193, 52);
            this.cb_timer.Name = "cb_timer";
            this.cb_timer.Size = new System.Drawing.Size(133, 17);
            this.cb_timer.TabIndex = 8;
            this.cb_timer.Text = "ShutOFF Timer Enable";
            this.cb_timer.UseVisualStyleBackColor = true;
            this.cb_timer.CheckedChanged += new System.EventHandler(this.cb_timer_CheckedChanged);
            // 
            // cb_dis_auto
            // 
            this.cb_dis_auto.AutoSize = true;
            this.cb_dis_auto.Checked = true;
            this.cb_dis_auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_dis_auto.Location = new System.Drawing.Point(194, 133);
            this.cb_dis_auto.Name = "cb_dis_auto";
            this.cb_dis_auto.Size = new System.Drawing.Size(145, 17);
            this.cb_dis_auto.TabIndex = 12;
            this.cb_dis_auto.Text = "Auto Gen From SER LSB";
            this.cb_dis_auto.UseVisualStyleBackColor = true;
            this.cb_dis_auto.CheckedChanged += new System.EventHandler(this.cb_dis_auto_CheckedChanged);
            // 
            // tb_dis
            // 
            this.tb_dis.Enabled = false;
            this.tb_dis.Location = new System.Drawing.Point(82, 131);
            this.tb_dis.MaxLength = 3;
            this.tb_dis.Name = "tb_dis";
            this.tb_dis.Size = new System.Drawing.Size(101, 20);
            this.tb_dis.TabIndex = 13;
            this.tb_dis.Text = "000";
            this.tb_dis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_dis.TextChanged += new System.EventHandler(this.tb_dis_TextChanged);
            this.tb_dis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_dis_KeyDown);
            this.tb_dis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_dis_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Discrimination:";
            // 
            // cb_ovr_set
            // 
            this.cb_ovr_set.AutoSize = true;
            this.cb_ovr_set.Checked = true;
            this.cb_ovr_set.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ovr_set.Location = new System.Drawing.Point(193, 79);
            this.cb_ovr_set.Name = "cb_ovr_set";
            this.cb_ovr_set.Size = new System.Drawing.Size(68, 17);
            this.cb_ovr_set.TabIndex = 10;
            this.cb_ovr_set.Text = "OVR Set";
            this.cb_ovr_set.UseVisualStyleBackColor = true;
            this.cb_ovr_set.CheckedChanged += new System.EventHandler(this.cb_ovr_set_CheckedChanged);
            // 
            // tb_seed
            // 
            this.tb_seed.Location = new System.Drawing.Point(82, 103);
            this.tb_seed.MaxLength = 8;
            this.tb_seed.Name = "tb_seed";
            this.tb_seed.Size = new System.Drawing.Size(101, 20);
            this.tb_seed.TabIndex = 11;
            this.tb_seed.Text = "00000000";
            this.tb_seed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_seed.TextChanged += new System.EventHandler(this.tb_seed_TextChanged);
            this.tb_seed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_seed_KeyDown);
            this.tb_seed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_seed_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SEED:";
            // 
            // tb_sync
            // 
            this.tb_sync.Location = new System.Drawing.Point(82, 77);
            this.tb_sync.MaxLength = 4;
            this.tb_sync.Name = "tb_sync";
            this.tb_sync.Size = new System.Drawing.Size(101, 20);
            this.tb_sync.TabIndex = 9;
            this.tb_sync.Text = "0000";
            this.tb_sync.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sync.TextChanged += new System.EventHandler(this.tb_sync_TextChanged);
            this.tb_sync.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sync_KeyDown);
            this.tb_sync.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sync_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "SYNC:";
            // 
            // btn_gen_ser
            // 
            this.btn_gen_ser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gen_ser.Location = new System.Drawing.Point(332, 48);
            this.btn_gen_ser.Name = "btn_gen_ser";
            this.btn_gen_ser.Size = new System.Drawing.Size(75, 23);
            this.btn_gen_ser.TabIndex = 6;
            this.btn_gen_ser.Text = "Generate";
            this.btn_gen_ser.UseVisualStyleBackColor = true;
            this.btn_gen_ser.Click += new System.EventHandler(this.btn_gen_ser_Click);
            // 
            // tb_ser
            // 
            this.tb_ser.Location = new System.Drawing.Point(82, 50);
            this.tb_ser.MaxLength = 8;
            this.tb_ser.Name = "tb_ser";
            this.tb_ser.Size = new System.Drawing.Size(101, 20);
            this.tb_ser.TabIndex = 7;
            this.tb_ser.Text = "FFFFFFFF";
            this.tb_ser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ser.TextChanged += new System.EventHandler(this.tb_ser_TextChanged);
            this.tb_ser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ser_KeyDown);
            this.tb_ser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ser_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SER:";
            // 
            // btn_gen_key
            // 
            this.btn_gen_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_gen_key.Location = new System.Drawing.Point(332, 22);
            this.btn_gen_key.Name = "btn_gen_key";
            this.btn_gen_key.Size = new System.Drawing.Size(75, 23);
            this.btn_gen_key.TabIndex = 4;
            this.btn_gen_key.Text = "Generate";
            this.btn_gen_key.UseVisualStyleBackColor = true;
            this.btn_gen_key.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "KEY:";
            // 
            // tb_key
            // 
            this.tb_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_key.Location = new System.Drawing.Point(82, 23);
            this.tb_key.MaxLength = 16;
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(236, 20);
            this.tb_key.TabIndex = 5;
            this.tb_key.Text = "FFFFFFFFFFFFFFFF";
            this.tb_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_key.TextChanged += new System.EventHandler(this.tb_key_TextChanged);
            this.tb_key.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_key_KeyDown);
            this.tb_key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_key_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_connect);
            this.groupBox2.Controls.Add(this.btn_update_port);
            this.groupBox2.Controls.Add(this.cb_port);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 78);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(7, 48);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(150, 23);
            this.btn_connect.TabIndex = 2;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_update_port
            // 
            this.btn_update_port.Location = new System.Drawing.Point(95, 19);
            this.btn_update_port.Name = "btn_update_port";
            this.btn_update_port.Size = new System.Drawing.Size(63, 23);
            this.btn_update_port.TabIndex = 1;
            this.btn_update_port.Text = "Refresh";
            this.btn_update_port.UseVisualStyleBackColor = true;
            this.btn_update_port.Click += new System.EventHandler(this.btn_update_port_Click);
            // 
            // cb_port
            // 
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(7, 20);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(82, 21);
            this.cb_port.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sERToolStripMenuItem,
            this.discriminationToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // sERToolStripMenuItem
            // 
            this.sERToolStripMenuItem.Name = "sERToolStripMenuItem";
            this.sERToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sERToolStripMenuItem.Text = "SER++ if Done!";
            this.sERToolStripMenuItem.Click += new System.EventHandler(this.sERToolStripMenuItem_Click);
            // 
            // discriminationToolStripMenuItem
            // 
            this.discriminationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitToolStripMenuItem,
            this.bitToolStripMenuItem1});
            this.discriminationToolStripMenuItem.Name = "discriminationToolStripMenuItem";
            this.discriminationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.discriminationToolStripMenuItem.Text = "Discrimination Crop";
            // 
            // bitToolStripMenuItem
            // 
            this.bitToolStripMenuItem.Name = "bitToolStripMenuItem";
            this.bitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bitToolStripMenuItem.Text = "8 Bit";
            this.bitToolStripMenuItem.Click += new System.EventHandler(this.bitToolStripMenuItem_Click);
            // 
            // bitToolStripMenuItem1
            // 
            this.bitToolStripMenuItem1.Checked = true;
            this.bitToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bitToolStripMenuItem1.Name = "bitToolStripMenuItem1";
            this.bitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.bitToolStripMenuItem1.Text = "10 Bit";
            this.bitToolStripMenuItem1.Click += new System.EventHandler(this.bitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportProblemToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.contaToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // reportProblemToolStripMenuItem
            // 
            this.reportProblemToolStripMenuItem.Name = "reportProblemToolStripMenuItem";
            this.reportProblemToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reportProblemToolStripMenuItem.Text = "Report Problem";
            this.reportProblemToolStripMenuItem.Click += new System.EventHandler(this.reportProblemToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // contaToolStripMenuItem
            // 
            this.contaToolStripMenuItem.Name = "contaToolStripMenuItem";
            this.contaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.contaToolStripMenuItem.Text = "Contact";
            this.contaToolStripMenuItem.Click += new System.EventHandler(this.contaToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // serial_port
            // 
            this.serial_port.ReadBufferSize = 256;
            this.serial_port.ReadTimeout = 1000;
            this.serial_port.WriteBufferSize = 256;
            this.serial_port.WriteTimeout = 1000;
            this.serial_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_port_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(590, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(590, 327);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_br);
            this.groupBox5.Location = new System.Drawing.Point(3, 154);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 50);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Baud Rate";
            // 
            // cb_br
            // 
            this.cb_br.FormattingEnabled = true;
            this.cb_br.Items.AddRange(new object[] {
            "00 400uS ALL",
            "01 200uS 1/2",
            "10 100uS 1/2",
            "11 100uS  1/4"});
            this.cb_br.Location = new System.Drawing.Point(6, 20);
            this.cb_br.Name = "cb_br";
            this.cb_br.Size = new System.Drawing.Size(152, 21);
            this.cb_br.TabIndex = 15;
            this.cb_br.SelectedIndexChanged += new System.EventHandler(this.cb_br_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_6v);
            this.groupBox4.Controls.Add(this.rb_9or12v);
            this.groupBox4.Location = new System.Drawing.Point(3, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 63);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "VDD";
            // 
            // rb_6v
            // 
            this.rb_6v.AutoSize = true;
            this.rb_6v.Location = new System.Drawing.Point(7, 39);
            this.rb_6v.Name = "rb_6v";
            this.rb_6v.Size = new System.Drawing.Size(41, 17);
            this.rb_6v.TabIndex = 14;
            this.rb_6v.Text = "6 V";
            this.rb_6v.UseVisualStyleBackColor = true;
            this.rb_6v.CheckedChanged += new System.EventHandler(this.rb_6v_CheckedChanged);
            // 
            // rb_9or12v
            // 
            this.rb_9or12v.AutoSize = true;
            this.rb_9or12v.Checked = true;
            this.rb_9or12v.Location = new System.Drawing.Point(7, 18);
            this.rb_9or12v.Name = "rb_9or12v";
            this.rb_9or12v.Size = new System.Drawing.Size(65, 17);
            this.rb_9or12v.TabIndex = 14;
            this.rb_9or12v.TabStop = true;
            this.rb_9or12v.Text = "9 or12 V";
            this.rb_9or12v.UseVisualStyleBackColor = true;
            this.rb_9or12v.CheckedChanged += new System.EventHandler(this.rb_9or12v_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rtb);
            this.groupBox3.Location = new System.Drawing.Point(3, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 109);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // rtb
            // 
            this.rtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb.Location = new System.Drawing.Point(6, 14);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(572, 88);
            this.rtb.TabIndex = 17;
            this.rtb.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 379);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(606, 418);
            this.Name = "Form1";
            this.Text = "HCS301 Programmer V0.3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.IO.Ports.SerialPort serial_port;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_update_port;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Button btn_gen_key;
        private System.Windows.Forms.TextBox tb_ser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_gen_ser;
        private System.Windows.Forms.TextBox tb_sync;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_seed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_ovr_set;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb_6v;
        private System.Windows.Forms.RadioButton rb_9or12v;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cb_br;
        private System.Windows.Forms.CheckBox cb_dis_auto;
        private System.Windows.Forms.TextBox tb_dis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_timer;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportProblemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discriminationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitToolStripMenuItem1;
    }
}

