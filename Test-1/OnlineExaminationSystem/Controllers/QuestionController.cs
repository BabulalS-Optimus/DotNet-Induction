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
    /// Class to manage Questions
    /// </summary>
    public class QuestionController : Controller
    {
        private DotNetTestEntities1 db = new DotNetTestEntities1();


        //
        // GET: /Question/

        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Test);
            return View(questions.ToList());
        }

        //
        // GET: /Question/Details/5

        public ActionResult Details(decimal id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // GET: /Question/Create

        public ActionResult Create()
        {
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title");
            return View();
        }

        //
        // POST: /Question/Create

        [HttpPost]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", question.TestID);
            return View(question);
        }

        //
        // GET: /Question/Edit/5

        public ActionResult Edit(decimal id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", question.TestID);
            return View(question);
        }

        //
        // POST: /Question/Edit/5

        [HttpPost]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestID = new SelectList(db.Tests, "ID", "Title", question.TestID);
            return View(question);
        }

        //
        // GET: /Question/Delete/5

        public ActionResult Delete(decimal id = 0)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // POST: /Question/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// Action to redirect to List of Tests
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult GoToTests()
        {
            return RedirectToAction("Index", "Test");
        }
    }
}