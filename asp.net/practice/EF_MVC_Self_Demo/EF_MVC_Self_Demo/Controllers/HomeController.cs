using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Db.DbOperations;
using MyModel.Model;

namespace EF_MVC_Self_Demo.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepo repo = null;
        public HomeController()
        {
            repo = new EmployeeRepo();
        }
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
                    ViewBag.IsSuccess = "Employee with Id- " + id + " Added Successfully";
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            var result = repo.GetAllEmployees();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            try
            {
                //throw new Exception(""); 
                var data = repo.GetEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.IsError = ex.Message;
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var data = repo.GetEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.IsError = ex.Message;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel employee)
        {
            try
            {
                var data = repo.UpdateEmployee(id, employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.IsError = ex.Message;
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}