using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using breadCompany.Models;

namespace breadCompany
{
    public partial class LoginForm : Form
    {
        private readonly GanjaBreadCompanyEntity db;
        public LoginForm()
        {
            db = new GanjaBreadCompanyEntity();
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var checkUserCount = db.Users.Where(w => w.DeletedDate == null).Count();
            if (checkUserCount >= 3)
            {
                linkRegister.Visible = false;
            }

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);


        }

        private void grpUP_Enter(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPart regPart = new RegisterPart();
            regPart.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtUserPassword.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(email)||string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!!");
                }
                else
                {
                    var checkUser = db.Users.Where(a => a.DeletedDate == null && a.UserEmail == email).FirstOrDefault();
                    if (checkUser==null)
                    {
                        MessageBox.Show("Bu istifadəçi Mövcut Deyil!!");
                    }
                    else
                    {
                        //var checkPassword = Extention.Extention.CheckPassword(password,checkUser.UserPassword);
                        if (checkUser.UserPassword!=password/*checkPassword==false*/)
                        {
                            MessageBox.Show("Zəhmət olmasa şifrəni düzgün daxil edin!!");
                        }
                        else
                        {
                            MarketForm marketList = new MarketForm(checkUser);
                            marketList.Show();
                            this.Hide();

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPass = new ForgotPassword();
            forgotPass.Show();
            
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
