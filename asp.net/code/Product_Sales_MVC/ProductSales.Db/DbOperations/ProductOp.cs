using ProductSales.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProductSales.Db.DbOperations
{
    public class ProductOp
    {
        public int AddProduct(Product product)
        {
            using (var context = new ProdSalesEntities())
            {
                tblProduct tblProd = new tblProduct()
                {
                    ProdId = product.ProdId,
                    ProdName = product.ProdName,
                    Qty = product.Qty,
                    Price = product.Price,
                    Image = product.Image
                };
                context.tblProduct.Add(tblProd);
                context.SaveChanges();
                return tblProd.Id;
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new ProdSalesEntities())
            {
                var resultSet = context.tblProduct.Select(x => new Product()
                {
                    Id = x.Id,
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    Qty = x.Qty,
                    Price = x.Price,
                    Image = x.Image
                }).ToList();

                return resultSet;
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var context = new ProdSalesEntities())
            {
                var result = context.tblProduct.FirstOrDefault(x => x.Id == product.Id);
                if (result != null)
                {
                    result.ProdId = product.ProdId;
                    result.ProdName = product.ProdName;
                    result.Qty = product.Qty;
                    result.Price = product.Price;
                    if(product.Image != null)
                    {
                        result.Image = product.Image;
                    }
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var conn = new ProdSalesEntities())
            {
                var result = conn.tblProduct.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    conn.tblProduct.Remove(result);
                    conn.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateSalesData(Product product)
        {
            using (var context = new ProdSalesEntities())
            {
                var result = context.tblProduct.FirstOrDefault(x => x.Id == product.Id);
                if (result != null)
                {
                    result.ProdId = product.ProdId;
                    result.ProdName = product.ProdName;
                    result.Price = product.Price;
                    result.Qty = product.Qty;
                    result.Image = product.Image;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
