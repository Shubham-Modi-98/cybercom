using InventoryDbLayer.Db.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashBoardController : ApiController
    {
        OrderOp orderOp = null;
        ProductOp productOp = null;
        CustomerOp customerOp = null;
        DashBoardController()
        {
            orderOp = new OrderOp();
            productOp = new ProductOp();
            customerOp = new CustomerOp();
        }

        // GET api/dashboard/TodaysOrders
        [HttpGet]
        [Route("todaysordercounts")]
        public IHttpActionResult TodaysOrdersCounts()
        {
            try
            {
                var todaysOrders = orderOp.GetTodaysOrders();
                if (todaysOrders > 0)
                    return Content(HttpStatusCode.OK, todaysOrders);
                else
                    return Content(HttpStatusCode.NoContent, "No Orders found in Today's Date...");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/dashboard
        [HttpGet]
        [Route("availableproductcounts")]
        public IHttpActionResult AvailableProductsCounts()
        {
            try
            {
                var avlProds = productOp.GetAvailableProductsCount();
                if (avlProds > 0)
                    return Content(HttpStatusCode.OK, avlProds);
                else
                    return Content(HttpStatusCode.NoContent, "No Products Available");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/dashboard
        [HttpGet]
        [Route("lessproductcounts")]
        public IHttpActionResult LessProductCounts()
        {
            try
            {
                var lessProds = productOp.GetLessthan10Products();
                if (lessProds > 0)
                    return Content(HttpStatusCode.OK, lessProds);
                else
                    return Content(HttpStatusCode.NoContent, "Products with less than 10 Quantity not Available");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        //[HttpGet]
        //[Route("allproducts")]
        //public IHttpActionResult AllProducts()
        //{
        //    try
        //    {
        //        var prod = productOp.GetAllProducts();
        //        if (prod != null)
        //            return Content(HttpStatusCode.OK, prod);
        //        else
        //            return Content(HttpStatusCode.OK, "No Data Found");
        //    }
        //    catch (Exception exception)
        //    {
        //        return Content(HttpStatusCode.BadRequest, exception);
        //    }
        //}
        
        //[HttpGet]
        //[Route("allcustomers")]
        //public IHttpActionResult AllCustomers()
        //{
        //    try
        //    {
        //        var custCount = customerOp.GetAllCustomers();
        //        if (custCount != null)
        //            return Content(HttpStatusCode.OK, custCount);
        //        else
        //            return Content(HttpStatusCode.OK, "No Data Found");
        //    }
        //    catch (Exception exception)
        //    {
        //        return Content(HttpStatusCode.BadRequest, exception);
        //    }
        //}


    }
}
