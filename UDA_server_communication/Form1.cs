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
        public int contatore;
        public string UDA_index;
        public ArrayList L1 = new ArrayList();

        public ArrayList txts = new ArrayList() { "IDLE" };
        public ArrayList labels = new ArrayList() { "IDLE" };
        public ArrayList colors = new ArrayList() { Color.Black };

        public Form1(string x,int j)
        {

            txts.Add("START");
            labels.Add("STARTED");
            colors.Add(Color.DarkGreen);

            txts.Add("ABORT");
            labels.Add("ABORTED");
            colors.Add(Color.DarkRed);

            txts.Add("PAUSE");
            labels.Add("PAUSED");
            colors.Add(Color.DarkOrange);

            txts.Add("RESUME");
            labels.Add("RESUMED");
            colors.Add(Color.Brown);

            txts.Add("FINALIZED");
            labels.Add("COMPLETED");
            colors.Add(Color.DarkOrchid);

            txts.Add("FINISHED");
            labels.Add("FINALIZED");
            colors.Add(Color.DarkCyan);

            txts.Add("NOT IMPLEMENTED");
            labels.Add("FINISHED");
            colors.Add(Color.Purple);

            ServerRequest r = new ServerRequest(this,x);
            UDA_index = x;
            InitializeComponent();
            contatore = 0;
            st.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
        }

        public  void Show_String(string s, int i)
        {

            this.BeginInvoke((Action)delegate ()
            {
                if (i == 1)

                    textBox1.Text = s;
                else
                    textBox2.Text = s;
            });

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
                setSelection(Int32.Parse(k));
            });
        }
        private void setSelection(int k)
        {
            st.ForeColor = (Color)colors[k];
            label1.ForeColor = (Color)colors[k];
            st.Text = (string)txts[k];
            label1.Text = (string)labels[k];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string nome;
            nome= string.Concat("UDA ", UDA_index);
            this.Text = nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
                var fr2 = new Form2();
                fr2.Closed += (s, args) => this.Close();
                fr2.Show();
        }
    }
}
