using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileHandling.DataLayer;
using FileHandling.BusinessLayer;

namespace DirectoriesAndFiles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Click event handler for btnAddNewDir which adds a new directory to C:
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnAddNewDir_Click(object sender, EventArgs e)
        {
            //call to the CreatDirectory() method which creates the directory in C:
            bool result = UtilityFunctions.CreateDirectory();
            //checking the result received
            if (result)
            {
                //if success
                Response.Write(Messages.DirCreationSuccess);
            }
            else
            {
                //if failed
                Response.Write(Messages.DirCreationFailed);
            }
        }

        /// <summary>
        /// Click event handler for btnAddFiles which adds files to the directory
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnAddFiles_Click(object sender, EventArgs e)
        {
            //paths for file to be created
            string fileRead = @"C:\Test\FileRead";
            string fileWrite = @"C:\Test\FileWrite";

            //call to the CreateFiles() method which creates the files
            bool resultFileRead = UtilityFunctions.CreateFiles(fileRead);
            bool resultFileWrite = UtilityFunctions.CreateFiles(fileWrite);

            //checking the result
            if (resultFileRead && resultFileWrite)
            {
                //if success
                Response.Write(Messages.FileCreationSuccess);
            }
            else
            {
                //if failed
                Response.Write(Messages.FileCreationFailed);
            }
        }

        /// <summary>
        /// Click event handler for btnDetailsC which shows details about C:
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnDetailsC_Click(object sender, EventArgs e)
        {
            //call to the DetailsOfCDrive() method to get attributes of C:
            List<string> result = UtilityFunctions.DetailsOfCDrive();

            //displaying the attributes
            Response.Write("<h2>Attributes of C:</h2>");
            foreach (string item in result)
            {
                Response.Write(item + "<br />");
            }
        }

        /// <summary>
        /// Click event handler for btnDetailsDirNFile which shows details about newly created Directory and files
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnDetailsDirNFile_Click(object sender, EventArgs e)
        {
            //call to the DetailsOfDir() method to get attributes of directory
            List<string> resultDir = UtilityFunctions.DetailsOfDir();

            //call to the DetailsOfFile() method to get attributes of the file i.e. FileRead
            List<string> resultFileRead = UtilityFunctions.DetailsOfFile(@"C:\Test\FileRead");

            //call to the DetailsOfFile() method to get attributes of the file i.e. FileWrite
            List<string> resultFileWrite = UtilityFunctions.DetailsOfFile(@"C:\Test\FileWrite");

            //displaying the attributes of the directory
            Response.Write("<h2>Attributes of Test</h2>");
            foreach (string item in resultDir)
            {
                Response.Write(item + "<br />");
            }

            //displaying the attributes of the file i.e. FileRead
            Response.Write("<h2>Attributes of FileRead</h2>");
            foreach (string item in resultFileRead)
            {
                Response.Write(item + "<br />");
            }

            //displaying the attributes of the file i.e. FileWrite
            Response.Write("<h2>Attributes of FileWrite</h2>");
            foreach (string item in resultFileWrite)
            {
                Response.Write(item + "<br />");
            }
        }

        /// <summary>
        /// Click event handler for btnDirPath which shows the complete path to the directory
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnDirPath_Click(object sender, EventArgs e)
        {
            //call to DirectoryPath() method to get the full path to the directory
            string path = UtilityFunctions.DirectoryPath();

            //displaying the returned result
            Response.Write(path);
        }

        /// <summary>
        /// Click event handler for btnSetReadonly which sets ReadOnly property on FileRead
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnSetReadonly_Click(object sender, EventArgs e)
        {

            //path to the file
            string fileName = @"C:\Test\FileRead";
            bool result = UtilityFunctions.SetReadOnlyOnFile(fileName);

            //checking the result received
            if (result)
            {
                //if success
                Response.Write(Messages.FileReadOnlySuccess);
            }
            else
            {
                //if failed
                Response.Write(Messages.FileReadOnlyFailed);
            }
        }

        /// <summary>
        /// Click event handler for btnRead which reads from FileRead and writes to FileWrite
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnRead_Click(object sender, EventArgs e)
        {
            //path to the files
            string fileRead = @"C:\Test\FileRead";
            string fileWrite = @"C:\Test\FileWrite";

            //call to CopyContents() method to copy the contents
            bool result = UtilityFunctions.CopyContents(fileRead, fileWrite);

            //checking the result received
            if (result)
            {
                //if success
                Response.Write(Messages.ContentCopySuccess);
            }
            else
            {
                //if failed
                Response.Write(Messages.ContentCopyFailed);
            }
        }

        /// <summary>
        /// Click event handler for btnCompress which compresses the file FileWrite
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnCompress_Click(object sender, EventArgs e)
        {
            //
            //path to the files
            string fileWrite = @"C:\Test\FileWrite";
            string fileWriteZip = @"C:\Test\FileWriteZip";

            //call to CompressFile() method to compress the FileWrite file
            bool result = UtilityFunctions.CompressFile(fileWrite, fileWriteZip);

            //checking the result received
            if (result)
            {
                //if success
                Response.Write(Messages.CompressSuccess);
            }
            else
            {
                //if failed
                Response.Write(Messages.CompressFailed);
            }
        }

    }
}