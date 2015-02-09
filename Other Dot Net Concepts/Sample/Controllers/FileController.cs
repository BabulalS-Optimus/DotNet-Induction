using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Models;

namespace Sample.Controllers
{
    public class FileController : Controller
    {
        private FileHandlerContext db = new FileHandlerContext();

        //
        // GET: /File/

        public ActionResult Index()
        {
            return View(db.FileHandlers.ToList());
        }

        //
        // GET: /File/Details/5

        public ActionResult Details(int id = 0)
        {
            FileHandler filehandler = db.FileHandlers.Find(id);
            if (filehandler == null)
            {
                return HttpNotFound();
            }
            return View(filehandler);
        }

        //
        // GET: /File/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /File/Create

        [HttpPost]
        public ActionResult Create(FileHandler filehandler)
        {
            if (ModelState.IsValid)
            {
                db.FileHandlers.Add(filehandler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filehandler);
        }

        //
        // GET: /File/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FileHandler filehandler = db.FileHandlers.Find(id);
            if (filehandler == null)
            {
                return HttpNotFound();
            }
            return View(filehandler);
        }

        //
        // POST: /File/Edit/5

        [HttpPost]
        public ActionResult Edit(FileHandler filehandler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filehandler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filehandler);
        }

        //
        // GET: /File/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FileHandler filehandler = db.FileHandlers.Find(id);
            if (filehandler == null)
            {
                return HttpNotFound();
            }
            return View(filehandler);
        }

        //
        // POST: /File/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FileHandler filehandler = db.FileHandlers.Find(id);
            db.FileHandlers.Remove(filehandler);
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
            return RedirectToAction("Login", "Login");

        }
    }
}