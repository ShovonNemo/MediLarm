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
    
    public partial class medicine2Form : Form
    {
        SerialPort Arduino = new SerialPort();
        Form1 mainForm = new Form1();
        public medicine2Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void medicine2Form_Load(object sender, EventArgs e)
        {
            Arduino.PortName = mainForm.ComboBox1.Text;
            for (Int16 i = 1; i <= 12; i++)
                comboBox1.Items.Add(i);
            comboBox1.SelectedIndex = 11;
            for (Int16 i = 0; i < 60; i++)
                comboBox2.Items.Add(i);
            comboBox2.SelectedIndex = 30;
            comboBox3.Items.Add("AM");
            comboBox3.Items.Add("PM");
            comboBox3.SelectedIndex = 0;
            for (int i = 1; i <= 4; i++)
                comboBox4.Items.Add(i);
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arduino.Open();
            drugs drug1 = new drugs();
            drug1.hour = int.Parse(comboBox1.Text);
            drug1.minutes = int.Parse(comboBox2.Text);
            drug1.meridian = comboBox3.Text;
            drug1.drugName = textBox1.Text;
            drug1.amnount = int.Parse(comboBox4.Text);
            drug1.drugID = 2;
            Arduino.WriteLine('"' + drug1.hour.ToString() + ":" + drug1.minutes.ToString() + drug1.meridian + "?" + drug1.drugName + "?" + drug1.amnount.ToString() + "?" + drug1.drugID.ToString());
            Arduino.Close();
            this.Close();
        }
    }
}
