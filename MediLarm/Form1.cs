using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace MediLarm
{
    public partial class Form1 : Form
    {
        SerialPort Arduino = new SerialPort();
        public string[] portName=null;
        public Form1()
        {
            InitializeComponent();
            portSetup();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            medicine1Form frm1 = new medicine1Form();
            frm1.Show();
            //medicine1Form
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            medicine2Form frm2 = new medicine2Form();
            frm2.Show();
            //medicine1Form
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            medicine3Form frm3 = new medicine3Form();
            frm3.Show();
        }
        void portSetup()
        {
            comboBox1.Items.Clear();
            portName = SerialPort.GetPortNames();
            foreach (string i in portName)
            {
                comboBox1.Items.Add(i);
            }
            if (portName.Length == 0)
            {
                MessageBox.Show("Connect a device to USB");
                //Application.Exit();
                Application.Exit();
                //Application.Exit();

            }
            //if(string xb in portName==0)
            //else
              //  comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Arduino.PortName=null;
            Arduino.PortName = comboBox1.Text;
        }

        public ComboBox ComboBox1
        {
          get
            {
                return comboBox1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            portSetup();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
