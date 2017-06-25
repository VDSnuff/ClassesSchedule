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
    }
}