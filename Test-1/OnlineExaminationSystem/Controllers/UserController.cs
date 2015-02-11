using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineExaminationSystem.Entity;

namespace OnlineExaminationSystem.Controllers
{
    /// <summary>
    /// Class to manage user data
    /// </summary>
    public class UserController : Controller
    {
        private DotNetTestEntities1 db = new DotNetTestEntities1();

        /// <summary>
        /// Action for Login
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        ///  Action to display List of Tests
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult TestList()
        {
            //Find the user ID and all tests assigned to him
            //dispaly the tests
            decimal studID;
            decimal.TryParse(Session["UserID"].ToString(), out studID);

            if (db.Activities.Where(act => act.UserID == studID).ToList().Count > 0)
            {

                var tests = db.Tests.Include(q => q.Activities).Include(r => r.User).ToList();
                return View(tests);
            }
            else
            {
                //if no test is assigned
                return RedirectToAction("NoTest", "User");

            }
        }

        /// <summary>
        /// Action to display No test message
        /// </summary>
        /// <returns>Action Result</returns>
        public ActionResult NoTest()
        {
            return View();
        }

        /// <summary>
        /// Action to display No questions in this test
        /// </summary>
        /// <returns>Action Result</returns>
        public ActionResult NoQuestions()
        {
            return View();
        }

        /// <summary>
        /// Action to Login a user
        /// </summary>
        /// <param name="user">User data to login</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Login(User user)
        {
            User u = db.Users.Where(a => a.Email == user.Email && a.Password == user.Password).FirstOrDefault();
            if (u != null)
            {
                //Find the user and redirect to apprpriate location
                Session["Role"] = u.Role;
                Session["UserID"] = u.ID.ToString();
                if (u.Role.Equals("Admin"))
                {
                    return RedirectToAction("Index", "User");
                }
                else if (u.Role.Equals("Organiser"))
                {
                    return RedirectToAction("Index", "Test");
                }
                else
                {
                    return RedirectToAction("TestList", "User");
                }
            }
            return View(user);
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
        /// Action to List users
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            if (Session.Count != 0)
            {
                if (Session["Role"].Equals("Admin"))
                {
                    return View(db.Users.ToList());
                }
            }
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// Action to display details of any User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(decimal id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Action to display UI for new user creation
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post action for Create which saves a user to database
        /// </summary>
        /// <param name="user">User record</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        /// <summary>
        /// Action to edit any user
        /// </summary>
        /// <param name="id">Id of the user to be added</param>
        /// <returns>ActionResult</returns>
        public ActionResult Edit(decimal id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Post action which updates user record
        /// </summary>
        /// <param name="user">New user record</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        /// <summary>
        /// Action to display all the answers for a Test
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult ListAnswers()
        {
            //Find all the answers with some test ID and user ID
            decimal testID;
            decimal.TryParse(Session["TestID"].ToString(), out testID);
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);
            var answers = db.Answers.Include(a => a.Question).Include(a => a.Test).Include(a => a.User).Where(a => a.TestID == testID && a.UserID == userID).ToList();

            return View(answers);
        }

        /// <summary>
        /// Action for displaying a UI to attempt a test
        /// </summary>
        /// <param name="id">ID of the question to display</param>
        /// <returns>ActionResult</returns>
        public ActionResult Attempt(decimal id = 0)
        {
            //Find a question with specific question ID and User ID
            decimal testID;
            decimal.TryParse(Session["TestID"].ToString(), out testID);

            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);

            Answer answers = db.Answers.Include(a => a.Question).Include(a => a.Test).Include(a => a.User).Where(a => a.TestID == testID && a.UserID == userID && a.QuesID == id).FirstOrDefault() as Answer;

            return View(answers);
        }

        /// <summary>
        /// Post for Attempt which saves user entry in database
        /// </summary>
        /// <param name="ansID">ID of the answer</param>
        /// <param name="testID">ID of the test</param>
        /// <param name="quesID">ID of the question</param>
        /// <param name="ans">Answer</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Attempt(string ansID, string testID, string quesID, string ans)
        {
            //Parse the given strings into decimals
            #region Parsing Values
            decimal aID;
            decimal tID;
            decimal qID;

            decimal.TryParse(testID, out tID);
            decimal.TryParse(quesID, out qID);
            decimal.TryParse(ansID, out aID);
            #endregion

            //Find the answer
            Answer answer = db.Answers.Where(a => a.ID == aID).FirstOrDefault();
            answer.Ans = ans;
            db.SaveChanges();

            //Update it
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);
            var newQuestion = db.Answers.Include(a => a.Question).Include(a => a.Test).Include(a => a.User).Where(a => a.TestID == tID && a.UserID == userID && a.Question.ID > qID).FirstOrDefault();
            if (newQuestion != null)
            {
                decimal newQuesID = newQuestion.Question.ID;

                return RedirectToAction(string.Format("Attempt/{0}", newQuesID), "User");
            }
            else
            {
                return RedirectToAction("ListAnswers", "User");
            }
        }

        /// <summary>
        /// Action to show a UI for any test for attempting
        /// </summary>
        /// <param name="id">ID of the test</param>
        /// <returns>ActionResult</returns>
        public ActionResult GetTest(decimal id = 0)
        {
            //Find the test ID
            Session["TestID"] = id.ToString();
            decimal userID;
            decimal.TryParse(Session["UserID"].ToString(), out userID);
            var question = db.Answers.Include(a => a.Question).Include(a => a.Test).Include(a => a.User).Where(a => a.TestID == id && a.UserID == userID).FirstOrDefault();

            //Check if there are questions or not
            if (question == null)
            {
                return RedirectToAction("NoQuestions", "User");

            }
            var quesID = question.Question.ID;
            return RedirectToAction(string.Format("Attempt/{0}", quesID), "User");

        }

        /// <summary>
        /// Delete Action to delete a user
        /// </summary>
        /// <param name="id">ID of the user to be deleted</param>
        /// <returns>ActionResult</returns>
        public ActionResult Delete(decimal id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       /// <summary>
       /// Post for Delete which deletes a user
       /// </summary>
       /// <param name="id">ID of the user to be deleted</param>
        /// <returns>ActionResult</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(decimal id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}