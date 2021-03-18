using PassDatafromViewtoController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassDatafromViewtoController.Controllers
{
    [RoutePrefix("Student")]
    public class StudentController : Controller
    {
        static List<Student> studentsList = new List<Student>();
        
        // GET: Student
        [Route("")]
        public ActionResult Index()
        {
            Student student1 = new Student()
            {
                Id = 1,
                FirstName = "Teenu",
                LastName = "Modi",
                Email = "modi@gmail.com",
                Mobile = "9081307324"
            };
            Student student2 = new Student()
            {
                Id = 35,
                FirstName = "Shubham",
                LastName = "Modi",
                Email = "shubh@gmail.com",
                Mobile = "9081307324"
            };
            studentsList.Add(student1);
            studentsList.Add(student2);
            return View();
        }

        #region Pass Data using Parameters
        //[HttpPost]
        //public string DataUsingParameters(int id, string firstname, string lastname, 
        //    string email, string mobile)
        //{
        //    return "Form Data using Parameters :-<br/>" + id.ToString() + "<br/>" +
        //        firstname + "<br/>" + lastname + "<br/>" + email + "<br/>" + mobile;
        //}
        #endregion

        #region Pass Data Using Request
        //[HttpPost]
        //public string DataUsingRequest()
        //{
        //    string id = Request["Id"].ToString();
        //    string fname = Request["FirstName"];
        //    string lname = Request["LastName"];
        //    string email = Request["Email"];
        //    string mob = Request["Mobile"];
        //    return "Form Data using Request :-<br/>" + id + "<br/>" +
        //        fname + "<br/>" + lname + "<br/>" + email + "<br/>" + mob;
        //}
        #endregion

        #region Pass Data Using Form Collection
        //[HttpPost]
        //public string DataUsingFormCollection(FormCollection form)
        //{
        //    string id = form["Id"].ToString();
        //    string fname = form["FirstName"];
        //    string lname = form["LastName"];
        //    string email = form["Email"];
        //    string mob = form["Mobile"];
        //    return "Form Data using Form Collection :-<br/>" + id + "<br/>" +
        //        fname + "<br/>" + lname + "<br/>" + email + "<br/>" + mob;
        //}
        #endregion

        #region Pass Data Using Strongly Binding
        //[HttpPost]
        //public string DataUsingStronglyBinding(Student student)
        //{
        //    return "Form Data using Form Collection :-<br/>" + student.Id + "<br/>" +
        //        student.FirstName + "<br/>" + student.LastName + "<br/>" + 
        //        student.Email + "<br/>" + student.Mobile;
        //}
        #endregion

        //Display all inserted form Data from Index using Strongly Binding
        [HttpPost]
        public ActionResult DisplayData(Student student)
        {
            if (ModelState.IsValid)
            {
                int listCount = studentsList.Count;
                if (listCount > 0)
                {
                    foreach (var item in studentsList)
                    {
                        if (student.Id == item.Id)
                        {
                            return View("Index");
                        }
                    }
                }
                studentsList.Insert(listCount, student);
                return View(studentsList);
            }
            else
            {
                return View("Index");
            }
        }

        [Route("Display")]
        public ActionResult Display()
        {
            return View(studentsList);
        }

        [Route("Edit/{id}")]
        public ActionResult EditStudent(int id)
        {
            Student studentData = studentsList.Where(x => x.Id == id).FirstOrDefault();
            return View(studentData);
        }

        [Route("Update")]
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            //Student studentData = studentsList.Where(x => x.Id == student.Id).FirstOrDefault();
            int index = studentsList.FindIndex(x => x.Id == student.Id);
            studentsList.RemoveAt(index);
            studentsList.Insert(index, student);
            return View("Display",studentsList);
        }

        [Route("Delete/{id}")]
        public ActionResult DeleteStudent(int id)
        {
            int index = studentsList.FindIndex(x => x.Id == id);
            studentsList.RemoveAt(index);
            return View("Display",studentsList);
        }

        [Route("Get/{id}")]
        public ActionResult GetStudent(int id)
        {
            Student student = studentsList.Where(x => x.Id == id).FirstOrDefault();
            return View(student);
        }
    }
}