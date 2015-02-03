using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SendingMails.DataLayer
{
    public class UtilityFunctions
    {
        /// <summary>
        /// Method to delete files from a directory
        /// </summary>
        /// <param name="folderPath">Path to the directory</param>
        /// <returns>List of files deleted</returns>
        public static List<string> DeleteFiles(string folderPath)
        {
            List<string> filesDeleted = new List<string>();

            //check whether directory exists or not
            if (Directory.Exists(folderPath))
            {
                //if directory exists

                // Get array of all file names.
                string[] allFiles = Directory.GetFiles(folderPath, "*.*");

                foreach (string fileName in allFiles)
                {
                    // Use FileInfo to get length of each file.
                    FileInfo fileInfo = new FileInfo(fileName);

                    //checking for the size of the file
                    if (fileInfo.Length > 100)
                    {
                        //if size is more than 100 bytes
                        filesDeleted.Add(fileName);
                        //deleting the file
                        File.Delete(fileName);
                    }
                    else
                    {
                        //if file size is less than 100 bytes
                        //appending the text to the file
                        string message = "Size less than 100 bytes.";
                        File.AppendAllText(fileName, message);
                    }
                }
            }
            else
            {
                //if there is no such directory
                filesDeleted = null;
            }

            //returning result
            return filesDeleted;
        }

        public static bool SendMail(List<string> files)
        {
            bool result = false;

            

            return result;

        }
    }
}