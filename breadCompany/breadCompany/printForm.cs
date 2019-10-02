using breadCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Bitmap bitmap;
        private void BtnPrintSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                Bitmap bitmap = new Bitmap(this.Width, this.Height);
                DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                if (save.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(save.FileName + ".png", ImageFormat.Png);
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            ////////Graphics grp = this.CreateGraphics();
            ////////bitmap = new Bitmap(this.Width, this.Height);
            ////////Graphics mg = Graphics.FromImage(bitmap);
            ////////mg.CopyFromScreen(this.Location.X, this.Location.Y,102, 50, this.Size);
            ////////printPreviewDialog1.ShowDialog();
            ////int height = dgvDayForPrint.Height;
            ////dgvDayForPrint.Height = dgvDayForPrint.RowCount * dgvDayForPrint.RowTemplate.Height * 2;
            ////bitmap = new Bitmap(dgvDayForPrint.Width, dgvDayForPrint.Height);
            ////DrawToBitmap(bitmap, new Rectangle(0, 0, dgvDayForPrint.Width, dgvDayForPrint.Height));
            ////dgvDayForPrint.Height = height;
            ////printPreviewDialog1.ShowDialog();

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }
    }
}
