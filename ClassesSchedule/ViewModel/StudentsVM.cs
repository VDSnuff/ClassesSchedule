using ClassesSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class StudentsVM
    {
        public IEnumerable<Student1> StudentList { get; set;}

        public string FName { get; set; }

        public string LName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime? DofB { get; set; }

        public string Spec { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}