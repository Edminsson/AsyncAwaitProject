using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Applikationen ser ut att vara responsiv under awaiten.
        private async void startBtn_Click(object sender, EventArgs e)
        {
            //Observera att Click-hanteraren måste vara async för att det ska funka
            //Jag kan inte anropa GetResult som jag gjorde i konsolprogrammet.
            //var textTask = GetResult();
            //resultatTxt.Text = textTask.Result;
            var texten = await GetResult();
            resultatTxt.Text = texten;
        }

        public async Task<string> GetResult()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            string urlContents = await getStringTask;
            return urlContents;
        }

        private void skrivBtn_Click(object sender, EventArgs e)
        {
            resultatTxt.Text += "Meddelande";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead("http://msdn.microsoft.com");
            StreamReader reader = new StreamReader (data);
            string s = reader.ReadToEnd ();
            data.Close ();
            reader.Close ();

            resultatTxt.Text = s;
        }
    }
}
