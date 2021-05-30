
namespace SQLChecker2021
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.Panel_Login = new System.Windows.Forms.Panel();
            this.BUT_exit = new System.Windows.Forms.Label();
            this.BUT_login = new System.Windows.Forms.Button();
            this.LB_ClearFields = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.PB_Password = new System.Windows.Forms.PictureBox();
            this.TB_UserName = new System.Windows.Forms.TextBox();
            this.PB_UserName = new System.Windows.Forms.PictureBox();
            this.Label_LoginLogo = new System.Windows.Forms.Label();
            this.PB_LoginLogo = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoginLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Login
            // 
            this.Panel_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.Panel_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Login.Controls.Add(this.BUT_exit);
            this.Panel_Login.Controls.Add(this.BUT_login);
            this.Panel_Login.Controls.Add(this.LB_ClearFields);
            this.Panel_Login.Controls.Add(this.TB_Password);
            this.Panel_Login.Controls.Add(this.PB_Password);
            this.Panel_Login.Controls.Add(this.TB_UserName);
            this.Panel_Login.Controls.Add(this.PB_UserName);
            this.Panel_Login.Controls.Add(this.Label_LoginLogo);
            this.Panel_Login.Controls.Add(this.PB_LoginLogo);
            this.Panel_Login.Location = new System.Drawing.Point(12, 11);
            this.Panel_Login.Name = "Panel_Login";
            this.Panel_Login.Size = new System.Drawing.Size(253, 344);
            this.Panel_Login.TabIndex = 2;
            // 
            // BUT_exit
            // 
            this.BUT_exit.AutoSize = true;
            this.BUT_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUT_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.BUT_exit.Location = new System.Drawing.Point(110, 274);
            this.BUT_exit.Name = "BUT_exit";
            this.BUT_exit.Size = new System.Drawing.Size(33, 16);
            this.BUT_exit.TabIndex = 14;
            this.BUT_exit.Text = "Exit";
            this.BUT_exit.Click += new System.EventHandler(this.label3_Click);
            // 
            // BUT_login
            // 
            this.BUT_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.BUT_login.FlatAppearance.BorderSize = 0;
            this.BUT_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUT_login.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUT_login.ForeColor = System.Drawing.Color.White;
            this.BUT_login.Location = new System.Drawing.Point(18, 233);
            this.BUT_login.Name = "BUT_login";
            this.BUT_login.Size = new System.Drawing.Size(216, 29);
            this.BUT_login.TabIndex = 13;
            this.BUT_login.Text = "LOG IN";
            this.BUT_login.UseVisualStyleBackColor = false;
            this.BUT_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // LB_ClearFields
            // 
            this.LB_ClearFields.AutoSize = true;
            this.LB_ClearFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ClearFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.LB_ClearFields.Location = new System.Drawing.Point(145, 198);
            this.LB_ClearFields.Name = "LB_ClearFields";
            this.LB_ClearFields.Size = new System.Drawing.Size(92, 16);
            this.LB_ClearFields.TabIndex = 12;
            this.LB_ClearFields.Text = "Clear Fields";
            this.LB_ClearFields.Click += new System.EventHandler(this.label2_Click);
            // 
            // TB_Password
            // 
            this.TB_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.TB_Password.Location = new System.Drawing.Point(49, 152);
            this.TB_Password.Multiline = true;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(188, 22);
            this.TB_Password.TabIndex = 11;
            // 
            // PB_Password
            // 
            this.PB_Password.Image = ((System.Drawing.Image)(resources.GetObject("PB_Password.Image")));
            this.PB_Password.Location = new System.Drawing.Point(18, 150);
            this.PB_Password.Name = "PB_Password";
            this.PB_Password.Size = new System.Drawing.Size(25, 23);
            this.PB_Password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Password.TabIndex = 10;
            this.PB_Password.TabStop = false;
            // 
            // TB_UserName
            // 
            this.TB_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.TB_UserName.Location = new System.Drawing.Point(49, 116);
            this.TB_UserName.Multiline = true;
            this.TB_UserName.Name = "TB_UserName";
            this.TB_UserName.Size = new System.Drawing.Size(188, 22);
            this.TB_UserName.TabIndex = 9;
            // 
            // PB_UserName
            // 
            this.PB_UserName.Image = ((System.Drawing.Image)(resources.GetObject("PB_UserName.Image")));
            this.PB_UserName.Location = new System.Drawing.Point(18, 116);
            this.PB_UserName.Name = "PB_UserName";
            this.PB_UserName.Size = new System.Drawing.Size(25, 23);
            this.PB_UserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_UserName.TabIndex = 7;
            this.PB_UserName.TabStop = false;
            // 
            // Label_LoginLogo
            // 
            this.Label_LoginLogo.AutoSize = true;
            this.Label_LoginLogo.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LoginLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.Label_LoginLogo.Location = new System.Drawing.Point(69, 56);
            this.Label_LoginLogo.Name = "Label_LoginLogo";
            this.Label_LoginLogo.Size = new System.Drawing.Size(114, 36);
            this.Label_LoginLogo.TabIndex = 2;
            this.Label_LoginLogo.Text = "LOG IN";
            // 
            // PB_LoginLogo
            // 
            this.PB_LoginLogo.Image = ((System.Drawing.Image)(resources.GetObject("PB_LoginLogo.Image")));
            this.PB_LoginLogo.Location = new System.Drawing.Point(101, 13);
            this.PB_LoginLogo.Name = "PB_LoginLogo";
            this.PB_LoginLogo.Size = new System.Drawing.Size(51, 41);
            this.PB_LoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_LoginLogo.TabIndex = 1;
            this.PB_LoginLogo.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(279, 366);
            this.Controls.Add(this.Panel_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Panel_Login.ResumeLayout(false);
            this.Panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LoginLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Login;
        private System.Windows.Forms.Label BUT_exit;
        private System.Windows.Forms.Button BUT_login;
        private System.Windows.Forms.Label LB_ClearFields;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.PictureBox PB_Password;
        private System.Windows.Forms.TextBox TB_UserName;
        private System.Windows.Forms.PictureBox PB_UserName;
        private System.Windows.Forms.Label Label_LoginLogo;
        private System.Windows.Forms.PictureBox PB_LoginLogo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

