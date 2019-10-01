using breadCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breadCompany
{
    public partial class MarketForm : Form
    {
        string AZN = " AZN";
        Users activeUser;
        bool isActive;
        int marketId;
        int monthId;
        int selectedRowId;
        string saveEvent;
        private readonly GanjaBreadCompanyEntity db;
        public MarketForm(Users User)
        {

            try
            {
                activeUser = User;
                isActive = true;
                db = new GanjaBreadCompanyEntity();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message :" + ex);
                throw;
            }
            InitializeComponent();
        }

        private void MarketForm_Load(object sender, EventArgs e)
        {
            var currentMonthDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<int> dates = new List<int>();
            for (int i = 1; i <= currentMonthDays; i++)
            {
                dates.Add(i);
            }
            try
            {

                cmbMarkets.DataSource = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == activeUser.Id && w.Users.DeletedDate == null).Select(s => new ComboItem
                {

                    Text = s.MarketName,
                    value = s.Id,
                }).ToList();
                cmbMonth.DataSource = db.Months.Select(s => new ComboItem
                {
                    Text = s.MonthName,
                    value = s.MonthNumber,
                }).ToList();
                lblActiveUser.Text = activeUser.UserName;
                cmbMarketForCreateMonth.DataSource = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == activeUser.Id && w.Users.DeletedDate == null).Select(s => new ComboItem
                {

                    Text = s.MarketName,
                    value = s.Id,
                }).ToList();
                cmbMonthForCreateMonth.DataSource = db.Months.Select(s => new ComboItem
                {
                    Text = s.MonthName,
                    value = s.MonthNumber,
                }).ToList();

                lblActiveUser.Text = activeUser.UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);

                throw;
            }
        }

        private void btnShowMarkets_Click(object sender, EventArgs e)
        {
            try
            {
                var marketList = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == activeUser.Id && w.Users.DeletedDate == null).ToList();
                if (marketList == null)
                {
                    MessageBox.Show("Zəhmət olmasa market elavə edin!!");
                    return;
                }
                ComboItem selectedMarket = cmbMarkets.SelectedItem as ComboItem;
                ComboItem selectedMonth = cmbMonth.SelectedItem as ComboItem;

                marketId = selectedMarket.value;
                monthId = selectedMonth.value;
                calculatePriceAndCount(marketId, monthId);
                dgvRefleshDay(marketId, monthId);
                grbEdit.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);
                throw;
            }
        }

        void dgvRefleshDay(int Id, int monthId)
        {
            var currentYear = DateTime.Now.Year;
            try
            {
                dgvMarketList.DataSource = db.CountForDays.Where(w =>w.DeletedDate==null&& w.Subsidiary.MarketId == Id && w.MonthId == monthId && w.Year == currentYear).Select(s => new
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

                }).ToList();
                int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, monthId);

                if (daysInMonth == 28)
                {
                    this.dgvMarketList.Columns["Day29"].Visible = false;
                    this.dgvMarketList.Columns["Day30"].Visible = false;
                    this.dgvMarketList.Columns["Day31"].Visible = false;
                }
                else if (daysInMonth == 29)
                {
                    this.dgvMarketList.Columns["Day29"].Visible = true;
                    this.dgvMarketList.Columns["Day30"].Visible = false;
                    this.dgvMarketList.Columns["Day31"].Visible = false;
                }
                else if (daysInMonth == 30)
                {
                    this.dgvMarketList.Columns["Day29"].Visible = true;
                    this.dgvMarketList.Columns["Day30"].Visible = true;
                    this.dgvMarketList.Columns["Day31"].Visible = false;
                }

                else if (daysInMonth == 31)
                {
                    this.dgvMarketList.Columns["Day29"].Visible = true;
                    this.dgvMarketList.Columns["Day30"].Visible = true;
                    this.dgvMarketList.Columns["Day31"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);

                throw;
            }
        }

        void calculatePriceAndCount(int Id, int monthId)
        {
            try
            {
                var marketList = db.CountForDays.Where(w => w.Subsidiary.MarketId == Id && w.Subsidiary.MarketList.UserId == activeUser.Id).ToList();
                foreach (var item in marketList)
                {

                    int? totalCount = Convert.ToInt32(item.Day1) + Convert.ToInt32(item.Day2) + Convert.ToInt32(item.Day3) + Convert.ToInt32(item.Day4) + Convert.ToInt32(item.Day5) + Convert.ToInt32(item.Day6) + Convert.ToInt32(item.Day7) + Convert.ToInt32(item.Day8)
                          + Convert.ToInt32(item.Day9) + Convert.ToInt32(item.Day10) + Convert.ToInt32(item.Day11) + Convert.ToInt32(item.Day12) + Convert.ToInt32(item.Day13) + Convert.ToInt32(item.Day14) + Convert.ToInt32(item.Day15)
                          + Convert.ToInt32(item.Day16) + Convert.ToInt32(item.Day17) + Convert.ToInt32(item.Day18) + Convert.ToInt32(item.Day19) + Convert.ToInt32(item.Day20) + Convert.ToInt32(item.Day21) + Convert.ToInt32(item.Day22) + Convert.ToInt32(item.Day23)
                          + Convert.ToInt32(item.Day24) + Convert.ToInt32(item.Day25) + Convert.ToInt32(item.Day26) + Convert.ToInt32(item.Day27) + Convert.ToInt32(item.Day28) + Convert.ToInt32(item.Day29) + Convert.ToInt32(item.Day30) + Convert.ToInt32(item.Day31);

                    decimal onePrice = Convert.ToDecimal(item.PriceOfOne);
                    decimal? totalMoney = onePrice * totalCount;
                    item.TotalCount = totalCount;
                    int? x = Convert.ToInt32(item.Day25);
                    item.TotalPrice = totalMoney;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);

                throw;
            }
        }

        private void btnCreateNewMonth_Click(object sender, EventArgs e)
        {
            try
            {
                var marketList = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == activeUser.Id && w.Users.DeletedDate == null).ToList();
                if (marketList == null)
                {
                    MessageBox.Show("Zəhmət olmasa Market əlavə edin!!");
                    return;
                }
                ComboItem selectedMarket = cmbMarketForCreateMonth.SelectedItem as ComboItem;
                ComboItem selectedMonth = cmbMonthForCreateMonth.SelectedItem as ComboItem;
                double price = Convert.ToDouble(numPrice.Value);

                if (price==0)
                {
                    MessageBox.Show("Qiyməti daxil edin!!");
                    return;
                }
                marketId = selectedMarket.value;
                monthId = selectedMonth.value;
                var currentYear = DateTime.Now.Year;

                var subMarket = db.Subsidiary.Where(w => w.DeletedDate == null && w.MarketId == marketId).ToList();

                foreach (var item in subMarket)
                {
                    var check = db.CountForDays.Where(w => w.DeletedDate == null &&w.MarketName==item.Subsidiary1 &&w.MonthId == monthId
                    && w.Subsidiary.MarketId == marketId && w.Year == currentYear).FirstOrDefault();
                    if (check==null)
                    {
                        var relatedMarket = new CountForDays();
                        relatedMarket.Year = currentYear;
                        relatedMarket.MonthId = monthId;
                        relatedMarket.SubsidiaryId = item.Id;
                        relatedMarket.PriceOfOne = price;
                        relatedMarket.CreatedDate = DateTime.Now;
                        relatedMarket.MarketName = item.Subsidiary1;
                        db.CountForDays.Add(relatedMarket);
                        db.SaveChanges();
                    }
                }
                calculatePriceAndCount(marketId, monthId);
                dgvRefleshDay(marketId, monthId);
                dgvCreateMonth.Visible = false;
                btnShowNewMonthGrid.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);

                throw;
            }
        }

        private void marketYaratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMarket createMarket = new CreateMarket(activeUser);
            createMarket.Show();
            this.Hide();
        }

        private void filialYaratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSubsudiary createSub = new CreateSubsudiary(activeUser);
            createSub.Show();
            this.Hide();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                isActive = false;
                LoginForm logPart = new LoginForm();
                logPart.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);
                throw;
            }
        }

        private void btnShowNewMonthGrid_Click(object sender, EventArgs e)
        {
            dgvCreateMonth.Visible = true;
            btnShowNewMonthGrid.Visible = false;
            grbEdit.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvCreateMonth.Visible = false;
            btnShowNewMonthGrid.Visible = true;
        }

        private void dgvMarketList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMarketList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                grbEdit.Visible = true;
                int id = Convert.ToInt32(dgvMarketList.Rows[e.RowIndex].Cells[0].Value);
                selectedRowId = id;
                var findRow = db.CountForDays.Find(id);

                CUD1.Value = Convert.ToInt32(findRow.Day1); lblPriceDay1.Text = (findRow.Day1*findRow.PriceOfOne).ToString() + AZN;
                CUD2.Value = Convert.ToInt32(findRow.Day2); lblPriceDay2.Text = (findRow.Day2 * findRow.PriceOfOne).ToString() + AZN;
                CUD3.Value = Convert.ToInt32(findRow.Day3); lblPriceDay3.Text = (findRow.Day3 * findRow.PriceOfOne).ToString() + AZN;
                CUD4.Value = Convert.ToInt32(findRow.Day4); lblPriceDay4.Text = (findRow.Day4 * findRow.PriceOfOne).ToString() + AZN;
                CUD5.Value = Convert.ToInt32(findRow.Day5); lblPriceDay5.Text = (findRow.Day5 * findRow.PriceOfOne).ToString() + AZN;
                CUD6.Value = Convert.ToInt32(findRow.Day6); lblPriceDay6.Text = (findRow.Day6 * findRow.PriceOfOne).ToString() + AZN;
                CUD7.Value = Convert.ToInt32(findRow.Day7); lblPriceDay7.Text = (findRow.Day7 * findRow.PriceOfOne).ToString() + AZN;
                CUD8.Value = Convert.ToInt32(findRow.Day8); lblPriceDay8.Text = (findRow.Day8 * findRow.PriceOfOne).ToString() + AZN;
                CUD9.Value = Convert.ToInt32(findRow.Day9); lblPriceDay9.Text = (findRow.Day9 * findRow.PriceOfOne).ToString() + AZN;
                CUD10.Value = Convert.ToInt32(findRow.Day10); lblPriceDay10.Text = (findRow.Day10 * findRow.PriceOfOne).ToString() + AZN;
                CUD11.Value = Convert.ToInt32(findRow.Day11); lblPriceDay11.Text = (findRow.Day11 * findRow.PriceOfOne).ToString() + AZN;
                CUD12.Value = Convert.ToInt32(findRow.Day12); lblPriceDay12.Text = (findRow.Day12 * findRow.PriceOfOne).ToString() + AZN;
                CUD13.Value = Convert.ToInt32(findRow.Day13); lblPriceDay13.Text = (findRow.Day13 * findRow.PriceOfOne).ToString() + AZN;
                CUD14.Value = Convert.ToInt32(findRow.Day14); lblPriceDay14.Text = (findRow.Day14 * findRow.PriceOfOne).ToString() + AZN;
                CUD15.Value = Convert.ToInt32(findRow.Day15); lblPriceDay15.Text = (findRow.Day15 * findRow.PriceOfOne).ToString() + AZN;
                CUD16.Value = Convert.ToInt32(findRow.Day16); lblPriceDay16.Text = (findRow.Day16 * findRow.PriceOfOne).ToString() + AZN;
                CUD17.Value = Convert.ToInt32(findRow.Day17); lblPriceDay17.Text = (findRow.Day17 * findRow.PriceOfOne).ToString() + AZN;
                CUD18.Value = Convert.ToInt32(findRow.Day18); lblPriceDay18.Text = (findRow.Day18 * findRow.PriceOfOne).ToString() + AZN;
                CUD19.Value = Convert.ToInt32(findRow.Day19); lblPriceDay19.Text = (findRow.Day19 * findRow.PriceOfOne).ToString() + AZN;
                CUD20.Value = Convert.ToInt32(findRow.Day20); lblPriceDay20.Text = (findRow.Day20 * findRow.PriceOfOne).ToString() + AZN;
                CUD21.Value = Convert.ToInt32(findRow.Day21); lblPriceDay21.Text = (findRow.Day21 * findRow.PriceOfOne).ToString() + AZN;
                CUD22.Value = Convert.ToInt32(findRow.Day22); lblPriceDay22.Text = (findRow.Day22* findRow.PriceOfOne).ToString() + AZN;
                CUD23.Value = Convert.ToInt32(findRow.Day23); lblPriceDay23.Text = (findRow.Day23 * findRow.PriceOfOne).ToString() + AZN;
                CUD24.Value = Convert.ToInt32(findRow.Day24); lblPriceDay24.Text = (findRow.Day24 * findRow.PriceOfOne).ToString() + AZN;
                CUD25.Value = Convert.ToInt32(findRow.Day25); lblPriceDay25.Text = (findRow.Day25 * findRow.PriceOfOne).ToString() + AZN;
                CUD26.Value = Convert.ToInt32(findRow.Day26); lblPriceDay26.Text = (findRow.Day26 * findRow.PriceOfOne).ToString() + AZN;
                CUD27.Value = Convert.ToInt32(findRow.Day27); lblPriceDay27.Text = (findRow.Day27 * findRow.PriceOfOne).ToString() + AZN;
                CUD28.Value = Convert.ToInt32(findRow.Day28); lblPriceDay28.Text = (findRow.Day28 * findRow.PriceOfOne).ToString() + AZN;
                txtPrice.Text = findRow.PriceOfOne.ToString();
                if (DateTime.DaysInMonth(DateTime.Now.Year, monthId) == 28)
                {
                    CUD29.Visible = false;
                    CUD30.Visible = false;
                    CUD31.Visible = false;
                    label32.Visible = false;
                    label33.Visible = false;
                    label34.Visible = false;
                }
                else if (DateTime.DaysInMonth(DateTime.Now.Year, monthId) == 29)
                {
                    CUD29.Value = Convert.ToInt32(findRow.Day29);
                    lblPriceDay29.Text = (findRow.Day29 * findRow.PriceOfOne).ToString() + AZN;
                    CUD29.Visible = true;
                    CUD30.Visible = false;
                    CUD31.Visible = false;
                    label32.Visible = true;
                    label33.Visible = false;
                    label34.Visible = false;
                    lblPriceDay30.Visible = false;
                    lblPriceDay31.Visible = false;

                }
                else if (DateTime.DaysInMonth(DateTime.Now.Year, monthId) == 30)
                {
                    CUD29.Value = Convert.ToInt32(findRow.Day29);
                    lblPriceDay29.Text = (findRow.Day29 * findRow.PriceOfOne).ToString() + AZN;
                    CUD30.Value = Convert.ToInt32(findRow.Day30);
                    lblPriceDay30.Text = (findRow.Day30 * findRow.PriceOfOne).ToString() + AZN;
                    CUD29.Visible = true;
                    CUD30.Visible = true;
                    CUD31.Visible = false;
                    label32.Visible = true;
                    label33.Visible = true;
                    label34.Visible = false;
                    lblPriceDay31.Visible = false;
                }
                else if (DateTime.DaysInMonth(DateTime.Now.Year, monthId) == 31)
                {
                    CUD29.Value = Convert.ToInt32(findRow.Day29);
                    lblPriceDay29.Text = (findRow.Day29 * findRow.PriceOfOne).ToString() +AZN;
                    CUD30.Value = Convert.ToInt32(findRow.Day30);
                    lblPriceDay30.Text = (findRow.Day30 * findRow.PriceOfOne).ToString() + AZN;
                    CUD31.Value = Convert.ToInt32(findRow.Day31);
                    lblPriceDay31.Text = (findRow.Day31 * findRow.PriceOfOne).ToString() + AZN;
                    CUD29.Visible = true;
                    CUD30.Visible = true;
                    CUD31.Visible = true;
                    label32.Visible = true;
                    label33.Visible = true;
                    label34.Visible = true;
                    lblPriceDay29.Visible = true;
                    lblPriceDay30.Visible = true;
                    lblPriceDay31.Visible = true;
                }
                lblTotalAmount.Text = 0.ToString() + "  AZN";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);
                throw;
            }
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            try
            {
                var findRow = db.CountForDays.Find(selectedRowId);
                findRow.Day1 = (int)CUD1.Value; findRow.Day2 = (int)CUD2.Value; findRow.Day3 = (int)CUD3.Value;
                findRow.Day4 = (int)CUD4.Value; findRow.Day5 = (int)CUD5.Value; findRow.Day6 = (int)CUD6.Value;
                findRow.Day7 = (int)CUD7.Value; findRow.Day8 = (int)CUD8.Value; findRow.Day9 = (int)CUD9.Value;
                findRow.Day10 = (int)CUD10.Value; findRow.Day11 = (int)CUD11.Value; findRow.Day12 = (int)CUD12.Value;
                findRow.Day13 = (int)CUD13.Value; findRow.Day14 = (int)CUD14.Value; findRow.Day15 = (int)CUD15.Value;
                findRow.Day16 = (int)CUD16.Value; findRow.Day17 = (int)CUD17.Value; findRow.Day18 = (int)CUD18.Value;
                findRow.Day19 = (int)CUD19.Value; findRow.Day20 = (int)CUD20.Value; findRow.Day21 = (int)CUD21.Value;
                findRow.Day22 = (int)CUD22.Value; findRow.Day23 = (int)CUD23.Value; findRow.Day24 = (int)CUD24.Value;
                findRow.Day25 = (int)CUD25.Value; findRow.Day26 = (int)CUD26.Value; findRow.Day27 = (int)CUD27.Value;
                findRow.Day28 = (int)CUD28.Value; findRow.Day29 = (int)CUD29.Value; findRow.Day30 = (int)CUD30.Value;
                findRow.Day31 = (int)CUD31.Value; findRow.PriceOfOne = Convert.ToDouble(txtPrice.Text);
                lblPriceDay1.Text = (findRow.Day1 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay2.Text = (findRow.Day2 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay3.Text = (findRow.Day3* findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay4.Text = (findRow.Day4 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay5.Text = (findRow.Day5 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay6.Text = (findRow.Day6 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay7.Text = (findRow.Day7 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay8.Text = (findRow.Day8 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay9.Text = (findRow.Day9 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay10.Text = (findRow.Day10 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay11.Text = (findRow.Day11 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay12.Text = (findRow.Day12 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay13.Text = (findRow.Day13 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay14.Text = (findRow.Day14 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay15.Text = (findRow.Day15 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay16.Text = (findRow.Day16 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay17.Text = (findRow.Day17 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay18.Text = (findRow.Day18 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay19.Text = (findRow.Day19 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay20.Text = (findRow.Day20 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay21.Text = (findRow.Day21 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay22.Text = (findRow.Day22 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay23.Text = (findRow.Day23 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay24.Text = (findRow.Day24 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay25.Text = (findRow.Day25* findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay26.Text = (findRow.Day26 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay27.Text = (findRow.Day27 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay28.Text = (findRow.Day28 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay29.Text = (findRow.Day29 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay30.Text = (findRow.Day30 * findRow.PriceOfOne).ToString() + AZN;
                lblPriceDay31.Text = (findRow.Day31 * findRow.PriceOfOne).ToString() + AZN;
                db.Entry(findRow).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                calculatePriceAndCount(marketId, monthId);
                dgvRefleshDay(marketId, monthId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);

                throw;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                double totalPrice = 0;
                var days = db.CountForDays.Where(w => w.DeletedDate == null && w.Subsidiary.MarketId == marketId && w.MonthId == monthId &&
                w.Year == DateTime.Now.Year).ToList();
                foreach (var row in days)
                {
                    totalPrice += (double)row.TotalPrice;
                }
                lblTotalAmount.Text = totalPrice.ToString()+"  AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex);
                throw;
            }
        }

        private void MarketForm_Click(object sender, EventArgs e)
        {
            lblTotalAmount.Text = "AZN";
        }

        private void MarketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm logForm = new LoginForm();
            logForm.Show();
        }

    }
}
