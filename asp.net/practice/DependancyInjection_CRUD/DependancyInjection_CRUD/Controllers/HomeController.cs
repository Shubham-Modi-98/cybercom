using BussineLogic;
using BussineLogic.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependancyInjection_CRUD.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IProduct _product = null; 
        public HomeController(IProduct product)
        {
            _product = product;
        }
        [Route("")]
        public ActionResult Index()
        {
            var result = _product.GetAllProducts();
            if(result != null)
            {
                return View(result);
            }
            return View("Error");
        }
        [Route("Add")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            int id = _product.AddProduct(product);
            if(id > 0)
            {
                ViewBag.IsSuccess = "Product with Id- " + id +" Added Successfully";
                return View();
            }
            return View("Error");
        }
        [Route("Get/{id}")]
        public ActionResult Details(int id)
        {
            var result = _product.GetAllProducts().FirstOrDefault(x => x.Id == id);
            //var res = _product.GetProduct(id);
            if(result != null)
            {
                return View(result);
            }
            return View("Error");

        }
        [Route("Change/{id}")]
        public ActionResult Edit(int id)
        {
            var result = _product.GetAllProducts().FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                return View(result);
            }
            return View("Error");

        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if (_product.UpdateProduct(id,product))
            {
                ViewBag.IsSuccess = "Product with Id-" + id +" Updated Successfully";
                return View();
            }
            return View("Error");

        }
        [Route("Remove/{id}")]
        public ActionResult Delete(int id, Product product)
        {
            if (_product.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            return View("Error");

        }
    }
}