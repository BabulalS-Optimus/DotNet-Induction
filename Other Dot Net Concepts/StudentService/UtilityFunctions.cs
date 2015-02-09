using System.Configuration;
using System.Data.SqlClient;

namespace StudentService
{
    /// <summary>
    /// Class to handle database operations
    /// </summary>
    public class UtilityFunctions
    {
        /// <summary>
        /// Method to fetch Student record from database
        /// </summary>
        /// <param name="rollNo">Roll number of the student to search for</param>
        /// <returns>Studnet object holding record of the student</returns>
        public static Student GetRecord(int rollNo)
        {
            Student stud = null;

            //SqlConnection object to hold the properties of the Database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open();

                //Fetch the data and store it in the Student object
                string query = "select * from student_master where rollNo=@rollNo";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("rollNo", rollNo);
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    #region adding the fetched data to student object
                    int studID;
                    int.TryParse(reader[0].ToString(), out studID);
                    string fullName = reader[1].ToString();
                    string fathersName = reader[2].ToString();
                    int age;
                    int.TryParse(reader[4].ToString(), out age);
                    string stream = reader[5].ToString();
                    string address = reader[6].ToString();
                    string state = reader[7].ToString();
                    stud = new Student(studID, fullName, fathersName, rollNo, age, stream, address, state);
                    #endregion
                }
                reader.Close();  //closing the reader
                conn.Close(); //closing the connection
            }
            catch (SqlException)
            {
                stud = null;
            }


            return stud;
        }
    }
}