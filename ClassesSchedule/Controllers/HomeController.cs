using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using ClassesSchedule.ViewModel;

namespace ClassesSchedule.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult Courses()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Marks()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Main(string fName, int role, int id)
        {
            MainP model = new MainP();


            return View(model);
        }


        //POST ACTION


        [HttpPost]
        public ActionResult PostLogin(string login, string password)
        {
            var loggedUser = new Person();
            MainP lUser = new ViewModel.MainP();

            using (var ctx = new CSEntities())
            {
                loggedUser = ctx.GetLogin(login, password).FirstOrDefault();

                if (loggedUser == null)
                {
                    ViewBag.BadSignIn = "<p class=\"bg bg-warning\">Incorrect login or password, please try again.</p>";
                    return View("Login");
                }
                else
                {
                    lUser.User.FName = loggedUser.FName;
                    lUser.User.Role = loggedUser.RoleID;
                    lUser.User.ID = loggedUser.ID;
                    return RedirectToAction("Main", new { fName = lUser.User.FName, role = lUser.User.Role, id = lUser.User.ID });
                }
            }
        }
    }
}