using System;

namespace OOPSConcept
{
    //solutin for assignment 8
    class Student
    {
        //private attributes for storing information about the student
        #region Attributes
        private string name;
        private int age;
        private string course;
        private int[] marks = new int[6];
        private int roll;
        private string adm_date;
        private static int studentCount = 0;
        private long enrolmentNo;
        #endregion

        //public properties for private attributes
        #region PublicProperties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {

            get { return age; }
            set { age = value; }
        }
        public string Course
        {

            get { return course; }
            set { course = value; }
        }
        public int[] Marks
        {

            get { return marks; }
            set { marks = value; }
        }
        public int Roll
        {
            get { return roll; }
            set { roll = value; }
        }
        public string Adm_date
        {

            get { return adm_date; }
            set { adm_date = value; }
        }
        public long EnrolmentNo
        {
            get { return enrolmentNo; }
        }
        public static int StudentCount
        {
            get { return studentCount; }
        }
        #endregion

        //enum for StudentAttributes
        internal enum StudentAttributes
        {
            Name,
            Age,
            Course,
            Marks,
            Roll,
            Adm_Date,
            EnrollmentNo,
            Percentage
        }
        
        //parameteric constructor for creating a new Student object
        public Student(string name, int age, string course, int[] marks, int roll, string admDate)
        {
            this.name = name;
            this.age = age;
            this.course = course;
            this.marks = marks;
            this.roll = roll;
            this.adm_date = admDate;
            studentCount++;
            this.enrolmentNo = RandomNumberGenerator();
        }
       
        //Random Number Generator function for Enrolment Number of the student
        private long RandomNumberGenerator()
        {
            Random randomObject = new Random();
            return randomObject.Next();
        }
        
        //Method to display all the details of the Student 
        public void ShowDetails()
        {
            double sum = 0; //to store the sum of marks
            //printing the details of the user
            Console.WriteLine("Hello {0},", name);
            Console.WriteLine("\tHere are your details:\n");
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("Age : {0}", age);
            Console.WriteLine("Course : {0}", course);
            Console.WriteLine("Roll number : {0}", roll);
            Console.WriteLine("Enrolment number : {0}", enrolmentNo);
            Console.WriteLine("Admission date : {0}", adm_date);
            Console.Write("Marks : ");
            for (int i = 0; i < 6; i++)
            {
                sum += marks[i];
                Console.Write("{0}\t ", marks[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Percentage : {0:F2} ", (sum / 600));
            Console.WriteLine("\n\tThank you!!!!\n");
        }
       
        //overloaded method to display details of student as per choice
        public void ShowDetails(int choice)
        {
            //checking for the choice of the user
            switch (choice)
            {
                case (int)StudentAttributes.Name:
                    //if choice is for name
                    Console.WriteLine("Name : {0}", name);
                    break;
                case (int)StudentAttributes.Course:
                    //if choice is for Course name
                    Console.WriteLine("Course : {0}", course);
                    break;
                case (int)StudentAttributes.Age:
                    //if choice is for age
                    Console.WriteLine("Age : {0}", age);
                    break;
                case (int)StudentAttributes.Roll:
                    //if choice is for Roll number
                    Console.WriteLine("Roll number : {0}", roll);
                    break;
                case (int)StudentAttributes.EnrollmentNo:
                    //if choice is for Enrolment number
                    Console.WriteLine("Enrolment number : {0}", enrolmentNo);
                    break;
                case (int)StudentAttributes.Adm_Date:
                    //if choice is for Admission Date
                    Console.WriteLine("Admission date : {0}", adm_date);
                    break;
                case (int)StudentAttributes.Marks:
                    //if choice is for Marks
                    Console.Write("Marks : ");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write("{0}\t ", marks[i]);
                    }
                    Console.WriteLine();
                    break;
                case (int)StudentAttributes.Percentage:
                    //if choice is for Percentage
                    int sum = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        sum += marks[i];
                    }
                    Console.WriteLine("Percentage : {0:F2} ", (sum / 600));
                    break;
            }
        }
    }
}
