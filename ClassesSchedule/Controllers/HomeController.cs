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

        #region RENDER ACTION
        public ActionResult Schedule()
        {
            ScheduleVM model = new ScheduleVM();
            using (var ctx = new CSEntities())
            {
                model.ScheduleList = (from t in ctx.ScheduleLists select t).ToList();

                model.ScheduleUser = ctx.ScheduleUserFunc(Convert.ToInt32(Session["ID"])).ToList();

                model.ClassList = (from t in ctx.ClassRooms select t.ClassNumber).ToList();

                model.TeacherList = (from t in ctx.Teachers select t.Person.LName).ToList();

                model.CourseList = (from t in ctx.Courses select t.Name).ToList();
            }
            return View(model);
        }

        public ActionResult Courses()
        {
            CoursesVM model = new CoursesVM();
            using (var ctx = new CSEntities())
            {
                model.CoursesList = (from t in ctx.CoursesLists select t).ToList();

                model.CoursesUser = ctx.Courses1(Convert.ToInt32(Session["ID"])).ToList();
            }
            return View(model);
        }

        public ActionResult Teachers()
        {

            TeachersVM model = new TeachersVM();
            using (var ctx = new CSEntities())
            {
                model.TeacherList = (from t in ctx.Teachers1 select t).ToList();
            }
            return View(model);

        }

        public ActionResult Students()
        {
            StudentsVM model = new StudentsVM();
            using (var ctx = new CSEntities())
            {
                model.StudentList = (from t in ctx.Students1 select t).ToList();
            }
            return View(model);
        }

        public ActionResult Marks()
        {
            MarksVM model = new MarksVM();
            using (var ctx = new CSEntities())
            {
                model.MarksList = (from t in ctx.MarkLists select t).ToList();
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["ID"] = null;
            Session["ROLE"] = null;
            Session["FNAME"] = null;

            return View("Login");
        }

        public ActionResult Main()
        {
            ScheduleVM model = new ScheduleVM();
            using (var ctx = new CSEntities())
            {
                model.ScheduleView = (from t in ctx.Schedules select t).ToList();
            }
            return View(model);
        }

        #endregion

        #region POST ACTION

        [HttpPost]
        public ActionResult PostLogin(string login, string password)
        {
            var loggedUser = new Person();
            ScheduleVM lUser = new ViewModel.ScheduleVM();

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
                    Session["ID"] = loggedUser.ID;
                    Session["ROLE"] = loggedUser.RoleID;
                    Session["FNAME"] = loggedUser.FName;
                    return RedirectToAction("Main");
                }
            }
        }

        [HttpPost]
        public ActionResult PostNewDate(ScheduleVM post)
        {
            if (post.STime != null || post.ETime != null)
            {
                using (var ctx = new CSEntities())
                {
                    ctx.AddNewDate(post.STime, post.ETime, post.ClassList.FirstOrDefault(), post.CourseList.FirstOrDefault(), post.TeacherList.FirstOrDefault());

                    return RedirectToAction("Schedule", "Home");
                }
            }
            return RedirectToAction("Schedule", "Home");
        }

        [HttpPost]
        public ActionResult PostNewCourse(CoursesVM post)
        {
                using (var ctx = new CSEntities())
                {
                    ctx.AddNewCourse(post.Name, post.Description);

                    return RedirectToAction("Courses", "Home");
                }
        }
        #endregion
    }
}