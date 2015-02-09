using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class LoginController : Controller
    {
        private UserContext db = new UserContext();
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                var v = db.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();

                if (v != null)
                {
                    Session["UserID"] = v.ID;
                    Session["Username"] = v.Username;

                    if (v.Username.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "File");
                    }
                }
            }
            return View(u);
        }

        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");

        }
    }
}
