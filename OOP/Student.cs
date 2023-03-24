using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class School
    {
        public string School_Name { get; set; }
        public string Location { get; set; }
        public string Principal { get; set; }
        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }

        public School(string sname, string location, string principal)
        {
            School_Name = sname;
            Location = location;
            Principal = principal;
        }

        public School(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public void PrintInfo()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("School Name: {0}", School_Name);
            Console.WriteLine("Location: {0}", Location);
            Console.WriteLine("Principal: {0}", Principal);
        }
    }

    class Student : School
    {
        public string ID { get; set; }
        public string Grade { get; set; }
        public string Gender { get; set; }


        public Student(string sname, string location, string principal, string id, string grade, string gender)
            : base(sname, location, principal)
        {
            ID = id;
            Grade = grade;
            Gender = gender;
        }

        public void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("=======================");
            Console.WriteLine("Student ID: {0}", ID);
            Console.WriteLine("Grade: {0}", Grade);
            Console.WriteLine("Gender: {0}", Gender);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student myStudent = new Student("UBSI", "Kota Bogor", "Bu Dewi", "12", "11th Grade","Male");
            myStudent.PrintInfo();
        }
    }
}
