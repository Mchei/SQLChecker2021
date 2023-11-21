
namespace Latest_27_05
{
    partial class importQueries
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
            this.Import = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(217, 135);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 0;
            this.Import.Text = "Export";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(101, 135);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.comboBox1.Location = new System.Drawing.Point(101, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // importQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(393, 220);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Import);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "importQueries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "importQueries";
            this.Load += new System.EventHandler(this.importQueries_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}