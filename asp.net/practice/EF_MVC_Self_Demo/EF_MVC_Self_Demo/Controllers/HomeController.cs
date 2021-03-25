﻿using System;
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

        [ValidateInput(false)]
        public ActionResult Index(string Sort="EmpId", string IconClass="fa-sort-asc")
        {
            var result = repo.GetAllEmployees();
            ViewBag.Sort = Sort;
            ViewBag.IconClass = IconClass;
            if(ViewBag.Sort == "EmpId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    result = result.OrderBy(x => x.EmpId).ToList();
                else
                    result = result.OrderByDescending(x => x.EmpId).ToList();
            }
            else if (ViewBag.Sort == "Name")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    result = result.OrderBy(x => x.Name).ToList();
                else
                    result = result.OrderByDescending(x => x.Name).ToList();
            }
            else if (ViewBag.Sort == "Address")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    result = result.OrderBy(x => x.Address).ToList();
                else
                    result = result.OrderByDescending(x => x.Address).ToList();
            }
            else if (ViewBag.Sort == "City")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    result = result.OrderBy(x => x.City).ToList();
                else
                    result = result.OrderByDescending(x => x.City).ToList();
            }
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