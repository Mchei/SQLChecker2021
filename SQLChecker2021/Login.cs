using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;

namespace Latest_27_05
{
    public partial class Login : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Login()
        {
            InitializeComponent();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string connectionString;
            SqlConnection conn;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            //connectionString = connectionString.Replace("\\bin\\Debug", "");
            //Console.WriteLine(connectionString);
            //\bin\Debug
            //connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilig\source\repos\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            conn.Open();
            //MessageBox.Show("Connection Open " + connectionString);

            conn.Close();

            if(txtUserName.Text == "admin")
            {
                if(txtpassword.Text == "1234")
                {
                    Properties.Settings.Default.username = txtUserName.Text;
                    Properties.Settings.Default.password = txtpassword.Text;
                    Properties.Settings.Default.Save();
                    new Dashboard().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong Username!");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.username;
            txtpassword.Text = Properties.Settings.Default.password;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void login_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void login_panel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void login_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
