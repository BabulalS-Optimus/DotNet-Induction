using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;

namespace FileHandling.DataLayer
{
    public class UtilityFunctions
    {

        /// <summary>
        /// Method to create a new directory in C:
        /// </summary>
        /// <returns>Whether directory is created or not.</returns>
        public static bool CreateDirectory()
        {
            bool result = false;
            //checking if directory already exists
            if (Directory.Exists(@"C:\Test"))
            {
                result = true;
            }
            else
            {
                try
                {
                    //creating the directory
                    Directory.CreateDirectory(@"C:\Test");
                    result = true;
                }
                catch (Exception ex)
                {
                    //if any exception occured while creating the directory
                    result = false;
                }
            }
            //returning the result for directory creation
            return result;
        }

        /// <summary>
        /// Method to create two files [FileRead and FileWrite] in the new directory 
        /// </summary>
        /// <param name="fileName">File name to be created.</param>
        /// <returns>Whether files were created or not.</returns>
        public static bool CreateFiles(string fileName)
        {
            bool result = false;
            try
            {
                //cheking whether file already exists or not
                if (!File.Exists(fileName))
                    File.Create(fileName).Close(); //creating the file

                result = true;
            }
            catch (Exception ex)
            {
                //if any exception occured while creating the directory
                result = false;
            }
            //returning the result for file creation
            return result;
        }

        /// <summary>
        /// Method to get the details about C:
        /// </summary>
        /// <returns>List containing the properties of C:</returns>
        public static List<string> DetailsOfCDrive()
        {
            //a list to hold the output
            List<string> list = new List<string>();

            //creating an object of DriveInfo to hold the properties of the C:
            DriveInfo driveInfo = new DriveInfo("C:");
            list.Add("Drive Format : " + driveInfo.DriveFormat);
            list.Add("Drive Type : " + driveInfo.DriveType);
            list.Add("Root Directory : " + driveInfo.RootDirectory);
            list.Add("AvailableFreeSpace : " + driveInfo.AvailableFreeSpace + " bytes");
            list.Add("Total Free Space :" + driveInfo.TotalFreeSpace + " bytes");
            list.Add("Total Size : " + driveInfo.TotalSize + " bytes");
            list.Add("Is Ready : " + driveInfo.IsReady);

            //returning the result
            return list;
        }

        /// <summary>
        /// Method to get the details about newly created directory
        /// </summary>
        /// <returns>List containing the properties of directory</returns>
        public static List<string> DetailsOfDir()
        {
            //a list to hold the output
            List<string> list = new List<string>();

            //creating an object of DirectoryInfo to hold the properties of the directory
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Test");
            list.Add("Fullname : " + dirInfo.FullName);
            list.Add("Name : " + dirInfo.Name);
            list.Add("Root : " + dirInfo.Root);
            list.Add("Creation Time : " + dirInfo.CreationTime);
            list.Add("Last Access Time : " + dirInfo.LastAccessTime);
            list.Add("Last Write Time : " + dirInfo.LastWriteTime);

            //returning the result
            return list;
        }

        /// <summary>
        /// Method to get the details about newly created file
        /// </summary>
        /// <param name="path">Path of the files whose properties are fetched</param> 
        /// <returns>List containing the properties of the file</returns>
        public static List<string> DetailsOfFile(string path)
        {
            //a list to hold the output
            List<string> list = new List<string>();

            //creating an object of FileInfo to hold the properties of the file
            FileInfo fileInfo = new FileInfo(path);
            list.Add("Name : " + fileInfo.Name);
            list.Add("Fullname : " + fileInfo.FullName);
            list.Add("Parent : " + fileInfo.Directory);
            list.Add("Size : " + fileInfo.Length + " bytes");
            list.Add("Creation Time : " + fileInfo.CreationTime);
            list.Add("Last Access Time : " + fileInfo.LastAccessTime);
            list.Add("Last Write Time : " + fileInfo.LastWriteTime);

            //returning the result
            return list;
        }

        /// <summary>
        /// Method to get the complete path of directory using Path class
        /// </summary>
        /// <returns>List containing the properties of the file</returns>
        public static string DirectoryPath()
        {
            //string object to hold the path
            string path = "";

            //combining directory with Drive
            path = Path.Combine("C:", Path.DirectorySeparatorChar.ToString(), "Test");

            //getting the full path to the directory
            path = Path.GetFullPath(path);

            //returning the result
            return path;
        }

        /// <summary>
        /// Method to set ReadOnly access rights on FileRead
        /// </summary>
        /// <param name="fileName">Path of the files for which Acces rule are set</param> 
        /// <returns>Whether rights set or not</returns>
        public static bool SetReadOnlyOnFile(string fileName)
        {
            //bool object to hold the result
            bool result = false;

            try
            {
                //FileSecurity  object to Deny Write
                FileSecurity accessWrite = File.GetAccessControl(fileName);
                //setting rule to Deny Write on the file
                accessWrite.SetAccessRule(
                    new FileSystemAccessRule(
                        new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Write, AccessControlType.Deny)
                    );
                //applying the access rule on the file
                File.SetAccessControl(fileName, accessWrite);

                //FileSecurity object to allow read
                FileSecurity accessReadOnly = File.GetAccessControl(fileName);
                //setting rule to allow read on the file
                accessReadOnly.SetAccessRule(
                                new FileSystemAccessRule(
                                    new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, AccessControlType.Allow)
                                );
                //applying the rule to allow read operation on the file
                File.SetAccessControl(fileName, accessReadOnly);

                //setting the result of the operations
                result = true;
            }
            catch (Exception ex)
            {
                //if any exception occurs
                result = false;
            }

            //returning the result
            return result;
        }

        /// <summary>
        /// Method to read from FileRead and write into FileWrite
        /// </summary>
        /// <param name="fileSource">Path of the source files</param> 
        /// <param name="fileDest">Path of the destination files</param> 
        /// <returns>Whether rights set or not</returns>
        public static bool CopyContents(string fileSource, string fileDest)
        {
            //bool object to hold the result
            bool result = false;

            try
            {
                //FileStream objects to read and write contents
                FileStream reader = File.OpenRead(fileSource);
                FileStream writer = File.OpenWrite(fileDest);

                //to store amount of data read from file
                int read = -1;
                //buffer to store read data
                byte[] buffer = new byte[4096];
                //loop to read data repeatedly until found end of file
                while (read != 0)
                {
                    //reading the contents from source file
                    read = reader.Read(buffer, 0, buffer.Length);
                    //writing conetns to destination file
                    writer.Write(buffer, 0, read);
                }
                //closing the FileStreams
                reader.Close();
                writer.Close();

                //setting the result of the operations
                result = true;
            }
            catch (Exception ex)
            {
                //if any exception occurs
                result = false;
            }

            //returning the result
            return result;
        }

        /// <summary>
        /// Method to compress the fileSource and save it as fileDest
        /// </summary>
        /// <param name="fileSource">Path of the source files</param> 
        /// <param name="fileDest">Path of the destination files</param> 
        /// <returns>Whether rights set or not</returns>
        public static bool CompressFile(string fileSource, string fileDest)
        {
            //bool object to hold the result
            bool result = false;

            try
            {
                //FileStream to the source file which needs to be compressed
                FileStream sourceFileStream = File.OpenRead(fileSource);

                //FileStream to the destination file i.e. compressed file
                FileStream compressedFileStream = File.Create(fileDest);

                //GZipStream object to compress the file
                GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress);

                //copying the compressed contents to GZipStream object
                sourceFileStream.CopyTo(compressionStream);

                //closing the FileStreams
                sourceFileStream.Close();
                compressedFileStream.Close();

                //setting the result of the operations
                result = true;
            }
            catch (Exception ex)
            {
                //if any exception occurs
                result = false;
            }

            //returning the result
            return result;
        }

        /// <summary>
        /// Method to add some contents to the file specified.
        /// </summary>
        /// <param name="fileName">Path of the file in which contents are to be added.</param>
        public static bool AddContentsToFile(string fileName)
        {
            bool result = false;
            try
            {
                //FileStream to the file 
                FileStream fileStream = File.OpenWrite(fileName);

                //Object of BinaryWriter to write something through the FileStream
                BinaryWriter writer = new BinaryWriter(fileStream);

                //Write something in the file
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i);
                }

                //Closing the BinaryWriter and FileStream
                writer.Close();
                fileStream.Close();

                result = true;
            }
            catch (IOException ex)
            {
                //if found any IOException
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Method to read contents of a binary file.
        /// </summary>
        /// <param name="fileSource">Path of the binary file.</param>
        /// <returns>List of data</returns>
        public static List<int> ReadContents(string fileName)
        {
            //list for the data to be read from the binary file
            List<int> fileContents = new List<int>();

            try
            {

                //Creating a file stream for the file
                FileStream fileStream = File.Open(fileName, FileMode.Open);

                //Creating a binary reader to read the data
                BinaryReader reader = new BinaryReader(fileStream);

                //reading the data from the file
                for (int i = 0; i < 10; i++)
                {
                    //adding the fethced data to the list
                    fileContents.Add(reader.ReadInt32());
                }

                //closing the reader and file stream
                reader.Close();
                fileStream.Close();
            }
            catch (IOException ex)
            {
                //if found any IOException
                fileContents.Clear();
            }
            //returning the result
            return fileContents;
        }
    }
}