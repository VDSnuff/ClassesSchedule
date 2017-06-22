using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class ScheduleVM
    {
        public IEnumerable<Schedule> ScheduleView { get; set; }

        public IEnumerable<ScheduleList> ScheduleList { get; set;}

        public IEnumerable<ScheduleUserFunc_Result> ScheduleUser { get; set; }

    }
}