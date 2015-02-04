using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XMLAssignment.BusinessLayer;

namespace XMLAssignment.DataLayer
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
        /// parametric constructor to hold record for a new student
        /// </summary>
        /// <param name="fullName">full name of the student</param>
        /// <param name="fathersName">fathers name </param>
        /// <param name="age">age of the student</param>
        /// <param name="stream">stream for his course</param>
        /// <param name="address">address of the student</param>
        /// <param name="state">state which the student belongs to</param>
        public Student(string fullName, string fathersName, int rollNo, int age, string stream, string address, string state)
        {
            this.fullName = fullName;
            this.fathersName = fathersName;
            this.rollNo = rollNo;
            this.age = age;
            this.stream = this.GetStream(stream);
            this.address = address;
            this.state = this.GetState(state);
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
        /// Method to  insert student in databse
        /// </summary>
        /// <param name="studentsData">List containing records of student</param>
        /// <returns>result for the operation</returns>
        public static bool InsertStudents(List<Student> studentsData)
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
                Console.WriteLine("{0} EX : {1} ", Strings.ConnToDBFailed, ex.ToString());
            }

            //returning the result
            return result;
        }


        /// <summary>
        /// Method to get Stream ID from database
        /// </summary>
        /// <param name="state">Stream name</param>
        /// <returns>stream id</returns>
        public int GetStream(string stream)
        {
            int result = 14;
            //Object to hold the connection properties
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open(); //opening the connection
                //query to be executed
                string query = "select StreamID from stream_master where StreamName=@streamName";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("streamName", stream);
                object value = comm.ExecuteScalar(); //executing the query

                if (value != null)  //if any data is fetched
                {
                    int.TryParse(value.ToString(), out result); //returning the result
                }
            }
            catch (SqlException)
            {
                //if any exception is found
            }
            return result;
        }

        /// <summary>
        /// Method to get State ID from database
        /// </summary>
        /// <param name="state">State name</param>
        /// <returns>state id</returns>
        public int GetState(string state)
        {
            int result = 32;
            //Object to hold the connection properties
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open(); //opening the connection
                //query to be executed
                string query = "select StateID from state_master where StateName=@stateName";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("stateName", state);
                object value = comm.ExecuteScalar(); //executing the query

                if (value != null)  //if any data is fetched
                {
                    int.TryParse(value.ToString(), out result); //returning the result
                }
            }
            catch (SqlException)
            {
                //if any exception is found
            }
            return result;
        }
    }
}