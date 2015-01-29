using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class SchoolStudent : Student
    {
        //private attributes for SchoolStudent class
        #region PrivateAttributes
        private string schoolName;
        private string classTeacher;
        private int[] marks;
        #endregion

        //public properties for private attributes
        #region PublicProperty
        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }

        public string ClassTeacher
        {
            get { return classTeacher; }
            set { classTeacher = value; }
        }
        public int[] Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        #endregion

        //parametric constructor for SchoolStudent 
        public SchoolStudent(string fullName, int age, string section, int roll, string adm_date, string schoolName, string classTeacher,int[] marks)
            : base(fullName, age, section, roll, adm_date)
        {
            this.schoolName = schoolName;
            this.classTeacher = classTeacher;
            this.marks = marks;
        }

        //method to display details of the student
        public void ShowDetails()
        {
            Console.WriteLine("Details of student : ");
            base.ShowDetails(); //display the basic details from base class
            Console.WriteLine("School Name: {0} ", SchoolName);  //displaying school name
            Console.WriteLine("Class Teacher : {0} ", ClassTeacher); //displaying class teacher's name
            Console.Write("Marks : ");
            double sum = 0; // to store the total marks obtained by the student
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(" {0}\t", marks[i]);
                sum += marks[i];
            }
            Console.WriteLine("\nPercentage : {0:F2}",(sum/marks.Length)); //displaying the percentage
            Console.ReadKey();
        }
    }
}
