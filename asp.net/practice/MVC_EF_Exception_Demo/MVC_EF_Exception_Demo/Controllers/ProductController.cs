using MVC_EF_Exception_Demo.Models;
using MVC_EF_Exception_Demo.Operations;
using MVC_EF_Exception_Demo.ProductDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_EF_Exception_Demo.Controllers
{
    [HandleError]
    public class ProductController : Controller
    {
        ProductRepo repo = null;
        public ProductController()
        {
            repo = new ProductRepo();
        }
        public ActionResult Index()
        {
            var res = repo.GetAllProducts();
            return View(res);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var id = repo.AddProduct(product);
            ViewBag.IsSucess = "Product with Id-"+ id + " Added Succesfully";
            return View();
        }

        public ActionResult Details(int id)
        {
            var res = repo.GetAllProducts().FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                return View(res);
            }
            return RedirectToAction("Error");
           
        }
        public ActionResult Edit(int id)
        {
            var res = repo.GetAllProducts().FirstOrDefault(x => x.Id == id);
            if(res != null)
            {
                return View(res);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if(repo.UpdateProduct(id,product))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
            
        }

        public ActionResult Delete(int id)
        {
            if (repo.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}