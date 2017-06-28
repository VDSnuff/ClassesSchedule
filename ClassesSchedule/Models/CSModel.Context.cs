﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CSEntities : DbContext
    {
        public CSEntities()
            : base("name=CSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; }
        public virtual DbSet<ClassScheduleShadow> ClassScheduleShadows { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<CourseStudent> CourseStudents { get; set; }
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
        public virtual DbSet<ScheduleList> ScheduleLists { get; set; }
        public virtual DbSet<CoursesList> CoursesLists { get; set; }
        public virtual DbSet<Teacher1> Teachers1 { get; set; }
        public virtual DbSet<Student1> Students1 { get; set; }
        public virtual DbSet<MarkList> MarkLists { get; set; }
    
        public virtual ObjectResult<Login_Result> Login(string login, string password)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Login_Result>("Login", loginParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Person> GetLogin(string login, string password)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("GetLogin", loginParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Person> GetLogin(string login, string password, MergeOption mergeOption)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person>("GetLogin", mergeOption, loginParameter, passwordParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        [DbFunction("CSEntities", "ScheduleUser")]
        public virtual IQueryable<ScheduleUser_Result> ScheduleUser(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ScheduleUser_Result>("[CSEntities].[ScheduleUser](@ID)", iDParameter);
        }
    
        [DbFunction("CSEntities", "ScheduleUserFunc")]
        public virtual IQueryable<ScheduleUserFunc_Result> ScheduleUserFunc(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ScheduleUserFunc_Result>("[CSEntities].[ScheduleUserFunc](@ID)", iDParameter);
        }
    
        [DbFunction("CSEntities", "Courses1")]
        public virtual IQueryable<Courses1_Result> Courses1(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Courses1_Result>("[CSEntities].[Courses1](@ID)", iDParameter);
        }
    
        [DbFunction("CSEntities", "CoursesUser")]
        public virtual IQueryable<Courses1_Result> CoursesUser(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Courses1_Result>("[CSEntities].[CoursesUser](@ID)", iDParameter);
        }
    
        public virtual int AddNewDate(Nullable<System.DateTime> sTime, Nullable<System.DateTime> eTime, string classR, string course, string teacher)
        {
            var sTimeParameter = sTime.HasValue ?
                new ObjectParameter("STime", sTime) :
                new ObjectParameter("STime", typeof(System.DateTime));
    
            var eTimeParameter = eTime.HasValue ?
                new ObjectParameter("ETime", eTime) :
                new ObjectParameter("ETime", typeof(System.DateTime));
    
            var classRParameter = classR != null ?
                new ObjectParameter("ClassR", classR) :
                new ObjectParameter("ClassR", typeof(string));
    
            var courseParameter = course != null ?
                new ObjectParameter("Course", course) :
                new ObjectParameter("Course", typeof(string));
    
            var teacherParameter = teacher != null ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewDate", sTimeParameter, eTimeParameter, classRParameter, courseParameter, teacherParameter);
        }
    
        public virtual int AddNewDateSP(Nullable<System.DateTime> sTime, Nullable<System.DateTime> eTime, string classR, string course, string teacher)
        {
            var sTimeParameter = sTime.HasValue ?
                new ObjectParameter("STime", sTime) :
                new ObjectParameter("STime", typeof(System.DateTime));
    
            var eTimeParameter = eTime.HasValue ?
                new ObjectParameter("ETime", eTime) :
                new ObjectParameter("ETime", typeof(System.DateTime));
    
            var classRParameter = classR != null ?
                new ObjectParameter("ClassR", classR) :
                new ObjectParameter("ClassR", typeof(string));
    
            var courseParameter = course != null ?
                new ObjectParameter("Course", course) :
                new ObjectParameter("Course", typeof(string));
    
            var teacherParameter = teacher != null ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewDateSP", sTimeParameter, eTimeParameter, classRParameter, courseParameter, teacherParameter);
        }
    
        public virtual int AddNewCourse(string name, string description)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewCourse", nameParameter, descriptionParameter);
        }
    
        public virtual int AddNewCourseSP(string name, string description)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewCourseSP", nameParameter, descriptionParameter);
        }
    
        public virtual int AddNewTeacher(string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string degree, string login, string password)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var degreeParameter = degree != null ?
                new ObjectParameter("Degree", degree) :
                new ObjectParameter("Degree", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewTeacher", fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, degreeParameter, loginParameter, passwordParameter);
        }
    
        public virtual int AddNewTeacherPS(string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string degree, string login, string password)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var degreeParameter = degree != null ?
                new ObjectParameter("Degree", degree) :
                new ObjectParameter("Degree", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewTeacherPS", fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, degreeParameter, loginParameter, passwordParameter);
        }
    
        public virtual int AddNewStudent(string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string spec, string login, string password)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var specParameter = spec != null ?
                new ObjectParameter("Spec", spec) :
                new ObjectParameter("Spec", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewStudent", fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, specParameter, loginParameter, passwordParameter);
        }
    
        public virtual int AddNewStudentSP(string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string spec, string login, string password)
        {
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var specParameter = spec != null ?
                new ObjectParameter("Spec", spec) :
                new ObjectParameter("Spec", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewStudentSP", fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, specParameter, loginParameter, passwordParameter);
        }
    
        public virtual int AddNewMark(string course, Nullable<int> student, Nullable<byte> mark, string when, string teacher)
        {
            var courseParameter = course != null ?
                new ObjectParameter("Course", course) :
                new ObjectParameter("Course", typeof(string));
    
            var studentParameter = student.HasValue ?
                new ObjectParameter("Student", student) :
                new ObjectParameter("Student", typeof(int));
    
            var markParameter = mark.HasValue ?
                new ObjectParameter("Mark", mark) :
                new ObjectParameter("Mark", typeof(byte));
    
            var whenParameter = when != null ?
                new ObjectParameter("When", when) :
                new ObjectParameter("When", typeof(string));
    
            var teacherParameter = teacher != null ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewMark", courseParameter, studentParameter, markParameter, whenParameter, teacherParameter);
        }
    
        public virtual int AddNewMarkSP(string course, Nullable<int> student, Nullable<byte> mark, string when, string teacher)
        {
            var courseParameter = course != null ?
                new ObjectParameter("Course", course) :
                new ObjectParameter("Course", typeof(string));
    
            var studentParameter = student.HasValue ?
                new ObjectParameter("Student", student) :
                new ObjectParameter("Student", typeof(int));
    
            var markParameter = mark.HasValue ?
                new ObjectParameter("Mark", mark) :
                new ObjectParameter("Mark", typeof(byte));
    
            var whenParameter = when != null ?
                new ObjectParameter("When", when) :
                new ObjectParameter("When", typeof(string));
    
            var teacherParameter = teacher != null ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewMarkSP", courseParameter, studentParameter, markParameter, whenParameter, teacherParameter);
        }
    
        public virtual int AssignTeacherForCourse(Nullable<int> teacher, Nullable<int> courseID)
        {
            var teacherParameter = teacher.HasValue ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(int));
    
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignTeacherForCourse", teacherParameter, courseIDParameter);
        }
    
        public virtual int AssignTforC(Nullable<int> teacher, Nullable<int> courseID)
        {
            var teacherParameter = teacher.HasValue ?
                new ObjectParameter("Teacher", teacher) :
                new ObjectParameter("Teacher", typeof(int));
    
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignTforC", teacherParameter, courseIDParameter);
        }
    
        public virtual int DelCourse(Nullable<int> courseID)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DelCourse", courseIDParameter);
        }
    
        public virtual int UpdateCourse(Nullable<int> courseID, string cName, string cDescription)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            var cNameParameter = cName != null ?
                new ObjectParameter("CName", cName) :
                new ObjectParameter("CName", typeof(string));
    
            var cDescriptionParameter = cDescription != null ?
                new ObjectParameter("CDescription", cDescription) :
                new ObjectParameter("CDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCourse", courseIDParameter, cNameParameter, cDescriptionParameter);
        }
    
        public virtual int DelCourseSP(Nullable<int> courseID)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DelCourseSP", courseIDParameter);
        }
    
        public virtual int UpdateCourseSP(Nullable<int> courseID, string cName, string cDescription)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("CourseID", courseID) :
                new ObjectParameter("CourseID", typeof(int));
    
            var cNameParameter = cName != null ?
                new ObjectParameter("CName", cName) :
                new ObjectParameter("CName", typeof(string));
    
            var cDescriptionParameter = cDescription != null ?
                new ObjectParameter("CDescription", cDescription) :
                new ObjectParameter("CDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCourseSP", courseIDParameter, cNameParameter, cDescriptionParameter);
        }
    
        public virtual int DelMark(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DelMark", idParameter);
        }
    
        public virtual int DelMarkSP(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DelMarkSP", idParameter);
        }
    
        public virtual int StartCourse(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("StartCourse", idParameter);
        }
    
        public virtual int DismissTeacher(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DismissTeacher", idParameter);
        }
    
        public virtual int UpdateTeacher(Nullable<int> id, string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string degree, string login, string password)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var degreeParameter = degree != null ?
                new ObjectParameter("Degree", degree) :
                new ObjectParameter("Degree", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTeacher", idParameter, fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, degreeParameter, loginParameter, passwordParameter);
        }
    
        public virtual int UpdateTeacherSP(Nullable<int> id, string fName, string lName, string phone, string email, Nullable<System.DateTime> dofB, string degree, string login, string password)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("FName", fName) :
                new ObjectParameter("FName", typeof(string));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("LName", lName) :
                new ObjectParameter("LName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dofBParameter = dofB.HasValue ?
                new ObjectParameter("DofB", dofB) :
                new ObjectParameter("DofB", typeof(System.DateTime));
    
            var degreeParameter = degree != null ?
                new ObjectParameter("Degree", degree) :
                new ObjectParameter("Degree", typeof(string));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTeacherSP", idParameter, fNameParameter, lNameParameter, phoneParameter, emailParameter, dofBParameter, degreeParameter, loginParameter, passwordParameter);
        }
    
        public virtual int DismissTeacherSP(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DismissTeacherSP", idParameter);
        }
    }
}
