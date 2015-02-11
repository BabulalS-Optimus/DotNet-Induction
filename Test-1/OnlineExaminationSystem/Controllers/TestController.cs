using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExaminationSystem.Entity;

namespace OnlineExaminationSystem.Controllers
{
    /// <summary>
    /// Class to manage Tests
    /// </summary>
    public class TestController : Controller
    {
        private DotNetTestEntities1 db = new DotNetTestEntities1();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.User);
            return View(tests.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(decimal id = 0)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);
            ViewBag.Organiser = new SelectList(db.Users.Where(u => u.ID == userID), "ID", "Name");
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Organiser = new SelectList(db.Users, "ID", "Name", test.Organiser);
            return View(test);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(decimal id = 0)
        {

            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);

            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organiser = new SelectList(db.Users.Where(u => u.ID == userID), "ID", "Name", test.Organiser);
            return View(test);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Organiser = new SelectList(db.Users, "ID", "Name", test.Organiser);
            return View(test);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(decimal id = 0)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        /// <summary>
        /// Action to delete a test with specified test ID
        /// </summary>
        /// <param name="id">Id for the test</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            //Find the test
            Test test = db.Tests.Find(id);

            // Delete all Activities with TestID=test.ID
            #region Delete Activities
            List<Activity> activities = db.Activities.Where(act => act.TestID == test.ID).ToList();
            if (activities != null)
            {
                foreach (Activity act in activities)
                {
                    db.Activities.Remove(act);
                }
            }
            #endregion

            // Delete all answers with TestID=test.ID
            #region Delete Answers
            List<Answer> answers = db.Answers.Where(ans => ans.TestID == test.ID).ToList();
            if (answers != null)
            {
                foreach (Answer ans in answers)
                {
                    db.Answers.Remove(ans);
                }
            }
            #endregion

            // Delete all questions with TestID=test.ID
            #region Delete Questions
            List<Question> questions = db.Questions.Where(ques => ques.TestID == test.ID).ToList();
            if (questions != null)
            {
                foreach (Question ques in questions)
                {
                    db.Questions.Remove(ques);
                }
            }
            #endregion

            //Delete the test
            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Action to Logout
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// Method to redirect user to assign the test
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Assign()
        {
            return RedirectToAction("Create", "Activity");
        }

        /// <summary>
        /// Action to List Questions for the current test
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult ShowQuestions()
        {
            return RedirectToAction("Index", "Question");
        }
    }
}