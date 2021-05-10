using InventoryDbLayer.Db;
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
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        CustomerOp customerOp = null;
        public CustomersController()
        {
            customerOp = new CustomerOp();
        }

        // GET api/customers/totalcustomers
        [HttpGet]
        [Route("totalcustomers")]
        public IHttpActionResult Totalcustomers()
        {
            try
            {
                int custCount = customerOp.GetCustomerCounts();
                if (custCount > 0)
                    return Content(HttpStatusCode.OK, custCount);
                else
                    return Content(HttpStatusCode.OK, "Customers Data Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/customers/allcustomercounts
        [HttpGet]
        [Route("allcustomers")]
        public IHttpActionResult AllCustomers()
        {
            try
            {
                var custCount = customerOp.GetAllCustomers();
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

        // GET api/customers/getcustomers
        [Route("getcustomers")]
        [HttpGet]
        public IHttpActionResult GetCustomersDetails(int? recordSkip = 0, int? recordTake = 5)
        {
            try
            {
                var custList = customerOp.GetCustomers((int)recordSkip, (int)(recordTake ==null?5:recordTake));
                int custCount = customerOp.GetCustomerCounts();
                if (custList != null)
                    return Content(HttpStatusCode.OK,custList);
                else
                    return Content(HttpStatusCode.OK, "Customers Data Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // GET api/customers/getcustomerbyid/1
        [Route("getcustomerbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetCustomerbyId(int id)
        {
            try
            {
                var cust = customerOp.GetCustomer(id);
                if (cust != null)
                    return Ok(cust);
                else
                    return Content(HttpStatusCode.OK, "Customers Data with id-" + id + "Not Found");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // POST api/customers/addcustomer
        [Route("addcustomer")]
        [HttpPost]
        public IHttpActionResult AddCustomer([FromBody] CustomerIms customer)
        {
            try
            {
                int custId = customerOp.AddCustomer(customer);
                if (custId > 0)
                    return Ok("Customer with Id-" + custId + " added Successfully");
                else
                    return Content(HttpStatusCode.BadGateway, "Something went Wrong!,Try Again after sometimes");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // PUT api/customers/udatecustomer/1
        [Route("updatecustomer/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, [FromBody] CustomerIms customer)
        {
            try
            {
                bool custId = customerOp.UpdateCustomer(id, customer);
                if (custId)
                    return Ok("Customer with Id-" + id + " updated Successfully");
                else
                    return Content(HttpStatusCode.BadGateway, "Something went Wrong!,Try Again after sometimes");
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        // DELETE api/customers/deletecustomer/1
        [Route("deletecustomer/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                bool custId = customerOp.DeleteCustomer(id);
                if (custId)
                    return Ok("Customer with Id-" + id + " deleted Successfully");
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
