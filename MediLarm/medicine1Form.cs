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
    public partial class medicine1Form : Form
    {

        Form1 mainForm = new Form1();
        SerialPort Arduino = new SerialPort();
        //public string[] portName=    
        public medicine1Form()
        {
            InitializeComponent();
        }

        private void medicine1Form_Load(object sender, EventArgs e)
        {
            try
            {
                Arduino.PortName = mainForm.ComboBox1.Text.ToString();
            }
            catch(Exception ex)
            {

                //MessageBox.Show(ex.GetObjectData());
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Arduino.PortName = mainForm.ComboBox1.Text;
            try
            {
                Arduino.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Shovon");
            }
            drugs drug1 = new drugs();
            drug1.hour = int.Parse(comboBox1.Text);
            drug1.minutes = int.Parse(comboBox2.Text);
            drug1.meridian = comboBox3.Text;
            drug1.drugName = textBox1.Text;
            drug1.amnount = int.Parse(comboBox4.Text);
            drug1.drugID = 1;
            //if(drug1.minutes<10)
            Arduino.WriteLine('"' + drug1.hour.ToString() + ":" + drug1.minutes.ToString() + drug1.meridian + "?" + drug1.drugName + "?" + drug1.amnount.ToString() + "?" + drug1.drugID.ToString());
            //Arduino.WriteLine(drug1.hour.GetType().ToString());
            //else
            //Arduino.WriteLine(drug1.hour + ":" + drug1.minutes + drug1.meridian + "?" + drug1.drugName + "?" + drug1.amnount);
            //MessageBox.Show(drug1.hour + ":" + drug1.minutes + drug1.meridian + " " + textBox1.Text + " " + drug1.amnount + "pcs");
            Arduino.Close();
            this.Close();
        }
    }
}
