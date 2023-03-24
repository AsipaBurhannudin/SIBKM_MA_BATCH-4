using System;

namespace School
{
    class School
    {
        public string School_Name { get; set; }
        public string Location { get; set; }
        public string Principal { get; set; }

        public School(string sname, string location, string principal)
        {
            School_Name = sname;
            Location = location;
            Principal = principal;
        }

        public void PrintInfo()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("School Name: {0}", School_Name);
            Console.WriteLine("Location: {0}", Location);
            Console.WriteLine("Principal: {0}", Principal);
        }
    }
}































/*class School
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Principal { get; set; }

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
}*/
