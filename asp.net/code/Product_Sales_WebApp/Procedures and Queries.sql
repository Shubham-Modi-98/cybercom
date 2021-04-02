/*
Truncate Table tblSales
delete from tblProduct where ProdId = 'P035'

Create Proc spAddProduct
@prodId nvarchar(50),
@prodName nvarchar(200),
@prodQty int,
@prodPrice numeric(18,2),
@prodImage varbinary(MAX)
As
Begin
	Insert into tblProduct values (@prodId,@prodName,@prodQty,@prodPrice,@prodImage)
End
*/
Use ProductSales
Go


Alter Proc spInsertProduct
@prodId nvarchar(50),
@prodName nvarchar(200),
@prodQty int,
@prodPrice numeric(18,2),
@prodImage varbinary(MAX),
@pId nvarchar(50) output
As
Begin
	Declare @no int
	Insert into tblProduct values (@prodId,@prodName,@prodQty,@prodPrice,@prodImage)
	Select @no = SCOPE_IDENTITY()
	Select @pId = ProdId from tblProduct where Id = @no
End



Create Proc spGetAllProduct
As
Begin
	Select * from tblProduct
End

Alter Proc spGetProductImage
@prodId nvarchar(50)
As
Begin
	Select ProdImage from tblProduct where ProdId =  @prodId
End


Alter Proc spDeleteProductId
@prodId nvarchar(50)
As
Begin
	Delete from tblProduct where ProdId = @prodId
End

Create Proc spGetProductByProdId
@prodId nvarchar(50)
As
Begin
	Select * from tblProduct where ProdId =  @prodId
End

create Proc spUpdateProduct
@prodId nvarchar(50),
@name nvarchar(200),
@qty int,
@price numeric(18,2)
As
Begin
	update tblProduct set ProdName = @name, ProdQty = @qty, ProdPrice = @price 
	where ProdId = @prodId
End

create Proc spUpdateProductWithImage
@prodId nvarchar(50),
@name nvarchar(200),
@qty int,
@price numeric(18,2),
@image varbinary(MAX)
As
Begin
	update tblProduct set ProdName = @name, ProdQty = @qty, ProdPrice = @price, ProdImage = @image 
	where ProdId = @prodId
End

Insert into tblProduct values ('P02','Apple',10,40,Null)

Create Proc spAllGetIdName
As
Begin
	select Id,ProdName from tblProduct
End

Alter Proc spGetProductById
@id int
As
Begin
	Select * from tblProduct where Id =  @id
End

Alter Proc spAddSaleProduct
@qty int,
@price numeric(18,2),
@total numeric(18,2),
@prodId int,
@id int output
As
Begin
	Insert into tblSales values(@qty,@price,@total,GETDATE(),@prodId)
	Select @id = SCOPE_IDENTITY()
	Update tblProduct set ProdQty = (ProdQty-@qty) where Id = @prodId
End

Alter Proc spGetSaleById
@salesId int
As
Begin
	Select S.SalesId, S.Qty,S.Price,S.TotalPrice,P.ProdId,P.ProdName from [tblSales] S , tblProduct P 
	where S.Id = P.Id and S.SalesId = @salesId
End
	Select S.SalesId, S.Qty,S.Price,S.TotalPrice,P.ProdId,P.ProdName from [tblSales] S , tblProduct P 
	where S.Id = P.Id and S.SalesId = 2

Alter Proc spFetchProdData
As
Begin
	Select ProdId,ProdName,ProdPrice,ProdImage from tblProduct
	where ProdName In
	(Select P.ProdName
	from tblProduct P, tblSales S
	where S.Id = P.Id
	Group By P.ProdName)
	/*
	Select ROW_NUMBER() Over (ORDER BY ProdImage) as [RowNo],ProdId,ProdName,ProdPrice,ProdImage from tblProduct
	where ProdName In
	(Select P.ProdName
	from tblProduct P, tblSales S
	where S.Id = P.Id
	Group By P.ProdName) 
	*/
End

Alter Proc spGetSalesDataByName --'cbv'
@name nvarchar(50)
As
Begin
	Select Qty,TotalPrice,SalesDate from tblSales S,tblProduct P
	where P.Id = S.Id and P.ProdName = @name

	/* Select SUM(Qty) as [Qty],SUM(TotalPrice) as [TotalPrice],
	CONVERT(date,SalesDate) as [SalesDate]
	from tblSales S,tblProduct P
	where P.Id = S.Id and P.ProdName = @name
	Group By CONVERT(date,SalesDate) */
End

--If told to fetch total data from date as group by
Select SUM(Qty) as [Qty],SUM(TotalPrice) as [TotalPrice]
,CONVERT(date,SalesDate) as [SalesDate]
from tblSales S,tblProduct P
where P.Id = S.Id and P.ProdName = 'Oppo A3'
Group By CONVERT(date,SalesDate)

	Select ProdName,ProdPrice from tblProduct
	where ProdName In
	(Select P.ProdName
	from tblProduct P, tblSales S
	where S.Id = P.Id
	Group By P.ProdName)

	Select ROW_NUMBER() Over (ORDER BY ProdImage) as [RowNo],ProdId,ProdName,ProdPrice,ProdImage from tblProduct
	where ProdName In
	(Select P.ProdName
	from tblProduct P, tblSales S
	where S.Id = P.Id
	Group By P.ProdName)
	

	Select * from tblProduct
	Select * from tblSales
	
Update tblProduct set ProdQty = (ProdQty-10) where Id = 7

Alter Procedure selectAllProduct
As
Begin
	select ProdId,ProdName,ProdQty,ProdPrice,ProdImage from tblProduct
End

/*
Truncate Table tblSales
delete from tblProduct where ProdId = 'P035'
*/