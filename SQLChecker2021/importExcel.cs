using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace SQLChecker2021
{
    public partial class importExcel : Form
    {
        private int rowCnt;
        List<string> QueryOneList;
        List<string> IDList;

        public importExcel()
        {
            InitializeComponent();

        }

        private void importExcel_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryOneList = new List<string>();
            IDList = new List<string>();

            Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(@textBox1.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)theWorkbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

            range = worksheet.UsedRange;

            for (rowCnt = 1; rowCnt <= range.Rows.Count; rowCnt++)
            {

                string ID = range.Cells[rowCnt, 2].Text.ToString();
                string QueryOne = (string)(range.Cells[rowCnt, 3] as Excel.Range).Value;
                
                QueryOneList.Add(QueryOne);
                IDList.Add(ID);
                //.Console.WriteLine(ID + " -------- " + Q;

            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse xlsx Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "xlsx files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }

        }
    }
    }
