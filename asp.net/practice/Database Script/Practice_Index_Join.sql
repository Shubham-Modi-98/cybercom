select * from tblProduct
select * from tblProductSale

create Index Ix_Name_Product ON tblProduct(Name)

create Clustered Index UCIx_Qty_Sale ON tblProductSale(ProductId)

select p.Name, ISNULL(SUM(p.UnitPrice*s.QtySold),0) as TotalSales, COUNT(s.QtySold) as TotalTransaction 
from tblProduct p, tblProductSale s 
where p.ProductId = s.ProductId 
Group By p.Name

select Name, SUM(UnitPrice*QtySold) as TotalSales, COUNT(*) as TotalTransaction from tblProduct
Join tblProductSale ON 
tblProduct.ProductId = tblProductSale.ProductId
Group By Name 
