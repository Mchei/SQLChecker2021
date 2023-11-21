
namespace Latest_27_05
{
    partial class frmReport
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
            this.import = new System.Windows.Forms.Button();
            this.fileNameText = new System.Windows.Forms.TextBox();
            this.sheetName = new System.Windows.Forms.ComboBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.report = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(638, 467);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(28, 21);
            this.import.TabIndex = 0;
            this.import.Text = "...";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // fileNameText
            // 
            this.fileNameText.Location = new System.Drawing.Point(338, 468);
            this.fileNameText.Name = "fileNameText";
            this.fileNameText.Size = new System.Drawing.Size(294, 20);
            this.fileNameText.TabIndex = 1;
            // 
            // sheetName
            // 
            this.sheetName.FormattingEnabled = true;
            this.sheetName.Location = new System.Drawing.Point(340, 504);
            this.sheetName.Name = "sheetName";
            this.sheetName.Size = new System.Drawing.Size(121, 21);
            this.sheetName.TabIndex = 2;
            this.sheetName.SelectedIndexChanged += new System.EventHandler(this.sheetName_SelectedIndexChanged);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.fileNameLabel.Location = new System.Drawing.Point(262, 471);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(70, 13);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "Report Name";
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.sheetNameLabel.Location = new System.Drawing.Point(262, 507);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(72, 13);
            this.sheetNameLabel.TabIndex = 4;
            this.sheetNameLabel.Text = "Sheet Name: ";
            // 
            // report
            // 
            this.report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.report.Location = new System.Drawing.Point(39, 32);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(816, 407);
            this.report.TabIndex = 5;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(899, 605);
            this.Controls.Add(this.report);
            this.Controls.Add(this.sheetNameLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.sheetName);
            this.Controls.Add(this.fileNameText);
            this.Controls.Add(this.import);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReport";
            this.Text = "frmResult";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button import;
        private System.Windows.Forms.TextBox fileNameText;
        private System.Windows.Forms.ComboBox sheetName;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.DataGridView report;
    }
}