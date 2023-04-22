using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private bool doorsopen;

        [Key]
        public string Vin { get { return vin; } set { vin = value; } }
        public string Regnum { get { return regnum; } set { regnum = value; } }
        public string Name { get { return name; } set { Name = value; } }
        public double Speed { get { return speed; } set { speed = value; } }
        public EnumLights Lights { get { return lights; } set { lights = value; } }
        public bool EmergencyLights { get { return emergencyLights; } set { emergencyLights = value; } }
        public bool Doorsopen { get { return doorsopen; } set { doorsopen = value; } }
        public virtual User User { get; set; }
        public int Email { get; set; }

        public Car(string vin, string regnum, string name)
        {
            this.vin = vin;
            this.regnum = regnum;
            this.name = name;
            speed = 0;
            lights = EnumLights.DRLs;
            emergencyLights = false;
            doorsopen = false;
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
        }

        public void ToggleEmergencyLights()
        {
            emergencyLights = !emergencyLights;
        }

        public void ToggleDoors()
        {
            doorsopen = !doorsopen;
        }
    }
}

