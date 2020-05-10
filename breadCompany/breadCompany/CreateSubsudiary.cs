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
    public partial class CreateSubsudiary : Form
    {
        private readonly GanjaBreadCompanyEntity db;
        const string folderForEroor = "seeAllError";
        string pathTxt = Path.Combine(folderForEroor, "error.txt");
        Users activeUser;
        int selectedRowId;
        public CreateSubsudiary(Users user)
        {
            try
            {
                db = new GanjaBreadCompanyEntity();
                activeUser = user;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            InitializeComponent();
        }


        private void CreateSubsudiary_Load(object sender, EventArgs e)
        {
            try
            {
                cmbMarket.DataSource = db.MarketList.Where(w => w.DeletedDate == null && w.UserId == activeUser.Id).Select(s => new ComboItem
                {
                    Text = s.MarketName,
                    value = s.Id,
                }).ToList();
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                dgvSubsidaryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void btnCreateSubMarket_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFlialNAme.Text))
                {
                    MessageBox.Show("Zəhmıət olmasa Filialin adını daxil edin!!");
                    return;
                }
                ComboItem selectedMarket = cmbMarket.SelectedItem as ComboItem;
                var subsidiary = db.Subsidiary.Any(w => w.Subsidiary1 == txtFlialNAme.Text && w.DeletedDate == null && w.MarketId == selectedMarket.value);
                if (subsidiary)
                {
                    MessageBox.Show("Bu adda Filial var");
                    return;
                }
                Subsidiary newFilial = new Subsidiary();
                newFilial.MarketId = selectedMarket.value;
                newFilial.Subsidiary1 = txtFlialNAme.Text.ToUpper();
                newFilial.CreatedDate = DateTime.Now;
                db.Subsidiary.Add(newFilial);
                db.SaveChanges();
                dgvSubsidaryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }


        void dgvSubsidaryList()
        {
            try
            {
                ComboItem selectedItem = cmbMarket.SelectedItem as ComboItem;
                dgvSubsidary.DataSource = db.Subsidiary.Where(w => w.DeletedDate == null && w.MarketList.UserId == activeUser.Id && w.MarketId == selectedItem.value).Select(s => new
                {
                    s.Id,
                    s.MarketList.MarketName,
                    s.Subsidiary1,
                }).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }

        }

        private void dgvSubsidary_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int id = (int)dgvSubsidary.Rows[e.RowIndex].Cells["ID"].Value;
                selectedRowId = id;
                var findSubsidiary = db.Subsidiary.Where(w => w.Id == id).FirstOrDefault();
                txtFlialNAme.Text = findSubsidiary.Subsidiary1;
                cmbMarket.SelectedValue = findSubsidiary.MarketId;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
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
                if (string.IsNullOrWhiteSpace(txtFlialNAme.Text))
                {
                    MessageBox.Show("Zəhmıət olmasa Filialin adını daxil edin!!");
                    return;
                }
                ComboItem selectedItem = cmbMarket.SelectedItem as ComboItem;
                var findSubsidiary = db.Subsidiary.Where(w => w.Id == selectedRowId).FirstOrDefault();
                findSubsidiary.Subsidiary1 = txtFlialNAme.Text;
                findSubsidiary.MarketId = selectedItem.value;
                db.Entry(findSubsidiary).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dgvSubsidaryList();
                txtFlialNAme.Text = "";
                btnDelete.Visible = false;
                btnEdit.Visible = false;
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

                var findSubsidiary = db.Subsidiary.Where(w => w.Id == selectedRowId).FirstOrDefault();
                findSubsidiary.DeletedDate = DateTime.Now;
                db.Entry(findSubsidiary).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                dgvSubsidaryList();
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                txtFlialNAme.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void cmbMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSubsidaryList();
        }

        private void CreateSubsudiary_Click(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            btnEdit.Visible = false;
            txtFlialNAme.Text = "";
        }

        private void CreateSubsudiary_FormClosing(object sender, FormClosingEventArgs e)
        {
            MarketForm marketForm = new MarketForm(activeUser);
            marketForm.Show();
        }
    }
}
