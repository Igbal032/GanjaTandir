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
    public partial class RegisterPart : Form
    {
        private readonly GanjaBreadCompanyEntity db;
        const string folderForEroor = "seeAllError";
        string pathTxt = Path.Combine(folderForEroor, "error.txt");
        public RegisterPart()
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



        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm logPart = new LoginForm();
            logPart.Show();
            this.Close();
        }

        private void btnSubmitRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var name = txtUserName.Text.Trim().ToUpper();
                var surName = txtUserSurname.Text.Trim().ToUpper();
                var email = txtEmail.Text.Trim().ToUpper();
                var password = txtPassword.Text.Trim();
                var confirmpassword = txtConPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(name)|| string.IsNullOrWhiteSpace(surName)|| string.IsNullOrWhiteSpace(email)
                    || string.IsNullOrWhiteSpace(password)|| string.IsNullOrWhiteSpace(confirmpassword))
                {
                //    var user = db.Users.FirstOrDefault();
                //    txtPassword.Text=Extention.Extention.HashPassword(user.UserPassword);
                    MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!!");
                }
                else
                {
                    var checkUser = db.Users.Any(a => a.DeletedDate == null && a.UserEmail == email);
                    if (checkUser==true)
                    {
                    MessageBox.Show("Bu istifadəçi artıq mövcuddur!!");
                    }
                    else if(password!=confirmpassword)
                    {
                        MessageBox.Show("Zəhmət olmasa təkrar şifrəni düzgün daxil edin!!");
                    }
                    else
                    {
                        var newUser = new Users();
                        newUser.UserEmail = email;
                        newUser.UserName = name;
                        newUser.UserSurname = surName;
                        newUser.UserPassword =password /*Extention.Extention.HashPassword(password)*/;
                        newUser.CreatedDate = DateTime.Now;
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        this.Close();
                        LoginForm logPart = new LoginForm();
                        logPart.Show();
                        MessageBox.Show("Istifadəçi Yaradıldı");
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
