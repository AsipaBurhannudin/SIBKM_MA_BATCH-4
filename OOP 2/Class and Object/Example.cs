using System;

namespace ClassAndObject
{
    public class Employee
    {
        public string id;
        public string name;
        public float salary;
        public string job;

        public void Introduction()
        {
            Console.WriteLine("===================");
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Salary : " + salary);
            Console.WriteLine("Job : " + job);
        }

        public int CalculateTax()
        {
            float tax = 2.5f;
            return (int)(salary * tax);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Employee fahri = new Employee();
            Employee hanif = new Employee();

            fahri.id = "xee22";
            fahri.name = "Fahriii";
            fahri.salary = 10000;
            fahri.job = "Accountant";

            hanif.id = "xee23";
            hanif.name = "Hanifff";
            hanif.salary = 15000;
            hanif.job = "Programmer";

            fahri.Introduction();
            hanif.Introduction();
        }
    }

}