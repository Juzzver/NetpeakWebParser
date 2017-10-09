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
            var url = GetUrl(UrlTextBox.Text);

            if (url == null)
                return;

            ClearOldTips(ResponseDataGridView);

            Stopwatch timer = new Stopwatch();
            timer.Start();

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
            page.ImagesList = new List<Image>();
            page.InnerLinksList = new List<HrefInner>();
            page.OuterLinksList = new List<HrefOuter>();

            var headers = htmlDoc.DocumentNode.SelectNodes("//h1");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    page.HeadersList.Add(new Header() { Text = header.InnerText });
                }
            }

            var images = htmlDoc.DocumentNode.SelectNodes("//img");

            if (images != null)
            {
                foreach (var img in images)
                {
                    if (img.Attributes["src"] != null && img.Attributes["src"].Value != null)
                    {
                        page.ImagesList.Add(new Image() { Src = img.Attributes["src"].Value });
                    }
                }
            }

            var links = htmlDoc.DocumentNode.SelectNodes("//a");

            if (links != null)
            {
                foreach (var href in links)
                {
                    if (href.Attributes["href"] != null && href.Attributes["href"].Value != null)
                    {
                       
                        if (href.Attributes["href"].Value.Contains(GetRemovedProtocolUrl(page.Url)))
                        {
                            page.InnerLinksList.Add(new HrefInner()
                            {
                                Link = href.Attributes["href"].Value,
                                Text = href.InnerText.Trim()
                            });
                        }
                        else
                        {
                            page.OuterLinksList.Add(new HrefOuter()
                            {
                                Link = href.Attributes["href"].Value,
                                Text = href.InnerText.Trim()
                    });
                        }
                    }
                }
            }

            ResponseDataGridView.Rows[0].Cells["Url"].Value = page.Url;
            ResponseDataGridView.Rows[0].Cells["Title"].Value = page.Title;
            ResponseDataGridView.Rows[0].Cells["Description"].Value = page.Description;
            ResponseDataGridView.Rows[0].Cells["StatusCode"].Value = page.ResponseCode;
            ResponseDataGridView.Rows[0].Cells["ResponseTime"].Value = page.ResponseTime;
            ResponseDataGridView.Rows[0].Cells["h1"].Value = page.HeadersList.Count;
            ResponseDataGridView.Rows[0].Cells["Image"].Value = page.ImagesList.Count;
            ResponseDataGridView.Rows[0].Cells["AHREF_Inner"].Value = page.InnerLinksList.Count;
            ResponseDataGridView.Rows[0].Cells["AHREF_Outer"].Value = page.OuterLinksList.Count;
            
            for (int i = 0; i < page.HeadersList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["h1"].ToolTipText += $"[{i}] {((List<Header>)page.HeadersList)[i].Text}\n";
            for (int i = 0; i < page.ImagesList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["Image"].ToolTipText += $"[{i}] {((List<Image>)page.ImagesList)[i].Src}\n";
            for (int i = 0; i < page.InnerLinksList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["AHREF_Inner"].ToolTipText +=
                    $"[{i}] [{((List<HrefInner>)page.InnerLinksList)[i].Link}] [{((List<HrefInner>)page.InnerLinksList)[i].Text}] \n";

            for (int i = 0; i < page.OuterLinksList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["AHREF_Outer"].ToolTipText +=
                    $"[{i}] [{((List<HrefOuter>)page.OuterLinksList)[i].Link}] [{((List<HrefOuter>)page.OuterLinksList)[i].Text}] \n";
                                              
        }

        private string GetRemovedProtocolUrl(string url)
        {
            if (url.Contains("http://"))
                url = url.Replace("http://", "");
            else if (url.Contains("https://"))
                url = url.Replace("https://", "");

             if (url.Contains("www."))
                url = url.Replace("www.", "");

            return url;
        }

        private void ClearOldTips(Control control)
        {
            var grid = control as DataGridView;
           if ( grid != null)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                        grid.Rows[i].Cells[j].ToolTipText = null;
                }
            }

        }

        private string GetUrl(string url)
        {
            if (String.IsNullOrEmpty(UrlTextBox.Text))
            {
                MessageBox.Show("You may enter URL address!", "URL not found");
                UrlTextBox.Focus();
                UrlTextBox.BackColor = Color.PaleVioletRed;

                return null;
            }

            if (!url.Contains("http://") && !url.Contains("https://"))
                url = "http://" + url;

            return url;
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
