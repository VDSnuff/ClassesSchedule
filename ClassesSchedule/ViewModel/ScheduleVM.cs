using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassesSchedule.ViewModel
{
    public class ScheduleVM
    {
        public IEnumerable<Schedule> ScheduleView { get; set; }

        public IEnumerable<ScheduleList> ScheduleList { get; set;}

        public IEnumerable<ScheduleUserFunc_Result> ScheduleUser { get; set; }

        public IEnumerable<string> ClassList { get; set; }

        public IEnumerable<string> CourseList { get; set; }

        public IEnumerable<string> TeacherList { get; set; }

        public IEnumerable<SelectListItem> ClassL { get; set; }

        public DateTime? STime { get; set; }

        public DateTime? ETime { get; set; }

        public string Class { get; set; }

        public string Course { get; set; }

        public string Teacher { get; set; }

        public int HelpID { get; set; }
    }
}