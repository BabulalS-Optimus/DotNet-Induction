using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] marks={77,87,69,74,89};
            SchoolStudent schoolStudent = new SchoolStudent("Babu Lal Swami", 21, "12-F", 27, "25/01/2015","Chiranjiv Bharati School","Mr. Ajay Singh",marks);
            schoolStudent.ShowDetails();

            Console.WriteLine("\n");
            double[] tgpa = { 7.8, 6.7, 8.3, 7.9, 7.7, 6.9 };
            CollegeStudent collStudent = new CollegeStudent("Babu Lal Swami", 21, "K1101", 51, "12/01/2014", "Lovely Professional University", "Lovely Professional University", "Nikhil Sharma", tgpa);
            collStudent.ShowDetails();

            Console.ReadKey();
        }
    }
}
