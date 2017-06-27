using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassesSchedule.ViewModel
{
    public class CoursesVM
    {
        public IEnumerable<Courses1_Result> CoursesUser { get; set; }
      
        //POST
        public IEnumerable<CoursesList> CoursesList { get; set; }

        public IEnumerable<Teacher> TeacherList { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int[] SelectedValuesT { get; set; }
        public IEnumerable<SelectListItem> ValuesT { get; set; }

        public int[] SelectedValuesC { get; set; }
        public IEnumerable<SelectListItem> ValuesC { get; set; }


    }
}