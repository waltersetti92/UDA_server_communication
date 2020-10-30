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

    class ServerRequest
    {
        private static System.Timers.Timer aTimer;
        private Form1 main;
        public int counter;
        //public string UDA_index1;
        public string char1;
        ArrayList L = new ArrayList();
        public ServerRequest(Form1 form)
        {
            main = form;
            //UDA_index1 = main.UDA_index;
            counter = 0;
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }
        public string Status_Put(string k)
        {

            string url;
            url = "";
            if (String.Equals(k, Convert.ToString(0)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=0";
            }
            if (String.Equals(k, Convert.ToString(1)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=1";

            }
            if (String.Equals(k, Convert.ToString(2)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=2";
            }
            if (String.Equals(k, Convert.ToString(3)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=3";

            }
            if (String.Equals(k, Convert.ToString(4)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=4";
            }
            if (String.Equals(k, Convert.ToString(5)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=5";
            }
            if (String.Equals(k, Convert.ToString(6)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=6";
            }
            if (String.Equals(k, Convert.ToString(7)))
            {
                url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=1&k=7";
            }
            return url;
        }
        public async static Task<string> Rexcp1(string url)
        {

            WebRequest server = HttpWebRequest.Create(url);
            var response = server.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }
        }
        public async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string url, concatenate_g, get_url;
            int leng_g;
            get_url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/get/?i=1";
            leng_g = get_url.Length;
            try
            {
                //concatenate_g = string.Concat("i=", UDA_index1);
                //get_url = get_url.Replace("i=1", concatenate_g);
                string t = await Rexcp1(get_url);
                //MessageBox.Show(t);
               main.WriteTextSafe1(t);
              // main.Show_String(t, 1);
                
                char1 = Convert.ToString(t[88]);
                //char1=main.Check_Status();               
                if (main.contatore == 0)
                {
                    main.L1.Insert(main.contatore, char1);
                    url = Status_Put(char1);
                    string t1 = await Rexcp1(url);
                    //main.WriteTextSafe2(t1);
                    //main.Show_String(t1, 2);
                    //main.Status_Changed1(char1);
                    //main.Status_Changed(char1, 2);
                }
                else
                {

                    main.L1.Insert(main.contatore, char1);
                    if (main.L1[main.contatore] == main.L1[main.contatore - 1])
                    {
                        main.contatore = 0;
                    }
                    else
                    {
                        url = Status_Put(char1);
                        string t1 = await Rexcp1(url);
                       // main.WriteTextSafe2(t1);
                       //main.Show_String(t1, 2);
                        //main.Status_Changed2(char1);                       
                        //main.Status_Changed(char1, 2);
                        main.contatore = 1;
                    }
                }
                main.contatore++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                //throw new ApplicationException("Error", ex);
                // MessageBox.Show(char1);
                aTimer.Stop();
            }

        }
    }
}
