using StronglyTypedHelperMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StronglyTypedHelperMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Student student = new Student()
            {
                Id = 035,
                Name = "Shubham",
                City = "Ahmedabad",
                isTeacher = false,
            };
            return View(student);
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (student.Name != null && student.City != null)
            {
                return View(student);
            }
            else
            {
                return View();
            }
        }
    }
}