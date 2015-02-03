using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendingMails.DataLayer;
using SendingMails.BusinessLayer;

namespace SendingMails
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Click event handler for btnSendMail button which send a mail after deleting few files from a folder
        /// </summary>
        /// <param name="sender">Object on which event occured.</param>
        /// <param name="e">Args for event</param>
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            //Store folder path
            string folderPath = txtPathToFolder.Text;

            //checking for the path entered
            if (folderPath.Length > 0)
            {
                //Call to DeleteFiles() method to delete files
                List<string> deletedFiles = UtilityFunctions.DeleteFiles(folderPath);

                //checking the returned result
                if (deletedFiles == null)
                {
                    //if returned null
                    Response.Write(Messages.DirNotFound);
                }
                else
                {
                    //if data returned
                    bool result = UtilityFunctions.SendMail(deletedFiles);

                    //checking the result
                    if (result)
                    {
                        //if success
                        Response.Write(Messages.SendMailSuccess);
                    }
                    else
                    {
                        //if failed
                        Response.Write(Messages.SendMailFailed);
                    }

                }
            }
            else
            {
                Response.Write(Messages.NoFolderPathFound);
            }
        }
    }
}