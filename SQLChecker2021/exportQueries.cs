using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Latest_27_05
{

    public partial class exportQueries : Form
    {
        
        public exportQueries()
        {
            InitializeComponent();
        }

        private void exportQueries_Load(object sender, EventArgs e)
        {
            
        }
        List<Export> export = new List<Export>();
        private void export_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string connectionString;
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string combo = comboBox1.SelectedItem.ToString();
                string queryString = "SELECT * FROM SQLChecker_queries WHERE diff = @diff";
                SqlCommand cmd = new SqlCommand(queryString, conn);

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@diff";
                param.Value = combo;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Export f = new Export();
                    //f.ID = int.Parse((string)reader["ID"]);
                    //Console.WriteLine(reader["ID"]);
                    f.query = (string)reader["query"];
                    f.diff = (string)reader["diff"];
                    export.Add(f);
                }
                conn.Close();
                //cmd.ExecuteNonQuery();
                setup(export);
                MessageBox.Show("Queries Exported!");
                this.Close();
            }
        }

        private void setup(List<Export> exports)
        {
            try
            {
                Random r = new Random();
                Console.WriteLine(exports.Count);
                Console.WriteLine("E" + exports[3].query);
                //int rInt = r.Next(2,export.Count); //for ints
                //List<int> exist = new List<int>();
                //exist.Add(rInt);
                Properties.Settings.Default.query1 = exports[3].query;
                Properties.Settings.Default.Save();
                this.Close();
                new Dashboard().Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Select difficulty may not contain enough data!");
            }

        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            new Dashboard().Show();
        }
    }
}
