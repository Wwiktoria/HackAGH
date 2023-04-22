public class User
{
    public string name;
    public string surname;
    public string telnr;

    public string Name { get { return name; } set { name = value; } }
    public string Surame { get { return surname; } set { surname = value; } }
    public string Telrn
    {
        get { return telrn; }
        //parsowanie
        set { telrn = value; }
    }
}