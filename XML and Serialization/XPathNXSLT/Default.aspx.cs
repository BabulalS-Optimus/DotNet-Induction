using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XPathNXSLT.BusinessLayer;
using XPathNXSLT.DataLayer;

namespace XPathNXSLT
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Handler for btnShowAll to display all student records
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //Call the ShowStudents() method to read all the records form
            List<Student> result = UtilityFunctions.ShowStudents(Server.MapPath(Strings.XsltFilePath), Server.MapPath(Strings.XmlFilePath));

            //check the result
            if (result != null)
            {
                //display the records
                Response.Write("<h2>Data fetched : </h2>");
                foreach (Student student in result)
                {
                    Response.Write(string.Format("Name : {0} <br />", student.Name));
                    Response.Write(string.Format("Age : {0} <br />", student.Age));
                    Response.Write(string.Format("Stream : {0} <br />", student.Stream));
                    Response.Write(string.Format("Address : {0} <br /><hr />", student.Address));
                }
            }
            else
            {
                Response.Write(Strings.DisplayFailed);
            }
        }

        /// <summary>
        /// Event Handler for btnTransform to transform XML to HTML using XSLT
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnTransform_Click(object sender, EventArgs e)
        {
            //Call the TranformXSL() method to transform XML to HTML using XSLT file
            bool result = UtilityFunctions.TransformXSL(Server.MapPath(Strings.XsltFilePath), Server.MapPath(Strings.XmlFilePath), Server.MapPath(Strings.ResultFilePath));

            //check the result
            if (result)
            {
                Response.Redirect(Server.MapPath(Strings.ResultFilePath));
            }
            else
            {
                Response.Write(Strings.TransformFailed);
            }
        }

        /// <summary>
        /// Event Handler for btnAddCollege to add a college node where stream = PCM
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnAddCollege_Click(object sender, EventArgs e)
        {
            //Call the AddCollegeNode() method to add college node where stream = PCM
            bool result = UtilityFunctions.AddCollegeNode(Server.MapPath(Strings.XmlFilePath));

            //Check the result
            if (result)
            {
                Response.Write(Strings.AddCollegeNodeSuccess);
            }
            else
            {
                Response.Write(Strings.AddCollegeNodeFailed);
            }

        }
    }
}