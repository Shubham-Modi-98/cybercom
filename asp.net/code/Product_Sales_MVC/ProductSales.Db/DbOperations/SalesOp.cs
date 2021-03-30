using ProductSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSales.Db.DbOperations
{
    public class SalesOp
    {
        public int AddSales(double txtTotalPrice, int drpProdId, int txtQty, double txtPrice)
        {
            using (var context = new ProdSalesEntities())
            {
                tblSales sales = new tblSales()
                {
                    Qty = txtQty,
                    Price = Convert.ToDecimal(txtPrice),
                    TotalPrice = Convert.ToDecimal(txtTotalPrice),
                    Id = drpProdId,
                    SalesDate = DateTime.Now
                };
                context.tblSales.Add(sales);
                context.SaveChanges();
                return sales.SalesId;
            }
        }

        public Sales GetSalesById(int salesId)
        {
            using (var context = new ProdSalesEntities())
            {
                var result = context.tblSales.Where(x => x.SalesId == salesId).Select(x => new Sales()
                {
                    Qty = x.Qty,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice,
                    SalesDate = x.SalesDate,
                    Product = new Product()
                    {
                        Id = x.tblProduct.Id,
                        ProdId = x.tblProduct.ProdId,
                        ProdName = x.tblProduct.ProdName,
                        Price = x.tblProduct.Price,
                        Qty = x.tblProduct.Qty,
                        Image = x.tblProduct.Image,
                    }
                }).FirstOrDefault();
                return result;
            }
        }
    }
}
