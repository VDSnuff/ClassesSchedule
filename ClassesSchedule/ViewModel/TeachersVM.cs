using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class TeachersVM
    {
        public IEnumerable<Teacher1> TeacherList { get; set; }
    }
}