using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace AutoClassLibrary
{
    public enum EnumLights
    {
        Off,
        DRLs,
        DippedHeadlights,
    }

    public class Car
    {
        private string vin;
        private string regnum;
        private string name;
        private double speed;
        private EnumLights lights;
        private bool emergencyLights;
        private bool alarm;
        private bool doorsopen;
        private List<string> emergencyPeopleTel;
        private List<Raport> raports;

        [Key]
        public string Vin { get { return vin; } set { vin = value; } }
        public string Regnum { get { return regnum; } set { regnum = value; } }
        public string Name { get { return name; } set { Name = value; } }
        public double Speed { get { return speed; } set { speed = value; } }
        public EnumLights Lights { get { return lights; } set { lights = value; } }
        public bool EmergencyLights { get { return emergencyLights; } set { emergencyLights = value; } }
        public bool Alarm { get { return alarm; } set { alarm = value; } }
        public bool Doorsopen { get { return doorsopen; } set { doorsopen = value; } }
        public virtual User User { get; set; }
        public string UserEmail { get; set; }
        public List<string> EmergencyPeopleTel { get { return emergencyPeopleTel; } set { emergencyPeopleTel = value; } }
        public List<Raport> Raports { get; set; }

        public Car()
        {
            Raports = new List<Raport>();
        }
        public Car(string vin, string regnum, string name):this()
        {
            this.vin = vin;
            this.regnum = regnum;
            this.name = name;
            speed = 0;
            lights = EnumLights.DRLs;
            emergencyLights = false;
            doorsopen = false;
            alarm = false;
        }

        public void CapSpeed(double cap)
        {
            if (speed > cap)
            {
                speed = cap;
            }
            // temp
        }

        public void ToggleLights(EnumLights type)
        {
            lights = type;
            string log = $"Changed lights to {type}";
            Raports.Add(new Raport(log));

        }
        public void ToggleEmergencyLights()
        {
            emergencyLights = !emergencyLights;
            string log;
            if (emergencyLights)
            {
                log = $"Turned emergency lights ON";
            }
            else
            {
                log = $"Turned emergency lights OFF";
            }
            Raports.Add(new Raport(log));
        }

        public void ToggleDoors()
        {
            doorsopen = !doorsopen;
            string log;
            if (doorsopen)
            {
                log = $"Doors opened";
            }
            else
            {
                log = $"Doors closed";
            }
            Raports.Add(new Raport(log));
            //dodaæ raport do sqla
        }
        public void ToggleAlarm()
        {
            alarm = !alarm;
            string log;
            if (doorsopen)
            {
                log = $"Doors opened";
            }
            else
            {
                log = $"Doors closed";
            }
            Raports.Add(new Raport(log));
            //dodaæ raport do sqla
        }
        public void Notify(string num)
        {
            Console.WriteLine($"Wys³ano powiadomienie na numer alarmowy {num} o godzinie {DateTime.Now}");
        }
        public void ShowLocalization()
        {

        }
        public void Theft(Car c)
        {
            //lokalizacja
            //zatrzymanie samochodu
            //otwieramy drzwi
            //œwiat³a awaryjne ON
            //alarm
            ShowLocalization();
            c.Speed = 0;
            c.Doorsopen = true;
            c.EmergencyLights = true;
            c.Alarm = true;
        }
        public void Emergency()
        {
            //wysy³a powiadomienie do osób z listy emergencyPeople
            //lokalizacja
            //data godzina
            foreach (string num in EmergencyPeopleTel)
            {
                Notify(num);
            }
            ShowLocalization();
        }
        public void Diabetes(Car c)
        {
            //wyœwietla na ekranie ostrze¿enie ¿e coœ siê dzieje z opaski
            //jeœli stan jest bardzo z³y to: 5min na zaznaczenie ¿e jest okej, inaczej:
            //lokalizacja
            //wysy³a powiadomienie do osób z listy emergencyPersons
            //zatrzymanie samochodu
            //œwiat³a awaryjne ON
            //otwieramy drzwi

            ShowLocalization();
            foreach(string num in EmergencyPeopleTel)
            {
                Notify(num);
            }
            c.speed = 0;
            c.doorsopen = true;
            c.emergencyLights = true;
        }

        public void UpdateRaport()
        {
            string oldpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            string path = $"{Path.GetFullPath(Path.Combine(oldpath, @"..\..\..\"))}\\report.txt";
            File.WriteAllText(path, "");
            string textFin = "";
            StringBuilder sb = new StringBuilder();
            foreach(Raport raport in Raports)
            {
                string rep = $"{raport.Log} at {raport.Data}";
                sb.AppendLine(rep);
            }
            File.WriteAllText(path, textFin.ToString());
            //Raports.Clear(); //skoro nie dodajemy do sqla to nie trzeba czyœciæ
        }

        public static void SaveXML(string name, Car c)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            TextWriter writer = new StreamWriter($"{name}.xml");
            serializer.Serialize(writer, c);
            writer.Close();
        }
        public static Car ReadXML(string name)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            FileStream fs = new FileStream($"{name}.xml", FileMode.Open);
            return (Car)serializer.Deserialize(fs);
        }

    }
}

