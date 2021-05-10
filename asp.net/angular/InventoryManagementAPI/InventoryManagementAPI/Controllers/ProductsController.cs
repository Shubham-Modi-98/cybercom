using InventoryDbLayer.Db.DbOperations;
using InventoryDbLayer.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        ProductOp productOp = null;
        public ProductsController()
        {
            productOp = new ProductOp();
        }

        // GET api/products/gettotalproducts
        [HttpGet]
        [Route("gettotalproducts")]
        public IHttpActionResult GetTotalProducts()
        {
            try
            {
                int prodCount = productOp.GetProductsCount();
                if (prodCount > 0)
                    return Content(HttpStatusCode.OK, prodCount);
                else
                    return Content(HttpStatusCode.OK, "Product Data Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/products/allproductcounts
        [HttpGet]
        [Route("allproducts")]
        public IHttpActionResult AllProducts()
        {
            try
            {
                var custCount = productOp.GetAllProducts();
                if (custCount != null)
                    return Content(HttpStatusCode.OK, custCount);
                else
                    return Content(HttpStatusCode.OK, "No Data Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }


        // GET api/products/getproducts
        [HttpGet]
        [Route("getproducts")]
        public IHttpActionResult GetProducts(int? recordSkip = 0, int? recordTake = 5)
        {
            try
            {
                var prodList = productOp.GetProducts((int)recordSkip,(int)recordTake);
                if (prodList != null)
                    return Content(HttpStatusCode.OK, prodList);
                else
                    return Content(HttpStatusCode.OK, "Products Data Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/products/getproductsbyid/1
        [HttpGet]
        [Route("getproductsbyid/{id}")]
        public IHttpActionResult GetProductsById(int id)
        {
            try
            {
                var product = productOp.GetProduct(id);
                if (product != null)
                    return Ok(product);
                else
                    return Content(HttpStatusCode.OK, "Product Data with id-" + id + "Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // POST api/products/addproducts
        [HttpPost]
        [Route("addproducts")]
        public IHttpActionResult AddProducts([FromBody] ProductIms product)
        {
            try
            {
                int prodId = productOp.AddProduct(product);
                if (prodId > 0)
                    return Ok("Product with Id-" + prodId + " added Successfully");
                else
                    return Content(HttpStatusCode.BadGateway, "Something went Wrong!,Try Again after sometimes");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // PUT api/products/updateproduct/1
        [HttpPut]
        [Route("updateproduct/{id}")]
        public IHttpActionResult UpdateProduct(int id, [FromBody] ProductIms product)
        {
            try
            {
                bool prodId = productOp.UpdateProduct(id, product);
                if (prodId)
                    return Ok("Product with Id-" + id + " updated Successfully");
                else
                    return Content(HttpStatusCode.BadGateway, "Something went Wrong!,Try Again after sometimes");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // DELETE api/products/DeleteProduct/1
        [HttpDelete]
        [Route("deleteproduct/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                bool prodId = productOp.DeleteProduct(id);
                if (prodId)
                    return Ok("Product with Id-" + id + " deleted Successfully");
                else
                    return Content(HttpStatusCode.BadGateway, "Something went Wrong!,Try Again after sometimes");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

    }
}
