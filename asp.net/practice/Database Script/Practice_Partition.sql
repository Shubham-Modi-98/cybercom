Use [DatabaseDemo]
Go
Create Table ProdElect
(Product nvarchar(25),
Amount int)

Insert into dbo.ProdElect values ('Iphone',500)
Insert into dbo.ProdElect values ('Laptop',800)
Insert into dbo.ProdElect values ('Iphone',1000)
Insert into dbo.ProdElect values ('Speaker',400)
Insert into dbo.ProdElect values ('Laptop',600)

select * from ProdElect

Select Product, SUM(Sale) as [Total Sales] 
from ProdElect
Where Product IN('Laptop','Iphone')
Group By Product
Having SUM(Sale) > 1000


Select ISNULL(Country,'All') as Country, ISNULL(Gender,'All') as Gender, SUM(Salary) as [Total Salry]
from tblEmployee
Group By 
	GROUPING SETS
	(
		(Country , Gender),
		(Country),
		(Gender)
	)
Order By GROUPING(Country), GROUPING(Gender)


select Country, Gender,
SUM(Salary) Over(Partition By Country) as SalaryPart,
SUM(Salary) Over(Partition By Gender) as GenSal
from [dbo].[tblEmployee]

select DISTINCT Gender,
SUM(Salary) Over(Partition By Gender) as GenSal
from [dbo].[tblEmployee]

select DISTINCT Country,
SUM(Salary) Over(Partition By Country) as SalaryPart
from [dbo].[tblEmployee]

