namespace NetpeakWebParser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.StartParsingButton = new System.Windows.Forms.Button();
            this.ResponseDataGridView = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHREF_Inner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHREF_Outer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveDataButton = new System.Windows.Forms.Button();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.LoadedDataGridView = new System.Windows.Forms.DataGridView();
            this.ClearDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(672, 20);
            this.UrlTextBox.TabIndex = 0;
            this.UrlTextBox.Text = "http://ya.ru";
            this.UrlTextBox.TextChanged += new System.EventHandler(this.UrlTextBox_TextChanged);
            this.UrlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UrlTextBox_KeyPress);
            // 
            // StartParsingButton
            // 
            this.StartParsingButton.Location = new System.Drawing.Point(690, 10);
            this.StartParsingButton.Name = "StartParsingButton";
            this.StartParsingButton.Size = new System.Drawing.Size(75, 23);
            this.StartParsingButton.TabIndex = 1;
            this.StartParsingButton.Text = "Start Parsing";
            this.StartParsingButton.UseVisualStyleBackColor = true;
            this.StartParsingButton.Click += new System.EventHandler(this.StartParsingButton_Click);
            // 
            // ResponseDataGridView
            // 
            this.ResponseDataGridView.AllowUserToDeleteRows = false;
            this.ResponseDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ResponseDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ResponseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResponseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.Title,
            this.Description,
            this.StatusCode,
            this.ResponseTime,
            this.h1,
            this.Image,
            this.AHREF_Inner,
            this.AHREF_Outer});
            this.ResponseDataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ResponseDataGridView.Location = new System.Drawing.Point(12, 38);
            this.ResponseDataGridView.Name = "ResponseDataGridView";
            this.ResponseDataGridView.ReadOnly = true;
            this.ResponseDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResponseDataGridView.RowHeadersVisible = false;
            this.ResponseDataGridView.Size = new System.Drawing.Size(753, 150);
            this.ResponseDataGridView.TabIndex = 3;
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // StatusCode
            // 
            this.StatusCode.HeaderText = "Status Code";
            this.StatusCode.Name = "StatusCode";
            this.StatusCode.ReadOnly = true;
            this.StatusCode.Width = 90;
            // 
            // ResponseTime
            // 
            this.ResponseTime.HeaderText = "Response Time";
            this.ResponseTime.Name = "ResponseTime";
            this.ResponseTime.ReadOnly = true;
            this.ResponseTime.Width = 106;
            // 
            // h1
            // 
            this.h1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.h1.HeaderText = "h1";
            this.h1.Name = "h1";
            this.h1.ReadOnly = true;
            this.h1.Width = 44;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 50;
            // 
            // AHREF_Inner
            // 
            this.AHREF_Inner.HeaderText = "Inner href";
            this.AHREF_Inner.Name = "AHREF_Inner";
            this.AHREF_Inner.ReadOnly = true;
            this.AHREF_Inner.Width = 80;
            // 
            // AHREF_Outer
            // 
            this.AHREF_Outer.HeaderText = "Outer href";
            this.AHREF_Outer.Name = "AHREF_Outer";
            this.AHREF_Outer.ReadOnly = true;
            this.AHREF_Outer.Width = 80;
            // 
            // SaveDataButton
            // 
            this.SaveDataButton.Location = new System.Drawing.Point(271, 194);
            this.SaveDataButton.Name = "SaveDataButton";
            this.SaveDataButton.Size = new System.Drawing.Size(75, 23);
            this.SaveDataButton.TabIndex = 4;
            this.SaveDataButton.Text = "Save Data";
            this.SaveDataButton.UseVisualStyleBackColor = true;
            this.SaveDataButton.Click += new System.EventHandler(this.SaveDataButton_Click);
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(352, 194);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 5;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // LoadedDataGridView
            // 
            this.LoadedDataGridView.AllowUserToAddRows = false;
            this.LoadedDataGridView.AllowUserToDeleteRows = false;
            this.LoadedDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LoadedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoadedDataGridView.Location = new System.Drawing.Point(12, 38);
            this.LoadedDataGridView.Name = "LoadedDataGridView";
            this.LoadedDataGridView.ReadOnly = true;
            this.LoadedDataGridView.RowHeadersVisible = false;
            this.LoadedDataGridView.Size = new System.Drawing.Size(753, 150);
            this.LoadedDataGridView.TabIndex = 6;
            this.LoadedDataGridView.Visible = false;
            // 
            // ClearDataButton
            // 
            this.ClearDataButton.Location = new System.Drawing.Point(433, 194);
            this.ClearDataButton.Name = "ClearDataButton";
            this.ClearDataButton.Size = new System.Drawing.Size(75, 23);
            this.ClearDataButton.TabIndex = 8;
            this.ClearDataButton.Text = "Clear Data";
            this.ClearDataButton.UseVisualStyleBackColor = true;
            this.ClearDataButton.Click += new System.EventHandler(this.ClearDataButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(778, 229);
            this.Controls.Add(this.ClearDataButton);
            this.Controls.Add(this.LoadedDataGridView);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.SaveDataButton);
            this.Controls.Add(this.ResponseDataGridView);
            this.Controls.Add(this.StartParsingButton);
            this.Controls.Add(this.UrlTextBox);
            this.Name = "MainForm";
            this.Text = "Netpeak Web Parser";
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Button StartParsingButton;
        private System.Windows.Forms.DataGridView ResponseDataGridView;
        private System.Windows.Forms.Button SaveDataButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn h1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHREF_Inner;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHREF_Outer;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.DataGridView LoadedDataGridView;
        private System.Windows.Forms.Button ClearDataButton;
    }
}

