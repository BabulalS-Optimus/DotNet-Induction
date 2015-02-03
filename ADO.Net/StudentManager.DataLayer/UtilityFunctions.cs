using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentManager.BusinessLayer;
using System.Diagnostics;
using System.Web.Caching;

namespace StudentManager.DataLayer
{
    public class UtilityFunctions
    {

        /// <summary>
        /// Method to get all the streams from the database
        /// </summary>
        /// <returns>Dictionary object holding the StreamID and StreamName</returns>
        public  Dictionary<int, string> GetAllStreams()
        {
            //Dictionary object to hold the results
            Dictionary<int, string> streams = new Dictionary<int, string>();
            
                //SqlConnection object to hold the connection properties
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
                try
                {
                    conn.Open();   //opening the connection

                    //query to be executed
                    string query = "select * from stream_master";
                    SqlCommand comm = new SqlCommand(query, conn);
                    SqlDataReader reader = comm.ExecuteReader(); //executing the query

                    while (reader.Read())
                    {
                        //adding the fetched data to the dictionary object
                        streams.Add(Convert.ToInt32(reader["StreamID"]), reader["StreamName"].ToString());
                    }
                    reader.Close();  //closing the reader
                    conn.Close(); //closing the connection
                }
                catch (SqlException ex)
                {
                    //if any exception occurs while opening the connection
                    Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                    UtilityFunctions.LogToEventLog(ex);
                }
                
            
            return streams; //returing the result
        }

        /// <summary>
        /// Method to get all the states from the database
        /// </summary>
        /// <returns>Dictionary object holding the StateID and StateName</returns>
        public static Dictionary<int, string> GetAllStates()
        {
            //Dictionary object to hold the result
            Dictionary<int, string> states = new Dictionary<int, string>();

               //SqlConnection object to hold the properties of the Database connection
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
                try
                {
                    conn.Open();  //opening the connection

                    //query to be executed
                    string query = "select * from state_master";
                    SqlCommand comm = new SqlCommand(query, conn);
                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        //adding the fetched data to Dictionary object
                        states.Add(Convert.ToInt32(reader["StateID"]), reader["StateName"].ToString());
                    }
                    reader.Close();  //closing the reader
                    conn.Close(); //closing the connection
                }
                catch (SqlException ex)
                {
                    //if any exception found
                    Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                    UtilityFunctions.LogToEventLog(ex);
                }
           

            return states; //returng the result
        }

        /// <summary>
        /// A method to find State Name form database for a specified StateID
        /// </summary>
        /// <param name="stateID">StateID for which StateName is searched</param>
        /// <returns>State Name</returns>
        public static string GetStateName(int stateID)
        {
            //Object to hold the connection properties
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open(); //opening the connection
                //query to be executed
                string query = "select StateName from state_master where StateID=@stateID";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("stateID", stateID);
                object value = comm.ExecuteScalar(); //executing the query

                if (value != null)  //if any data is fetched
                {
                    return value.ToString(); //returning the result
                }
            }
            catch (SqlException ex)
            {
                //if any exception is found
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }


            return null;
        }

        /// <summary>
        /// A method to find Stream Name form database for a specified StreamID
        /// </summary>
        /// <param name="stateID">StreamID for which StreamName is searched</param>
        /// <returns>Stream Name</returns>
        public static string GetStreamName(int streamID)
        {
            //SqlConnection object to hold properties of the connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ToString());
            try
            {
                conn.Open(); //opening the connection

                //query to be executed
                string query = "select StreamName from stream_master where StreamID=@streamID";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("streamID", streamID);
                object value = comm.ExecuteScalar();

                if (value != null)  //if any data is fetched
                {
                    return value.ToString(); //returning the fetched data
                }
            }
            catch (SqlException ex)
            {
                //if any exception is found while opening the connection
                Console.WriteLine("{0} EX : {1} ", Messages.ConnToDBFailed, ex.ToString());
                UtilityFunctions.LogToEventLog(ex);
            }


            return null;
        }

        /// <summary>
        /// Method to log the exception in EventLog
        /// </summary>
        /// <param name="ex">Exception object to store in EventLog</param>
        public static void LogToEventLog(Exception ex)
        {

            //logging exception in Application Event Log

            //Note : as this account does not have the Administrative privileges, we cannot write Event Logs
            //uncomment the code if you have Privileges to create event logs for this account.


            EventLog eventLog = new EventLog();
            eventLog.Source = "Student";
            eventLog.WriteEntry(ex.ToString());

        }
    }
}