select * from tblProduct
select * from tblSales

/*select P.ProdName, P.Image from tblProduct P, tblSales S 
where P.Id = S.Id
Group By P.ProdName
*/

Create procedure spGetProduct
As
Begin
	Select ProdName,Image from tblProduct
	where ProdName In(Select P.ProdName from tblProduct P, tblSales S 
	where P.Id = S.Id
	Group By P.ProdName)
End

Create Proc spGetSalesDataByName --'HP Laptop'
@name nvarchar(50)
As
Begin
	Select S.Qty,TotalPrice,SalesDate from tblSales S,tblProduct P
	where P.Id = S.Id and P.ProdName = @name

	/* Select SUM(S.Qty) as [Qty],SUM(TotalPrice) as [TotalPrice],
	CONVERT(date,SalesDate) as [SalesDate]
	from tblSales S,tblProduct P
	where P.Id = S.Id and P.ProdName = @name
	Group By CONVERT(date,SalesDate) */
End

