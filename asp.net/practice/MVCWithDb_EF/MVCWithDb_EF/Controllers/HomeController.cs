using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpApp.Db.DbOperations;

namespace MVCWithDb_EF.Controllers
{
    public class HomeController : Controller
    {
        EmpRepo repo = null;
        public HomeController()
        {
            repo = new EmpRepo();
        }
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            if(ModelState.IsValid)
            {
                int id = repo.AddEmployee(employee);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Employee Id - " + id + " Added Successfully";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel employee)
        {
            if(ModelState.IsValid)
            {
                int id = repo.AddEmployee(employee);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Employee Id - " + id + " Added Successfully";
                }
                else
                {
                    ViewBag.IsSuccess = "Error id Added!";
                }
            }
            return View("Create",JsonRequestBehavior.AllowGet);
        }
        public ActionResult Display()
        {
            var resultData = repo.GetAllEmployees();
            return View(resultData);
        }

        public ActionResult Details(int id)
        {
            //var result = repo.GetEmployee(id); 
            var result = repo.GetAllEmployees().FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = repo.GetEmployee(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(int id,EmployeeModel employee)
        {
            if(repo.UpdateEmployee(id,employee))
            {
                return RedirectToAction("Display");
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteEmployee(id);
            return RedirectToAction("Display");
        }
    }
}