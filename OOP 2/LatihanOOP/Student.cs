using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanOOP
{
    public class Student : School
    {
        public int id;
        public string  name;

        public Student (string sname, string location, int id, string name)
            :base(sname,location)
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
}
