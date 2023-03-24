using System;


namespace Inheritance;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Person(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Name: {0}", Name);
        Console.WriteLine("Age: {0}", Age);
        Console.WriteLine("Gender: {0}", Gender);
    }
}

class Student : Person
{
    public string ID { get; set; }
    public string Grade { get; set; }

    public Student(string name, int age, string gender, string id, string grade)
        : base(name, age, gender)
    {
        ID = id;
        Grade = grade;
    }

    public void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Student ID: {0}", ID);
        Console.WriteLine("Grade: {0}", Grade);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student myStudent = new Student("John Doe", 17, "Male", "12345", "11th Grade");
        myStudent.PrintInfo();
    }
}