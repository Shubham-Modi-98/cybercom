USE [DatabaseDemo]
GO

select * from tblStudCourse
select * from tblStudent

alter procedure addStudent
@roll nvarchar(15),
@name nvarchar(50),
@php int,
@asp int,
@js int,
@cid int
/*@no nvarchar(15) output*/
as
Begin
	insert into tblStudent values (@roll, @name, @php, @asp, @js, @cid)
	/*select @no = RollNo from tblStudent where Id IN (select MAX(Id) from tblStudent)*/
End

alter procedure getCourseData
as
Begin
	select Id,Course from tblStudCourse
End

alter procedure getData
as
Begin
	select RollNo,[Name],Php,Asp,Js,CourseId, Course from tblStudent, tblStudCourse 
	where CourseId = tblStudCourse.Id
End

select RollNo, Course, CourseId from tblStudCourse as sc, tblStudent as s where CourseId = sc.Id

alter procedure updateRecord
@roll nvarchar(15),
@name nvarchar(50),
@cid int,
@php int,
@asp int,
@js int
as
Begin
	update tblStudent set Name = @name, CourseId = @cid, Php = @php, Asp = @asp, Js = @js
	where RollNo = @roll
End

create procedure deleteRecord
@roll nvarchar(15)
as
Begin
	delete from tblStudent where RollNo = @roll
End

select RollNo, Course, CourseId from tblStudCourse as sc, tblStudent as s where CourseId = sc.Id and RollNo = 'CC001'