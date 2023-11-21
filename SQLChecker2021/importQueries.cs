using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latest_27_05
{
    public partial class importQueries : Form
    {
        public importQueries()
        {
            InitializeComponent();
        }
        string query1;
        string query2;
        string query3;
        string query4;
        string query5;
        List<string> query = new List<string>();

        private void importQueries_Load(object sender, EventArgs e)
        {
            query1 = Properties.Settings.Default.query1;
            query2 = Properties.Settings.Default.query2;
            query3 = Properties.Settings.Default.query3;
            query4 = Properties.Settings.Default.query4;
            query5 = Properties.Settings.Default.query5;

            query.Add(query1);
            query.Add(query2);
            query.Add(query3);
            query.Add(query4);
            query.Add(query5);
            Console.WriteLine(query[0]);
        }

        private void Import_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string connectionString;
            SqlConnection conn;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            conn.Open();
            for (int i = 0; i < query.Count; i++)
            {
                string queryString = "INSERT INTO SQLChecker_queries VALUES(@query, @diff)";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                string queryIn = query[i];
                string combo = comboBox1.SelectedItem.ToString();
                cmd.Parameters.AddWithValue("@query", queryIn);
                cmd.Parameters.AddWithValue("@diff", combo);
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Records Inserted Successfully: " + queryIn + " " + combo);
            }
            conn.Close();
            MessageBox.Show("Queries Exported!");
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
