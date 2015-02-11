using MvcPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcPattern.Views.Student
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region fetch all student records and display it
            //Fetch records
            StudentContext context = new StudentContext();
            List<MvcPattern.Models.Student> students = context.Students.ToList();

            //Display the records
            for (int i = 0; i < students.Count; i++)
            {
                var item = students[i];
                Response.Write(string.Format("Name : {0}, Email : {1}, <a href='../../Student/Edit/{2}'>Edit</a> <hr/>", item.Name, item.Email, item.ID));
            }
            #endregion
        }
    }
}