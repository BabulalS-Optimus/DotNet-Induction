using OnlineExaminationSystem.Entity;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OnlineExaminationSystem.Controllers
{
    /// <summary>
    /// Class to handle assignment activities
    /// </summary>
    public class ActivityController : Controller
    {
        private DotNetTestEntities1 db = new DotNetTestEntities1();

        /// <summary>
        /// Action to display List of assigned Activities
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.User).Include(a => a.Test).Include(a => a.User1);
            return View(activities.ToList());
        }

        /// <summary>
        /// Action to display details of any activity with a specified ID
        /// </summary>
        /// <param name="id">ID for which data would be dispaly</param>
        /// <returns></returns>
        public ActionResult Details(decimal id = 0)
        {
            //Search the record and view it
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        /// <summary>
        /// Get for Assigning any Test to any student
        /// </summary>
        /// <returns>Action status for redirect to any action</returns>
        public ActionResult Create()
        {
            // Extract User ID
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);

            //Create data for viewing Listboxes
            ViewBag.Organiser = new SelectList(db.Users.Where(a => a.ID == userID), "ID", "Name");
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title");
            ViewBag.UserID = new SelectList(db.Users.Where(a => a.Role.Equals("Student")), "ID", "Name");

            //show the view
            return View();
        }

        /// <summary>
        /// Post for Assigning any Test to any student
        /// </summary>
        /// <param name="activity">Details of assigning the test</param>
        /// <returns>Action status for redirect to any action</returns>
        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                //Find if already assigned or not
                Activity oldActivity = db.Activities.Where(act => act.UserID == activity.UserID && act.TestID == activity.TestID && act.Organiser == activity.Organiser).FirstOrDefault();

                //if not assigned
                if (oldActivity == null)
                {
                    //Assign the test and create answers for it
                    db.Activities.Add(activity);
                    db.SaveChanges();

                    #region Creating answers
                    decimal id = activity.ID;
                    decimal organiserID = activity.ID;
                    decimal? testID = activity.TestID;
                    decimal? userID = activity.UserID;

                    List<Question> questions = db.Questions.Where(a => a.TestID == testID).ToList();

                    foreach (Question ques in questions)
                    {
                        Answer ans = new Answer();
                        ans.QuesID = ques.ID;
                        ans.TestID = ques.TestID;
                        ans.UserID = userID;
                        ans.Ans = " ";
                        db.Answers.Add(ans);
                    }
                    db.SaveChanges();
                    #endregion
                }
                return RedirectToAction("Index");
            }
            //Display the next view
            ViewBag.Organiser = new SelectList(db.Users, "ID", "Name", activity.Organiser);
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", activity.TestID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name", activity.UserID);
            return View(activity);
        }

        /// <summary>
        /// Action to edit any record 
        /// </summary>
        /// <param name="id">ID of the redcord to be edited</param>
        /// <returns>ActionResult</returns>
        public ActionResult Edit(decimal id = 0)
        {

            // Extract User ID and fetch the data
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);

            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            //Display next view
            ViewBag.Organiser = new SelectList(db.Users.Where(a => a.ID == userID), "ID", "Name", activity.Organiser);
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", activity.TestID);
            ViewBag.UserID = new SelectList(db.Users.Where(a => a.Role.Equals("Student")), "ID", "Name", activity.UserID);
            return View(activity);
        }

        /// <summary>
        /// Post request for edit which updates data in database
        /// </summary>
        /// <param name="activity">New record</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            //Check the validity of the data and update DB
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Display next view
            ViewBag.Organiser = new SelectList(db.Users, "ID", "Name", activity.Organiser);
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", activity.TestID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name", activity.UserID);
            return View(activity);
        }

        /// <summary>
        /// Action for delete
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns></returns>
        public ActionResult Delete(decimal id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        /// <summary>
        /// Delete request for any record 
        /// </summary>
        /// <param name="id">ID to be deleted</param>
        /// <returns>ActionResult</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Activity activity = db.Activities.Find(id);

            // Delete all answers with TestID=activity.TestID
            #region Delete Answers
            List<Answer> answers = db.Answers.Where(ans => ans.TestID == activity.TestID).ToList();
            if (answers != null)
            {
                foreach (Answer ans in answers)
                {
                    db.Answers.Remove(ans);
                }
            }
            #endregion

            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">whether to dispose or not</param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Action to logout the user
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// Action to redirect the user to Test List
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult GoToTests()
        {
            return RedirectToAction("Index", "Test");
        }
    }
}