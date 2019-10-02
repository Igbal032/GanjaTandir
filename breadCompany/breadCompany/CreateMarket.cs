using breadCompany.Models;
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

namespace breadCompany
{
    public partial class CreateMarket : Form
    {
        Users activeUser;
        int selectedRowId;
        const string folderForEroor = "seeAllError";
        string pathTxt = Path.Combine(folderForEroor, "error.txt");
        private readonly GanjaBreadCompanyEntity db;
        public CreateMarket(Users User)
        {
            try
            {
                db = new GanjaBreadCompanyEntity();
                activeUser = User;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            InitializeComponent();
        }

        private void btnCreateMarket_Click(object sender, EventArgs e)
        {
            try
            {
                var markets = db.MarketList.Any(w => w.DeletedDate == null && w.UserId == activeUser.Id && w.MarketName == txtMarketName.Text);
                if (string.IsNullOrWhiteSpace(txtMarketName.Text))
                {
                    MessageBox.Show("Zəhmət olmasa Market adı daxil edin!!");
                    return;
                }
                if (markets)
                {
                    MessageBox.Show("Bu adda market mövcuddur!!");
                    return;
                }
                var marketName = txtMarketName.Text.ToUpper();
                MarketList newMarket = new MarketList();
                newMarket.MarketName = marketName;
                newMarket.UserId = activeUser.Id;
                newMarket.CreatedDate = DateTime.Now;
                db.MarketList.Add(newMarket);
                db.SaveChanges();
                dgvMarket(activeUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void CreateMarket_Load(object sender, EventArgs e)
        {
            try
            {
                dgvMarket(activeUser);
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }


        }

        void dgvMarket(Users user)
        {

            try
            {
                dgvMarketListInCreate.DataSource = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == user.Id).Select(s => new {

                    s.Id,
                    s.MarketName,
                }).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }
        private void dgvMarketListInCreate_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int id = (int)dgvMarketListInCreate.Rows[e.RowIndex].Cells["ID"].Value;
                selectedRowId = id;
                var findMarket = db.MarketList.Where(w => w.Id == id).FirstOrDefault();
                txtMarketName.Text = findMarket.MarketName;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMarketName.Text))
                {
                    MessageBox.Show("Zəhmət olmasa Market adı daxil edin!!");
                    return;
                }
                var findMarket = db.MarketList.Where(w => w.Id == selectedRowId).FirstOrDefault();
                findMarket.MarketName = txtMarketName.Text;
                db.Entry(findMarket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dgvMarket(activeUser);
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtMarketName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                var findMarket = db.MarketList.Where(w => w.Id == selectedRowId).FirstOrDefault();
                findMarket.DeletedDate = DateTime.Now;
                db.Entry(findMarket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dgvMarket(activeUser);
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtMarketName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void CreateMarket_Click(object sender, EventArgs e)
        {
            txtMarketName.Text = "";
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void CreateMarket_FormClosing(object sender, FormClosingEventArgs e)
        {
            MarketForm marketForm = new MarketForm(activeUser);
            marketForm.Show();
        }
    }
}
