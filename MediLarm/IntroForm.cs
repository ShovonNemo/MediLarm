using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MediLarm
{
    public partial class IntroForm : Form
    {
        
        public IntroForm()
        {
            InitializeComponent();
        }

       

        private void IntroForm_Load(object sender, EventArgs e)
        {
            
            this.Show();
            Thread.Sleep(2000);
            this.Close();  
        }

        
    }
}
