using ProductSales.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<Sales> GetSalesData()
        {
            using (var context = new ProdSalesEntities())
            {

                var result = context.tblSales.Select(x => new Sales()
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
                }).ToList();
                return result;
            }
        }

        //Call Store Procedure spGetProduct
        public List<spGetProduct_Result> GetProducts()
        {
            using (var contex = new ProdSalesEntities())
            {
                var result = contex.Database.SqlQuery<spGetProduct_Result>("spGetProduct").ToList();
                contex.Dispose();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
        }

        //Call Store Procedure spGetSalesDataByName
        public List<spGetSalesDataByName_Result> GetSalesDataByName(string prodName)
        {
            using (var contex = new ProdSalesEntities())
            {
                //var result = contex.Database.SqlQuery<spGetProduct_Result>("spGetProduct").ToList();
                //List<spGetSalesDataByName_Result> resultSet = null;
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@name",prodName??(object)DBNull.Value)
                };
                var result = contex.Database.SqlQuery<spGetSalesDataByName_Result>("spGetSalesDataByName @name", param).ToList();
                if(result != null)
                {
                    return result;
                }
                return null;
            }
        }
    }
}
