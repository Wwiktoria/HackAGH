using AutoClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoGUI
{
    /// <summary>
    /// Logika interakcji dla klasy LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 0 || txtPassword.Text.Length > 0 || txtSurname.Text.Length > 0 || txtPhone.Text.Length > 0 || txtMail.Text.Length > 0 )
            {


                User user = new User(CapitalizeFirstLetter(txtName.Text), CapitalizeFirstLetter(txtSurname.Text), txtPhone.Text, txtMail.Text, txtPassword.Text);

                if (user.CheckIfExist())
                {
                    MessageBox.Show("This email has already existed");
                }
                else
                {
                    user.SaveUserToBase();
                    User.SavedUser = user;
                    
                    Close();

                }


            }
        }

        public string CapitalizeFirstLetter(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
                return s.ToUpper();
            return s.Remove(1).ToUpper() + s.Substring(1);
        }
    }
}
