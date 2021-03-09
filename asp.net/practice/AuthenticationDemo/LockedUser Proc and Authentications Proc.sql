Alter proc spAddUser
@name nvarchar(50),
@password nvarchar(250),
@email nvarchar(50),
@id int output
as
Begin
	Insert into tblUser(Name,Password,Email,RegiDateTime) values (@name, @password, @email,GETDATE())
	select @id = SCOPE_IDENTITY() 
End

/* Count Attempts and Block User Procedures */
Alter proc spUserAuth
@email nvarchar(50),
@password nvarchar(250)
as
Begin
	declare @locked int
	declare @count int
	declare @attempt int
	declare @chkEmail nvarchar(50)

	select @locked = IsNULL(IsLocked,0) from tblUser where Email = @email and Password = @password
	
	if(@locked = 1)
	begin
		select 1 as Locked, 0 as Auth, 0 as Attempt
	end
	else
	begin
		select @count = COUNT(NAME) from tblUser where Email = @email and Password = @password	
		
		if(@count = 1)
		begin
			update tblUser set RetryAttempt = NULL where Email = @email
			declare @name nvarchar(50)
			select @name = Name from tblUser where Email = @email
			select 0 as Locked, 1 as Auth, 0 as Attempt, @name as UserName
		end
		else
		begin
			select @chkEmail = Email from tblUser where Email = @email and Password = @password	
			if(@chkEmail = @email)
			begin
				select @attempt = IsNULL(RetryAttempt,0) from tblUser where Email = @email
				set @attempt = @attempt + 1	
			end
			else
			begin
				select 0 as Locked, 0 as Auth, 0 as Attempt
			end
		end
		
		if(IsNULL(@attempt,0) <= 3)
		begin
			update tblUser set RetryAttempt = @attempt where Email = @email
			select 0 as Locked, 0 as Auth, @attempt as Attempt
		end
		else
		begin
			update tblUser set RetryAttempt = @attempt, 
			IsLocked = 1, LockedDateTime = GETDATE() 
			where Email = @email
			select 1 as Locked, 0 as Auth, 0 as Attempt
		end
	end
End

/* Change Locked Account to UnLocked using [SQL Server Agent JOB] */
Update tblUser set RetryAttempt = NULL, 
IsLocked = NULL, LockedDateTime = NULL
where DATEDIFF(MINUTE,LockedDateTime,GETDATE()) >= 20

select IsNULL(IsLocked,0), IsNULL(RetryAttempt,0) from tblUser 
where Email = 'admin@gmail.com' and Password = 'BA75BE5A3634E6828643A3772F05D4654EAE3C1B'



select * from tblUser

select DATEDIFF(MINUTE,'2021-03-09 19:57:01.3733333',GETDATE())