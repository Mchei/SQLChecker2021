using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;

namespace Latest_27_05
{


    public partial class frmSetting : Form
    {

        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            sampleDatabaseTextbox.Text = Properties.Settings.Default.Sample_location;
            excel_location.Text = Properties.Settings.Default.Excel_location;
            ans_location.Text = Properties.Settings.Default.ans_location;

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

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Sample_location = sampleDatabaseTextbox.Text;
            Properties.Settings.Default.Excel_location = excel_location.Text;
            Properties.Settings.Default.ans_location = ans_location.Text;
            Properties.Settings.Default.Save();
            frmQueries frm = new frmQueries(sampleDatabaseTextbox.Text, excal_location.Text, ans_location.Text);

            MessageBox.Show("Paths saved!");
        }

        public List<string> ans_location_string()
        {
            string[] path = Directory.GetFiles(@Properties.Settings.Default.ans_location);
            List<string> ansFile = new List<string>();
            foreach (string i in path)
            {
                Console.WriteLine(i);
                ansFile.Add(i);
            }
            return ansFile;
        }

        private void databasereportImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "mdf";
            openFileDialog1.Filter = "mdf files (*.mdf)|*.mdf";
            openFileDialog1.Title = "Open Sample Answer Database";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sampleDatabaseTextbox.Text = openFileDialog1.FileName;
            }
        }

        private void ansImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                ans_location.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void reportImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                sampleDatabaseTextbox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        string query1;
        string query2;
        string query3;
        string query4;
        string query5;
        List<string> query = new List<string>();


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
                string combo = comboBox2.SelectedItem.ToString();
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
                MessageBox.Show("Queries Imported!");
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
            }
            catch (Exception e)
            {
                MessageBox.Show("Select difficulty may not contain enough data!");
            }

        }

    }
    public class Export //custom list
    {
        public int ID { get; set; }  // can be more then 1
        public string query { get; set; }  // only 2 but different aID
        public string diff { get; set; } // only 1 for selection of aID and bID
    }
}
