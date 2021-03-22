using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineLogic.Operations
{
    public interface IProduct
    {
        int AddProduct(Product product);
        List<Product> GetAllProducts();
        bool UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
        Product GetProduct(int id);
    }
}
