using MVC_EF_Exception_Demo.Models;
using MVC_EF_Exception_Demo.ProductDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_Exception_Demo.Operations
{
    public class ProductRepo
    {
        public int AddProduct(Product product)
        {
            using (var contex = new DbDemoEFEntities())
            {
                tblProduct prod = new tblProduct()
                {
                    ProdId = product.ProdId,
                    ProdName = product.ProdName,
                    ProdPrice = product.ProdPrice,
                    ProdQty = product.ProdQty
                };
                contex.tblProduct.Add(prod);
                contex.SaveChanges();
                return prod.Id;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var contex = new DbDemoEFEntities())
            {
                var result = contex.tblProduct.Select(x => new Product
                {
                    Id = x.Id,
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdPrice = x.ProdPrice,
                    ProdQty = x.ProdQty
                }).ToList();

                return result;
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            using (var contex = new DbDemoEFEntities())
            {
                var res = contex.tblProduct.Where(x => x.Id == id).FirstOrDefault();
                if(res != null)
                {
                    res.ProdId = product.ProdId;
                    res.ProdName = product.ProdName;
                    res.ProdQty = product.ProdQty;
                    res.ProdPrice = product.ProdPrice;
                    contex.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            using (var contex = new DbDemoEFEntities())
            {
                var res = contex.tblProduct.Where(x => x.Id == id).FirstOrDefault();
                if (res != null)
                {
                    contex.tblProduct.Remove(res);
                    contex.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}