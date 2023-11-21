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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using JoinCheck = Latest_27_05.JoinCheck;
using System.IO;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Threading;

namespace Latest_27_05
{
    public partial class frmQueries : Form
    {
        frmSetting frmSetting = new frmSetting();
        private static frmQueries staticQueries;
        //ansChecker
        //IList<string> answerColumns = new List<string>();
        List<string> tableName;
        static List<List<string>> colList = new List<List<string>>();

        static List<string> colName1;
        static List<string> colName2;
        static List<string> colName3;
        

        //studentChecker
        List<string> stuTableName;
        List<string> stuColName;
        List<List<string>> stuColList = new List<List<string>>();
        public string QueryOne;
        public string QueryTwo;
        public string QueryThree;

        //excel import
        //private int rowCnt;
        //List<string> QueryOneList;
        //List<string> QueryTwoList;
        //List<string> QueryThreeList;
        //List<string> QueryFourList;
        //List<string> QueryFiveList;
        //List<string> IDList;

        public string sampleQueryLocation;
        public string ansFolderName;
        public string excel_folder;

        //Deduction
        //getCol()
        public static int colRecord;

        //Answer file Import
        string ansLine = "";


        public frmQueries(string sampleQueryLocation, string excel_folder, string ansFolderName)
        {
            InitializeComponent();
            this.sampleQueryLocation = sampleQueryLocation;
            this.excel_location = excel_folder;
            this.ansFolderName = ansFolderName;

        }
        public frmQueries()
        {
            InitializeComponent();

            tableName = new List<string>();
            colName1 = new List<string>();
            colName2 = new List<string>();
            colName3 = new List<string>();
            stuTableName = new List<string>();
            stuColName = new List<string>();
            staticQueries = this;

        }
        public string ansQuery;
        public string excel_location;
        public string connectionString;
        public int studentCount;

        List<string> StuCheckerRows = new List<string>();
        List<string> AnsCheckerRows = new List<string>();

        List<string> StuCheckerCols = new List<string>();
        List<string> AnsCheckerCols = new List<string>();

        long stuSqlTime = 0;
        long ansSqlTime = 0;

        private void executeButton_Click(object sender, EventArgs e)
        {
            execute();
            saveTempData();
        }

        private void execute()
        {
            int mark = 5;
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + sampleQueryLocation + ";Integrated Security=True;Connection Timeout=30;Min Pool Size=50;Max Pool Size=1000;Pooling=true;";
                List<student> students = new List<student>();
                students = ansReaderFunction();
                List<studentReport> report = new List<studentReport>();
                StuCheckerRows.Clear();
                StuCheckerCols.Clear();
                AnsCheckerCols.Clear();
                AnsCheckerRows.Clear();
                stuSqlTime = 0;
                ansSqlTime = 0;

                for (int i = 0; i < students.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(students[i].Query) == false || string.IsNullOrWhiteSpace(students[i].StudentID) == false)
                    {
                        string[] ansQuery = new string[] { "Q1001", "Q1002", "Q1003", "Q1004", "Q1005", "Q1006", "Q1007", "Q1008", "Q1009", "Q1010"
                                                         , "Q1011", "Q1012", "Q1013", "Q1014", "Q1015"};
                        string[] ansMark = new string[] { "markOne", "markTwo", "markThree", "markFour", "markFive", "mark6", "mark7", "mark8", "mark9", "mark10",
                                                         "mark11", "mark12", "mark13", "mark14", "mark15"};
                        Console.WriteLine("Debug executeButton | Students ID: " + students[i].StudentID); //Check Student Query
                        //Console.WriteLine("Debug executeButton | Students Query: " + students[i].Query); //Check Student Query

                        for (int w = 0; w < 8; w++)
                        {
                            StuCheckerRows = JoinCheck.JoinCheckQueryTest(connectionString, students[i].Query);
                            stuSqlTime = JoinCheck.sqlExecutionTime();

                        }

                        StuCheckerCols = getStuCol(connectionString, students[i].Query);
                        Control[] ansQueryTextBox = this.Controls.Find(students[i].questionNo, true);
                        //Control[] ansMarkTextBox = this.Controls.Find(ansMark[5], true);
                        //Console.WriteLine("Debug executeButton | Students Rows: " + StuCheckerRows[0]); //Check Student Rows
                        int c = 0;
                        foreach (string item in ansQuery)
                        {
                            if (item.Equals(students[i].questionNo))
                            {
                                Control[] ansMarkTextBox = this.Controls.Find(ansMark[c], true);
                                mark = Int32.Parse(ansMarkTextBox[0].Text);
                            }
                            else
                            {
                                c++;
                            }
                        }

                        for (int w = 0; w < 8; w++)
                        {
                            AnsCheckerRows = JoinCheck.AnswerQuery(connectionString, ansQueryTextBox[0].Text); //Return Answer affacted Rows
                            ansSqlTime = JoinCheck.sqlExecutionTime();
                        }

                        AnsCheckerCols = getAnsCol(connectionString, ansQueryTextBox[0].Text);
                        //Console.WriteLine(checker[c]);
                        report = compareAnswer(mark, students[i].StudentID, students[i].questionNo, StuCheckerRows, AnsCheckerRows, StuCheckerCols, AnsCheckerCols, stuSqlTime, ansSqlTime);
                        //Console.WriteLine("Debug executeButton | Reports: " + report[i].getStudentReport());
                    }
                    else
                    {
                        //Console.WriteLine("Debug executeButton | Students Rows Done Reading"); //Check Student Rows
                        break;
                    }
                    AnsCheckerRows.Clear();
                }
                MessageBox.Show("SQL Checker has checked: " + report.Count());
                var userList = report;
                try
                {

                    //string fileName = "UserManager.xlsx";
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Browse Execel file";
                    saveFileDialog1.DefaultExt = "xlsx";
                    saveFileDialog1.Filter = "excel files (*.xlsx)|*.xlsx";
                    if (!String.IsNullOrEmpty(Properties.Settings.Default.Excel_location))
                    {
                        saveFileDialog1.InitialDirectory = Properties.Settings.Default.Excel_location;
                    }
                    saveFileDialog1.ShowDialog();
                    string customExcelSavingPath = saveFileDialog1.FileName;
                    Properties.Settings.Default.ReportPath = customExcelSavingPath;
                    ExcelExport.GenerateExcel(ConvertToDataTable(userList), DataTableCopy(ConvertToDataTable(userList),
                                                customExcelSavingPath), customExcelSavingPath);

                }
                catch (Exception ex)
                {
                    report.Clear();
                    MessageBox.Show("Excel export failed!\n" + ex.Message);

                }
            }
            catch (Exception error)
            {
                //MessageBox.Show("Please check if Sample Database Location/student Answer Location have been set in setting page! \n" + error.Message);
                MessageBox.Show(error.Message);
            }
        }

        List<studentReport> studentsReport = new List<studentReport>();
        public int d = 1;
        //CompareAnswer Default Marks = 5 (Need to be Modify)
        //CompareAnswer Default Deduction for "Wrong Column Name but same rows" = -2
        //CompareAnswer Default Deduction for "Correct Column Name but different rows" = -3
        public List<studentReport> compareAnswer(int mark, string studentID,string queryNo, List<string> studentRows, List<string> answerRows, List<string> studentCol, List<string> answerCol, long stuTime, long ansTime)
        {
            try
            {
                int marks = mark;
                string StudentID = studentID;
                string error;
                //Console.WriteLine(studentID + " AnswerCol Count: " + answerCol.Count + " StudentCol Count: " + studentCol.Count);
                //Compare Column Count then Column Name
                if (studentsReport != null)
                {
                    if (answerCol.Count == studentCol.Count)
                    {
                        //Console.WriteLine(studentID + " AnswerCol Count: " + answerCol.Count + " StudentCol Count: " + studentCol.Count);
                        int colChecker = 0;
                        for (int i = 0; i < answerCol.Count; i++)
                        {
                            Console.WriteLine(studentID + " AnswerCol name: " + answerCol[i] + " StudentCol name: " + studentCol[i]);
                            if (string.Equals(answerCol[i], studentCol[i], StringComparison.OrdinalIgnoreCase))
                            {
                                colChecker++;
                            }
                        }
                        if (colChecker == answerCol.Count) //Pass Column Test
                        {
                            error = "Column Name Test Passed | Marks + 2";
                            Console.WriteLine(studentID + " Column Name Test Passed | Marks +2 | Rows will now be checked!");
                        }
                        else
                        {
                            error = "Column Name Test Failed | Marks -2";
                            Console.WriteLine(studentID + " Column Name Test Failed | Marks -2 | Rows will now be checked!");
                            marks = marks - 2;
                        }
                    }
                    else
                    {
                        error = "Column Count Test Failed | Marks -2";
                        Console.WriteLine(studentID + " Column Count Test Failed | Marks -2 | Rows will now be checked!");
                        marks = marks - 2;
                    }

                    if (studentRows.Count == answerRows.Count)
                    {
                        int rowChecker = 0;
                        int i = 0;

                        foreach (string item in studentRows)
                        {
                            //Console.WriteLine(item);
                            if (answerRows.Contains(item))
                            {
                                //Console.WriteLine(answerRows[i]);
                                i++;
                                rowChecker++;
                            }
                            else
                            {
                                //Console.WriteLine("Student | " + item);
                                //Console.WriteLine("ANS | " + answerRows[i]);
                                i++;
                            }
                        }
                        if (rowChecker == answerRows.Count) //Pass Column Test
                        {
                            error = error + "| Row(s) Name Test Passed | Marks + 3";
                            //Now do an efficiency compare, if the first one 40 still pass 
                            if (stuSqlTime <= ansSqlTime)
                            {
                                error = error + "| Efficiency check Passed | ";
                                d++; //For Checking if this is the first Question
                                //Console.WriteLine("D" + d, " AnsTime: " + ansSqlTime + " StuTime " + stuSqlTime);
                            }
                            else
                            {
                                marks = marks - 1;
                                error = error + "| Efficiency check Failed | ";
                                //Console.WriteLine(studentID + " | Efficiency check Failed | Marks: " + marks);
                                d++; //For Checking if this is the first Question
                                //Console.WriteLine("D" + d);
                            }

                            //Console.WriteLine(studentID + " Test Passed | Marks " + marks);
                        }
                        else
                        {
                            error = error + "Row(s) Name Test Failed | Marks -3";
                            //Console.WriteLine(studentID + " Row(s) Name Test Failed | Marks - 3");
                            marks = marks - 3;
                            d++;
                        }
                        //Console.WriteLine("Passed | Student Rows: " + studentRows.Count + " Answer Rows: " + answerRows.Count);
                        //marks = 5;
                        //error = "Query Passed all test!";
                    }
                    else
                    {
                        error = error + " Row(s) Count Test Failed | Marks - 3";
                        //Console.WriteLine(studentID + " Rows(s) Count Test Failed | Marks -3");
                        marks = marks - 3;
                        d++;
                    }
                    studentsReport.Add(new studentReport { StudentID = studentID, error = error, questionNo = queryNo, score = marks, CreatedOn = DateTime.Now, executionTime = stuTime });
                    return studentsReport;
                }
                else
                {
                    if (answerCol.Count == studentCol.Count)
                    {
                        //Console.WriteLine(studentID + " AnswerCol Count: " + answerCol.Count + " StudentCol Count: " + studentCol.Count);
                        int colChecker = 0;
                        for (int i = 0; i < answerCol.Count; i++)
                        {
                            //Console.WriteLine(studentID + " AnswerCol name: " + answerCol[i] + " StudentCol name: " + studentCol[i]);
                            if (string.Equals(answerCol[i], studentCol[i], StringComparison.OrdinalIgnoreCase))
                            {
                                colChecker++;
                            }
                        }
                        if (colChecker == answerCol.Count) //Pass Column Test
                        {
                            error = "Column Name Test Passed | Marks + 2";
                            //Console.WriteLine(studentID + " Column Name Test Passed | Marks +2 | Rows will now be checked!");
                        }
                        else
                        {
                            error = "Column Name Test Failed | Marks -2";
                            //Console.WriteLine(studentID + " Column Name Test Failed | Marks -2 | Rows will now be checked!");
                            marks = marks - 2;
                        }
                    }
                    else
                    {
                        error = "Column Count Test Failed | Marks -2";
                        //Console.WriteLine(studentID + " Column Count Test Failed | Marks -2 | Rows will now be checked!");
                    }

                    if (studentRows.Count == answerRows.Count)
                    {
                        int rowChecker = 0;
                        int i = 0;
                        foreach (string item in studentRows)
                        {
                            //Console.WriteLine(item);
                            if (answerRows.Contains(item))
                            {
                                //Console.WriteLine(answerRows[i]);
                                i++;
                                rowChecker++;
                            }
                            else
                            {
                                //Console.WriteLine("Student | " + item);
                                //Console.WriteLine("ANS | " + answerRows[i]);
                                i++;
                            }
                        }
                        if (rowChecker == answerRows.Count) //Pass Column Test
                        {
                            error = "Row(s) Name Test Passed | Marks + 3";
                            //Console.WriteLine(studentID + " Row(s) Name Test Passed | Marks " + marks);
                        }
                        else
                        {
                            error = "Row(s) Name Test Failed | Marks -3";
                            //Console.WriteLine(studentID + " Row(s) Name Test Failed | Marks - 3");
                            marks = marks - 3;
                        }
                    }
                    else
                    {
                        error = "Row(s) Count Test Failed | Marks - 3";
                       // Console.WriteLine(studentID + " Rows(s) Count Test Failed | Marks -3");
                        marks = marks - 3;
                    }
                    studentsReport.Add(new studentReport { StudentID = studentID, error = error, questionNo = queryNo, score = marks, CreatedOn = DateTime.Now, executionTime = stuTime });
                    return studentsReport;
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }
        public int numberOfRecords;
        static DataTable ConvertToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties of that model  
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Loop through all the properties              
            // Adding Column name to our datatable  
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names    
                dataTable.Columns.Add(prop.Name);
            }

            // Adding Row and its value to our dataTable  
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    Console.WriteLine(item);
                    //inserting property values to datatable rows    
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable    
                dataTable.Rows.Add(values);
            }
           

            return dataTable;
        }

        static DataTable DataTableCopy(DataTable dt, string customExcelSavingPath)
        {
            DataTable dt_copy = new DataTable();
            dt_copy.TableName = "StudentScore";
            dt_copy.Columns.Add("StudentID", typeof(string));
            dt_copy.Columns.Add("Question");
            dt_copy.Columns.Add("Score");
            //dt_copy = dt.Copy();

            DataTable dtFinal = dt.AsEnumerable()
                                .GroupBy(r => r["StudentID"])
                                .Select(x => 
                                {
                                    var row = dt_copy.NewRow();
                                    row["StudentID"] = x.Key;
                                    row["Question"] = x.Count();
                                    row["Score"] = x.Sum(r => Convert.ToInt32(r["score"]));
                                    return row;
                                }).CopyToDataTable();

            var query = from r in dt.AsEnumerable()
                        group r by r.Field<int>(0) into groupedTable
                        select new
                        {
                            id = groupedTable.Key,
                            sumOfValue = groupedTable.Sum(s => s.Field<decimal>("Value"))
                        };

            return dtFinal;
        }


        public List<List<string>> AnsRows(string connectionString) //Checking Sample Answer
        {
            string[] ansQuery = new string[] { "query1", "query2", "query3", "query4", "query5"};

            List<List<string>> SampleAnswerChecker = new List<List<string>>();
            //SampleAnswerChecker.Clear();
            for (int i = 0; i < 5; i++)
            {
                    Control[] ansQueryTextBox = this.Controls.Find(ansQuery[i], true);
                    SampleAnswerChecker.Add(JoinCheck.AnswerQuery(connectionString, ansQueryTextBox[0].Text));

                    //Console.WriteLine("Debug ANS | " + SampleAnswerChecker[i][0]);
                    //return SampleAnswerChecker;
            }
            return SampleAnswerChecker;

        }
        
        public bool ansSQLChecker(List<string> ansChecker) //Basic SQL Select checker -- version 1.0 of checker
            {
            //tableName = GetTables(connectionString);
            //getCol(connectionString, tableName, sql);
            List<string> SampleAnswerChecker = new List<string>();
            SampleAnswerChecker = ansChecker;

            List<string> StudentAnswerChecker = new List<string>();

            try
            {
                if(SampleAnswerChecker.Count == 1)
                {
                    //Console.WriteLine("Debug ansSQLChecker | Returned 1" );
                    return true;
                }
                else if(SampleAnswerChecker.Count == 16)
                {
                    //Console.WriteLine("Debug ansSQLChecker | Returned 16");
                    return true;
                }
                else
                {
                    return false;
                }


            }catch (Exception e)
            {
                return false;
            }

        }
        
        public static List<string> getStuCol(string connectionString, string sqlCommand) //Method to Return Columns Name and Number
        {
            DataTable schema = null;
            colName1.Clear();

            //staticQueries.Q1001.Enabled = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var schemaCommand = new SqlCommand(sqlCommand, connection);
                connection.Open();
                var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly);
                schema = reader.GetSchemaTable();

                foreach (DataRow col in schema.Rows)
                {
                    colName1.Add(col.Field<String>("ColumnName"));
                    colRecord++;
                }

                connection.Close();
                //colList.Add(colName1);
                //Console.WriteLine("Debug getCol | Column subList check: " + String.Join(", ", colName1));
                return colName1;
                    //
                    //Console.WriteLine("Debug getCol | Column List check: " + colList[0][0]);
            }
        }

        public static List<string> getAnsCol(string connectionString, string sqlCommand) //Method to Return Columns Name and Number
        {
            DataTable schema = null;
            colName2.Clear();

            //staticQueries.Q1001.Enabled = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var schemaCommand = new SqlCommand(sqlCommand, connection);
                connection.Open();
                var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly);
                schema = reader.GetSchemaTable();

                foreach (DataRow col in schema.Rows)
                {
                    colName2.Add(col.Field<String>("ColumnName"));
                    colRecord++;
                }

                connection.Close();
                //colList.Add(colName1);
                //Console.WriteLine("Debug getCol | Column subList check: " + String.Join(", ", colName1));
                return colName2;
                //
                //Console.WriteLine("Debug getCol | Column List check: " + colList[0][0]);
            }
        }

        public static List<string> GetStudentTables(string connectionString, string table)
        {

            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jeffe\Source\Repos\Mchei\SQLChecker2021\SQLChecker2021\SQLProjectDB.mdf;Integrated Security=True";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startupPath + "\\SQLProjectDB.mdf;Integrated Security=True";
            //connectionString = connectionString.Replace("\\bin\\Debug", "");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> stuTableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    stuTableNames.Add(row[2].ToString());

                    //Console.WriteLine("row[2].ToString(): " + row[2].ToString());
                }
                connection.Close();
                return stuTableNames;
            }
        }

        public void getStudentCol(string connectionString, List<string> stuTable, string sqlCommand)
        {
            DataTable schema = null;
            if (stuColName.Count == 0)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var schemaCommand = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();
                        using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                        {
                            
                            schema = reader.GetSchemaTable();
                            foreach (DataRow col in schema.Rows)
                            {
                                stuColName.Add(col.Field<String>("ColumnName"));
                                //Console.WriteLine("Debug getStudentCol | Column check: " + String.Join(", ", stuColName));
                            }
                            this.stuColList.Add(stuColName);

                            //numberOfRecords = insertColReturn(connectionString, null);
                            getColSingle(connectionString, sqlCommand);
                            //testQuery(connectionString, sqlCommand);


                            //Console.WriteLine("Debug getCol | getColSingle: " + numberOfRecords);
                            //Console.WriteLine("Debug | Column subList check: " + String.Join(", ", stuColName));
                            //Console.WriteLine("Debug | Student Column List check: " + stuColList[0][0]);
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                stuColName.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var schemaCommand = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();
                        using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                        {
                            schema = reader.GetSchemaTable();
                            foreach (DataRow col in schema.Rows)
                            {
                                stuColName.Add(col.Field<String>("ColumnName"));
                                //Console.WriteLine("Debug getStudentCol | Column check: " + String.Join(", ", stuColName));
                            }
                            this.stuColList.Add(stuColName);
                            connection.Close();
                            //Console.WriteLine("Debug | Column subList check: " + String.Join(", ", stuColName));
                            //Console.WriteLine("Debug | Student Column List check: " + stuColList[0][0]);

                        }
                    }
                }
            }




        }

        public void getColSingle(string connectionString, string sqlCommand)
        {
            try
            {
               // DataTable schema = null;
                SqlConnection connection = new SqlConnection(connectionString);
                string sql = "Select Avg(userId) From Account";
                SqlCommand comd = new SqlCommand(sql, connection);
                connection.Open();
                numberOfRecords = Convert.ToInt32(comd.ExecuteScalar());
            }
            catch(Exception e)
            {
                Console.WriteLine("Debug | getColSingle: " + e.Message);
            }
        }

        private void query1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveTempData()
        {
            Properties.Settings.Default.query1 = Q1001.Text;
            Properties.Settings.Default.query2 = Q1002.Text;
            Properties.Settings.Default.query3 = Q1003.Text;
            Properties.Settings.Default.query4 = Q1004.Text;
            Properties.Settings.Default.query5 = Q1005.Text;
            Properties.Settings.Default.query6 = Q1006.Text;
            Properties.Settings.Default.query7 = Q1007.Text;
            Properties.Settings.Default.query8 = Q1008.Text;
            Properties.Settings.Default.query9 = Q1009.Text;
            Properties.Settings.Default.query10 = Q1009.Text;
            Properties.Settings.Default.query11 = Q1011.Text;
            Properties.Settings.Default.query12 = Q1012.Text;
            Properties.Settings.Default.query13 = Q1013.Text;
            Properties.Settings.Default.query14 = Q1014.Text;
            Properties.Settings.Default.query15 = Q1015.Text;

            Properties.Settings.Default.mark1 = markOne.Text;
            Properties.Settings.Default.mark2 = markTwo.Text;
            Properties.Settings.Default.mark3 = markThree.Text;
            Properties.Settings.Default.mark4 = markFour.Text;
            Properties.Settings.Default.mark5 = markFive.Text;
            Properties.Settings.Default.mark6 = mark6.Text;
            Properties.Settings.Default.mark7 = mark7.Text;
            Properties.Settings.Default.mark8 = mark8.Text;
            Properties.Settings.Default.mark9 = mark9.Text;
            Properties.Settings.Default.mark10 = mark10.Text;
            Properties.Settings.Default.mark11 = mark11.Text;
            Properties.Settings.Default.mark12 = mark12.Text;
            Properties.Settings.Default.mark13 = mark13.Text;
            Properties.Settings.Default.mark14 = mark14.Text;
            Properties.Settings.Default.mark15 = mark15.Text;
            Properties.Settings.Default.Save();
        }
        private void frmQueries_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveTempData();
        }

        private void frmQueries_FormLoad(object sender, EventArgs e)
        {
            Q1001.Text = Properties.Settings.Default.query1;
            Q1002.Text = Properties.Settings.Default.query2;
            Q1003.Text = Properties.Settings.Default.query3;
            Q1004.Text = Properties.Settings.Default.query4;
            Q1005.Text = Properties.Settings.Default.query5;
            Q1006.Text = Properties.Settings.Default.query6;
            Q1007.Text = Properties.Settings.Default.query7;
            Q1008.Text = Properties.Settings.Default.query8;
            Q1009.Text = Properties.Settings.Default.query9;
            Q1009.Text = Properties.Settings.Default.query10;
            Q1011.Text = Properties.Settings.Default.query11;
            Q1012.Text = Properties.Settings.Default.query12;
            Q1013.Text = Properties.Settings.Default.query13;
            Q1014.Text = Properties.Settings.Default.query14;
            Q1015.Text = Properties.Settings.Default.query15;

            markOne.Text = Properties.Settings.Default.mark1;
            markTwo.Text = Properties.Settings.Default.mark2;
            markThree.Text = Properties.Settings.Default.mark3;
            markFour.Text = Properties.Settings.Default.mark4;
            markFive.Text = Properties.Settings.Default.mark5;
            mark6.Text = Properties.Settings.Default.mark6;
            mark7.Text = Properties.Settings.Default.mark7;
            mark8.Text = Properties.Settings.Default.mark8;
            mark9.Text = Properties.Settings.Default.mark9;
            mark10.Text = Properties.Settings.Default.mark10;
            mark11.Text = Properties.Settings.Default.mark11;
            mark12.Text = Properties.Settings.Default.mark12;
            mark13.Text = Properties.Settings.Default.mark13;
            mark14.Text = Properties.Settings.Default.mark14;
            mark15.Text = Properties.Settings.Default.mark15;

            sampleQueryLocation = Properties.Settings.Default.Sample_location;
            excel_location = Properties.Settings.Default.Excel_location;
            ansFolderName = Properties.Settings.Default.ans_location;
        }

        public void ListToExcel(List<string> list)
        {

        }

        public string queryReader;
        public string Username;
        public string queryNo;
        private void ReadAns_Click(object sender, EventArgs e)
        {
            ansReaderFunction();
        }

        public int marks;

        private List<student> ansReaderFunction() 
        {
            List<string> ansFile = new List<string>();
            List<student> students = new List<student>();

            ansFile = frmSetting.ans_location_string();
            string fileExt = String.Empty;

            for (int i = 0; i < ansFile.Count; i++)
            {
                fileExt = Path.GetExtension(ansFile[i]);

                if (fileExt.CompareTo(".txt") == 0)
                {
                    StreamReader reader = new StreamReader(ansFile[i]);
                    StringBuilder builder = new StringBuilder();

                        //while ((ansLine = reader.ReadLine()) != null)
                        for (ansLine = reader.ReadLine(); ansLine != null; ansLine = reader.ReadLine())
                        {

                            if (ansLine.Contains("-- Username"))
                            {
                                //Console.WriteLine(ansLine);
                                List<string> usernamePart = new List<string>();

                                ansLine = ansLine.Replace("-- Username:", "");
                                usernamePart = ansLine.Split(':').ToList();
                                //Console.WriteLine(usernamePart[0].Length); 
                                if (usernamePart[0].Length > 9)
                                {
                                    Username = usernamePart[0].Trim();
                                    Username = Username.Substring(0, 9);
                                    //Console.WriteLine(Username);
                                }
                                else if (string.IsNullOrWhiteSpace(usernamePart[0]))
                                {
                                    Username = "Null";
                                    Console.WriteLine("StudentID returned null: " + ansFile[i]);
                                }
                                else
                                {
                                    Username = usernamePart[0].Trim();
                                    Username = Username.Substring(0, 8);
                                    //Console.WriteLine(Username);
                                }
                                //string contentPart = String.Join(":", usernamePart.Skip(0).ToList());
                                //Username = ansLine;
                            }else if(ansLine.Contains("-- Q100"))
                            {
                                List<string> QuestionPart = new List<string>();

                                ansLine = ansLine.Replace("-- ", "");
                                QuestionPart = ansLine.Split(' ').ToList();
                                queryNo = QuestionPart[0];
                                //Console.WriteLine(QuestionPart[0]);
                            }
                            else if (ansLine.Contains("SELECT"))
                            {
                                queryReader = ansLine + " " + reader.ReadToEnd();
                            }
                            if (string.IsNullOrWhiteSpace(Username) == false)
                            {
                                students.Add(new student());
                                students[i].StudentID = Username;
                                students[i].questionNo = queryNo;
                                students[i].Query = queryReader;
                            }
                        }
                }
            }
            //Console.WriteLine(students[1].Query);
            return students;
        }

        private void saveTemp_Click(object sender, EventArgs e)
        {
            saveTempData();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            
            new exportQueries().Show();
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            saveTempData();

            new importQueries().Show();
            this.Close();
        }
    }
}
