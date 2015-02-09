using System;
using System.Collections.Generic;
using StudentService;

namespace StudentImplementation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// CLick event handler for btnShowRecord to display record of selected student
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for the event</param>
        protected void btnShowRecord_Click(object sender, EventArgs e)
        {
            //Extract rollno from textbox
            string value = txtRollNo.Text;
            int rollNo;
            int.TryParse(value, out rollNo);

            //Call GetStudentRecord() method to fetch data
            StudentDataHandler studentHandler = new StudentDataHandler();
            List<string> stud = studentHandler.GetStudentRecord(rollNo);

            //Check the returned result
            if (stud != null)
            {
                #region Display Record
                Response.Write("<h2>Data for Student </h2>");
                Response.Write(string.Format("Student ID : {0}<br />", stud[0]));
                Response.Write(string.Format("Full Name : {0}<br />", stud[1]));
                Response.Write(string.Format("Father's Name : {0}<br />", stud[2]));
                Response.Write(string.Format("Age : {0}<br />", stud[3]));
                Response.Write(string.Format("Roll No. : {0}<br />", stud[4]));
                Response.Write(string.Format("Stream : {0}<br />", stud[5]));
                Response.Write(string.Format("Address : {0}<br />", stud[7]));
                #endregion
            }
            else
            {
                Response.Write("No record found.");
            }
        }
    }
}