//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassesSchedule.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mark
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int ClassScheduleID { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
        public byte Value { get; set; }
    
        public virtual ClassSchedule ClassSchedule { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
