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

        public IEnumerable<ClassRoom> ClassList { get; set; }

        public IEnumerable<CoursesList> CoursesList { get; set; }

        public IEnumerable<Teacher> TeacherList { get; set; }

        public IEnumerable<SelectListItem> ClassL { get; set; }

        public DateTime? STime { get; set; }

        public DateTime? ETime { get; set; }

        public string Class { get; set; }

        public string Course { get; set; }

        public string Teacher { get; set; }

        public int HelpID { get; set; }

        public IEnumerable<SelectListItem> ValuesCl { get; set; }

        public int[] SelectedValuesCl { get; set; }

        public IEnumerable<SelectListItem> ValuesC { get; set; }

        public int[] SelectedValuesC { get; set; }

        public IEnumerable<SelectListItem> ValuesT { get; set; }

        public int[] SelectedValuesT { get; set; }
    }
}