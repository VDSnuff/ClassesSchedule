--insert into ClassSchedule.dbo.PERSON (
--		person.FName,
--		person.LName,
--		person.DateOfBirth,
--		person.Email,
--		person.Phone,
--		person.[RoleID],
--		person.[Login],
--		person.[Password]) 
--select 
--		ad.FirstName, 
--		ad.LastName, 
--		hre.BirthDate, 
--		ad.EmailPromotion, 
--		'TP-555-666-777', 
--		4, 
--		'TestLogin', 
--		'TestPassword'

--FROM AdventureWorks2014.Person.Person as ad inner join AdventureWorks2014.HumanResources.Employee as hre 
--on ad.BusinessEntityID = hre.BusinessEntityID

--insert into Teacher(PersonID)
--select ID from Person
--where ID > 270

--delete from Student
--where ID > 270

--create view Schedule
--as
--select cs.ID as id, 
--	   cs.StartTime as [Start time], 
--	   cs.EndTime as [End time],
--	   cr.ClassNumber as [Classroom No.], 
--	   c.Name as [Course Name], 
--	   p.FName + ' ' + p.LName as [Teacher name], 
--	   t.Degree
--from [ClassSchedule] as cs
--inner join ClassRoom as cr on ClassRoomID = cr.ID
--inner join Course as c on CourseID = c.ID
--inner join Teacher as t on TeacherID = t.ID
--inner join Person as p on t.PersonID = p.ID
 
 -------------------------------------------------
-- CREATE PROCEDURE [dbo].[Login] 
--								@Login nvarchar(25),
--								@Password nvarchar(50)
--AS
--BEGIN
--SELECT FName, LName, RoleID 
--FROM Person
--WHERE [Login] = @Login and [Password] = @Password
--END
--GO

--USE [ClassSchedule]
--GO
--/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 17-Jun-17 1:30:39 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[Login] 
--								@Login nvarchar(25),
--								@Password nvarchar(50)
--AS
--BEGIN
--SELECT FName, LName, RoleID 
--FROM Person
--WHERE [Login] = @Login and [Password] = @Password
--RETORN
--END

--SELECT p.*, s.*, t.* From Person as p
--FULL OUTER JOIN Student as s on p.ID = s.PersonID
--FULL OUTER JOIN Teacher as t on p.ID = t.PersonID
--GO

--update Person 
--SET [Login] = 'DanWilson', [Password] = 'dv666'
--where ID = 271

--CREATE FUNCTION ScheduleUser (@ID int)
--RETURNS TABLE
--AS
--RETURN
--SELECT          cs.ID AS ID, cs.StartTime AS [Start time], cs.EndTime AS [End time], 
--				cr.ClassNumber AS [Classroom No.], c.Name AS [Course Name], 
--                p.FName + ' ' + p.LName AS [Teacher name], 
--				t.Degree

--FROM            dbo.ClassSchedule AS cs INNER JOIN
--                         dbo.ClassRoom AS cr ON cs.ClassRoomID = cr.ID INNER JOIN
--                         dbo.Course AS c ON cs.CourseID = c.ID INNER JOIN
--                         dbo.Teacher AS t ON cs.TeacherID = t.ID INNER JOIN
--                         dbo.Person AS p ON t.PersonID = p.ID LEFT OUTER JOIN
--						 dbo.CourseStudent AS cms ON c.ID = cms.CourseID LEFT OUTER JOIN
--						 dbo.CourseTeacher AS cmt ON c.ID = cmt.TeacherID 

						 
--WHERE p.ID = @ID
--GO


--CREATE VIEW [dbo].[CoursesList]
--AS
--SELECT                   c.ID AS ID, c.Name, c.[Description], p.FName, p.LName, t.Degree

                        
--FROM					 dbo.Course AS c LEFT OUTER JOIN
--						 dbo.CourseTeacher as cmt on c.ID = cmt.CourseID LEFT OUTER JOIN
--						 dbo.Teacher AS t ON cmt.TeacherID = t.ID LEFT OUTER JOIN
--						 dbo.Person AS p ON t.PersonID = p.ID

--CREATE FUNCTION [dbo].[Courses] (@ID int)
--RETURNS TABLE
--AS
--RETURN
--SELECT          c.ID AS ID, c.Name, c.[Description], p.FName + ' ' + p.LName as Teacher, t.Degree

--FROM            dbo.Course AS c LEFT OUTER JOIN
--			    dbo.CourseTeacher as cmt on c.ID = cmt.CourseID LEFT OUTER JOIN
--				dbo.Teacher AS t ON cmt.TeacherID = t.ID LEFT OUTER JOIN
--			    dbo.Person AS p ON t.PersonID = p.ID

						 
--WHERE p.ID = @ID

--GO

--Alter VIEW Teachers
--AS
--select p.ID as [Person ID], p.FName as [Name], p.LName [Surname], p.Phone, p.Email, t.ID as [Teacher ID], t.Degree
--from Person as p inner join 
--     Teacher as t on p.ID = t.PersonID 

--update Person
--Set Email = 'testStudent@cs.com'
--where ID between 1 and 270

--update Student
--Set Specialization = 'Programming and web technology'

--CREATE VIEW Students
--AS
--select p.ID as [Person ID], p.FName as [Name], p.LName [Surname], p.Phone, p.Email, s.ID as [Student ID], s.[Specialization]
--from Person as p inner join 
--     Student as s on p.ID = s.PersonID 

