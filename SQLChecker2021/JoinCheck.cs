using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace Latest_27_05
{
    class JoinCheck
    {

        public static void JoinCheckQuery(string connectionString, string sqlCommand)
        {
            string queryString = "select distinct dbid, DB_NAME(dbid) FROM sys.sysprocesses where dbid > 0 ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //colLists = frmQueries.getCol(connectionString, ansTable, queryString);
                            //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);
                            Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                        }
                        reader.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine("Debug JoinCheckQuery | " + e.Message);
            }
        }
        public static List<string> rowsList = new List<string>();
        public static List<string> rowsList1 = new List<string>();
        public static List<string> rowsList2 = new List<string>();
        public static List<string> rowsList3 = new List<string>();
        public static List<string> rowsList4 = new List<string>();

        public static List<string> ArowsList = new List<string>();
        public static List<string> ArowsList1 = new List<string>();
        public static List<string> ArowsList2 = new List<string>();
        public static List<string> ArowsList3 = new List<string>();
        public static List<string> ArowsList4 = new List<string>();
        public static int colRecord;
        public static int AcolRecord;

        public static List<string> JoinCheckQueryTest(string connectionString, string sql) //Method to check Join Function
        {
            DataTable schema = null;
            //string sqlCommand = sql;

            int rowsRecord = 0;
            rowsList1.Clear();
            rowsList2.Clear();
            rowsList3.Clear();
            rowsList4.Clear();
            rowsList.Clear();
            List<string> colLists = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.StatisticsEnabled = true;
                    connection.ResetStatistics();
                    times = 0;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        colRecord = reader.FieldCount;
                        while (reader.Read())
                        {
                            if (colRecord == 1)
                            {

                                var rowString = reader[0].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString);

                                rowsList.Add(rowString);
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowsList[rowsRecord]);

                                rowsRecord++;
                            }
                            else if (colRecord == 2)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();

                                rowsList1.Add(rowString1);
                                rowsList2.Add(rowString2);

                                rowsList.Add(String.Join(", ", rowString1, rowString2));
                                //Console.WriteLine("Debug RowsData | 2 Rows List check: " + rowsList[rowsRecord]);

                                rowsRecord++;
                            }
                            else if (colRecord == 3)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();
                                var rowString3 = reader[2].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString);
                                rowsList1.Add(rowString1);
                                rowsList2.Add(rowString2);
                                rowsList3.Add(rowString3);

                                rowsList.Add(String.Join(", ", rowString1, rowString2, rowString3));
                                //Console.WriteLine("Debug RowsData | 3 Rows List check: " + rowsList[rowsRecord]);

                                //Console.WriteLine("Debug RowsData | Rows Data check: " + String.Join(", ", rowsList1[rowsRecord], rowsList2[rowsRecord], rowsList3[rowsRecord]));
                                rowsRecord++;

                            }
                            else if (colRecord == 4)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();
                                var rowString3 = reader[2].ToString();
                                var rowString4 = reader[3].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString);
                                rowsList1.Add(rowString1);
                                rowsList2.Add(rowString2);
                                rowsList3.Add(rowString3);
                                rowsList4.Add(rowString4);

                                rowsList.Add(String.Join(", ", rowString1, rowString2, rowString3, rowString4));

                                //Console.WriteLine("Debug RowsData | Rows Data check: " + String.Join(", ", rowsList1[rowsRecord], rowsList2[rowsRecord], rowsList3[rowsRecord]));

                                rowsRecord++;

                            }

                        }
                        reader.Close();

                        IDictionary stats = connection.RetrieveStatistics();
                        times = (long)stats["ExecutionTime"];
                        sqlExecutionTime();

                        return rowsList;
                    }
                }
                finally
                {
                    connection.StatisticsEnabled = false;
                }

            }

            }

        public static List<List<string>> ansRowLists = new List<List<string>>();
        static long times = 0;
        public static List<string> AnswerQuery(string connectionString, string sql) //Method to check Join Function
        {
            //DataTable schema = null;
            //string sqlCommand = sql;

            int ArowsRecord = 0;
            ArowsList1.Clear();
            ArowsList2.Clear();
            ArowsList3.Clear();
            ArowsList4.Clear();
            ArowsList.Clear();
            List<string> colLists = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.StatisticsEnabled = true;
                    connection.ResetStatistics();
                    times = 0;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    {
                        //colLists = frmQueries.getCol(connectionString, sql); //Get the Column Name
                        //colRecord = colLists[0].Count;

                        //Console.WriteLine("Debug RowsData | Ans Column Record check: " + AcolRecord);
                        AcolRecord = reader.FieldCount;
                        while (reader.Read())
                        {
                            int count = 0;
                            if (AcolRecord == 1)
                            {

                                var rowString = reader[0].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString);


                                ArowsList.Add(rowString);
                                //ansRowLists[ArowsRecord].Add(rowString);
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowsList[rowsRecord]);



                                //TODO: GetColList Valid Join Query Column Name & Get affected rows Record
                                //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);

                                ArowsRecord++;

                                //Console.WriteLine("Debug RowsData | Rows count check: " + rowsList.Count);
                                //Console.WriteLine(String.Format("{0}, {1},{2}", reader[0], reader[1], reader[2]));

                            }
                            else if (AcolRecord == 2)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();

                                ArowsList1.Add(rowString1);
                                ArowsList2.Add(rowString2);
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + String.Join(", ", rowsList1[rowsRecord], rowsList2[rowsRecord]));

                                ArowsList.Add(String.Join(", ", rowString1, rowString2));
                                //Console.WriteLine("Debug RowsData | 2 Rows List check: " + rowsList[rowsRecord]);
                                //ansRowLists[ArowsRecord].Add(String.Join(", ", rowString1, rowString2));

                                //TODO: GetColList Valid Join Query Column Name & Get affected rows Record
                                //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);

                                ArowsRecord++;
                                //Console.WriteLine("Debug RowsData | Rows count check: " + rowsList.Count);
                                //Console.WriteLine(String.Format("{0}, {1},{2}", reader[0], reader[1], reader[2]));
                            }
                            else if (AcolRecord == 3)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();
                                var rowString3 = reader[2].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString); 
                                ArowsList1.Add(rowString1);
                                ArowsList2.Add(rowString2);
                                ArowsList3.Add(rowString3);

                                ArowsList.Add(String.Join(", ", rowString1, rowString2, rowString3));
                                //ansRowLists[count].Add(String.Join(", ", rowString1, rowString2, rowString3));
                                //Console.WriteLine("Debug RowsData | 3 Rows List check: " + rowsList[rowsRecord]);

                                //Console.WriteLine("Debug RowsData | Rows Data check: " + String.Join(", ", rowsList1[rowsRecord], rowsList2[rowsRecord], rowsList3[rowsRecord]));

                                //TODO: GetColList Valid Join Query Column Name & Get affected rows Record

                                //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);

                                ArowsRecord++;
                                //Console.WriteLine("Debug RowsData | 3 Rows count check: " + rowsRecord);
                                //Console.WriteLine(String.Format("{0}, {1},{2}", reader[0], reader[1], reader[2]));
                            }
                            else if (AcolRecord == 4)
                            {
                                var rowString1 = reader[0].ToString();
                                var rowString2 = reader[1].ToString();
                                var rowString3 = reader[2].ToString();
                                var rowString4 = reader[3].ToString();
                                //Console.WriteLine("Debug RowsData | Rows Data check: " + rowString);
                                ArowsList1.Add(rowString1);
                                ArowsList2.Add(rowString2);
                                ArowsList3.Add(rowString3);
                                ArowsList4.Add(rowString4);

                                ArowsList.Add(String.Join(", ", rowString1, rowString2, rowString3, rowString4));
                                //Console.WriteLine("Debug RowsData | 3 Rows List check: " + rowsList[rowsRecord]);
                                //ansRowLists[ArowsRecord].Add(String.Join(", ", rowString1, rowString2, rowString3, rowString4));

                                //Console.WriteLine("Debug RowsData | Rows Data check: " + String.Join(", ", rowsList1[rowsRecord], rowsList2[rowsRecord], rowsList3[rowsRecord]));

                                //TODO: GetColList Valid Join Query Column Name & Get affected rows Record

                                //Console.WriteLine("Debug getCol | Column List check: " + colLists[0][0]);

                                ArowsRecord++;
                                //Console.WriteLine("Debug RowsData | 3 Rows count check: " + rowsRecord);
                                //Console.WriteLine(String.Format("{0}, {1},{2}", reader[0], reader[1], reader[2]));
                            }
                            count++;

                        }
                        reader.Close();


                        //TODO: Deduction expected to be here
                        //Console.WriteLine("Debug Rows Count | " + rowsRecord);
                        //Console.WriteLine("Debug RowsData | Rows List check: " + rowsList[5]);

                        IDictionary stats = connection.RetrieveStatistics();
                        times = (long)stats["ExecutionTime"];
                        sqlExecutionTime();
                        return ArowsList;

                    }

                }
                finally
                {
                    connection.StatisticsEnabled = false;
                }


            }

        }
        public static long sqlExecutionTime()
        {
            return times;
        }
    }
}
