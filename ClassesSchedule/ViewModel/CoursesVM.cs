using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class CoursesVM
    {
        public IEnumerable<CoursesList> CoursesList { get; set; }

        public IEnumerable<Courses1_Result> CoursesUser { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}