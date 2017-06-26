using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassesSchedule.Models;

namespace ClassesSchedule.ViewModel
{
    public class MarksVM
    {
        public IEnumerable<MarkList> MarksList { get; set; }

        public IEnumerable<string> Course { get; set; }

        public byte Mark { get; set; }

        public IEnumerable<DateTime> Date { get; set; }

        public string Teacher { get; set; }

        public int TeacherID { get; set; }

        public int StudentID { get; set; }



    }
}