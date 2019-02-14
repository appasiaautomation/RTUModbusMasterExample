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
        private byte[] crc;
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
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbComPort.Items.Add(port);
            }
        }
        public ReadDiscreateInputs(int startAddress,int quantity)
        {
            bool[] response;
            this.functionCode = 0x02;
            this.startingAddress = BitConverter.GetBytes(startAddress);
            this.quantity = BitConverter.GetBytes(quantity);
            this.SlaveId=0x01;

            byte[] data = new byte[] { 
         this.SlaveId,

    this.functionCode,
       this.startingAddress[1],
            this.startingAddress[0],
          this.quantity[1],

           this.quantity[0],
           
        };
            crc = BitConverter.GetBytes(calculateCRC(data,data.Length));
          
            serialPort.Write(data, 0, data.Length);
            data = new Byte[2100];
          //  int NumberOfBytes = serialPort.Read(data, 0, data.Length);
           // response = new bool[quantity];
           // for (int i = 0; i < quantity; i++)
          //  {
            //    int intData = data[9 + i / 8];
             //   int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
             //   response[i] = Convert.ToBoolean((intData & mask) / mask);
         //   }
        //    return (response);
            
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
                serialPort = new SerialPort(portName, baudRate,parity, 8, stopBits);
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 500;
                serialPort.WriteTimeout = 500;

                serialPort.Open();
                connected = true;
                MessageBox.Show("COM-Port Connected");
            }
            catch(IOException se)
            {
                MessageBox.Show(""+se.Message);
            }

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            disConnect();
        }

        public void disConnect()
        {
            serialPort.Close();
            connected = false;
        }

     
      bool[]   ReadCoils()
        {
          
            int slaveId=Int32.Parse(txtSlaveId.Text);
             

             int startAddress=Int32.Parse(txtStartAddress.Text)-1;
        
            int quantity = Int16.Parse(txtSize.Text);
           bool[] response;
            
        this.functionCode=0x01;
            
             this.SlaveId=Convert.ToByte(slaveId);
			this.startingAddress = BitConverter.GetBytes(startAddress);
			this.quantity = BitConverter.GetBytes(quantity);

           byte[] data=new byte[]{
               this.SlaveId,
               this.functionCode,
               this.startingAddress[1],
               this.startingAddress[0],
               this.quantity[1],
               this.quantity[0],
              
           };
        
             serialPort.Write(data,0,data.Length);
             data = new byte[2100];
                 int numberofbytes =serialPort.Read(data, 0, data.Length);
                 receiveData = new byte[numberofbytes];

                 response = new bool[quantity];
                 for (int i = 0; i < quantity; i++)
                 {
                     int intData = data[9 + i / 8];
                     int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
                     response[i] = Convert.ToBoolean((intData & mask) / mask);
                 }


             return (response);

           }

    
     ushort calculateCRC(byte[] data, int numberOfBytes)
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
    


        

        private void btnReadCoils_Click(object sender, EventArgs e)
        {
            ReadDiscreateInputs(1,3);
           
          

            
        }

        private void btnReadDiscreateInputs_Click(object sender, EventArgs e)
        {

        }

        private void btnWriteSingleCoil_Click(object sender, EventArgs e)
        {
        
        }
    }
}
