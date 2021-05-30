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

namespace SQLChecker2021
{
    public partial class login : Form
    {


        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string connectionString;
            SqlConnection conn;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            connectionString = connectionString.Replace("\\bin\\Debug", "");
            Console.WriteLine(connectionString);
            //\bin\Debug
            //connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilig\source\repos\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            conn.Open();
            //MessageBox.Show("Connection Open " + connectionString);
            conn.Close();

            new form1().Show();
            this.Hide();

            /*
            if (txtUserName.Text == "demo" && txtpassword.Text == "1234")
            {
                new form1().Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("The User name or password you entered is incorrect, try again");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }
            */
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TB_UserName.Clear();
            TB_Password.Clear();
            TB_UserName.Focus();
        }
    }
 }

