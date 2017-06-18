using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesSchedule.ViewModel
{
    public class MainP
    {
       public Authentication User { get; set; }

        public MainP()
        {
            User = new Authentication();
        }
    }
}