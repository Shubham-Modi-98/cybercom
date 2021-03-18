using RoutingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingMVC.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {   
        [Route("")]
        public ActionResult Index()
        {
            var student = Students();
            return View(student);
        }

        [Route("{id}")]
        public ActionResult GetStudent(int id)
        {
            var student = Students().FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        [Route("address/{id}")]
        public ActionResult GetAddress(int id)
        {
            var student = Students().Where(x => x.Id == id).Select(x => x.Address).FirstOrDefault();
            return View(student);
        }

        [Route("address")]
        public ActionResult GetAllAddress()
        {
            var address = Students().Select(x => x.Address).ToList();
            return View(address);
        }
        private List<Student> Students()
        {
            return new List<Student>()
            {
                new Student
                {
                    Id = 1,
                    Name = "Abc",
                    Email = "abc@gmail.com",
                    Address = new Address()
                    {
                        HomeNumber = "1",
                        AddressLine = "abflats",
                        City = "Bharuch",
                        State = "Gujarat"
                    }
                },
                new Student
                {
                    Id = 2,
                    Name = "Xyz",
                    Email = "xyz@gmail.com",
                    Address = new Address()
                    {
                        HomeNumber = "21",
                        AddressLine = "xzflats",
                        City = "Vadodara",
                        State = "Gujarat"
                    }
                },
                new Student
                {
                    Id = 3,
                    Name = "Pqr",
                    Email = "pqr@gmail.com",
                    Address = new Address()
                    {
                        HomeNumber = "101",
                        AddressLine = "prflats",
                        City = "Mumbai",
                        State = "Maharastra"
                    }
                },
                new Student
                {
                    Id = 4,
                    Name = "Def",
                    Email = "def@gmail.com",
                    Address = new Address()
                    {
                        HomeNumber = "401",
                        AddressLine = "panjim",
                        City = "Panjim",
                        State = "Goa"
                    }
                }
            };
        }
    }
}