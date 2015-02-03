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
    public partial class BinaryRW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Click event handler for btnCreateFile which creates a binary file and writes some default contents in it
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnCreateFile_Click(object sender, EventArgs e)
        {
            //Path for the source file
            string fileName = @"C:\Test\source.bin";

            //Call to the CreateFiles() method to create the binary file
            bool result = UtilityFunctions.CreateFiles(fileName);

            //checking the file creation result
            if (result)
            {
                //if success

                //writing the contents to the file
                UtilityFunctions.AddContentsToFile(fileName);

                Response.Write(Messages.FileCreationSuccess);

            }
            else
            {
                //if failed
                Response.Write(Messages.FileCreationFailed);
            }

        }

        /// <summary>
        /// Click event handler for btnReadData which reads data from a binary file
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnReadData_Click(object sender, EventArgs e)
        {
            //path for the file
            string fileName = @"C:\Test\source.bin";

            //Call to the ReadContents() method which reads the contents of the file
            List<int> result = UtilityFunctions.ReadContents(fileName);

            //checking the result of the file
            if (result.Count > 0)
            {
                //traversing the result received
                foreach (int item in result)
                {
                    //displaying the data
                    Response.Write("<br />" + item.ToString());
                }
            }
            else
            {
                //if no contents are read
                Response.Write(Messages.NoContentFoundInFile);
            }
        }
    }
}