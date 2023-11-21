
namespace Latest_27_05
{
    partial class frmSetting
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
            this.ansFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.databaseLocation = new System.Windows.Forms.OpenFileDialog();
            this.reportLocation = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportImport = new System.Windows.Forms.Button();
            this.ansImport = new System.Windows.Forms.Button();
            this.databasereportImport = new System.Windows.Forms.Button();
            this.ans_location = new System.Windows.Forms.TextBox();
            this.studentAnswerLocation = new System.Windows.Forms.Label();
            this.excel_location = new System.Windows.Forms.TextBox();
            this.excal_location = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.sampleDatabaseTextbox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exportLabel = new System.Windows.Forms.Label();
            this.Import = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ansFolder
            // 
            this.ansFolder.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // databaseLocation
            // 
            this.databaseLocation.FileName = "databaseLocation";
            // 
            // reportLocation
            // 
            this.reportLocation.FileName = "Report Location";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(58, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 424);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.tabPage1.Controls.Add(this.reportImport);
            this.tabPage1.Controls.Add(this.ansImport);
            this.tabPage1.Controls.Add(this.databasereportImport);
            this.tabPage1.Controls.Add(this.ans_location);
            this.tabPage1.Controls.Add(this.studentAnswerLocation);
            this.tabPage1.Controls.Add(this.excel_location);
            this.tabPage1.Controls.Add(this.excal_location);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.sampleDatabaseTextbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(771, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Location";
            // 
            // reportImport
            // 
            this.reportImport.Location = new System.Drawing.Point(604, 212);
            this.reportImport.Name = "reportImport";
            this.reportImport.Size = new System.Drawing.Size(27, 20);
            this.reportImport.TabIndex = 19;
            this.reportImport.Text = "...";
            this.reportImport.UseVisualStyleBackColor = true;
            this.reportImport.Click += new System.EventHandler(this.reportImport_Click);
            // 
            // ansImport
            // 
            this.ansImport.Location = new System.Drawing.Point(604, 171);
            this.ansImport.Name = "ansImport";
            this.ansImport.Size = new System.Drawing.Size(27, 20);
            this.ansImport.TabIndex = 18;
            this.ansImport.Text = "...";
            this.ansImport.UseVisualStyleBackColor = true;
            this.ansImport.Click += new System.EventHandler(this.ansImport_Click);
            // 
            // databasereportImport
            // 
            this.databasereportImport.Location = new System.Drawing.Point(604, 130);
            this.databasereportImport.Name = "databasereportImport";
            this.databasereportImport.Size = new System.Drawing.Size(27, 20);
            this.databasereportImport.TabIndex = 17;
            this.databasereportImport.Text = "...";
            this.databasereportImport.UseVisualStyleBackColor = true;
            this.databasereportImport.Click += new System.EventHandler(this.databasereportImport_Click);
            // 
            // ans_location
            // 
            this.ans_location.Location = new System.Drawing.Point(356, 171);
            this.ans_location.Name = "ans_location";
            this.ans_location.Size = new System.Drawing.Size(242, 20);
            this.ans_location.TabIndex = 16;
            // 
            // studentAnswerLocation
            // 
            this.studentAnswerLocation.AutoSize = true;
            this.studentAnswerLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.studentAnswerLocation.ForeColor = System.Drawing.SystemColors.Control;
            this.studentAnswerLocation.Location = new System.Drawing.Point(154, 169);
            this.studentAnswerLocation.Name = "studentAnswerLocation";
            this.studentAnswerLocation.Size = new System.Drawing.Size(196, 20);
            this.studentAnswerLocation.TabIndex = 15;
            this.studentAnswerLocation.Text = "Student Answer Location: ";
            // 
            // excel_location
            // 
            this.excel_location.Location = new System.Drawing.Point(356, 212);
            this.excel_location.Name = "excel_location";
            this.excel_location.Size = new System.Drawing.Size(242, 20);
            this.excel_location.TabIndex = 14;
            // 
            // excal_location
            // 
            this.excal_location.AutoSize = true;
            this.excal_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.excal_location.ForeColor = System.Drawing.SystemColors.Control;
            this.excal_location.Location = new System.Drawing.Point(158, 210);
            this.excal_location.Name = "excal_location";
            this.excal_location.Size = new System.Drawing.Size(192, 20);
            this.excal_location.TabIndex = 13;
            this.excal_location.Text = "Student Report Location: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(140, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sample Database Location: ";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(556, 248);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // sampleDatabaseTextbox
            // 
            this.sampleDatabaseTextbox.Location = new System.Drawing.Point(356, 130);
            this.sampleDatabaseTextbox.Name = "sampleDatabaseTextbox";
            this.sampleDatabaseTextbox.Size = new System.Drawing.Size(242, 20);
            this.sampleDatabaseTextbox.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(771, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Queries";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(418, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 290);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Import from Database";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.comboBox2.Location = new System.Drawing.Point(51, 145);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.export_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exportLabel);
            this.panel1.Controls.Add(this.Import);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(63, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 290);
            this.panel1.TabIndex = 6;
            // 
            // exportLabel
            // 
            this.exportLabel.AutoSize = true;
            this.exportLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.exportLabel.Location = new System.Drawing.Point(11, 52);
            this.exportLabel.Name = "exportLabel";
            this.exportLabel.Size = new System.Drawing.Size(233, 26);
            this.exportLabel.TabIndex = 6;
            this.exportLabel.Text = "Export to Database";
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(87, 195);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 3;
            this.Import.Text = "Export";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.comboBox1.Location = new System.Drawing.Point(25, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // frmSetting
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(899, 605);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog ansFolder;
        private System.Windows.Forms.OpenFileDialog databaseLocation;
        private System.Windows.Forms.OpenFileDialog reportLocation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button reportImport;
        private System.Windows.Forms.Button ansImport;
        private System.Windows.Forms.Button databasereportImport;
        private System.Windows.Forms.TextBox ans_location;
        private System.Windows.Forms.Label studentAnswerLocation;
        private System.Windows.Forms.TextBox excel_location;
        private System.Windows.Forms.Label excal_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox sampleDatabaseTextbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label exportLabel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}