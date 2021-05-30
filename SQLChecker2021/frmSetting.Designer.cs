
using System;
using System.IO;



namespace SQLChecker2021
{
   
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // text file location 
        public static string text = "link";
       
       
        string newlocation = ("");
        string location = ("");
        public static string path = ("");

        // /text file location
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BT_SaveSetting = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_NewLocation = new System.Windows.Forms.TextBox();
            this.LB_NewLocation = new System.Windows.Forms.Label();
            this.TB_CurrentLocation = new System.Windows.Forms.TextBox();
            this.LB_CurrentLocation = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();


            // path location of database
            path = System.IO.Directory.GetCurrentDirectory() + @"\dblocation.txt";
            location = path;


            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(50, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 343);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.tabPage1.Controls.Add(this.BT_SaveSetting);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TB_NewLocation);
            this.tabPage1.Controls.Add(this.LB_NewLocation);
            this.tabPage1.Controls.Add(this.TB_CurrentLocation);
            this.tabPage1.Controls.Add(this.LB_CurrentLocation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // BT_SaveSetting
            // 
            this.BT_SaveSetting.Location = new System.Drawing.Point(604, 228);
            this.BT_SaveSetting.Name = "BT_SaveSetting";
            this.BT_SaveSetting.Size = new System.Drawing.Size(54, 22);
            this.BT_SaveSetting.TabIndex = 19;
            this.BT_SaveSetting.Text = "Save";
            this.BT_SaveSetting.UseVisualStyleBackColor = true;
            this.BT_SaveSetting.Click += new System.EventHandler(this.BT_SaveSetting_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(262, 184);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(397, 22);
            this.textBox4.TabIndex = 18;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(262, 160);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(397, 22);
            this.textBox3.TabIndex = 17;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(177, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Password: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(179, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Username:";
            // 
            // TB_NewLocation
            // 
            this.TB_NewLocation.Location = new System.Drawing.Point(262, 136);
            this.TB_NewLocation.Name = "TB_NewLocation";
            this.TB_NewLocation.Size = new System.Drawing.Size(397, 22);
            this.TB_NewLocation.TabIndex = 14;
            this.TB_NewLocation.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // LB_NewLocation
            // 
            this.LB_NewLocation.AutoSize = true;
            this.LB_NewLocation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_NewLocation.ForeColor = System.Drawing.Color.White;
            this.LB_NewLocation.Location = new System.Drawing.Point(103, 133);
            this.LB_NewLocation.Name = "LB_NewLocation";
            this.LB_NewLocation.Size = new System.Drawing.Size(0, 20);
            this.LB_NewLocation.TabIndex = 13;
            // 
            // TB_CurrentLocation
            // 
            this.TB_CurrentLocation.Location = new System.Drawing.Point(262, 112);
            this.TB_CurrentLocation.Name = "TB_CurrentLocation";
            this.TB_CurrentLocation.Size = new System.Drawing.Size(502, 22);
            this.TB_CurrentLocation.TabIndex = 12;
            this.TB_CurrentLocation.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.TB_CurrentLocation.Text = File.ReadAllText(location); 
            // 
            // LB_CurrentLocation
            // 
            this.LB_CurrentLocation.AutoSize = true;
            this.LB_CurrentLocation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CurrentLocation.ForeColor = System.Drawing.Color.White;
            this.LB_CurrentLocation.Location = new System.Drawing.Point(133, 110);
            this.LB_CurrentLocation.Name = "LB_CurrentLocation";
            this.LB_CurrentLocation.Size = new System.Drawing.Size(121, 20);
            this.LB_CurrentLocation.TabIndex = 11;
            this.LB_CurrentLocation.Text = "Current Location: ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(899, 558);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetting";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

           
        }
        // getpath(), public function for frmQuries
        public static string GetPath()
        {
            path = System.IO.Directory.GetCurrentDirectory() + @"\dblocation.txt";
            return path;
        }


        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_NewLocation;
        private System.Windows.Forms.Label LB_NewLocation;
        private System.Windows.Forms.TextBox TB_CurrentLocation;
        private System.Windows.Forms.Label LB_CurrentLocation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BT_SaveSetting;
    }
}