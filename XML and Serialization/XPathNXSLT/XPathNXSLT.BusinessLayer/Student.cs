using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XPathNXSLT.BusinessLayer
{
    /// <summary>
    /// Class to hold student information
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Public properties
        /// </summary>
        #region Public Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string Stream { get; set; }
        public string Address { get; set; }
        #endregion

        /// <summary>
        /// Parametric Constructor
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <param name="age">Age of the student</param>
        /// <param name="stream">Stream of the student</param>
        /// <param name="address">Address for the student</param>
        public Student(string name, int age, string stream, string address)
        {
            Name = name;
            Age = age;
            Stream = stream;
            Address = address;
        }
    }
}