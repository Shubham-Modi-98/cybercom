using BussineLogic.DbLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineLogic.Operations
{
    public class ProductOperations : IProduct
    {
        public int AddProduct(Product product)
        {
            using(var context = new DbDemoEFEntities())
            {
                tblProduct prod = new tblProduct()
                {
                    ProdId = product.ProdId,
                    ProdName = product.ProdName,
                    ProdQty = product.ProdQty,
                    ProdPrice = product.ProdPrice
                };
                context.tblProduct.Add(prod);
                context.SaveChanges();
                return prod.Id;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblProduct.Select(x => new Product()
                {
                    Id = x.Id,
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdQty = x.ProdQty,
                    ProdPrice = x.ProdPrice
                }).ToList();
                if(result != null)
                {
                    return result;
                }
                return null;
            }
        }

        public Product GetProduct(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblProduct.Where(x => x.Id == id).Select(x => new Product() {
                    Id = x.Id,
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdQty = x.ProdQty,
                    ProdPrice = x.ProdPrice
                }).FirstOrDefault();
                return result;
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblProduct.FirstOrDefault(x => x.Id == id); 
                if(result != null)
                {
                    result.ProdId = product.ProdId;
                    result.ProdName = product.ProdName;
                    result.ProdPrice = product.ProdPrice;
                    result.ProdQty = product.ProdQty;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var context = new DbDemoEFEntities())
            {
                var result = context.tblProduct.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    context.tblProduct.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
