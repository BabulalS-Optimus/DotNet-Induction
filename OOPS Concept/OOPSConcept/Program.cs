using System;

namespace OOPSConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            //an array of marks
            int[] marks={60,70,65,77,80,87};

            //creating objects for Student class
            Student st1 = new Student("Babu Lal Swami", 21, "B.Tech.", marks, 23, "29/01/2015");
            Student st2 = new Student("Babu Lal Swami", 21, "B.Tech.", marks, 23, "29/01/2015");
            
            //showing all the details of the Student
            st1.ShowDetails();

            //showing the Age of the Student using overloaded method
            st1.ShowDetails((int)Student.StudentAttributes.Age);

            //showing the Percentage of the Student using overloaded method
            st1.ShowDetails((int)Student.StudentAttributes.Percentage);



            //checking the count of Students
            Console.WriteLine("Total number of students : {0}", Student.StudentCount);

            Console.ReadKey(); //to pause the console to see the output


        }
    }
}
