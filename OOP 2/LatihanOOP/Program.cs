namespace LatihanOOP;

public class School
{
    //Atribut
    public string sname { get; set; }
    public string location { get; set; }
    public int since { get; set; }

    //Constructor

    public School(string sname, string location)
    {
        sname = sname;
        location = location;
    }

    public School (string sname, string location, int since)
    {
        this.sname = sname;
        this.location = location;
        this.since = since;
    }

    public void Tampilkan()
    {
        Console.WriteLine("School Name: " + sname);
        Console.WriteLine("School Location: " + location);
        Console.WriteLine("Since : " + since);
    }

    public class Student : School
    {
        public int id;
        public string name;

        public Student(string sname, string location, int id, string name)
            : base(sname, location)
        {
            this.sname = sname;
            this.location = location;
            this.id = id;
            this.name = name;
        }

        public void PerkenalanDiri()
        {
            Console.WriteLine("Hai saya dari sekolah : " + sname);
            Console.WriteLine("Yang belokasi di : " + location);
            Console.WriteLine("Saya juga memiliki nama, yaitu : " + name);
            Console.WriteLine("dan ID Student saya adalah : " + id);
        }
    }

    static void Main(string[]args)
    {
        School mySchool = new School("UBSI", "Kota Bogor", 1994);
        mySchool.Tampilkan();
        Student mystudent = new Student("UBSI","Kota Bogor",22,"Naruto");
        mystudent.PerkenalanDiri();
    }
}