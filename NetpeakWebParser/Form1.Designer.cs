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
            this.components = new System.ComponentModel.Container();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.StartParsingButton = new System.Windows.Forms.Button();
            this.ResponseDataGridView = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Header_h1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHREF_Inner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHREF_Outer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveDataButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(769, 20);
            this.UrlTextBox.TabIndex = 0;
            this.UrlTextBox.Text = "http://ya.ru";
            this.UrlTextBox.TextChanged += new System.EventHandler(this.UrlTextBox_TextChanged);
            // 
            // StartParsingButton
            // 
            this.StartParsingButton.Location = new System.Drawing.Point(787, 10);
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
            this.ResponseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResponseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.Title,
            this.Description,
            this.ResponseCode,
            this.ResponseTime,
            this.Header_h1,
            this.Image,
            this.AHREF_Inner,
            this.AHREF_Outer});
            this.ResponseDataGridView.Location = new System.Drawing.Point(12, 38);
            this.ResponseDataGridView.Name = "ResponseDataGridView";
            this.ResponseDataGridView.ReadOnly = true;
            this.ResponseDataGridView.Size = new System.Drawing.Size(850, 150);
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
            // ResponseCode
            // 
            this.ResponseCode.HeaderText = "ResponseCode";
            this.ResponseCode.Name = "ResponseCode";
            this.ResponseCode.ReadOnly = true;
            // 
            // ResponseTime
            // 
            this.ResponseTime.HeaderText = "ResponseTime";
            this.ResponseTime.Name = "ResponseTime";
            this.ResponseTime.ReadOnly = true;
            // 
            // Header_h1
            // 
            this.Header_h1.HeaderText = "Header_h1";
            this.Header_h1.Name = "Header_h1";
            this.Header_h1.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // AHREF_Inner
            // 
            this.AHREF_Inner.HeaderText = "AHREF_Inner";
            this.AHREF_Inner.Name = "AHREF_Inner";
            this.AHREF_Inner.ReadOnly = true;
            // 
            // AHREF_Outer
            // 
            this.AHREF_Outer.HeaderText = "AHREF_Outer";
            this.AHREF_Outer.Name = "AHREF_Outer";
            this.AHREF_Outer.ReadOnly = true;
            // 
            // SaveDataButton
            // 
            this.SaveDataButton.Location = new System.Drawing.Point(404, 194);
            this.SaveDataButton.Name = "SaveDataButton";
            this.SaveDataButton.Size = new System.Drawing.Size(75, 23);
            this.SaveDataButton.TabIndex = 4;
            this.SaveDataButton.Text = "Save Data";
            this.SaveDataButton.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "fff";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 341);
            this.Controls.Add(this.SaveDataButton);
            this.Controls.Add(this.ResponseDataGridView);
            this.Controls.Add(this.StartParsingButton);
            this.Controls.Add(this.UrlTextBox);
            this.Name = "MainForm";
            this.Text = "Netpeak Web Parser";
            ((System.ComponentModel.ISupportInitialize)(this.ResponseDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Button StartParsingButton;
        private System.Windows.Forms.DataGridView ResponseDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header_h1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHREF_Inner;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHREF_Outer;
        private System.Windows.Forms.Button SaveDataButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

