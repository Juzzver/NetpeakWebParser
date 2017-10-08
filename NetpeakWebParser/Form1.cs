using NetpeakWebParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetpeakWebParser
{
    public partial class MainForm : Form
    {
        WebPageContext db;

        public MainForm()
        {
            InitializeComponent();

            db = new WebPageContext();
            db.WebPages.Load();

           
        }

        private async void StartParsingButton_Click(object sender, EventArgs e)
        {
            var request = CreateWebRequest(UrlTextBox.Text, "GET");
            var getResponse = await request.GetResponseAsync();
            var response = getResponse as HttpWebResponse;

            MessageBox.Show(String.Join(System.Environment.NewLine, response.Headers.AllKeys));
        }

        private WebRequest CreateWebRequest(string url, string method)
        {
            if (!String.IsNullOrEmpty(url))
            {
                if (!String.IsNullOrEmpty(method))
                {
                    var request = WebRequest.Create(url);
                    request.Method = method;

                    return request;
                }
                else
                    MessageBox.Show("Web Request method can't be null!", "Request Method Error");
            }
            else
                MessageBox.Show("URL address is not valid!", "URL Error");

            return null;
        }
    }
}
