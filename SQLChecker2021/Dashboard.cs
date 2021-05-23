using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SQLChecker2021
{
    

    public partial class form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );
        

        public form1()
        {
            
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;

            lbltitle.Text = "Dashbord";
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnDashbord_Leave_1(object sender, EventArgs e)
        {
            btnDashbord.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void btnContactUs_Leave(object sender, EventArgs e)
        {
            btnContactUs.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashbord_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashbord.Height;
            pnlNav.Top = btnDashbord.Top;
            pnlNav.Left = btnDashbord.Left;
            btnDashbord.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Dashbord";
            this.pnlFormLoader.Controls.Clear();
            frmDashboard frmDashboard_vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_vrb);
            frmDashboard_vrb.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnalytics_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = btnQueries.Height;
            pnlNav.Top = btnQueries.Top;
            pnlNav.Left = btnQueries.Left;
            btnQueries.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Queries Setting";
            this.pnlFormLoader.Controls.Clear();
            frmQueries frmQueries_vrb = new frmQueries() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmQueries_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmQueries_vrb);
            frmQueries_vrb.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQueries_Leave(object sender, EventArgs e)
        {
            btnQueries.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalender_Leave(object sender, EventArgs e)
        {
            btnCalender.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnQueries.Height;
            pnlNav.Top = btnQueries.Top;
            pnlNav.Left = btnQueries.Left;
            btnQueries.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Setting";
            this.pnlFormLoader.Controls.Clear();
            frmSetting frmSetting_vrb = new frmSetting() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmSetting_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmSetting_vrb);
            frmSetting_vrb.Show();
        }
    }
}
