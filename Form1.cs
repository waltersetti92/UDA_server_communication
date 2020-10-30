using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Collections;
using System.Timers;
using System.Windows;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace UDA_server_communication
{

    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);
        public int contatore, count;
        public string UDA_index;
        public ArrayList L1 = new ArrayList();
        private delegate void SafeCallDelegate(string text);
        public Form1(string x)
        {
            InitializeComponent();
            UDA_index = x;
            contatore = 0;
            count = 0;
        }
        public Thread mythread;
        public delegate void delSetValue(string x);
        public void Show_String(string s,int i)
        {
            if (i == 1)
            {

                textBox1.Invoke((MethodInvoker)(() => textBox1.Text = s));
            }
            else
            {
                textBox2.Invoke((MethodInvoker)(() => textBox2.Text = s));
            }

        }
        public void WriteTextSafe1(string text)
        {
            if (this.InvokeRequired) this.Invoke(new delSetValue(WriteTextSafe1), text);
            else this.textBox1.Text = text;
        }
        public void WriteTextSafe2(string text)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe2);
                textBox2.Invoke(d, new object[] { text });
            }
            else
            {
                textBox2.Text = text;
            }
        }
   
        public void Status_Changed(string k, int i)
        {
            this.BeginInvoke((Action)delegate ()
            {
                st.Visible = true;
                if (i == 2)
                {
                    textBox2.Visible = true;
                    label1.Visible = true;
                }
                if (String.Equals(k, Convert.ToString(0)))
                {
                    st.ForeColor = Color.DarkGreen;
                    label1.ForeColor = Color.DarkGreen;
                    st.Text = "IDLE";
                    label1.Text = "IDLE";

                }
                if (String.Equals(k, Convert.ToString(1)))
                {
                    st.ForeColor = Color.Black;
                    label1.ForeColor = Color.Black;
                    st.Text = "START";
                    label1.Text = "STARTED";
                }
                if (String.Equals(k, Convert.ToString(2)))
                {
                    st.ForeColor = Color.DarkRed;
                    label1.ForeColor = Color.DarkRed;
                    st.Text = "ABORT";
                    label1.Text = "ABORTED";

                }
                if (String.Equals(k, Convert.ToString(3)))
                {
                    label1.ForeColor = Color.DarkOrange;
                    st.ForeColor = Color.DarkOrange;
                    st.Text = "PAUSE";
                    label1.Text = "PAUSED";
                }
                if (String.Equals(k, Convert.ToString(4)))
                {
                    st.ForeColor = Color.Brown;
                    label1.ForeColor = Color.Brown;
                    st.Text = "RESUME";
                    label1.Text = "RESUMED";
                }
                if (String.Equals(k, Convert.ToString(5)))
                {
                    st.ForeColor = Color.DarkOrchid;
                    label1.ForeColor = Color.DarkOrchid;
                    st.Text = "FINALIZE";
                    label1.Text = "COMPLETED";
                }
                if (String.Equals(k, Convert.ToString(6)))
                {
                    st.ForeColor = Color.DarkGreen;
                    label1.ForeColor = Color.DarkGreen;
                    st.Text = "FINISHED";
                    label1.Text = "FINALIZED";
                }
                if (String.Equals(k, Convert.ToString(7)))
                {
                    label1.ForeColor = Color.Purple;
                    st.ForeColor = Color.Purple;
                    st.Text = "NOT IMPLEMENTED";
                    label1.Text = "FINISHED";
                }
            });

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerRequest r = new ServerRequest(this);
            textBox1.ReadOnly = true;
            st.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
        }
    }
}
