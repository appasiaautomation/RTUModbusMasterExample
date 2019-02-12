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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
              /*  portName = cmbComPort.SelectedText;
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
                }*/
                serialPort = new SerialPort("COM1", 9600,Parity.None, 8, StopBits.One);
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 500;
                serialPort.WriteTimeout = 500;

                serialPort.Open();
                connected = true;
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
          
            int slaveId=int.Parse(txtSlaveId.Text);
             

             int startAddress=int.Parse(txtStartAddress.Text)-1;
        
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
               this.crc[1],
               this.crc[0]
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



        

        private void btnReadCoils_Click(object sender, EventArgs e)
        {
           //
            //bool[] respondData = ReadCoils();
           bool[] respondData=new bool[]{
               true,
               false
           };
          

            for (int i = 0; i < respondData.Length; i++)
            {
                lstReadDataFromServer.Items.Add(respondData[i]);
            }
        }
    }
}
