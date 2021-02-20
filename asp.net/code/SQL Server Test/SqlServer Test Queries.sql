Use [DatabaseDemo]
Create Table Employee
(
	Employee_id int PRIMARY KEY Identity(1,1),
	First_name nvarchar(50) NOT NULL,
	Last_name nvarchar(50) NOT NULL,
	Salary int NOT NULL,
	Joining_date datetime NOT NULL,
	Department nvarchar(50) NOT NULL
)
GO

insert into Employee values (1,'John','Abraham',1000000,'01-01-13 12:00:00 AM','Banking')
insert into Employee values (2,'Michael','Clarke',800000,'01-01-13 12:00:00 AM','Insurance')
insert into Employee values (3,'Roy','Thomas',700000,'02-01-13 12:00:00 AM','Banking')
insert into Employee values (4,'Tom','Jose',600000,'02-01-13 12:00:00 AM','Insurance')
insert into Employee values (5,'Jerry','Pinto',650000,'02-01-13 12:00:00 AM','Insurance')
insert into Employee values (6,'Philip','Mathew',750000,'01-01-13 12:00:00 AM','Services')
insert into Employee values (7,'TestName 1','123',650000,'01-01-13 12:00:00 AM','Services')
insert into Employee values (8,'TestName 2','Lname%',600000,'02-01-13 12:00:00 AM','Insurance')


Create Table Incentives
(
	Employee_ref_id int FOREIGN KEY REFERENCES Employee(Employee_id),
	Incentive_date date NOT NULL,
	Incentive_amount int NOT NULL
)

insert into Incentives values (1,'02-01-13',5000)
insert into Incentives values (2,'02-01-13',3000)
insert into Incentives values (3,'02-01-13',4000)
insert into Incentives values (1,'01-01-13',4500)
insert into Incentives values (2,'01-01-13',3500)

delete from Employee
delete from Incentives

select * from Employee
select * from Incentives

Select First_name as [Employee Name] from Employee

Select CHARINDEX('o',First_name) as [Character Index] 
from Employee where First_name = 'John'

Select First_Name, YEAR(Joining_date) as [Joining Year], 
MONTH(Joining_date) as [Joining Month],
DAY(Joining_date) as [Joining Day]
from Employee

Select First_Name, YEAR(Joining_date) as [Joining Year],
FORMAT(Joining_date,'MMM') as [Joining Month],
DAY(Joining_date) as [Joining Date] 
from Employee

Select * from Employee 
ORDER BY First_name ASC, Salary DESC


Select e.First_name,x.Salary from Employee e
join Employee x
on e.Employee_id = x.Employee_id
Order by e.First_name , x.Salary Desc

Select * from Employee 
where First_name NOT IN('John','Roy')

Select * from Employee 
where First_name Not In
(select First_name from Employee 
where First_name like 'John%' or First_name like 'Roy%')

Select * from Employee where First_name like '%n'

Select * from Employee 
where First_name like '%n' and LEN(first_name) = 4

Select * from Employee where Salary < 800000

Select * from Employee where Joining_date < '01/01/2013'

select DATEDIFF(MONTH,e.Joining_date,i.Incentive_date) 
as DateDifference 
from Employee e, Incentives i
where e.Employee_id = i.Employee_ref_id

Select DATEDIFF(DAY,E.Joining_date,I.Incentive_date) 
as DateDifference 
from Employee E, Incentives I where E.Employee_id = I.Employee_ref_id

Select GETDATE() as [Database Date]

Select Department,SUM(Salary) as [Department Salary] 
from Employee Group By Department

Select Department, COUNT(Employee_id) as [No. of Employees], 
SUM(Salary) as [Department Salary] 
from Employee Group By Department

Select YEAR(Joining_date) as [Joining Year], 
FORMAT(Joining_date,'MMM') as [Joining Month], 
Count(Joining_date) as [No.of Employees] 
from Employee Group By Joining_date

Select E.*, I.Incentive_amount from Employee as E, Incentives as I
where E.Employee_id = I.Employee_ref_id and First_name = 'John'

Update Incentives set Incentive_amount = 1200 
From Employee E, Incentives I 
where E.Employee_id = I.Employee_ref_id and E.First_name = 'John'
select * from Incentives

Select TOP 2 Salary from Employee

Select MAX(Employee.Salary) as [2nd High Salary] 
from Employee where Salary 
NOT IN (Select MAX(Salary) from Employee)

Truncate Table Employee

Create Procedure spGetEmployeeById
@id int
AS
Begin
	Select * from Employee where Employee_id = @id
End
Execute spGetEmployeeById @id = 2

Create Function fnMaxNumber(@no1 int,@no2 int,@no3 int)
returns int AS
Begin
	Declare @maxVal as int
	If(@no1 > @no2 and @no1 > @no3)
		set @maxVal = @no1
	Else if (@no2 > @no1 and @no2 > @no3)
		set @maxVal = @no2
	ELSE
		set @maxVal = @no3
	return @maxVal
End
Select [dbo].[fnMaxNumber](15,20,10) as [Maximum Number]

--Update Employee set Salary = new_salary where Department = 'Insurence'
Select Salary from Employee where Department = 'Insurance'

Insert into Employee (First_name,Last_name,Salary,Joining_date,Department) 
values ('Cristiano','Ronaldo',30000,'02-01-2013 12:00:00: AM','Banking')


Select Employee_id,First_name,Last_name,Salary,
CONVERT(nvarchar,Joining_date,0) as [Joining_date],
Department
from Employee

Select Employee_ref_id,
Incentive_amount,
CONVERT(nvarchar,Incentive_date,0) 
as [Incentive_date]
from Incentives
