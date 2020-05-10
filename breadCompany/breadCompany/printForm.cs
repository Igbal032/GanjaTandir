using breadCompany.Models;
using iTextSharp.text.pdf.codec;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;

namespace breadCompany
{
    public partial class printForm : Form
    {
        private readonly GanjaBreadCompanyEntity db;
        const string folderForEroor = "seeAllError";
        string pathTxt = Path.Combine(folderForEroor, "error.txt");
        int monthIdd;
        int marketIdd;
        Users activeUser;
        public printForm(Users user,int monthId, int marketId)
        {
            try
            {
                marketIdd = marketId;
                monthIdd = monthId;
                activeUser = user;
                db = new GanjaBreadCompanyEntity();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            InitializeComponent();

        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            try
            {


                double totalPriceInOneMonth = 0;
                var days = db.CountForDays.Where(w => w.DeletedDate == null && w.Subsidiary.MarketId == marketIdd && w.MonthId == monthIdd &&
                w.Year == DateTime.Now.Year).ToList();
                foreach (var row in days)
                {
                    totalPriceInOneMonth += (double)row.TotalPrice;
                }
                foreach (var item in days)
                {
                    item.SumInOneMonth = (decimal)totalPriceInOneMonth;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                var currentYear = DateTime.Now.Year;
                dgvDayForPrint.DataSource = db.CountForDays.Where(w => w.DeletedDate == null && w.Subsidiary.MarketId == marketIdd && w.MonthId == monthIdd && w.Year == currentYear).Select(s => new
                {
                    s.Id,
                    s.MarketName,
                    s.Day1,
                    s.Day2,
                    s.Day3,
                    s.Day4,
                    s.Day5,
                    s.Day6,
                    s.Day7,
                    s.Day8,
                    s.Day9,
                    s.Day10,
                    s.Day11,
                    s.Day12,
                    s.Day13,
                    s.Day14,
                    s.Day15,
                    s.Day16,
                    s.Day17,
                    s.Day18,
                    s.Day19,
                    s.Day20,
                    s.Day21,
                    s.Day22,
                    s.Day23,
                    s.Day24,
                    s.Day25,
                    s.Day26,
                    s.Day27,
                    s.Day28,
                    s.Day29,
                    s.Day30,
                    s.Day31,
                    s.Months.MonthName,
                    s.PriceOfOne,
                    s.TotalCount,
                    s.TotalPrice,
                    s.SumInOneMonth,

                }).ToList();
                int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, monthIdd);

                if (daysInMonth == 28)
                {
                    this.dgvDayForPrint.Columns["Day29"].Visible = false;
                    this.dgvDayForPrint.Columns["Day30"].Visible = false;
                    this.dgvDayForPrint.Columns["Day31"].Visible = false;
                }
                else if (daysInMonth == 29)
                {
                    this.dgvDayForPrint.Columns["Day29"].Visible = true;
                    this.dgvDayForPrint.Columns["Day30"].Visible = false;
                    this.dgvDayForPrint.Columns["Day31"].Visible = false;
                }
                else if (daysInMonth == 30)
                {
                    this.dgvDayForPrint.Columns["Day29"].Visible = true;
                    this.dgvDayForPrint.Columns["Day30"].Visible = true;
                    this.dgvDayForPrint.Columns["Day31"].Visible = false;
                }

                else if (daysInMonth == 31)
                {
                    this.dgvDayForPrint.Columns["Day29"].Visible = true;
                    this.dgvDayForPrint.Columns["Day30"].Visible = true;
                    this.dgvDayForPrint.Columns["Day31"].Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }
        Bitmap bmp;

        private void btnPrintSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Recievable = 0;
                decimal Discount = 0;
                decimal Arrears = 0;
                decimal NetBal = 0;
                decimal Paid = 0;
                decimal RemBal = 0;
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvDayForPrint.Columns)
                {
                    dt.Columns.Add(column.HeaderText); //, column.ValueType
                }
                foreach (DataGridViewRow row in dgvDayForPrint.Rows)
                {
                    if (dgvDayForPrint.Rows.Count> row.Index)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value == null)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = 0.ToString();
                            }
                            else {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                            }
                        }
                    }
                    Console.WriteLine("success");
                }
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel File(.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            string count = "";
                            wb.Worksheets.Add(dt, "DefaultSchedule");
                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                Recievable += Convert.ToDecimal(dgvDayForPrint.Rows[i].Cells[2].Value);
                            }
                            string cell = "L" + (dt.Rows.Count + 2) + ":L" + (dt.Rows.Count + 2);
                            wb.Worksheet(1).Cells(cell).Value = Recievable;
                            wb.Worksheet(1).Columns().AdjustToContents();
                            wb.SaveAs(saveFileDialog1.FileName+".xlsx");
                        }
                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
                MessageBox.Show("Yadda saxlanıldı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Select All Checkbox to Export MS Excel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
