using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDA_server_communication
{
    public partial class Form2 : Form
    {
        private string Myval;
        public string check1;
        public string MyVal
        {
            get { return Myval; }
            set { Myval = value; }
        }
        public Form2()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fr1 = new Form1(MyVal,1);
            fr1.Closed += (s, args) => this.Close();
            fr1.Show();
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                MyVal = "1";
                button1.Enabled = true;
            }
            else if(radioButton2.Checked==true)
            {
                MyVal = "2";
                button1.Enabled = true;
            }
            else if (radioButton3.Checked == true)
            {
                MyVal = "3";
                button1.Enabled = true;
            }
            else if (radioButton4.Checked == true)
            {
                MyVal = "4";
                button1.Enabled = true;
            }
            else if (radioButton5.Checked == true)
            {
                MyVal = "5";
                button1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

    }
}
