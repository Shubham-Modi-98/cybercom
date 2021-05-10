using InventoryDbLayer.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDbLayer.Db.DbOperations
{
    public class ProductOp
    {
        InventoryManagementEntities context = null;
        public ProductOp()
        {
            context = new InventoryManagementEntities();
        }

        public int AddProduct(ProductIms product)
        {
            try
            {
                using (context)
                {
                    Product prod = new Product()
                    {
                        Name = product.Name,
                        Stock = product.Stock,
                        Price = product.Price,
                        Status = false,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    context.Product.Add(prod);
                    context.SaveChanges();
                    int prodId = prod.ProductID;
                    if (prodId > 0)
                        return prodId;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public int GetAvailableProductsCount()
        {
            try
            {
                using (context)
                {
                    int prodCount = context.Product.Where(p => p.Status == false && p.Stock > 0).Count();
                    if (prodCount > 0)
                        return prodCount;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public int GetLessthan10Products()
        {
            try
            {
                using (context)
                {
                    int prodCount = context.Product.Where(p => p.Status == false && p.Stock < 10).Count();
                    if (prodCount > 0)
                        return prodCount;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public int GetProductsCount()
        {
            try
            {
                using (context)
                {
                    int prodCount = context.Product.Where(p => p.Status == false).Count();
                    if (prodCount > 0)
                        return prodCount;
                    else
                        return 0;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return 0;
            }
        }

        public List<ProductIms> GetAllProducts()
        {
            try
            {
                using (context)
                {
                    var prodList = context.Product.Where(p => p.Status == false).Select(p => new ProductIms()
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Stock = p.Stock,
                        Price = p.Price,
                        UpdatedDate = p.UpdatedDate,
                    }).ToList();
                    if (prodList != null)
                        return prodList;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public List<ProductIms> GetProducts(int recordSkip = 0, int recordTake = 5)
        {
            try
            {
                using (context)
                {
                    var prodList = context.Product.Where(p => p.Status == false).Select(p => new ProductIms() 
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Stock = p.Stock,
                        Price = p.Price,
                        UpdatedDate = p.UpdatedDate,
                    }).OrderBy(x => 1 == 1).Skip(recordSkip).Take(recordTake).ToList();
                    if (prodList != null)
                        return prodList;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public ProductIms GetProduct(int id)
        {
            try
            {
                using (context)
                {
                    var product = context.Product.Where(p => p.Status == false).Select(p => new ProductIms()
                    {
                        ProductID = p.ProductID,
                        Name = p.Name,
                        Stock = p.Stock,
                        Price = p.Price,
                        UpdatedDate = p.UpdatedDate,
                    }).FirstOrDefault(p => p.ProductID == id);
                    if (product != null)
                        return product;
                    else
                        return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public bool UpdateProduct(int id, ProductIms product)
        {
            try
            {
                using (context)
                {
                    var prod = context.Product.Where(p => p.Status == false).FirstOrDefault(p => p.ProductID == id);
                    if (prod != null)
                    {
                        prod.Name = product.Name;
                        prod.Stock = product.Stock;
                        prod.Price = product.Price;
                        prod.UpdatedDate = DateTime.Now;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                using (context)
                {
                    var product = context.Product.Where(p => p.Status == false).FirstOrDefault(p => p.ProductID == id);
                    if (product != null)
                    {
                        //context.Product.Remove(product);
                        product.Status = true;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }
    }
}
