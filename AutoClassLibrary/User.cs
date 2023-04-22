using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AutoClassLibrary
{
    public class User
    {
        private string name;
        private string surname;
        private string telnr;
        private string userEmail;
        private string password;
        public static User SavedUser;

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Telnr
        {
            get { return telnr; }
            set {
                //if (Regex.IsMatch(value, @"^\d{3}(-)?\d{3}(-)?\d{3}$"))
                //{
                //    telnr = value;
                //}
                //else { }
                telnr = value;
            }
        }
        [Key]
        public string UserEmail {
            get { return userEmail; }
            set {
                //if(Regex.IsMatch(value, @"^([a-z]|\d)*@[a-z]*\.(com|pl)$"))
                //{
                //    email = value;
                //}
                //else { }
                userEmail = value;
            }
        }
        public string Password { get { return password; } set { password = value; } }

        public virtual List<Car> Cars { get; set; }

        public User(string name, string surname, string telnr, string email, string password)
        {
            Name = name;
            Surname = surname;
            Telnr = telnr;
            UserEmail = email;
            Password = password;
        }

        //public bool LogIn(string email, string givenPassword)
        //{
        //    //znalezienie has³a w bazie dla podanego emaila
        //    //password
        //    string password;
        //    bool access = (givenPassword == password) ? true : false;
        //    return access;
        //}
        public void LogOut()
        {

        }

    }
}
