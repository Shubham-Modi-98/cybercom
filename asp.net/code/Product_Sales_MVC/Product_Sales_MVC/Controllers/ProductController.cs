using ProductSales.Db.DbOperations;
using ProductSales.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Product_Sales_MVC.Controllers
{
    [HandleError]
    public class ProductController : Controller
    {
        ProductOp operations = null;
        public ProductController()
        {
            operations = new ProductOp();
        }
        public ActionResult Index(int? pageNo)
        {
            var resultSet = operations.GetProducts().ToPagedList(pageNo ?? 1,3);
            if (resultSet != null)
            {
                return View(resultSet);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(Image.FileName);
                if (extension == ".jpeg" || extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".jfif")
                {
                    //Running Successfully
                    var imgBytes = new Byte[Image.ContentLength];
                    Image.InputStream.Read(imgBytes, 0, Image.ContentLength);
                    var base64string = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    product.Image = base64string;
                    int id = operations.AddProduct(product);
                    if (id > 0)
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Product with Id - " + id + " Added Successfully...";
                        //ViewBag.Message.ForeColor = Color.Green;
                    }
                    else
                    {
                        ViewBag.Message = "Failed to Add Product, Something gone Wrong!!";
                        //ViewBag.Message.ForeColor = Color.Red;
                    }
                }
            }
            return View();

        }

        public ActionResult Edit(int id)
        {
            var resultSet = operations.GetProducts().Where(x => x.Id == id).FirstOrDefault();
            if (resultSet != null)
            {
                return View(resultSet);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    string extension = Path.GetExtension(Image.FileName);
                    if (extension == ".jpeg" || extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".jfif")
                    {
                        //Running Successfully
                        var imgBytes = new Byte[Image.ContentLength];
                        Image.InputStream.Read(imgBytes, 0, Image.ContentLength);
                        var base64string = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                        product.Image = base64string;
                    }
                }
                if (operations.UpdateProduct(product))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Product Updated Successfully";
                }
                else
                {
                    ViewBag.Message = "Error to Update, Try Again!!";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (operations.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}