using breadCompany.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace breadCompany
{
    public partial class LoginForm : Form
    {
        const string folder = "img";
        const string folderForEroor = "seeAllError";
        private readonly GanjaBreadCompanyEntity db;
        string pathTxt = Path.Combine(folderForEroor, "error.txt");

        public LoginForm()
        {
            try
            {
                db = new GanjaBreadCompanyEntity();
                Directory.CreateDirectory(folder);
                Directory.CreateDirectory(folderForEroor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                var checkUserCount = db.Users.Where(w => w.DeletedDate == null).Count();
                //adding user
              if (checkUserCount > 0)
              {
                  linkRegister.Visible = false;
              }

              int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internet şəbəkəsi yoxdur!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
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
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!!");
                }
                else
                {
                    var checkUser = db.Users.Where(a => a.DeletedDate == null && a.UserEmail == email).FirstOrDefault();
                    if (checkUser == null)
                    {
                        MessageBox.Show("Bu istifadəçi Mövcut Deyil!!");
                    }
                    else
                    {
                        //var checkPassword = Extention.Extention.CheckPassword(password,checkUser.UserPassword);
                        if (checkUser.UserPassword != password/*checkPassword==false*/)
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
            catch (Exception ex)
            {
                MessageBox.Show("Please, check again after some minutes!! ");
                File.AppendAllText(pathTxt, "\n" + ex + ":" + DateTime.Now);
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPass = new ForgotPassword();
            forgotPass.Show();
        }


        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DialogResult dialog = new DialogResult();

                dialog = MessageBox.Show("Tətbiqdən çıxmağa əmminsiz?", "Xəbərdarlıq!", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    System.Environment.Exit(1);
                }
                else {
                    LoginForm lg = new LoginForm();
                    lg.Show();
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
