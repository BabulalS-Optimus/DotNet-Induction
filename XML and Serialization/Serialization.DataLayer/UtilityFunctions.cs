using System;
using Serialization.BusinessLayer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;


namespace Serialization.DataLayer
{
    /// <summary>
    /// Class which handles Serialization and storing the data into files
    /// </summary>
    public class UtilityFunctions
    {
        /// <summary>
        /// Method to serialize the Student object using binary serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeBinary(Student stud, string filePath)
        {
            bool result = false;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                //create formatter and open the stream to file
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);

                //Serialize and save
                formatter.Serialize(stream, stud);
                stream.Close();

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize Student object using binary deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static Student DeserializeBinary(string filePath)
        {
            Student stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                //Create formatter
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    //create stream and deserialize the object
                    Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    stud = formatter.Deserialize(stream) as Student;
                    stream.Close();
                }
                catch (Exception)
                {
                    stud = null;
                }
            }

            //retrun the status
            return stud;
        }

        /// <summary>
        /// Method to serialize the Student object using XML serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeXml(Student stud, string filePath)
        {
            bool result = false;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Student));

                // To write to a file, create a StreamWriter object.
                StreamWriter writer = new StreamWriter(filePath);
                serializer.Serialize(writer, stud);
                writer.Close();

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize Student object using xml deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static Student DeserializeXml(string filePath)
        {
            Student stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                try
                {
                    FileStream stream = new FileStream(filePath, FileMode.Open);
                    // Call the Deserialize method and cast to the object type.
                    stud = serializer.Deserialize(stream) as Student;
                    stream.Close();
                }
                catch (Exception)
                {
                    stud = null;
                }
            }

            //retrun the status
            return stud;
        }

        /// <summary>
        /// Method to serialize the Student object using SOAP serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeSoap(Student stud, string filePath)
        {
            bool result = false;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {

                FileStream stream = new FileStream(filePath, FileMode.Create);

                // Construct a SoapFormatter and use it  
                // to serialize the data to the stream.
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    formatter.Serialize(stream, stud);
                }
                catch (SerializationException)
                {
                }
                finally
                {
                    stream.Close();
                }

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize Student object using SOAP deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static Student DeserializeSoap(string filePath)
        {
            Student stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                try
                {
                    SoapFormatter formatter = new SoapFormatter();

                    // Deserialize the student from the file and  
                    // assign the reference to the local variable.
                    stud = formatter.Deserialize(fs) as Student;
                }
                catch (SerializationException)
                {
                }
                finally
                {
                    fs.Close();
                }
            }

            //retrun the status
            return stud;
        }

        /// <summary>
        /// Method to serialize the List of Student using binary serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeListBinary(List<Student> stud, string filePath)
        {
            bool result = false;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                //create formatter and open the stream to file
                IFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filePath, FileMode.Create);

                //Serialize and save
                formatter.Serialize(stream, stud);
                stream.Close();

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize List of Students using binary deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static List<Student> DeserializeListBinary(string filePath)
        {
            List<Student> stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                //Create formatter
                IFormatter formatter = new BinaryFormatter();
                try
                {
                    //create stream and deserialize the object
                    Stream stream = new FileStream(filePath, FileMode.Open);
                    stud = formatter.Deserialize(stream) as List<Student>;
                    stream.Close();
                }
                catch (Exception)
                {
                    stud = null;
                }
            }

            //retrun the status
            return stud;
        }

        /// <summary>
        /// Method to serialize the Student list using XML serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeListXml(List<Student> stud, string filePath)
        {
            bool result = false;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

                // To write to a file, create a StreamWriter object.
                StreamWriter writer = new StreamWriter(filePath);
                serializer.Serialize(writer, stud);
                writer.Close();

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize List of Student using xml deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static List<Student> DeserializeListXml(string filePath)
        {
            List<Student> stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                try
                {
                    FileStream stream = new FileStream(filePath, FileMode.Open);
                    // Call the Deserialize method and cast to the object type.
                    stud = serializer.Deserialize(stream) as List<Student>;
                    stream.Close();
                }
                catch (Exception)
                {
                    stud = null;
                }
            }

            //retrun the status
            return stud;
        }

        /// <summary>
        /// Method to serialize the list of Student using SOAP serialization and save it in the file
        /// </summary>
        /// <param name="stud">Object to be serialized</param>
        /// <param name="filePath">File path to store the data</param>
        /// <returns>Status of the process</returns>
        public static bool SerializeListSoap(List<Student> stud, string filePath)
        {
            bool result = false;


            //check if serializable
            if (typeof(Student).IsSerializable)
            {

                FileStream stream = new FileStream(filePath, FileMode.Create);

                // Construct a SoapFormatter and use it  
                // to serialize the data to the stream.
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    formatter.Serialize(stream, stud.ToArray());
                }
                catch (SerializationException)
                {
                    return false;
                }
                finally
                {
                    stream.Close();
                }

                result = true;
            }
            //return state
            return result;
        }

        /// <summary>
        /// Method to deserialize List of Student using SOAP deserialization
        /// </summary>
        /// <param name="filePath">File Path from which to deserialize the object</param>
        /// <return>Deserialized object</returns>
        public static List<Student> DeserializeListSoap(string filePath)
        {
            List<Student> stud = null;

            //check if serializable
            if (typeof(Student).IsSerializable)
            {
                stud = new List<Student>();

                FileStream fs = new FileStream(filePath, FileMode.Open);
                try
                {
                    SoapFormatter formatter = new SoapFormatter();

                    // Deserialize the student from the file and  
                    // assign the reference to the local variable.
                    Student[] data = formatter.Deserialize(fs) as Student[];

                    stud.AddRange(data);
                }
                catch (SerializationException)
                {
                }
                finally
                {
                    fs.Close();
                }
            }

            //retrun the status
            return stud;
        }
    }
}


