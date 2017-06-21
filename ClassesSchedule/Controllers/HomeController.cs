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
            return View();
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View();
        }

        public ActionResult Marks()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Main()
        {
            MainP model = new MainP();

            using (var ctx = new CSEntities())
            {
                model.ScheduleView = (from t in ctx.Schedules select t).ToList();

            }

            return View(model);

        }

        #endregion

      
        
        #region GET GRID DATA

        public ActionResult GetScheduleViewGridData()
        {

            MainP model = new MainP();

            using (var ctx = new CSEntities())
            {
                model.ScheduleView = from t in ctx.Schedules select t;
            }

            WATableModel<Schedule> WATmodel = new WATableModel<Schedule>();

            WATmodel.Columns = new Dictionary<string, WATColumn> {
        { "Code", new WATColumn { Index = 1, Type = "string", Friendly = "Code" } },
        { "Type", new WATColumn { Index = 2, Type = "string", Friendly = "Type" } },
        { "ParentCode", new WATColumn { Index = 3, Type = "string", Friendly = "Parent" } },
        { "Country", new WATColumn { Index = 4, Type = "string", Friendly = "Country" } },
        { "State", new WATColumn { Index = 5, Type = "string", Friendly = "State" } },
        { "City", new WATColumn { Index = 6, Type = "string", Friendly = "City" } },
        { "Attn", new WATColumn { Index = 7, Type = "string", Friendly = "Attention" } },
        { "Phone", new WATColumn { Index = 8, Type = "string", Friendly = "Phone" } }
      };


            WATmodel.Rows = model.ScheduleView.ToList();

            return null;
        }

        #endregion

        #region POST ACTION

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

                    Session["ID"] = loggedUser.ID;
                    Session["ROLE"] = loggedUser.RoleID;
                    Session["FNAME"] = loggedUser.FName;
                    //lUser.User.FName = loggedUser.FName;
                    //lUser.User.Role = loggedUser.RoleID;
                    //lUser.User.ID = loggedUser.ID;
                    // return RedirectToAction("Main", new { fName = lUser.User.FName, role = lUser.User.Role, id = lUser.User.ID });
                    return RedirectToAction("Main");
                }
            }
        }
        #endregion
    }
}