create Procedure spAddCustomer
@name nvarchar(50),
@mobile nvarchar(15),
@pin int,
@balance numeric(18,4),
@limit numeric(18,4)
As
Begin
	Insert into tblBankCustomer values (@name,@mobile,@pin,@balance,@limit)
End

create Procedure spFetchCustomer
@name nvarchar(50),
@pin int
As
Begin
	select Id,Name,Mobile,Pin,Balance,Limit from tblBankCustomer 
	where Pin = @pin and Name = @name
End

create Procedure spUpdateBalance
@id nvarchar(50),
@balance numeric(18,4)
As
Begin
	Update tblBankCustomer set Balance = @balance where Id = @id
End

create Procedure spUpdateFetchUser
@id nvarchar(50)
As
Begin
	Select * from tblBankCustomer where Id = @id
End


select * from tblBankCustomer
