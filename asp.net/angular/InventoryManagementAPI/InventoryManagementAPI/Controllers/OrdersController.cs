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
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        OrderOp orderOp = null;
        OrdersController()
        {
            orderOp = new OrderOp();
        }

        // GET api/orders/gettotalorders
        [HttpGet]
        [Route("gettotalorders")]
        public IHttpActionResult GetTotalOrders(string fromDate="", string toDate="")
        {
            try
            {
                int orderCount = orderOp.GetOrderCounts(fromDate,toDate);
                if (orderCount > 0)
                    return Content(HttpStatusCode.OK, orderCount);
                else
                    return Content(HttpStatusCode.OK, "Order Count Not Available");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/orders
        [Route("getorders")]
        public IHttpActionResult GetOrders(int? recordSkip = 0, int? recordTake = 5, string ord = "desc", string fromDate="", string toDate="")
        {
            try
            {
                if (ord == "asc")
                {
                    var orderList = orderOp.GetOrdersAsc((int)recordSkip, (int)recordTake, fromDate, toDate);
                    if (orderList != null)
                        return Content(HttpStatusCode.OK, orderList);
                    else
                        return Content(HttpStatusCode.OK, "Orders Data Not Found");
                }
                else
                {
                    var orderList = orderOp.GetOrders((int)recordSkip, (int)recordTake, fromDate, toDate);
                    if (orderList != null)
                        return Content(HttpStatusCode.OK, orderList);
                    else
                        return Content(HttpStatusCode.OK, "Orders Data Not Found");
                }
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        //public IHttpActionResult Get(string fromDate, string toDate)
        //{
        //    try
        //    {
        //        var orderList = orderOp.GetFilteredOrders(Convert.ToDateTime(fromDate),Convert.ToDateTime(toDate));
        //            if (orderList != null)
        //                return Content(HttpStatusCode.OK, orderList);
        //            else
        //                return Content(HttpStatusCode.OK, "Products Data Not Found");
                
        //    }
        //    catch (Exception exception)
        //    {
        //        return Content(HttpStatusCode.BadRequest, exception);
        //    }
        //}

    }
}
