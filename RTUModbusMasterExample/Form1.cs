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
        int dataBits = 8;
        bool connected = false;
        string handshake;

        private byte functionCode;
        private byte SlaveId;
        private byte[] startingAddress;
        private byte[] quantity;
        private byte[] crc = new byte[2];

        private byte[] data;
        private byte[] sendData;
        private byte[] receiveData;

        

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

        public static UInt16 calculateCRC(byte[] data, UInt16 numberOfBytes)
        {
            ushort Polynominal = 0x1021;
            ushort InitValue = 0x0;

            ushort i, j, index = 0;
            ushort CRC = InitValue;
            ushort Remainder, tmp, short_c;
            for (i = 0; i < numberOfBytes; i++)
            {
                short_c = (ushort)(0x00ff & (ushort)data[index]);
                tmp = (ushort)((CRC >> 8) ^ short_c);
                Remainder = (ushort)(tmp << 8);
                for (j = 0; j < 8; j++)
                {

                    if ((Remainder & 0x8000) != 0)
                    {
                        Remainder = (ushort)((Remainder << 1) ^ Polynominal);
                    }
                    else
                    {
                        Remainder = (ushort)(Remainder << 1);
                    }
                }

                CRC = (ushort)((CRC << 8) ^ Remainder);
                index++;
            }
            return CRC;

        }
        public bool[] ReadDiscreateInputs(int startAddress, int quantity)
        {
                 bool[] response;
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
                crc = BitConverter.GetBytes(calculateCRC(data, length));
                data[6] = this.crc[0];
                data[7] = this.crc[1];
                serialPort.Write(data, 0, data.Length);
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

        bool[] ReadCoils(int startAddress,int quantity)
        {
            bool[] response;
            this.functionCode = 0x01;
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
            crc = BitConverter.GetBytes(calculateCRC(data, length));
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
            crc = BitConverter.GetBytes(calculateCRC(data, length));
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
            crc = BitConverter.GetBytes(calculateCRC(data, length));
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
        public void writeSingleRegister()
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Address Ans Size");
            }
            else
            {
                try
                {
                    int startaddress = Int32.Parse(txtStartAddress1.Text) - 1;
                    int value = Int16.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[0]));
                    byte[] RegisterValue = new byte[2];

                    this.SlaveId = 0x01;

                    this.functionCode = 0x06;
                    this.startingAddress = BitConverter.GetBytes(startaddress);

                    RegisterValue = BitConverter.GetBytes((int)value);

                    byte[] data = new byte[] 
                { 
                this.SlaveId,

                this.functionCode,
                this.startingAddress[1],
                this.startingAddress[0],
               RegisterValue[1],
							RegisterValue[0],
                 this.crc[0],
                this.crc[1]
           
                 };

                    ushort length = (ushort)data.Length;
                    crc = BitConverter.GetBytes(calculateCRC(data, length));
                    data[6] = this.crc[0];
                    data[7] = this.crc[1];

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
                bool[] response = ReadDiscreateInputs(Int32.Parse(txtStartAddress.Text),Int32.Parse(txtSize.Text));

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
                    serialPort.Handshake = Handshake.None;
                    serialPort.ReadTimeout = 500;
                    serialPort.WriteTimeout = 500;

                    serialPort.Open();
                    connected = true;
                    MessageBox.Show("COM-Port Connected");
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
                    byte byteCount = (byte)(values.Length * (sizeof(Int32) / 8));
                    byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);

                 
               
               
                    this.functionCode = 0x10;
                    this.startingAddress = BitConverter.GetBytes(startAddress);
                    Byte[] data = new byte[7 + 2 + values.Length * (sizeof(Int16) / 8)];
                data[0]=this.SlaveId;

                    data[1] = this.functionCode;
                    data[2] = this.startingAddress[1];
                    data[3] = this.startingAddress[0];
                    data[4] = quantityOfOutputs[1];
                    data[5] = quantityOfOutputs[0];
                    data[6] = byteCount;

                    for (int i = 0; i < values.Length; i++)
                    {
                        byte[] singleRegisterValue = BitConverter.GetBytes((int)values[i]);
                        data[7 + i * (sizeof(Int16) / 8)] = singleRegisterValue[1];
                        data[7 + i * (sizeof(Int16) / 8)] = singleRegisterValue[0];
                    }


                    serialPort.Write(data, 0, data.Length);
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message);

                }
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
              bool[] response = ReadCoils(Int32.Parse(txtStartAddress.Text), Int32.Parse(txtSize.Text));

              for (int i = 0; i < response.Length; i++)
              {
                  lstReadDataFromServer.Items.Add(response[i]);
              }
          }
          catch(Exception ioe)
          {
              MessageBox.Show(""+ioe.Message);
          }
      }

      private void btnDisconnect_Click_1(object sender, EventArgs e)
      {

          disConnect();
          if (!connected)
          {
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
          try
          {
              int[] response = ReadHoldingRegisters(Int32.Parse(txtStartAddress.Text), Int32.Parse(txtSize.Text));

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

      private void btnReadInputRegisters_Click(object sender, EventArgs e)
      {
          try
          {
              int[] response = ReadinputRegisters(Int32.Parse(txtStartAddress.Text), Int32.Parse(txtSize.Text));

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

      public void writeSingleCoil(int startAddress)
      {

         


          if (txtStartAddress1.Text == "")
          {
              MessageBox.Show("Please Enter Start Address");
          }
          else
          {
              try
              {
                  int startaddress = Int32.Parse(txtStartAddress1.Text) - 1;
                  bool value = Boolean.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[0]));
                  byte[] coilValue = new byte[2];
         
               
                
                  this.functionCode = 0x05;
                  this.startingAddress = BitConverter.GetBytes(startaddress);
                  if (value == true)
                  {
                      coilValue = BitConverter.GetBytes((int)0xFF00);
                  }
                  else
                  {
                      coilValue = BitConverter.GetBytes((int)0x0000);
                  }
                  

                  byte[] data = new byte[] 
                { 
                this.SlaveId,

                this.functionCode,
            
							this.startingAddress[1],
							this.startingAddress[0],
							coilValue[1],
							coilValue[0],
                 this.crc[0],
                this.crc[1]
           
                 };
                  serialPort.Write(data, 0, data.Length);
                  lstWriteDataToServer.Items.Clear();
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
               

                  int valuesLength = lstWriteDataToServer.Items.Count;
                  bool[] values = new bool[valuesLength];
                  this.SlaveId = 0x01;
                  for (int i = 0; i < valuesLength; i++)
                  {
                      values[i] = Boolean.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[i]));
                  }
                  byte byteCount = (byte)((values.Length % 8 != 0 ? values.Length / 8 + 1 : (values.Length / 8)));
                  byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);
                  byte singleCoilValue = 0;



                  this.functionCode = 0x0F;
                  this.startingAddress = BitConverter.GetBytes(startAddress);



                  Byte[] data = new byte[14 + 2 + (values.Length % 8 != 0 ? values.Length / 8 : (values.Length / 8) - 1)];
                  data[0] = this.SlaveId;
                  data[1] = this.functionCode;
                  data[2] = this.startingAddress[1];
                  data[3] = this.startingAddress[0];
                  data[4] = quantityOfOutputs[1];
                  data[5] = quantityOfOutputs[0];
                  data[6] = byteCount;
                  for (int i = 0; i < values.Length; i++)
                  {

                      if ((i % 8) == 0)
                      {
                          singleCoilValue = 0;
                      }
                      byte CoilValue;
                      if (values[i] == true)
                      {
                          CoilValue = 1;
                      }
                      else
                      {
                          CoilValue = 0;
                      }

                      singleCoilValue = (byte)((int)CoilValue << (i % 8) | (int)singleCoilValue);

                      data[ 7+ (i / 8)] = singleCoilValue;
                  }
                  serialPort.Write(data, 0, data.Length);
                  lstWriteDataToServer.Items.Clear();
              }
              catch (Exception e)
              {
                  MessageBox.Show("" + e.Message);
              }
          }

      }
     

      private void btnWriteSingleCoil_Click(object sender, EventArgs e)
      {
          writeSingleCoil(Int32.Parse(txtStartAddress1.Text)-1);

      }

      private void btnPrepareCoils_Click(object sender, EventArgs e)
      {
          lstWriteDataToServer.Items.Add(txtPrepareCoils.Text);
      }

      private void btnPrepareRegisters_Click(object sender, EventArgs e)
      {
       
          lstWriteDataToServer.Items.Add(txtPrepareRegisters.Text);
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

      }

      private void btnWriteMultipleCoils_Click(object sender, EventArgs e)
      {
          writeMultipleCoils(Int32.Parse(txtStartAddress1.Text));
      }

      private void btnWriteMultipleRegisters_Click(object sender, EventArgs e)
      {
          writeMultipleRegisters(Int32.Parse(txtStartAddress1.Text));
      }
    
    
        
     
        
       
        
    }
}
