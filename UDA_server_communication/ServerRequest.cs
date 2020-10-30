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
using System.Runtime.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tulpep.NotificationWindow;
using Timer = System.Timers.Timer;

namespace UDA_server_communication
{

    class ServerRequest
    {
        private static System.Timers.Timer aTimer;
        private Form1 main;
        public int counter;
        public string UDA_index1;
        public string save_status;
        ArrayList L = new ArrayList();
        public ServerRequest(Form1 form, string f)
        {
            save_status = "0";
            main = form;
            UDA_index1 = f; //Indice che discende dal radio button che è stato cliccato
            counter = 0;
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(Get_Status); //Il timer interroga il server ad intervalli
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

        }
        public string getPuturl(string k)
        {
            int ik = Int32.Parse(k);
            if (ik >= 0 && ik < 8)
                return "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/put/?i=" + UDA_index1 + "&k=" + ik.ToString();
            else
                return "";
        }
        public async static Task<string> Server_Request(string url) //Metodo che permette la comunicazione con il server
        {

            WebRequest server = HttpWebRequest.Create(url);
            var response = server.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = await reader.ReadToEndAsync();
                return result;
            }
        }
        public async void Get_Status(object source, ElapsedEventArgs e)
        {         
            string get_url,char_status,char_status1;
            get_url = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20200901_0900//api/uda/get/?i=" + UDA_index1;
            try
            {
                string json_string = await Server_Request(get_url);
                main.Show_String(json_string, 1);
                JObject json_parsed = JObject.Parse(json_string);
                char_status = (string)json_parsed["status"];
             
                if (main.contatore == 0)
                {
                    save_status = char_status; //salva lo stato attuale
                    putStatus_Server(char_status);//comunica al server che lo stato è cambiato
                    main.contatore++;
                }
                else
                {
                    char_status1 = (string)json_parsed["status"];
                    if (!string.Equals(char_status1, save_status))
                    {
                        main.contatore = 0;
                        putStatus_Server(char_status1);
                    }
                }
            }           
            catch (Exception ex)
            {
                //MessageBox.Show(Convert.ToString(ex));
                throw new ApplicationException("Error", ex);
                aTimer.Stop();
            }
        }
        // Con questo metodo, putStatus_Server, vado a cambiare lo stato del server 
        public async void  putStatus_Server(string status)
        {
            string url_put_server;
            url_put_server = getPuturl(status);
            string server_status = await Server_Request(url_put_server);
            main.Show_String(server_status, 2);
            main.Status_Changed(status, 2);
        }
    }
}
