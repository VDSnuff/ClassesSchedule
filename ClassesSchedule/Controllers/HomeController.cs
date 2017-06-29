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

                model.CourseList = (from t in ctx.Courses where t.Closed == false select t.Name).ToList();
            }
            return View(model);
        }

        public ActionResult Courses()
        {
            CoursesVM model = new CoursesVM();
            using (var ctx = new CSEntities())
            {
                // Drop Down List For Teachers
                model.TeacherList = (from t in ctx.Teachers select t).ToList();
                List<SelectListItem> itemsT = new List<SelectListItem>();
                foreach (var item in model.TeacherList)
                {
                    itemsT.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Person.FName + " " + item.Person.LName});
                }
                model.ValuesT = itemsT;

                // Drop Down List For Courses
                model.CoursesList = (from c in ctx.CoursesLists select c).ToList();
                List<SelectListItem> itemsC = new List<SelectListItem>();
                foreach (var item in model.CoursesList)
                {
                    itemsC.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Name});
                }
                model.ValuesC = itemsC;

                //List of Courses
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
                model.Teacher = Session["LNAME"].ToString();
                model.TeacherID = Int32.Parse(Session["ID"].ToString());

                model.MarksList = (from t in ctx.MarkLists select t).ToList();

                model.Course = (from c in ctx.Courses
                              join ct in ctx.CourseTeachers on c.ID equals ct.CourseID
                              join t in ctx.Teachers on ct.TeacherID equals t.ID
                              join p in ctx.People on t.PersonID equals p.ID
                              where p.ID == model.TeacherID && c.Closed == false
                              select c.Name).ToList();

                model.Date = (from cs in ctx.ClassSchedules
                              join t in ctx.Teachers on cs.TeacherID equals t.ID
                              join p in ctx.People on t.PersonID equals p.ID
                              where p.ID == model.TeacherID  
                              select cs.StartTime ).ToList();
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
            Session["LNAME"] = null;

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
                    Session["LNAME"] = loggedUser.LName;
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

        [HttpPost]
        public ActionResult PostNewTeacher(TeachersVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.AddNewTeacher(post.FName, post.LName, post.Phone, post.Email, post.DofB, post.Degree, post.Login, post.Password);

                return RedirectToAction("Teachers", "Home");
            }
        }

        [HttpPost]
        public ActionResult PostNewStudent(StudentsVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.AddNewStudent(post.FName, post.LName, post.Phone, post.Email, post.DofB, post.Spec, post.Login, post.Password);

                return RedirectToAction("Students", "Home");
            }
        }

        [HttpPost]
        public ActionResult PostNewMark(MarksVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.AddNewMark(post.Course.FirstOrDefault(), post.StudentID, post.Mark, post.Date.FirstOrDefault().ToString(), post.Teacher);

                return RedirectToAction("Marks", "Home");
            }
        }

        [HttpPost]
        public ActionResult UpdateCourse(CoursesVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.UpdateCourse(Int32.Parse(post.HelpID), post.Name, post.Description);

                return RedirectToAction("Courses", "Home");
            }
        }

        public ActionResult AssignTeacherForCourse(CoursesVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.AssignTeacherForCourse(post.SelectedValuesT.FirstOrDefault(), post.SelectedValuesC.FirstOrDefault());

                return RedirectToAction("Courses", "Home");
            }
        }

        public ActionResult DelCourse(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.DelCourse(ID);

                return RedirectToAction("Courses", "Home");
            }
        }


        public ActionResult DelMark(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.DelMark(ID);

                return RedirectToAction("Marks", "Home");
            }
        }

        public ActionResult StartCourse(int ID)
        {
            using (var ctx = new CSEntities())
            {
               ctx.StartCourse(ID);

               return RedirectToAction("Courses", "Home");
            }
        }

        public ActionResult DismissTeacher(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.DismissTeacher(ID);

                return RedirectToAction("Teachers", "Home");
            }
        }

        public ActionResult UpdateTeacher(TeachersVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.UpdateTeacher(post.HelpID, post.FName, post.LName, post.Phone, post.Email, post.DofB, post.Degree, post.Login, post.Password);

                return RedirectToAction("Teachers", "Home");
            }
        }


        public ActionResult InvolveTeacher(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.InvolveTeacher(ID);

                return RedirectToAction("Teachers", "Home");
            }
        }


        public ActionResult DismissStudent(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.DismissStudent(ID);

                return RedirectToAction("Students", "Home");
            }
        }

        public ActionResult InvolveStudent(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.InvolveStudent(ID);

                return RedirectToAction("Students", "Home");
            }
        }


         public ActionResult UpdateStudent(StudentsVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.UpdateStudent(post.HelpID, post.FName, post.LName, post.Phone, post.Email, post.DofB, post.Spec, post.Login, post.Password);

                return RedirectToAction("Students", "Home");
            }
        }

        public ActionResult DelScheduleDate(int ID)
        {
            using (var ctx = new CSEntities())
            {
                ctx.DelScheduleDate(ID);

                return RedirectToAction("Schedule", "Home");
            }
        }


        public ActionResult UpdateSchedule(ScheduleVM post)
        {
            using (var ctx = new CSEntities())
            {
                ctx.UpdateClassSchedule(post.HelpID, post.STime, post.ETime, Int32.Parse(post.ClassList.FirstOrDefault()), Int32.Parse(post.CourseList.FirstOrDefault()), Int32.Parse(post.TeacherList.FirstOrDefault()));

                return RedirectToAction("Students", "Home");
            }
        }

        #endregion
    }
}

