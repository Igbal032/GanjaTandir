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
    public partial class ForgotPassword : Form
    {
        private readonly GanjaBreadCompanyEntity db;
        const string folderForEroor = "seeAllError";
        string pathTxt = Path.Combine(folderForEroor, "error.txt");     
        public ForgotPassword()
        {
            try
            {
                db = new GanjaBreadCompanyEntity();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            InitializeComponent();
        }

        private void btnSendPassword_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Zəhmət olmasa xananı doldurun!!");
                }
                else
                {
                    var checkEmail = db.Users.Where(w => w.DeletedDate == null && w.UserEmail == email).FirstOrDefault();
                    if (checkEmail == null)
                    {
                        MessageBox.Show("Bu isdifadəçi mövcut deyil!!");
                    }
                    else
                    {
                        this.Close();
                        MessageBox.Show("Sizin şifrə :" + checkEmail.UserPassword);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

    }
}
