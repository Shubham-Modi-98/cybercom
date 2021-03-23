﻿using BusinesLayer.Operations;
using DropDownDemo_MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownDemo_MVC_EF.Controllers
{
    [HandleError]
    public class StudentController : Controller
    {
        StudClgOp repo = null;
        public StudentController()
        {
            repo = new StudClgOp();
        }
        // GET: Student
        public ActionResult Index()
        {
            var resultList = repo.GetAllCollegeData();
            if (resultList != null)
                ViewBag.List = resultList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {

            var result = repo.AddStudent(student);
            if (result > 0)
            {
                ViewBag.IsSuccess = "Record Added Successfully";
                var resultList = repo.GetAllCollegeData();
                if (resultList != null)
                    ViewBag.List = resultList;
                return View();
            }
            return RedirectToAction("Error");
        }

        public ActionResult Display()
        {
            var resultData = repo.GetAllStudents();
            return View(resultData);
        }

        public ActionResult Details(int id)
        {
            var result = repo.GetAllStudents().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                return View(result);
            }
            return View("Error");
        }

        public ActionResult Edit(int id)
        {
            var resultList = repo.GetAllCollegeData();
            if (resultList != null)
                ViewBag.List = resultList;
            var result = repo.GetAllStudents().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                ViewBag.SelectedItem = result.College.Id;
                return View(result);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                if (repo.UpdateStudent(id, student))
                {
                    return RedirectToAction("Display");
                }
            }
            return View("Error");
        }

        public ActionResult Delete(int id)
        {
            if (repo.DeleteStudent(id))
            {
                return RedirectToAction("Display");
            }
            return View("Error");
        }
    }
}