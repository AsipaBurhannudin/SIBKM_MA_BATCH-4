using System;

class School
{
    private string name;
    private string location;
    private string principal;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    public string Principal
    {
        get { return principal; }
        set { principal = value; }
    }

    public School(string name, string location, string principal)
    {
        Name = name;
        Location = location;
        Principal = principal;
    }

    public void PrintInfo()
    {
        Console.WriteLine("School Name: {0}", Name);
        Console.WriteLine("Location: {0}", Location);
        Console.WriteLine("Principal: {0}", Principal);
    }
}

class Program
{
    static void Main(string[] args)
    {
        School mySchool = new School("ABC School", "Jakarta", "Mr. John");
        mySchool.PrintInfo();

        // Mengakses properti secara langsung akan menghasilkan error karena mereka telah dienkapsulasi
        // mySchool.name = "DEF School";
        // mySchool.location = "Bandung";
        // mySchool.principal = "Ms. Jane";

        // Mengakses properti menggunakan metode setter
        mySchool.Name = "DEF School";
        mySchool.Location = "Bandung";
        mySchool.Principal = "Ms. Jane";

        mySchool.PrintInfo();
    }
}

