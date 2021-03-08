USE DatabaseDemo
GO

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Gender]
      ,[Salary]
      ,[Country]
  FROM [DatabaseDemo].[dbo].[tblEmployee]

  create procedure getEmployeeByName
  @name nvarchar(50)
  as
  Begin
	select * from tblEmployee where Name like '%' + @name + '%'
  End

select * from Test

create procedure storeData
@name varchar(50),
@email varchar(50),
@salary numeric(16,2),
@id int output
as
Begin
	insert into Test values (@name,@email,@salary)

	select @id = SCOPE_IDENTITY() 
End

create procedure getData
as
Begin
	Select * from Test
End


create procedure updateData
@id int,
@name nvarchar(50),
@email nvarchar(50),
@salary numeric(16,2)
as 
Begin
	update Test set Name = @name, Email = @email, Salary = @salary where Id = @id
End

create procedure  deleteData
@id int 
as
Begin
	delete from Test where Id = @id
End
