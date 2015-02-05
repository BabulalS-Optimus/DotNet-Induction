using System;

namespace Serialization.BusinessLayer
{
    /// <summary>
    /// Class holding the record of student
    /// </summary>
    [Serializable]
    public class Student
    {

        #region Public Members
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
        public char Grade
        {
            get
            {
                #region Calculate Grade
                if (TotalMarks > 60)
                {
                    return 'D';
                }
                else if (TotalMarks >= 60 && TotalMarks < 80)
                {
                    return 'C';
                }
                else if (TotalMarks >= 80 && TotalMarks < 90)
                {
                    return 'B';
                }
                else if (TotalMarks >= 90)
                {
                    return 'A';
                }
                else
                {
                    return 'F';
                }
                #endregion
            }
        }
        #endregion

        public Student()
        {
        }

        /// <summary>
        /// Perametric Constructor to create a new student record
        /// </summary>
        /// <param name="rollNo">Roll number of the student</param>
        /// <param name="name">Name of the student</param>
        /// <param name="totalMarks">Total Marks student obtained</param>
        public Student(int rollNo, string name, int totalMarks)
        {
            RollNo = rollNo;
            Name = name;
            TotalMarks = totalMarks;
        }

    }
}