using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;



namespace RTUModbusMasterExample
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        string portName;
        int baudRate;
        Parity parity;
        StopBits stopBits;
       
        bool connected = false;
     

       private byte [] transactionIdentifier = new byte[2];
		private byte [] protocolIdentifier = new byte[2];
        private byte[] crc = new byte[2];
		private byte [] length = new byte[2];
		private byte unitIdentifier = 0x01;
		private byte functionCode;
        private byte[] startingAddress = new byte[2];
        private uint transactionIdentifierInternal = 0;

        private byte[] quantity = new byte[2];
        private byte SlaveId = 0x01;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            btnClearAll.Enabled = false;
            btnClearEntry.Enabled = false;
            btnDisconnect.Enabled = false;
            btnPrepareCoils.Enabled = false;
            btnPrepareRegisters.Enabled = false;
            btnReadCoils.Enabled = false;
            btnReadDiscreateInputs.Enabled = false;
            btnReadHoldingRegisters.Enabled = false;
            btnWriteMultipleCoils.Enabled = false;
            btnWriteMultipleRegisters.Enabled = false;
            btnWriteSingleCoil.Enabled = false;
            btnWriteSingleRegister.Enabled = false;
            txtPrepareCoils.Enabled = false;
            txtPrepareRegisters.Enabled = false;
            txtSize.Enabled = false;
            txtStartAddress.Enabled = false;
            txtStartAddress1.Enabled = false;
            btnReadInputRegisters.Enabled = false;
            lstReadDataFromServer.Enabled = false;
            lstWriteDataToServer.Enabled = false;
            btnDisconnect.Enabled = false;

        
        }

       
          public static UInt16 calculateCRC(byte[] data, UInt16 numberOfBytes, int startByte)
        { 
            byte[] auchCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40
            };
		
            byte[] auchCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
            0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
            0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
            0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
            0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
            0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
            0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
            0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
            0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
            0x40
            };
            UInt16 usDataLen = numberOfBytes;
            byte  uchCRCHi = 0xFF ; 
            byte uchCRCLo = 0xFF ; 
            int i = 0;
            int uIndex ;
            while (usDataLen>0) 
            {
                usDataLen--;
                if ((i + startByte) < data.Length)
                {
                    uIndex = uchCRCLo ^ data[i + startByte];
                    uchCRCLo = (byte)(uchCRCHi ^ auchCRCHi[uIndex]);
                    uchCRCHi = auchCRCLo[uIndex];
                }
                i++;
            }
            return (UInt16)((UInt16)uchCRCHi << 8 | uchCRCLo);   
        }
       public void ReadCoils(int startAddress, int quantity)
          {
 
       

              this.startingAddress = BitConverter.GetBytes(startAddress);
              this.quantity = BitConverter.GetBytes(quantity);
    
              this.functionCode = 0x01;
              this.startingAddress = BitConverter.GetBytes(startAddress);
              this.quantity = BitConverter.GetBytes(quantity);



              byte[] data = new byte[] 
                { 
              this.unitIdentifier,

                this.functionCode,
                this.startingAddress[1],
                this.startingAddress[0],
                 this.quantity[1],

                this.quantity[0],
                 this.crc[0],
                this.crc[1]
           
                 };
         

              crc = BitConverter.GetBytes(calculateCRC(data, 0, 6));
              data[6] = this.crc[0];
              data[7] = this.crc[1];
              serialPort.Write(data, 0, 8);
              
              
                
        
            
          }
        public bool[] ReadDiscreateInputs(int startAddress, int quantity)
          {
              bool[] response;
              this.transactionIdentifier = BitConverter.GetBytes((uint)transactionIdentifierInternal);
              this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
              this.length = BitConverter.GetBytes((int)0x0006);
              this.functionCode = 0x02;
              this.startingAddress = BitConverter.GetBytes(startAddress);
              this.quantity = BitConverter.GetBytes(quantity);
              Byte[] data = new byte[]
                            {	
                            this.transactionIdentifier[1],
							this.transactionIdentifier[0],
							this.protocolIdentifier[1],
							this.protocolIdentifier[0],
							this.length[1],
							this.length[0],
							this.unitIdentifier,
							this.functionCode,
							this.startingAddress[1],
							this.startingAddress[0],
							this.quantity[1],
							this.quantity[0],
                            this.crc[0],
                            this.crc[1]
                            };
              crc = BitConverter.GetBytes(calculateCRC(data, 6, 6));
              data[12] = crc[0];
              data[13] = crc[1];
            try
                {
                    data = new Byte[2100];
                    int NumberOfBytes = serialPort.Read(data, 0, data.Length);
                }
            catch(Exception E)
                {
                    MessageBox.Show(""+E.Message);
            }
                response = new bool[quantity];
                for (int i = 0; i < quantity; i++)
                {
                    int intData = data[9 + i / 8];
                    int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
                    response[i] = Convert.ToBoolean((intData & mask) / mask);
                }
                return (response);
                
            }

      
        public int[] ReadHoldingRegisters(int startAddress, int quantity)
        {
            int[] response;
            this.functionCode = 0x02;
            this.startingAddress = BitConverter.GetBytes(startAddress);
            this.quantity = BitConverter.GetBytes(quantity);
            this.SlaveId = 0x01;


            byte[] data = new byte[] 
                { 
                this.SlaveId,

                this.functionCode,
                this.startingAddress[1],
                this.startingAddress[0],
                 this.quantity[1],

                this.quantity[0],
                 this.crc[0],
                this.crc[1]
           
                 };
            ushort length = (ushort)data.Length;
            crc = BitConverter.GetBytes(calculateCRC(data, 0,6));
            data[6] = this.crc[0];
            data[7] = this.crc[1];
            serialPort.Write(data, 0, data.Length);
            try
            {
                data = new Byte[2100];
                int NumberOfBytes = serialPort.Read(data, 0, data.Length);
            }
            catch (Exception E)
            {
                MessageBox.Show("" + E.Message);
            }
            response = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                byte lowByte;
                byte highByte;
                highByte = data[9 + i * 2];
                lowByte = data[9 + i * 2 + 1];

                data[9 + i * 2] = lowByte;
                data[9 + i * 2 + 1] = highByte;

                response[i] = BitConverter.ToInt16(data, (9 + i * 2));

            }
            return (response);
        }


        public int[] ReadinputRegisters(int startAddress, int quantity)
        {
            int[] response;
            this.functionCode = 0x03;
            this.startingAddress = BitConverter.GetBytes(startAddress);
            this.quantity = BitConverter.GetBytes(quantity);
            this.SlaveId = 0x01;


            byte[] data = new byte[] 
                { 
                this.SlaveId,

                this.functionCode,
                this.startingAddress[1],
                this.startingAddress[0],
                 this.quantity[1],

                this.quantity[0],
                 this.crc[0],
                this.crc[1]
           
                 };
            ushort length = (ushort)data.Length;
            crc = BitConverter.GetBytes(calculateCRC(data, 0,6));
            data[6] = this.crc[0];
            data[7] = this.crc[1];
            serialPort.Write(data, 0, data.Length);
            try
            {
                data = new Byte[2100];
                int NumberOfBytes = serialPort.Read(data, 0, data.Length);
            }
            catch (Exception E)
            {
                MessageBox.Show("" + E.Message);
            }
            response = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                byte lowByte;
                byte highByte;
                highByte = data[9 + i * 2];
                lowByte = data[9 + i * 2 + 1];

                data[9 + i * 2] = lowByte;
                data[9 + i * 2 + 1] = highByte;

                response[i] = BitConverter.ToInt16(data, (9 + i * 2));

            }
            return (response);
        }
        public void writeSingleCoil(int startAddress)
        {


            bool value = true;

            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Address");
            }
            else
            {
                try
                {
                    byte[] coilValue = new byte[2];
                    this.transactionIdentifier = BitConverter.GetBytes((uint)transactionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                    this.length = BitConverter.GetBytes((int)0x0006);
                    this.functionCode = 0x05;
                    this.startingAddress = BitConverter.GetBytes(startAddress);
                    if (value == true)
                    {
                        coilValue = BitConverter.GetBytes((int)0xFF00);
                    }
                    else
                    {
                        coilValue = BitConverter.GetBytes((int)0x0000);
                    }
                    Byte[] data = new byte[]{	
						
							
							
							
							this.unitIdentifier,
							this.functionCode,
							this.startingAddress[1],
							this.startingAddress[0],
							coilValue[1],
							coilValue[0],
                            this.crc[0],
                            this.crc[1]    
                            };
                    crc = BitConverter.GetBytes(calculateCRC(data, 6, 0));
                    data[6] = crc[0];
                    data[7] = crc[1];
                    serialPort.Write(data, 0, 8);
                    lstWriteDataToServer.Items.Clear();
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message);
                }
            }


        }

        public void writeSingleRegister(int startAddress)
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Address Ans Size");
            }
            else
            {
                try
                {


                    byte[] registerValue = new byte[2];
                    int value = Int16.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[0]));
                 
                  
           
                    this.functionCode = 0x06;
                    this.startingAddress = BitConverter.GetBytes(startAddress);
                    registerValue = BitConverter.GetBytes((int)value);

                    Byte[] data = new byte[]{	
							this.unitIdentifier,
							this.functionCode,
							this.startingAddress[1],
							this.startingAddress[0],
							registerValue[1],
							registerValue[0],
                            this.crc[0],
                            this.crc[1]    
                            };
                    crc = BitConverter.GetBytes(calculateCRC(data,6,0));
                    data[6] = crc[0];
                    data[7] = crc[1];
                    serialPort.Write(data, 0, 8);
                }

                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message);
                }
            }
        }
        public void writeMultipleCoils(int startAddress)
        {




            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Address");
            }
            else
            {
                try
                {

                    bool[] values;
                    int m = lstWriteDataToServer.Items.Count;
                    values = new bool[m];
                    for (int i = 0; i < m; i++)
                    {
                        values[i] = Convert.ToBoolean(lstWriteDataToServer.Items[i]);
                    }

                    byte byteCount = (byte)((values.Length % 8 != 0 ? values.Length / 8 + 1 : (values.Length / 8)));
                    byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);
                    byte singleCoilValue = 0;



                    this.functionCode = 0x0F;
                    this.startingAddress = BitConverter.GetBytes(startAddress);



                    Byte[] data = new byte[8 + 2 + (values.Length % 8 != 0 ? values.Length / 8 : (values.Length / 8) - 1)];

                    data[0] = this.unitIdentifier;
                    data[1] = this.functionCode;
                    data[2] = this.startingAddress[1];
                    data[3] = this.startingAddress[0];
                    data[4] = quantityOfOutputs[1];
                    data[5] = quantityOfOutputs[0];
                    data[6] = byteCount;
                    for (int i = 0; i < values.Length; i++)
                    {
                        if ((i % 8) == 0)
                            singleCoilValue = 0;
                        byte CoilValue;
                        if (values[i] == true)
                            CoilValue = 1;
                        else
                            CoilValue = 0;


                        singleCoilValue = (byte)((int)CoilValue << (i % 8) | (int)singleCoilValue);

                        data[7 + (i / 8)] = singleCoilValue;
                    }
                    crc = BitConverter.GetBytes(calculateCRC(data, (ushort)(data.Length - 2), 0));
                    data[data.Length - 2] = crc[0];
                    data[data.Length - 1] = crc[1];
                    serialPort.Write(data, 0, data.Length);
                    lstWriteDataToServer.Items.Clear();
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message);
                }
            }

        }

        public void writeMultipleRegisters(int startAddress)
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Adress");
            }
            else
            {
                try
                {


                    int valuesLength = lstWriteDataToServer.Items.Count;
                    int[] values = new int[valuesLength];
                    for (int i = 0; i < valuesLength; i++)
                    {
                        values[i] = Int16.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[i]));
                    }
                    byte byteCount = (byte)(values.Length * 2);
                    byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);
                    this.transactionIdentifier = BitConverter.GetBytes((uint)transactionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);

                    this.functionCode = 0x10;
                    this.startingAddress = BitConverter.GetBytes(startAddress);

                    Byte[] data = new byte[7 + 2 + values.Length * 2];

                    data[0] = this.unitIdentifier;
                    data[1] = this.functionCode;
                    data[2] = this.startingAddress[1];
                    data[3] = this.startingAddress[0];
                    data[4] = quantityOfOutputs[1];
                    data[5] = quantityOfOutputs[0];
                    data[6] = byteCount;
                    for (int i = 0; i < values.Length; i++)
                    {
                        byte[] singleRegisterValue = BitConverter.GetBytes((int)values[i]);
                        data[7 + i * 2] = singleRegisterValue[1];
                        data[8 + i * 2] = singleRegisterValue[0];
                    }
                    crc = BitConverter.GetBytes(calculateCRC(data, (ushort)(data.Length - 2), 0));
                    data[data.Length - 2] = crc[0];
                    data[data.Length - 1] = crc[1];

                    serialPort.Write(data, 0, data.Length);
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message);

                }
            }
        }
        
    
        private void btnReadDiscreateInputs_Click(object sender, EventArgs e)
        {
           
        
            try
            {
              bool[] response=   ReadDiscreateInputs(Int32.Parse(txtStartAddress.Text)-1,Int32.Parse(txtSize.Text));
                for(int i=0;i<response.Length;i++)
                {
                    lstReadDataFromServer.Items.Add(response[i]);
                }
               
            }
            catch (IOException ioe)
            {
                MessageBox.Show("" + ioe.Message);
            }
  
        
            
        }
        private void Form1_Closing(object sender, EventArgs e)
        {
            if(connected)
            {
                serialPort.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connected)
                {
                    portName = cmbComPort.Text;
                    baudRate = Int32.Parse(txtBraudRate.Text);
                    if (cmbParity.SelectedIndex == 0)
                    {
                        parity = Parity.None;
                    }
                    else if (cmbParity.SelectedIndex == 1)
                    {
                        parity = Parity.Even;
                    }
                    else
                    {
                        parity = Parity.Odd;
                    }

                    if (cmbStopBits.SelectedIndex == 0)
                    {
                        stopBits = StopBits.One;
                    }
                    else if (cmbStopBits.SelectedIndex == 1)
                    {
                        stopBits = StopBits.OnePointFive;
                    }
                    else
                    {
                        stopBits = StopBits.Two;
                    }
                    serialPort = new SerialPort(portName, baudRate, parity, 8, stopBits);
                    //serialPort.Handshake = Handshake.None;
                   // serialPort.ReadTimeout = 2000;
                   // serialPort.WriteTimeout = 2000;

                    serialPort.Open();
                    connected = true;
                    if(serialPort.IsOpen==true)
                    {
                    MessageBox.Show("COM-Port Connected");
                    }
                }
                if (connected)
                {
                    txtCheckConnect.BackColor = System.Drawing.Color.Lime;
                    txtCheckConnect.Text = "Connected To server";

                    btnClearAll.Enabled = true;
                    btnClearEntry.Enabled = true;
                    btnDisconnect.Enabled = true;
                    btnPrepareCoils.Enabled = true;
                    btnPrepareRegisters.Enabled = true;
                    btnReadCoils.Enabled = true;
                    btnReadDiscreateInputs.Enabled = true;
                    btnReadHoldingRegisters.Enabled = true;
                    btnWriteMultipleCoils.Enabled = true;
                    btnWriteMultipleRegisters.Enabled = true;
                    btnWriteSingleCoil.Enabled = true;
                    btnWriteSingleRegister.Enabled = true;
                    txtPrepareCoils.Enabled = true;
                    txtPrepareRegisters.Enabled = true;
                    txtSize.Enabled = true;
                    txtStartAddress.Enabled = true;
                    txtStartAddress1.Enabled = true;
                    btnReadInputRegisters.Enabled = true;
                    lstReadDataFromServer.Enabled = true;
                    lstWriteDataToServer.Enabled = true;

                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;
                    btnConnect.Enabled = false;
                    cmbComPort.Enabled = false;
                    cmbParity.Enabled = false;
                    cmbStopBits.Enabled = false;
                    txtBraudRate.Enabled = false;
                    txtSlaveId.Enabled = false;

                }
            }

            catch(IOException se)
            {
                MessageBox.Show(""+se.Message);
            }

        }




        public void disConnect()
        {
            if (connected)
            {
                serialPort.Close();
                connected = false;
            }
        }

     
     
      private void btnReadCoils_Click(object sender, EventArgs e)
      {

          try
          {
              ReadCoils(Int32.Parse(txtStartAddress.Text) - 1, Int32.Parse(txtSize.Text));

          }
          catch(Exception ee)
          {
              MessageBox.Show(""+ee.Message);
          }
       
        
      }

      private void btnDisconnect_Click_1(object sender, EventArgs e)
      {

          disConnect();
          if (!connected)
          {
              MessageBox.Show("Server Disconnected");
              txtCheckConnect.Text = "Not Connected To Server";
              txtCheckConnect.BackColor = System.Drawing.Color.Red;

              btnClearAll.Enabled = false;
              btnClearEntry.Enabled = false;
              btnDisconnect.Enabled = false;
              btnPrepareCoils.Enabled = false;
              btnPrepareRegisters.Enabled = false;
              btnReadCoils.Enabled = false;
              btnReadDiscreateInputs.Enabled = false;
              btnReadHoldingRegisters.Enabled = false;
              btnWriteMultipleCoils.Enabled = false;
              btnWriteMultipleRegisters.Enabled = false;
              btnWriteSingleCoil.Enabled = false;
              btnWriteSingleRegister.Enabled = false;
              txtPrepareCoils.Enabled = false;
              txtPrepareRegisters.Enabled = false;
              txtSize.Enabled = false;
              txtStartAddress.Enabled = false;
              txtStartAddress1.Enabled = false;
              btnReadInputRegisters.Enabled = false;
              lstReadDataFromServer.Enabled = false;
              lstWriteDataToServer.Enabled = false;
              btnConnect.Enabled = true;
              cmbComPort.Enabled = true;
              cmbParity.Enabled = true;
              cmbStopBits.Enabled = true;
              txtBraudRate.Enabled = true;
              txtSlaveId.Enabled = true;

          }
      }

      private void btnReadHoldingRegisters_Click(object sender, EventArgs e)
      {
          if(txtSize.Text==""||txtStartAddress.Text=="")
          {
              MessageBox.Show("Enter Start Address And Size");
          }
          else
          {
          try
          {
              int[] response = ReadHoldingRegisters(Int32.Parse(txtStartAddress.Text)-1, Int32.Parse(txtSize.Text));

              for (int i = 0; i < response.Length; i++)
              {
                  lstReadDataFromServer.Items.Add(response[i]);
              }
          }
          catch (IOException ioe)
          {
              MessageBox.Show("" + ioe.Message);
          }}
      }

      private void btnReadInputRegisters_Click(object sender, EventArgs e)
      {
          if (txtStartAddress.Text == "" || txtSize.Text == "")
          {
              MessageBox.Show("Enter Start Address and Size");
          }
          else
          {

              try
              {
                  int[] response = ReadinputRegisters(Int32.Parse(txtStartAddress.Text) - 1, Int32.Parse(txtSize.Text));

                  for (int i = 0; i < response.Length; i++)
                  {
                      lstReadDataFromServer.Items.Add(response[i]);
                  }
              }
              catch (IOException ioe)
              {
                  MessageBox.Show("" + ioe.Message);
              }
          }
      }
    
     

      private void btnWriteSingleCoil_Click(object sender, EventArgs e)
      {
          if (txtStartAddress1.Text == "")
          {
              MessageBox.Show("Enter Start Address");
          }
          else if (lstWriteDataToServer.Items.Count == 0)
          {
              MessageBox.Show("Add data to Write");
          }
          else    {
              writeSingleCoil(Int32.Parse(txtStartAddress1.Text)-1);

          }
        

      }

      private void btnPrepareCoils_Click(object sender, EventArgs e)
      {
          if (txtPrepareCoils.Text == "")
          {
              MessageBox.Show("Enter Data To add ");
          }
          else   {

          lstWriteDataToServer.Items.Add(txtPrepareCoils.Text);
          }
      }

      private void btnPrepareRegisters_Click(object sender, EventArgs e)
      {
          if(txtPrepareRegisters.Text=="")
          {
              MessageBox.Show("Enter Data To add");
          }
          else
          {
          lstWriteDataToServer.Items.Add(txtPrepareRegisters.Text);
          }
      }

      private void btnClearEntry_Click(object sender, EventArgs e)
      {

          int rowindex = lstWriteDataToServer.SelectedIndex;
          if (rowindex >= 0)
          {
              lstWriteDataToServer.Items.RemoveAt(rowindex);
          }
      }

      private void btnClearAll_Click(object sender, EventArgs e)
      {
          lstWriteDataToServer.Items.Clear();
      }

      private void btnWriteSingleRegister_Click(object sender, EventArgs e)
      {
         
         
              writeSingleRegister(Int32.Parse(txtStartAddress1.Text)-1);

        
        
      }

      private void btnWriteMultipleCoils_Click(object sender, EventArgs e)
      {

          if (txtStartAddress1.Text == "")
          {
              MessageBox.Show("Enter Start Address");
          }
          else if (lstWriteDataToServer.Items.Count == 0)
          {
              MessageBox.Show("Add data to Write");
          }
          else  {
              writeMultipleCoils(Int32.Parse(txtStartAddress1.Text)-1);
              
          }
        
      }

      private void btnWriteMultipleRegisters_Click(object sender, EventArgs e)
      {
          if (txtStartAddress1.Text == "")
          {
              MessageBox.Show("Enter Start Address");
          }
          else if (lstWriteDataToServer.Items.Count == 0)
          {
              MessageBox.Show("Add data to Write");
          }
          else {
              writeMultipleRegisters(Int32.Parse(txtStartAddress1.Text)-1);
              lstWriteDataToServer.Items.Clear();
          }
      }

      private void lstReadDataFromServer_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
    
         
    }
}
