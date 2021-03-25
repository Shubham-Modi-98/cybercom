using StoringImage_CRUD_Udemy.Models;
using StoringImage_CRUD_Udemy.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoringImage_CRUD_Udemy.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var context = new DbDemoEFEntities())
            {
                List<tblProd_Img> result = context.tblProd_Img.ToList();
                return View(result);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblProd_Img tblProd, HttpPostedFileBase Image)
        {
            string extension = Path.GetExtension(Image.FileName);
            if (extension == ".jpeg" || extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".jfif")
            {
                //Failed Code
                //var imgBytes = new Byte[Image.ContentLength];
                //var base64string = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                //tblProd.Image = base64string;

                //Running Successfully
                //var file = Request.Files[0];
                //var imgBytes = new Byte[file.ContentLength];
                //file.InputStream.Read(imgBytes, 0, file.ContentLength);
                //var base64string = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                //tblProd.Image = base64string;

                //Running Successfully
                var imgBytes = new Byte[Image.ContentLength];
                Image.InputStream.Read(imgBytes, 0, Image.ContentLength);
                var base64string = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                tblProd.Image = base64string;
            }
            else
                tblProd.Image = "NULL";
            using (var context = new DbDemoEFEntities())
            {
                context.tblProd_Img.Add(tblProd);
                context.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Create");
        }

        public ActionResult Details(int? id = 0)
        {
            tblProd_Img tblProd = getRecord(id);
            if (tblProd != null)
            {
                return View(tblProd);
            }
            else
            {
                ViewBag.Error = "No record found";
                return View("Details");
            }
        }

        public ActionResult Delete(int? id = 0)
        {
            tblProd_Img tblProd = getRecord(id);
            if (tblProd != null)
            {
                return View(tblProd);
            }
            else
            {
                ViewBag.Error = "No record found";
                return View("Delete");
            }
        }

        [HttpPost]
        public ActionResult Delete(tblProd_Img tblProd_, int? id = 0)
        {
            tblProd_Img tblProd = getRecord(id);
            if (tblProd != null)
            {
                using (var context = new DbDemoEFEntities())
                {
                    context.tblProd_Img.Remove(tblProd);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "No record found";
                return View("Delete");
            }
        }

        private tblProd_Img getRecord(int? id = 0)
        {
            using (var context = new DbDemoEFEntities())
            {
                tblProd_Img tblProd = context.tblProd_Img.Where(x => x.Id == id).FirstOrDefault();
                if (tblProd != null)
                {
                    return tblProd;
                }
                else
                {
                    ViewBag.Error = "No record found";
                    return null;
                }
            }
        }
    }
}