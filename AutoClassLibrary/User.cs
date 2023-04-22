using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClassLibrary.AutoClassLibrary;

namespace AutoClassLibrary
{
    public class User:Model1
    {
        private string name;
        private string surname;
        private string telnr;
        private string email;
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
        public string Email {
            get { return email; }
            set {
                //if(Regex.IsMatch(value, @"^([a-z]|\d)*@[a-z]*\.(com|pl)$"))
                //{
                //    email = value;
                //}
                //else { }
                email = value;
            } 
        }
        public string Password { get { return password; } set { password = value; } }
        public virtual List<Car> Cars { get; set; }

        public User(string name, string surname, string telnr, string email, string password)
        {
            Name = name;
            Surname = surname;
            Telnr = telnr;
            Email = email;
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
        public bool CheckIfExist()
        {
            return Users.Any(x => x.Email == this.Email);

        }

        public User CheckIfExistLogin(string email, string password)
        {
            SavedUser = Users.FirstOrDefault(x => (x.Email == email && x.Password == password));
            return SavedUser;
        }

        public void SaveUserToBase()
        {
            Users.Add(this);
            SaveChanges();
        }

    }
}
