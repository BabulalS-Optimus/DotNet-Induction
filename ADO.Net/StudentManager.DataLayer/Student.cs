using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentManager.BusinessLayer;

namespace StudentManager.DataLayer
{
    public class Student
    {
        /// <summary>
        /// private members
        /// </summary>
        #region PrivateProps
        private int studID;
        private string fullName;
        private string fathersName;
        private int rollNo;
        private int age;
        private int stream;
        private string address;
        private int state;
        #endregion



        /// <summary>
        /// public properties
        /// </summary>
        #region PublicProps
        public int StudID
        {
            get { return studID; }
            set { studID = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string FathersName
        {
            get { return fathersName; }
            set { fathersName = value; }
        }
        public int RollNo
        {
            get { return rollNo; }
            set { rollNo = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Stream
        {
            get { return stream; }
            set { stream = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion

        /// <summary>
        /// parametric constructor to hold record for a new student
        /// </summary>
        /// <param name="fullName">full name of the student</param>
        /// <param name="fathersName">fathers name </param>
        /// <param name="age">age of the student</param>
        /// <param name="stream">stream for his course</param>
        /// <param name="address">address of the student</param>
        /// <param name="state">state which the student belongs to</param>
        public Student(string fullName, string fathersName, int rollNo, int age, int stream, string address, int state)
        {
            this.fullName = fullName;
            this.fathersName = fathersName;
            this.rollNo = rollNo;
            this.age = age;
            this.stream = stream;
            this.address = address;
            this.state = state;
        }

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
        public Student(int studID, string fullName, string fathersName, int rollNo, int age, int stream, string address, int state)
        {
            this.studID = studID;
            this.fullName = fullName;
            this.fathersName = fathersName;
            this.rollNo = rollNo;
            this.age = age;
            this.stream = stream;
            this.address = address;
            this.state = state;
        }

        /// <summary>
        /// method to add a new Student record in the database
        /// </summary>
        /// <returns>whether record added or not.</returns>
        public bool AddStudent()
        {
            bool result = false;

            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                //opeining the connection
                conn.Open();

                //query to be executed
                string query = "insert into student_master values(@fullname,@fathersName,@rollNo,@age,@stream,@address,@state)";

                //SqlCommand object to handle the query execution
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("fullname", this.fullName);
                comm.Parameters.AddWithValue("fathersName", this.fathersName);
                comm.Parameters.AddWithValue("rollNo", this.rollNo);
                comm.Parameters.AddWithValue("age", this.age);
                comm.Parameters.AddWithValue("stream", this.stream);
                comm.Parameters.AddWithValue("address", this.address);
                comm.Parameters.AddWithValue("state", this.state);
                int count = comm.ExecuteNonQuery(); //executing the query

                conn.Close(); //closing the connection with the database

                if (count > 0) //checking if any record got added or not?
                    result = true;
            }
            catch (SqlException ex)
            {
                //if found any exception
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            return result; //returning the result
        }

        /// <summary>
        /// method to update record of any student
        /// </summary>
        /// <returns>whether record updated or not</returns>
        public bool UpdateStudent()
        {
            bool result = false;

            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open();   //opening the connection to the database

                //query to be excecuted
                string query = "update student_master set FullName=@fullname, FathersName=@fathersName,RollNo=@rollNo, Age=@age, Stream=@stream, Address=@address, State=@state where StudID=@studID";

                //SqlCommand object to handle the execution of the query
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("fullname", this.fullName);
                comm.Parameters.AddWithValue("fathersName", this.fathersName);
                comm.Parameters.AddWithValue("rollNo", this.rollNo);
                comm.Parameters.AddWithValue("age", this.age);
                comm.Parameters.AddWithValue("stream", this.stream);
                comm.Parameters.AddWithValue("address", this.address);
                comm.Parameters.AddWithValue("state", this.state);
                comm.Parameters.AddWithValue("studID", this.StudID);
                int count = comm.ExecuteNonQuery();  //exceuting the query

                conn.Close();  //closing the connection with database

                if (count > 0)  //checking whether any data got updated or not ?
                    result = true;
            }
            catch (SqlException ex)
            {
                //if found any exception
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            return result;  //returning the result
        }

        /// <summary>
        /// Method to retreave all the records of the students
        /// </summary>
        /// <returns>list of all students</returns>
        public static List<Student> ListAllStudents()
        {
            //list to store information of the students fetched from the database
            List<Student> students = new List<Student>();

            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open();   //opening the connection with the database

                //query to be executed
                string query = "select * from student_master";
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();

                //reading the data from DataReader after fetching
                while (reader.Read())
                {
                    //creating object of Student
                    Student stud = new Student(Convert.ToInt32(reader["StudID"]), reader["FullName"].ToString(), reader["FathersName"].ToString(), Convert.ToInt32(reader["RollNo"]), Convert.ToInt32(reader["Age"]), Convert.ToInt32(reader["Stream"]), reader["Address"].ToString(), Convert.ToInt32(reader["State"]));
                    students.Add(stud); //adding the object to List
                }
                reader.Close(); //closing the reader
                conn.Close(); //closing the connection
            }
            catch (SqlException ex)
            {
                //if found any exception in opening the connection
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            return students; //returning the list
        }

        /// <summary>
        /// Method to search for any specific Student in the database
        /// </summary>
        /// <param name="studID">ID of the student to search for</param>
        /// <returns>Object of student class holding the details regarding the searched student.</returns>
        public static Student FindStudent(int studID)
        {
            Student result = null;

            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open();  //opening the connection to the database

                //query to be executed
                string query = "select * from student_master where StudID=@studID";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("StudID", studID);
                SqlDataReader reader = comm.ExecuteReader(); //executing the query
                if (reader.HasRows)
                {
                    //if found any data
                    reader.Read();
                    result = new Student(Convert.ToInt32(reader["StudID"]), reader["FullName"].ToString(), reader["FathersName"].ToString(), Convert.ToInt32(reader["RollNo"]), Convert.ToInt32(reader["Age"]), Convert.ToInt32(reader["Stream"]), reader["Address"].ToString(), Convert.ToInt32(reader["State"]));
                }
                reader.Close(); //closing the reader
                conn.Close(); //closing the connection
            }
            catch (SqlException ex)
            {
                //if found any exception
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            return result; //returning the result
        }

        /// <summary>
        /// Method to delete student record using roll numbers
        /// </summary>
        /// <param name="rollNos">roll numbers of the students to delete.</param>
        /// <returns>Deletion success or failure</returns>
        public static bool DeleteStudent(string rollNos)
        {
            bool result = false;

            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open();   //opening the connection to the database
                string[] listRollNo = rollNos.Split(',');

                //traversing the list of roll numbers received
                for (int i = 0; i < listRollNo.Length - 1; i++)
                {
                    string rollNo = listRollNo[i];

                    //query to be excecuted
                    string query = "delete from student_master where RollNo=@rollNo";

                    //SqlCommand object to handle the execution of the query
                    SqlCommand comm = new SqlCommand(query, conn);
                    comm.Parameters.AddWithValue("rollNo", rollNo);
                    int count = comm.ExecuteNonQuery();  //exceuting the query

                    if (count > 0)  //checking whether any data got deleted or not ?
                        result = true;
                    else
                    {
                        //if no item got deleted
                        result = false;
                        break;
                    }
                }
                conn.Close();  //closing the connection with database

            }
            catch (SqlException ex)
            {
                //if found any exception
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            return result;
        }

        /// <summary>
        /// Method to  insert student in databse
        /// </summary>
        /// <param name="studentsData">List containing records of student</param>
        /// <returns>result for the operation</returns>
        public static bool insertStudents(List<Student> studentsData)
        {
            bool result = false;
            //SqlConnection object to hold the properties of the connect
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                //opeining the connection
                conn.Open();

                //traversing the list
                foreach (Student stud in studentsData)
                {
                    //query to be executed
                    string query = "insert into student_master values(@fullname,@fathersName,@rollNo,@age,@stream,@address,@state)";

                    //SqlCommand object to handle the query execution
                    SqlCommand comm = new SqlCommand(query, conn);
                    comm.Parameters.AddWithValue("fullname", stud.fullName);
                    comm.Parameters.AddWithValue("fathersName", stud.fathersName);
                    comm.Parameters.AddWithValue("rollNo", stud.rollNo);
                    comm.Parameters.AddWithValue("age", stud.age);
                    comm.Parameters.AddWithValue("stream", stud.stream);
                    comm.Parameters.AddWithValue("address", stud.address);
                    comm.Parameters.AddWithValue("state", stud.state);
                    int count = comm.ExecuteNonQuery(); //executing the query


                    if (count > 0) //checking if any record got added or not?
                        result = true;
                }
                conn.Close(); //closing the connection with the database

            }
            catch (SqlException ex)
            {
                //if found any exception
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }

            //returning the result
            return result;
        }
    }
}