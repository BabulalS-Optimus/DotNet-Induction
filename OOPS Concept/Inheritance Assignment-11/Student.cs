using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Student
    {
        internal string fullName;
        internal string section;
        internal int age;
        internal int roll;
        internal string adm_date;
        internal static int studentCount = 0;

        public Student(string fullName, int age, string section, int roll, string adm_date)
        {
            this.fullName = fullName;
            this.age = age;
            this.section = section;
            this.roll = roll;
            this.adm_date = adm_date;
            studentCount++;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Full Name : {0}", fullName);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Section: {0}", section);
            Console.WriteLine("Roll Number: {0}", roll);
            Console.WriteLine("Admission Date : {0}", adm_date);
        }

    }
}
