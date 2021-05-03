using ApiDemo.Models;
using ApiDemo.Models.DbModel;
using ApiDemo.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class ValuesController : ApiController
    {
        EmpOerations operations = null;

        public ValuesController()
        {
            operations = new EmpOerations();
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            try
            {
                var empList = operations.GetEmployees();
                if (empList != null)
                    return Request.CreateResponse(HttpStatusCode.OK, empList);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "List not Found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var emp = operations.GetEmployee(id);
                if (emp != null)
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Id not Found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }

        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                int empId = operations.AddEmployee(employee);
                if (empId > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK,"Employee Created Successfully");
                    message.Headers.Location = new Uri(Request.RequestUri + empId.ToString());
                    return message;
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went Wrong to Add");
            } 
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {
                bool isUpdate = operations.UpdateEmployee(id,employee);
                if (isUpdate)
                    return Request.CreateResponse(HttpStatusCode.OK, "Record with id-" + id + " Updated Successfully");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record with id-" + id + " not found");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                bool isDel = operations.DeleteEmployee(id);
                if (isDel)
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee with id-" + id + " deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee id-" + id + " Invalid");
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }
            
        }
    }
}
