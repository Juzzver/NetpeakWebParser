using NetpeakWebParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
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
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var url = GetUrl();

            if (url == null)
                return;

            var request = CreateWebRequest(url, "GET");
            var getResponse = await request.GetResponseAsync();
            var response = getResponse as HttpWebResponse;

            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(response.GetResponseStream(), Encoding.UTF8);
            response.Close();

            WebPage page = new WebPage();

            page.Url = url;
            page.Title = htmlDoc.DocumentNode.SelectSingleNode("//title")?.InnerHtml;
            page.Description = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"].Value;
            page.ResponseCode = (int)response.StatusCode;
            page.ResponseTime = timeTaken.TotalMilliseconds.ToString("#") + " ms";
            page.HeadersList = new List<Header>();

           var headers = htmlDoc.DocumentNode.SelectNodes("//h1");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    page.HeadersList.Add(new Header() { Text = header.InnerText });
                }
            }

            ResponseDataGridView.Rows[0].Cells["Url"].Value = url;
            ResponseDataGridView.Rows[0].Cells["Title"].Value = page.Title;
            ResponseDataGridView.Rows[0].Cells["Description"].Value = page.Description;
            ResponseDataGridView.Rows[0].Cells["ResponseCode"].Value = page.ResponseCode;
            ResponseDataGridView.Rows[0].Cells["ResponseTime"].Value = page.ResponseTime;
            ResponseDataGridView.Rows[0].Cells["Header_h1"].Value = page.HeadersList.Count;

            for (int i = 0; i< page.HeadersList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["Header_h1"].ToolTipText += $"[{i}] {((List<Header>)page.HeadersList)[i].Text}\n";
            
        }

        private string GetUrl()
        {
            if (String.IsNullOrEmpty(UrlTextBox.Text))
            {
                MessageBox.Show("You may enter URL address!", "URL not found");
                UrlTextBox.Focus();
                UrlTextBox.BackColor = Color.PaleVioletRed;

                return null;
            }


            return UrlTextBox.Text;
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

        private void UrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UrlTextBox.BackColor == Color.PaleVioletRed)
                UrlTextBox.BackColor = Color.White;
        }
    }
}
