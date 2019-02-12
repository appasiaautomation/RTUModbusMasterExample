namespace RTUModbusMasterExample
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.txtSlaveId = new System.Windows.Forms.TextBox();
            this.txtBraudRate = new System.Windows.Forms.TextBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.btnReadDiscreateInputs = new System.Windows.Forms.Button();
            this.btnReadHoldingRegisters = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnWriteSingleCoil = new System.Windows.Forms.Button();
            this.btnWriteSingleRegister = new System.Windows.Forms.Button();
            this.btnWriteMultipleCoils = new System.Windows.Forms.Button();
            this.btnWriteMultipleRegisters = new System.Windows.Forms.Button();
            this.lstReadDataFromServer = new System.Windows.Forms.ListBox();
            this.lstWriteDataToServer = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtCheckConnect = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtStartAddress1 = new System.Windows.Forms.TextBox();
            this.btnClearEntry = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnPrepareCoils = new System.Windows.Forms.Button();
            this.btnPrepareRegisters = new System.Windows.Forms.Button();
            this.txtPrepareCoils = new System.Windows.Forms.TextBox();
            this.txtPrepareRegisters = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Lime;
            this.btnConnect.Location = new System.Drawing.Point(659, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 37);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Red;
            this.btnDisconnect.Location = new System.Drawing.Point(757, 23);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 37);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM-Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slave Id";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Braud-Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pariy ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "StopBits";
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cmbComPort.Location = new System.Drawing.Point(-2, 25);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(121, 21);
            this.cmbComPort.TabIndex = 7;
            // 
            // txtSlaveId
            // 
            this.txtSlaveId.Location = new System.Drawing.Point(161, 32);
            this.txtSlaveId.Name = "txtSlaveId";
            this.txtSlaveId.Size = new System.Drawing.Size(100, 20);
            this.txtSlaveId.TabIndex = 8;
            // 
            // txtBraudRate
            // 
            this.txtBraudRate.Location = new System.Drawing.Point(278, 32);
            this.txtBraudRate.Name = "txtBraudRate";
            this.txtBraudRate.Size = new System.Drawing.Size(100, 20);
            this.txtBraudRate.TabIndex = 9;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(393, 31);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(100, 21);
            this.cmbParity.TabIndex = 10;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbStopBits.Location = new System.Drawing.Point(525, 31);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(100, 21);
            this.cmbStopBits.TabIndex = 11;
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(-2, 84);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(167, 23);
            this.btnReadCoils.TabIndex = 12;
            this.btnReadCoils.Text = "Read Coils-FC1";
            this.btnReadCoils.UseVisualStyleBackColor = true;
            this.btnReadCoils.Click += new System.EventHandler(this.btnReadCoils_Click);
            // 
            // btnReadDiscreateInputs
            // 
            this.btnReadDiscreateInputs.Location = new System.Drawing.Point(-2, 113);
            this.btnReadDiscreateInputs.Name = "btnReadDiscreateInputs";
            this.btnReadDiscreateInputs.Size = new System.Drawing.Size(167, 23);
            this.btnReadDiscreateInputs.TabIndex = 13;
            this.btnReadDiscreateInputs.Text = "Read Discreate Inputs-FC2";
            this.btnReadDiscreateInputs.UseVisualStyleBackColor = true;
            // 
            // btnReadHoldingRegisters
            // 
            this.btnReadHoldingRegisters.Location = new System.Drawing.Point(-2, 142);
            this.btnReadHoldingRegisters.Name = "btnReadHoldingRegisters";
            this.btnReadHoldingRegisters.Size = new System.Drawing.Size(167, 23);
            this.btnReadHoldingRegisters.TabIndex = 14;
            this.btnReadHoldingRegisters.Text = "Read Holding Registers-FC3";
            this.btnReadHoldingRegisters.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(-2, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Read Input Registers-FC4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnWriteSingleCoil
            // 
            this.btnWriteSingleCoil.Location = new System.Drawing.Point(-2, 233);
            this.btnWriteSingleCoil.Name = "btnWriteSingleCoil";
            this.btnWriteSingleCoil.Size = new System.Drawing.Size(167, 23);
            this.btnWriteSingleCoil.TabIndex = 16;
            this.btnWriteSingleCoil.Text = "Write Single Coil-FC5";
            this.btnWriteSingleCoil.UseVisualStyleBackColor = true;
            // 
            // btnWriteSingleRegister
            // 
            this.btnWriteSingleRegister.Location = new System.Drawing.Point(-2, 269);
            this.btnWriteSingleRegister.Name = "btnWriteSingleRegister";
            this.btnWriteSingleRegister.Size = new System.Drawing.Size(167, 23);
            this.btnWriteSingleRegister.TabIndex = 17;
            this.btnWriteSingleRegister.Text = "Write Single Register-FC6";
            this.btnWriteSingleRegister.UseVisualStyleBackColor = true;
            // 
            // btnWriteMultipleCoils
            // 
            this.btnWriteMultipleCoils.Location = new System.Drawing.Point(-2, 298);
            this.btnWriteMultipleCoils.Name = "btnWriteMultipleCoils";
            this.btnWriteMultipleCoils.Size = new System.Drawing.Size(167, 23);
            this.btnWriteMultipleCoils.TabIndex = 18;
            this.btnWriteMultipleCoils.Text = "Write Multiple Coils-FC15";
            this.btnWriteMultipleCoils.UseVisualStyleBackColor = true;
            // 
            // btnWriteMultipleRegisters
            // 
            this.btnWriteMultipleRegisters.Location = new System.Drawing.Point(-2, 327);
            this.btnWriteMultipleRegisters.Name = "btnWriteMultipleRegisters";
            this.btnWriteMultipleRegisters.Size = new System.Drawing.Size(167, 23);
            this.btnWriteMultipleRegisters.TabIndex = 19;
            this.btnWriteMultipleRegisters.Text = "Write Multiple Registers-FC16";
            this.btnWriteMultipleRegisters.UseVisualStyleBackColor = true;
            // 
            // lstReadDataFromServer
            // 
            this.lstReadDataFromServer.FormattingEnabled = true;
            this.lstReadDataFromServer.Location = new System.Drawing.Point(335, 76);
            this.lstReadDataFromServer.Name = "lstReadDataFromServer";
            this.lstReadDataFromServer.Size = new System.Drawing.Size(222, 121);
            this.lstReadDataFromServer.TabIndex = 20;
            // 
            // lstWriteDataToServer
            // 
            this.lstWriteDataToServer.FormattingEnabled = true;
            this.lstWriteDataToServer.Location = new System.Drawing.Point(335, 207);
            this.lstWriteDataToServer.Name = "lstWriteDataToServer";
            this.lstWriteDataToServer.Size = new System.Drawing.Size(222, 147);
            this.lstWriteDataToServer.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Read Data From Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Write Data To Server";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 356);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(907, 132);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = "";
            // 
            // txtCheckConnect
            // 
            this.txtCheckConnect.BackColor = System.Drawing.Color.Red;
            this.txtCheckConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckConnect.Location = new System.Drawing.Point(-2, 485);
            this.txtCheckConnect.Name = "txtCheckConnect";
            this.txtCheckConnect.Size = new System.Drawing.Size(913, 31);
            this.txtCheckConnect.TabIndex = 25;
            this.txtCheckConnect.Text = "NOt Connected To server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Start Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(213, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Start Address";
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(207, 115);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(100, 20);
            this.txtStartAddress.TabIndex = 29;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(207, 174);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(100, 20);
            this.txtSize.TabIndex = 30;
            // 
            // txtStartAddress1
            // 
            this.txtStartAddress1.Location = new System.Drawing.Point(196, 271);
            this.txtStartAddress1.Name = "txtStartAddress1";
            this.txtStartAddress1.Size = new System.Drawing.Size(100, 20);
            this.txtStartAddress1.TabIndex = 31;
            // 
            // btnClearEntry
            // 
            this.btnClearEntry.Location = new System.Drawing.Point(606, 200);
            this.btnClearEntry.Name = "btnClearEntry";
            this.btnClearEntry.Size = new System.Drawing.Size(75, 41);
            this.btnClearEntry.TabIndex = 32;
            this.btnClearEntry.Text = "Clear Entry";
            this.btnClearEntry.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(745, 199);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 42);
            this.btnClearAll.TabIndex = 33;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // btnPrepareCoils
            // 
            this.btnPrepareCoils.Location = new System.Drawing.Point(606, 312);
            this.btnPrepareCoils.Name = "btnPrepareCoils";
            this.btnPrepareCoils.Size = new System.Drawing.Size(112, 23);
            this.btnPrepareCoils.TabIndex = 34;
            this.btnPrepareCoils.Text = "Prepare Coils";
            this.btnPrepareCoils.UseVisualStyleBackColor = true;
            // 
            // btnPrepareRegisters
            // 
            this.btnPrepareRegisters.Location = new System.Drawing.Point(757, 312);
            this.btnPrepareRegisters.Name = "btnPrepareRegisters";
            this.btnPrepareRegisters.Size = new System.Drawing.Size(105, 23);
            this.btnPrepareRegisters.TabIndex = 35;
            this.btnPrepareRegisters.Text = "Prepare Registers";
            this.btnPrepareRegisters.UseVisualStyleBackColor = true;
            // 
            // txtPrepareCoils
            // 
            this.txtPrepareCoils.Location = new System.Drawing.Point(606, 271);
            this.txtPrepareCoils.Name = "txtPrepareCoils";
            this.txtPrepareCoils.Size = new System.Drawing.Size(100, 20);
            this.txtPrepareCoils.TabIndex = 36;
            // 
            // txtPrepareRegisters
            // 
            this.txtPrepareRegisters.Location = new System.Drawing.Point(757, 269);
            this.txtPrepareRegisters.Name = "txtPrepareRegisters";
            this.txtPrepareRegisters.Size = new System.Drawing.Size(100, 20);
            this.txtPrepareRegisters.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(919, 517);
            this.Controls.Add(this.txtPrepareRegisters);
            this.Controls.Add(this.txtPrepareCoils);
            this.Controls.Add(this.btnPrepareRegisters);
            this.Controls.Add(this.btnPrepareCoils);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearEntry);
            this.Controls.Add(this.txtStartAddress1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtStartAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCheckConnect);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstWriteDataToServer);
            this.Controls.Add(this.lstReadDataFromServer);
            this.Controls.Add(this.btnWriteMultipleRegisters);
            this.Controls.Add(this.btnWriteMultipleCoils);
            this.Controls.Add(this.btnWriteSingleRegister);
            this.Controls.Add(this.btnWriteSingleCoil);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnReadHoldingRegisters);
            this.Controls.Add(this.btnReadDiscreateInputs);
            this.Controls.Add(this.btnReadCoils);
            this.Controls.Add(this.cmbStopBits);
            this.Controls.Add(this.cmbParity);
            this.Controls.Add(this.txtBraudRate);
            this.Controls.Add(this.txtSlaveId);
            this.Controls.Add(this.cmbComPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.TextBox txtSlaveId;
        private System.Windows.Forms.TextBox txtBraudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.Button btnReadDiscreateInputs;
        private System.Windows.Forms.Button btnReadHoldingRegisters;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnWriteSingleCoil;
        private System.Windows.Forms.Button btnWriteSingleRegister;
        private System.Windows.Forms.Button btnWriteMultipleCoils;
        private System.Windows.Forms.Button btnWriteMultipleRegisters;
        private System.Windows.Forms.ListBox lstReadDataFromServer;
        private System.Windows.Forms.ListBox lstWriteDataToServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtCheckConnect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtStartAddress1;
        private System.Windows.Forms.Button btnClearEntry;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnPrepareCoils;
        private System.Windows.Forms.Button btnPrepareRegisters;
        private System.Windows.Forms.TextBox txtPrepareCoils;
        private System.Windows.Forms.TextBox txtPrepareRegisters;
    }
}

