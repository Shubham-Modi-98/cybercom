using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PracticeDemoMVC.Models;


namespace PracticeDemoMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var studData = GetStudent();
            return View(studData);
        }

        public string Name(string name)
        {
            return "Welcome, " + name;
        }

        public string FullName(string fname = null, string lname = null)
        {
            #region Without Buider
            if ((fname != "" || fname != null) && (lname == null || lname == ""))
            {
                return "First Name:- " + fname;
            }
            else if ((fname == "" || fname == null) && (lname != null || lname != ""))
            {
                return "Last Name:- " + lname;
            }
            else
            {
                return "First Name:- " + fname + " and Last Name:- " + lname;
            }
            #endregion

            #region Buider
            //StringBuilder sBuilder = new StringBuilder();
            //if(fname != null && fname != "")
            //{
            //    sBuilder.Append("First Name:- " + fname + "  ");
            //}
            //if(lname != "" && lname != null)
            //{
            //    sBuilder.Append("Last Name:- " + lname);
            //}
            //return Convert.ToString(sBuilder);
            #endregion
        }

        private Student GetStudent()
        {
            Student s1 =  new Student
            {
                Id = 035,
                Name = "Shubham Modi",
                Course = "MCA",
            };

            Student s2 =  new Student
            {
                Id = 005,
                Name = "Teenu",
                Course = "MSC.(IT)"
            };
            return s2;
        }
    }
}