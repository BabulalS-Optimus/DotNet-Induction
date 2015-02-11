using MvcPattern.Models;
using System;
using model = MvcPattern.Models;

namespace MvcPattern.Views.Student
{
    /// <summary>
    /// Class for Edit Page
    /// </summary>
    public partial class Edit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                #region Fetch details of Student from Database and display them in textbox
                StudentContext context = new StudentContext();

                string query = Request.QueryString["id"].ToString();
                int id;
                int.TryParse(query, out id);

                //Find the record and show in textbox
                model.Student stud = context.Students.Find(id);
                Name.Value = stud.Name;
                Email.Value = stud.Email;
                ID.Value = stud.ID.ToString();
                #endregion
            }
            catch (Exception)
            {
            }

        }
    }
}