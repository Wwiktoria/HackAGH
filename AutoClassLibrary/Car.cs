public class Car
{
    public string vin;
    public string regnum;
    //jakiœ pseudonim dla samochodu
    public double speed;
    public bool frontlights;
    public bool rearlights;
    public bool doorsopen;
    public (double, double) localization;

    public string Vin { get { return vin; } set { vin = value; } }
    public string Regnum { get { return regnum; } set { regnum = value; } }
    public bool Frontlights { get { return frontlights; } set { frontlights = value; } }
    public bool Rearlights { get { return rearlights; } set { rearlights = value; } }
    public bool Doorsopen { get { return doorsopen; } set { doorsopen = value; } }
    public (double, double) Localization { get { return localization; } set { localization = value; } }


    public double SpeedCap()
    {

    }
    public bool ToggleLights(bool lights)
    {

    }
    public ? ShowLocalization((double, double) localization)
    {

    }





}