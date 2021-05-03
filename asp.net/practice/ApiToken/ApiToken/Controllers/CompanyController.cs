using DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiToken.Controllers
{
    
    public class CompanyController : ApiController
    {
        // GET api/company
        public IHttpActionResult Get()
        {
            try
            {
                using (var context = new ApiDbEntities())
                {
                    var companyList = context.CompanyData.ToList();
                    if (companyList != null)
                    {
                        //var msg = Request.CreateResponse(HttpStatusCode.OK, companyList);
                        return Ok(companyList);
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "No Data Found");
                    }
                }
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.NotFound, exception);
            }
        }

        // GET api/company/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var context = new ApiDbEntities())
                {
                    var company = context.CompanyData.FirstOrDefault(x => x.Id == id);
                    if (company != null)
                    {
                        return Ok(company);
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, "No Record found with Id-" + id);
                    }
                }
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.NotFound, exception);
            }
        }

        // POST api/company
        [Authorize]
        public IHttpActionResult Post([FromBody]CompanyData company)
        {
            try
            {
                using (var context = new ApiDbEntities())
                {
                    if(company != null)
                    {
                        //CompanyData companyData = new CompanyData()
                        //{
                        //    CompanyName = company.CompanyName,
                        //    City = company.City,
                        //    NoOfEmployees = company.NoOfEmployees,
                        //    IsMNC = company.IsMNC,
                        //};
                        context.CompanyData.Add(company);
                        context.SaveChanges();
                        return Content(HttpStatusCode.OK,"Company Added with uid-"+company.Id);
                    }
                    return Content(HttpStatusCode.NotAcceptable,"Something went wrong!,Try Again");
                }
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.NotFound, exception);
            }
        }

        // PUT api/company/5
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/company/5
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
