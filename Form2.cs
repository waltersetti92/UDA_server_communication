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
            MyVal = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(MyVal);
            fr.Show();
            this.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MyVal = "1";
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MyVal = "2";
            button1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MyVal = "3";
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            MyVal = "4";
            button1.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            MyVal = "5";
            button1.Enabled = true;
        }
    }
}
