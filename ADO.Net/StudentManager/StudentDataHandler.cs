using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManager.DataLayer;

namespace StudentManager
{
    public class StudentDataHandler
    {

        /// <summary>
        /// A method to Add a new student in the database
        /// </summary>/// <param name="fullName">full name of the student</param>
        /// <param name="fathersName">fathers name </param>
        /// <param name="age">age of the student</param>
        /// <param name="stream">stream for his course</param>
        /// <param name="address">address of the student</param>
        /// <param name="state">state which the student belongs to</param>
        /// <returns>returns whether the record added to the database or not</returns>
        public bool AddStudent(string fullName, string fathersName, int rollNo, int age, int stream, string address, int state)
        {
            bool result = false;
            Student st = new Student(fullName, fathersName, rollNo, age, stream, address, state); //creating a new object of student class
            result = st.AddStudent(); //adding the record to the database
            return result;
        }

        /// <summary>
        /// Method to update the recortd of a student
        /// </summary>
        /// <param name="stud">Updated information regarding the student</param>
        /// <returns>Whether record got updated or not</returns>
        public static bool UpdateStudent(Student stud)
        {
            bool result;
            result = stud.UpdateStudent();
            return result;
        }

        /// <summary>
        /// Method to retrteave all the reords of students from database
        /// </summary>
        /// <returns>A list with details of all the students</returns>
        public static List<Student> ListAllStudent()
        {
            List<Student> students = Student.ListAllStudents();
            return students;
        }

        /// <summary>
        /// Method to search any student
        /// </summary>
        /// <param name="studID">Student ID to search for</param>
        /// <returns>Student object which holds the information regarding the searched student</returns>
        public static Student FindStudent(int studID)
        {
            Student result = Student.FindStudent(studID);
            return result;
        }

        /// <summary>
        /// Method to delete student record using roll numbers
        /// </summary>
        /// <param name="rollNos">roll numbers of the students to delete.</param>
        /// <returns>Deletion success or failure</returns>
        public static bool DeleteStudent(string rollNos)
        {
            bool result = Student.DeleteStudent(rollNos);
            return result;
        }
    }
}