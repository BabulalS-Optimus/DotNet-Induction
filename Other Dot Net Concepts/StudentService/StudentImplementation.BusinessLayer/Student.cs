using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentImplementation.BusinessLayer
{
    public class Student
    {
        /// <summary>
        /// public properties
        /// </summary>
        #region PublicProps
        public int StudID { get; set; }
        public string FullName { get; set; }
        public string FathersName { get; set; }
        public int RollNo { get; set; }
        public int Age { get; set; }
        public string Stream { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        #endregion

        /// <summary>
        /// parametric constructor to hold a already created student record
        /// </summary>
        /// <param name="studID">Roll number of the student</param>
        /// <param name="fullName">full name of the student</param>
        /// <param name="fathersName">fathers name </param>
        /// <param name="age">age of the student</param>
        /// <param name="stream">stream for his course</param>
        /// <param name="address">address of the student</param>
        /// <param name="state">state which the student belongs to</param>
        public Student(int studID, string fullName, string fathersName, int rollNo, int age, string stream, string address, string state)
        {
            StudID = studID;
            FullName = fullName;
            FathersName = fathersName;
            RollNo = rollNo;
            Age = age;
            Stream = stream;
            Address = address;
            State = state;
        }
    }
}