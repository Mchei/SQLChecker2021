using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latest_27_05
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void sheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[sheetName.SelectedItem.ToString()];
            report.DataSource = dt;
        }

        DataTableCollection tableCollection;

        private void import_Click(object sender, EventArgs e)
        {
            reportData(null);
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.ReportPath))
            {
                fileNameText.Text = Properties.Settings.Default.ReportPath;
                reportData(fileNameText.Text);
            }
        }

        private void reportData(string location)
        {
            try
            {
                if(location == null)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            fileNameText.Text = openFileDialog.FileName;
                            Properties.Settings.Default.ReportPath = fileNameText.Text;
                            Properties.Settings.Default.Save();

                            using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                    });
                                    tableCollection = result.Tables;
                                    sheetName.Items.Clear();
                                    foreach (DataTable table in tableCollection)
                                    {
                                        sheetName.Items.Add(table.TableName); //add sheet to combobox
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                            using (var stream = File.Open(fileNameText.Text, FileMode.Open, FileAccess.Read))
                            {
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                    });
                                    tableCollection = result.Tables;
                                    sheetName.Items.Clear();
                                    foreach (DataTable table in tableCollection)
                                    {
                                        sheetName.Items.Add(table.TableName); //add sheet to combobox
                                    }
                                }
                            }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report may be in used or opened!", ex.Message);
            }
        }
    }
}
