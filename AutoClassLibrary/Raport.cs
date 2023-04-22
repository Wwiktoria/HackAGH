using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClassLibrary
{
    public class Raport
    {
        private int logID;
        private DateTime data;
        private string log;

        [Key]
        public int LogID { get { return logID; } set { logID = value; } }
        public DateTime Data { get { return data; } set { data = value; } }
        public string Log { get { return log; } set { log = value; } }
        public virtual Car Car { get; set; }
        public string Vin { get; set; }

        public Raport()
        {
            LogID = 0;
            LogID++;
        }
        public Raport(string log):this()
        {
            Data = DateTime.Now;
            Log = log;
        }
    }
}
