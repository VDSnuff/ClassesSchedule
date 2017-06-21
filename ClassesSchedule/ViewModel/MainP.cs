using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class MainP
    {
        public IEnumerable<Schedule> ScheduleView { get; set; }

        public Authentication User { get; set; }
       
        public MainP()
        {
            User = new Authentication();
        }
    }
}