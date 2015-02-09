using System.Collections.Generic;

namespace StudentService
{
    /// <summary>
    /// Service to handle records of Student
    /// </summary>
    public class StudentDataHandler : IStudentDataHandler
    {
        /// <summary>
        /// Method to fetch record of a student with specified roll number
        /// </summary>
        /// <param name="rollNo">Roll number of the student to search for</param>
        /// <returns>Student object holding the record</returns>
        public List<string> GetStudentRecord(int rollNo)
        {
            //Call GetRecord() method of UtilityFunctions which fetches the data from database
            Student stud = UtilityFunctions.GetRecord(rollNo);

            //check the return result
            if (stud == null)
                return null;

            //save record in the List
            List<string> data = new List<string>();
            #region Save data in List
            data.Add(stud.StudID.ToString());
            data.Add(stud.FullName);
            data.Add(stud.FathersName);
            data.Add(stud.Age.ToString());
            data.Add(stud.RollNo.ToString());
            data.Add(stud.Stream);
            data.Add(stud.State);
            data.Add(stud.Address);
            #endregion

            return data;
        }
    }
}
