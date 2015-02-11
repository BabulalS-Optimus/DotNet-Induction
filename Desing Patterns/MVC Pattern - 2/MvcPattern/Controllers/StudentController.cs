using MvcPattern.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace MvcPattern.Controllers
{
    /// <summary>
    /// Controller for Student
    /// </summary>
    public class StudentController : Controller
    {
        /// <summary>
        /// Context object
        /// </summary>
        StudentContext context = new StudentContext();

        /// <summary>
        /// Action for Index view
        /// </summary>
        /// <returns>ActionResult to view the web page</returns>
        public ActionResult Index()
        {
            return Redirect(@"~/Views/Student/Index.aspx");
            
        }

        /// <summary>
        /// Action for Create
        /// </summary>
        /// <returns>Action Result showing Create web page</returns>
        public ActionResult Create()
        {
            return Redirect(@"~/Views/Student/Create.aspx");
        }

        /// <summary>
        /// Create Action for Post form method which creates a new user
        /// and saves it in the Database
        /// </summary>
        /// <param name="Name">Name of the new student</param>
        /// <param name="Email">Email ID for the new student</param>
        /// <returns>ActionResult redirecting to the page</returns>
        [HttpPost]
        public ActionResult Create(string Name, string Email)
        {
            // Create a new student object and add it to context student list
            Student student = new Student();
            student.Name = Name;
            student.Email = Email;
            context.Students.Add(student);

            // Save the changes using context
            context.SaveChanges();

            //Redirect to Create action
            return RedirectToAction("Create", "Student");

        }

        /// <summary>
        /// Action for Edit which displays details of the student to edit
        /// </summary>
        /// <param name="id">ID of the student whose details are to be updated</param>
        /// <returns>ActionResult for redirecting to a webpage</returns>
        public ActionResult Edit(int id = 0)
        {
            //Find the student record with ID as id
            Student stud = context.Students.Find(id);

            if (stud == null)
            {
                return HttpNotFound();
            }
            //Redirect to Edit page
            return Redirect(@"~/Views/Student/Edit.aspx?id=" + stud.ID);
        }

        /// <summary>
        /// Edit Action for Post form method which edits user's details
        /// and saves it in the Database
        /// </summary>
        /// <param name="ID">ID of the student</param>
        /// <param name="Name">New name for the student</param>
        /// <param name="Email">New Email ID for the student</param>
        /// <returns>ActionResult redirecting to the page</returns>
        [HttpPost]
        public ActionResult Edit(string ID, string Name, string Email)
        {

            int id;
            int.TryParse(ID, out id);

            // Find the student record with ID as id and assign new values
            Student student = context.Students.Where(a => a.ID == id).First();
            student.Name = Name;
            student.Email = Email;

            //Update the database
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();

            //Redirect to Index page
            return RedirectToAction("Index", "Student");

        }

    }
}