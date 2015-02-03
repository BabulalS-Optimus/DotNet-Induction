using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentManager.DataLayer;
using StudentManager.BusinessLayer;

namespace StudentManager
{
    public partial class ReadCSVFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Handler for SaveStudentsToDB button to add records from a CSV file to Database
        /// </summary>
        /// <param name="sender">Object on which event occured.</param>
        /// <param name="e">Args for click event.</param>
        protected void SaveStudentsToDB_Click(object sender, EventArgs e)
        {
            //checking if there is any file in FileUpload control
            if (fileCSVBrowser.HasFile)
            {
                //getting full path for the file selected by the user
                string filePath = Server.MapPath(fileCSVBrowser.FileName);

                //call to LoadFromCSV() method to store records from file to database
                bool result = UtilityFunctions.LoadFromCSV(filePath);

                //checking the result 
                if (result)
                {
                    //if success
                    Response.Write(Messages.CSVWriteSuccess);
                }
                else
                {
                    //if failed
                    Response.Write(Messages.CSVWriteFailed);
                }
            }
            else
            {
                //if no file in FileUpload
                Response.Write(Messages.NoFileFound);
            }
        }
    }
}