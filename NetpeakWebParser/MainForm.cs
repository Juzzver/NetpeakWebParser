using NetpeakWebParser.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NetpeakWebParser
{
    public partial class MainForm : Form
    {
        private WebPageContext db;
        private WebPage m_Page;
        private string[] m_ColumnNames = { "Id", "Url", "Title", "Description",
            "StatusCode", "ResponseTime", "h1", "Images", "AHREF_Inner",  "AHREF_Outer" };
                                               
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

            m_Page = new WebPage();

            m_Page.Url = url;
            m_Page.Title = htmlDoc.DocumentNode.SelectSingleNode("//title")?.InnerHtml;
            m_Page.Description = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='description']")?.Attributes["content"].Value;
            m_Page.StatusCode = (int)response.StatusCode;
            m_Page.ResponseTime = timeTaken.TotalMilliseconds.ToString("#") + " ms";
            m_Page.HeadersList = new List<Header>();
            m_Page.ImagesList = new List<Image>();
            m_Page.InnerLinksList = new List<HrefInner>();
            m_Page.OuterLinksList = new List<HrefOuter>();

            var headers = htmlDoc.DocumentNode.SelectNodes("//h1");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    m_Page.HeadersList.Add(new Header() { Text = header.InnerText });
                }
            }

            var images = htmlDoc.DocumentNode.SelectNodes("//img");

            if (images != null)
            {
                foreach (var img in images)
                {
                    if (img.Attributes["src"] != null && img.Attributes["src"].Value != null)
                    {
                        m_Page.ImagesList.Add(new Image() { Src = img.Attributes["src"].Value });
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

                        if (href.Attributes["href"].Value.Contains(GetCleanedUrl(m_Page.Url)) || href.Attributes["href"].Value[0].Equals('/'))
                        {
                            m_Page.InnerLinksList.Add(new HrefInner()
                            {
                                Link = href.Attributes["href"].Value,
                                Text = href.InnerText.Trim()
                            });
                        }
                        else
                        {
                            m_Page.OuterLinksList.Add(new HrefOuter()
                            {
                                Link = href.Attributes["href"].Value,
                                Text = href.InnerText.Trim()
                            });
                        }
                    }
                }
            }

            ResponseDataGridView.Rows[0].Cells["Url"].Value = m_Page.Url;
            ResponseDataGridView.Rows[0].Cells["Title"].Value = m_Page.Title;
            ResponseDataGridView.Rows[0].Cells["Description"].Value = m_Page.Description;
            ResponseDataGridView.Rows[0].Cells["StatusCode"].Value = m_Page.StatusCode;
            ResponseDataGridView.Rows[0].Cells["ResponseTime"].Value = m_Page.ResponseTime;
            ResponseDataGridView.Rows[0].Cells["h1"].Value = m_Page.HeadersList.Count;
            ResponseDataGridView.Rows[0].Cells["Image"].Value = m_Page.ImagesList.Count;
            ResponseDataGridView.Rows[0].Cells["AHREF_Inner"].Value = m_Page.InnerLinksList.Count;
            ResponseDataGridView.Rows[0].Cells["AHREF_Outer"].Value = m_Page.OuterLinksList.Count;

            for (int i = 0; i < m_Page.HeadersList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["h1"].ToolTipText += $"[{i}] {((List<Header>)m_Page.HeadersList)[i].Text}\n";
            for (int i = 0; i < m_Page.ImagesList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["Image"].ToolTipText += $"[{i}] {((List<Image>)m_Page.ImagesList)[i].Src}\n";
            for (int i = 0; i < m_Page.InnerLinksList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["AHREF_Inner"].ToolTipText +=
                    $"[{i}] [{((List<HrefInner>)m_Page.InnerLinksList)[i].Link}] [{((List<HrefInner>)m_Page.InnerLinksList)[i].Text}]\n";

            for (int i = 0; i < m_Page.OuterLinksList.Count; i++)
                ResponseDataGridView.Rows[0].Cells["AHREF_Outer"].ToolTipText +=
                    $"[{i}] [{((List<HrefOuter>)m_Page.OuterLinksList)[i].Link}] [{((List<HrefOuter>)m_Page.OuterLinksList)[i].Text}]\n";

            
        }

        private string GetCleanedUrl(string url)
        {
            if (url.Contains("http://"))
                url = url.Replace("http://", "");
            else if (url.Contains("https://"))
                url = url.Replace("https://", "");

            if (url.Contains("www."))
                url = url.Replace("www.", "");

            if (url.Contains("/"))
                url = url.Replace("/", "");

            return url;
        }

        private void ClearOldTips(Control control)
        {
            var grid = control as DataGridView;

            if (grid != null)
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

            return url.Trim();
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

        private void UrlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                StartParsingButton.PerformClick();
                this.Focus();
            }
        }

        private void SaveDataButton_Click(object sender, EventArgs e)
        {
            DBSaveDataAsync();
        }

        private async void DBSaveDataAsync()
        {
            if (m_Page != null)
            {
                db.WebPages.Add(m_Page);
                await db.SaveChangesAsync();
                MessageBox.Show("Data saving successfully", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No Data for saving!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            string query = @"SELECT w.Id, w.Url, w.Title, w.Description, w.StatusCode, w.ResponseTime, 
                            (select count(*) from Headers h where h.WebPageId = w.Id) as 'h1', 
                            (select count(*) from Images i where i.WebPageId = w.Id )as 'Images', 
                            (select count(*) from HrefInners hi where hi.WebPageId = w.Id) as 'Inner href', 
                            (select count(*) from HrefOuters ho where ho.WebPageId = w.Id ) as 'Outer href'
                            FROM WebPages w";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=WebPageDB;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand queryCommand = new SqlCommand(query, connection);
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);
                LoadedDataGridView.DataSource = dataTable;
            }

            LoadedDataGridView.Visible = true;
        }

        private void ClearDataButton_Click(object sender, EventArgs e)
        {            
            LoadedDataGridView.Visible = false;
            LoadedDataGridView.Columns.Clear();

            for (int i = 0; i < ResponseDataGridView.Rows[0].Cells.Count; i++)
                ResponseDataGridView.Rows[0].Cells[i].Value = null;
        }
    }
}
