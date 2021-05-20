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
using System.Collections;

namespace SQLChecker2021
{
    public partial class frmQueries : Form
    {
        List<string> tableName;
        List<string> colName;

        public frmQueries()
        {
            InitializeComponent();
            tableName = new List<string>();
            colName = new List<string>();

            tableName = GetTables();
            getCol();
        }

        private void executeButton1_Click(object sender, EventArgs e)
        {
            checkSQL(query1.Text, 1);
            checkSQL(query2.Text, 2);
            checkSQL(query3.Text, 3);
            checkSQL(query4.Text, 4);
            checkSQL(query5.Text, 5);
        }
        private void executeButton2_Click(object sender, EventArgs e)
        {
            checkSQL(query6.Text, 6);
            checkSQL(query7.Text, 7);
            checkSQL(query8.Text, 8);
            checkSQL(query9.Text, 9);
            checkSQL(query10.Text, 10);
        }

        private void executeButton3_Click(object sender, EventArgs e)
        {
            checkSQL(query11.Text, 11);
            checkSQL(query12.Text, 12);
            checkSQL(query13.Text, 13);
            checkSQL(query14.Text, 14);
            checkSQL(query15.Text, 15);
        }

        public bool checkSQL(string sql,int num)
        {

            //SELECT * FROM Account;
            if (!sql.Equals("", StringComparison.OrdinalIgnoreCase))
            {
                List<string> sqlPart = new List<string>();
                sql = sql.Replace(";", ""); //delete ; 
                sqlPart = sql.Split(' ').ToList();//

                //check sql select
                //root.Equals(root2, StringComparison.OrdinalIgnoreCase);
                //https://docs.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings
                if (!sqlPart[0].Equals("select", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Query " + num + " | Select wrong. Is it spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // SELECT username,userId,password FROM Account;
                //  [0]    [1]                      [2]    [3]  
                // check columnName and *
                // also check column Name

                // kill all space inside sqlPart[1]
                // TODO: kill all space
                sqlPart[1] = sqlPart[1].Replace(" ", "");

                // check if columnName exist in colName list<string>
                List<string> sqlColumnName = new List<string>();
                sqlColumnName = sqlPart[1].Split(',').ToList();
                bool columnNameExist = true;    //
                for (int i = 0; i < sqlColumnName.Count; i++)
                {
                    // check exist
                    if (colName.Contains(sqlColumnName[i]) == false)    //
                    {
                        columnNameExist = false;
                    }
                }


                if (!sqlPart[1].Equals("*", StringComparison.OrdinalIgnoreCase) && columnNameExist == false)
                {
                    MessageBox.Show("Query " + num + " | Column Name is wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                if (!sqlPart[2].Equals("from", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Query " + num + " | From wrong (may have a space?)", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check if table Name exist in tableName list<string>         

                // check exist
                if (tableName.Contains(sqlPart[3]) == false)
                {
                    MessageBox.Show("Query " + num + " | Tablename wrong, not exist or Spelling error?", "Error Message", MessageBoxButtons.OK);
                    return false;
                }


                // check groupby or orderby
                // SELECT * FROM Account GROUP BY username;
                //  [0]  [1] [2]   [3]    [4]  [5]   [6]

                if (sqlPart.Count > 4)
                {
                    // check whether is group by or order by or not
                    if (sqlPart[4].Equals("group", StringComparison.OrdinalIgnoreCase) || sqlPart[4].Equals("order", StringComparison.OrdinalIgnoreCase))
                    {
                        if (sqlPart[5].Equals("by", StringComparison.OrdinalIgnoreCase))
                        {
                            // check column Name
                            // check exist
                            if (colName.Contains(sqlPart[6]) == false)
                            {
                                MessageBox.Show("Query " + num + " | Group/order by column name is not exist.", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Query " + num + " | Group/order by is wrong.", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }

                    }
                    else if (sqlPart[4].Equals("where", StringComparison.OrdinalIgnoreCase))
                    {
                        // SELECT * FROM Account WHERE userId = 'Mexico';
                        //  [0]  [1] [2]   [3]    [4]   [5]  [6]   [7]
                        // check column Name
                        // check exist
                        if (colName.Contains(sqlPart[5]) == false)
                        {
                            MessageBox.Show("Query " + num + " | Where column name is not exist", "Error Message", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            // find the column name successful
                            // check =
                            if (!sqlPart[6].Equals("=", StringComparison.OrdinalIgnoreCase) && !sqlPart[6].Equals("!=", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show("Query " + num + " | = is wrong", "Error Message", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Query " + num + " | Where/group by/order by is wrong", "Error Message", MessageBoxButtons.OK);
                        return false;
                    }
                }
                Console.WriteLine("Query " + num + " | No error :)");
                return true;
            }
            return false;
        }

        // get all column name and store in into a colName
        public void getCol()
        {
            DataTable schema = null;
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            connectionString = connectionString.Replace("\\bin\\Debug", "");
            for (int i = 0; i < tableName.Count; i++) 
            { 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var schemaCommand = new SqlCommand("SELECT * FROM "+ tableName [i]+ ";", connection))
                    {
                        connection.Open();
                        using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                        {
                            schema = reader.GetSchemaTable();
                        }
                    }
                }
                foreach (DataRow col in schema.Rows)
                {
                    colName.Add(col.Field<String>("ColumnName"));
                    //Console.WriteLine("ColumnName={0}", col.Field<String>("ColumnName"));
                }
            }
        }

        // get all table name and store in into a tableName
        public static List<string> GetTables()
        {
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            //connectionString = connectionString.Replace("\\bin\\Debug", "");
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                    
                    //Console.WriteLine("row[2].ToString(): " + row[2].ToString());
                }
                connection.Close();
                return TableNames;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
