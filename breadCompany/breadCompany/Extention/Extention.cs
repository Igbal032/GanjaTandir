using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breadCompany.Extention
{
    class Extention
    {
        public static string HashPassword(string password)
        {

            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashArray = new SHA256Managed().ComputeHash(byteArray);
            string hashedPassword = ASCIIEncoding.ASCII.GetString(hashArray);
            return hashedPassword;
        }

        public static bool CheckPassword(string password, string hashedpassword)
        {
            return HashPassword(password) == hashedpassword;
        }
    }
}
