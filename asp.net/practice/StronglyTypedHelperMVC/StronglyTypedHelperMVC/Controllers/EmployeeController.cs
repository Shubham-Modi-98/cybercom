using StronglyTypedHelperMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StronglyTypedHelperMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Shubham",
                Email = "shubh@gmail.com",
                IsOnline = true,
                DateOfJoining = DateTime.Now
            };
            return View(employee);
        }
    }
}