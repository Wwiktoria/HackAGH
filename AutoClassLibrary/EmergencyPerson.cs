using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClassLibrary
{
    public class EmergencyPerson
    {
        private int emergencyPersonID;
        private string name;
        private string surname;
        private string nrtel;

        public int EmergencyPersonID { get { return emergencyPersonID; } set { emergencyPersonID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get {  return surname; } set { surname = value; } }
        public string Nrtel { get { return nrtel; } set { nrtel = value; } }
        public virtual User User { get; set; }
        public string UserEmail { get; set; }

        public EmergencyPerson()
        {
            emergencyPersonID = 0;
            emergencyPersonID++;
        }

        public EmergencyPerson(string name, string surname, string nrtel) : this()
        {
            this.name = name;
            this.surname = surname;
            this.nrtel = nrtel;
        }
    }
}
