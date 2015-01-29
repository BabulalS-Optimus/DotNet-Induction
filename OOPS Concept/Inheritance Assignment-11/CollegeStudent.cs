using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class CollegeStudent : Student
    {
           //private attributes for SchoolStudent class
        #region PrivateAttributes
        private string collegeName;
        private string universityName;
        private string classTeacher;
        private string course;
        private double[] tgpa;
        #endregion

        //public properties for private attributes
        #region PublicProperty
        public string CollegeName
        {
            get { return collegeName; }
            set { collegeName = value; }
        }
        public string UniversityName
        {
            get { return universityName; }
            set { universityName = value; }
        }
        public string Course
        {
            get { return course; }
            set { course = value; }
        }

        public string ClassTeacher
        {
            get { return classTeacher; }
            set { classTeacher = value; }
        }
        public double[] TGPA
        {
            get { return tgpa; }
            set { tgpa = value; }
        }
        #endregion

        //parametric constructor for SchoolStudent 
        public CollegeStudent(string fullName, int age, string section, int roll, string adm_date, string collegeName, string universityName, string classTeacher, double[] tgpa)
            : base(fullName, age, section, roll, adm_date)
        {
            this.collegeName = collegeName;
            this.universityName = universityName;
            this.classTeacher = classTeacher;
            this.tgpa = tgpa;
        }

        //method to display details of the student
        public void ShowDetails()
        {
            Console.WriteLine("Details of student : ");
            base.ShowDetails(); //display the basic details from base class
            Console.WriteLine("College Name: {0} ", CollegeName);  //displaying college name
            Console.WriteLine("University Name: {0} ", UniversityName);  //displaying university name
            Console.WriteLine("Course Name : {0} ", ClassTeacher); //displaying course name
            Console.WriteLine("Class Teacher : {0} ", ClassTeacher); //displaying class teacher's name
            Console.Write("TGPA : ");
            double sum = 0; // to store the sum of TGPA obtained by the student in each semester
            for (int i = 0; i < tgpa.Length; i++)
            {
                Console.Write(" {0}\t", tgpa[i]);
                sum += tgpa[i];
            }
            Console.WriteLine("\nCGPA : {0:F2}",(sum/tgpa.Length)); //displaying the percentage
            Console.ReadKey();
        }
    }
}
