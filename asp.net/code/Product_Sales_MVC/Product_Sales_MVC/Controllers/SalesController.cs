using ProductSales.Db.DbOperations;
using ProductSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Sales_MVC.Controllers
{
    [HandleError]
    public class SalesController : Controller
    {
        ProductOp operations = null;
        SalesOp salesOp = null;
        public SalesController()
        {
            operations = new ProductOp();
            salesOp = new SalesOp();
        }
        public ActionResult Index()
        {
            var resultList = operations.GetProducts();
            if (resultList != null)
                ViewBag.List = resultList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(double txtTotalPrice = 0, int drpProdId = 0, int txtQty = 0, double txtPrice = 0)
        {
            var resultList = operations.GetProducts();
            if (resultList != null)
                ViewBag.List = resultList;
            if (drpProdId != 0)
            {
                var resultData = operations.GetProducts().FirstOrDefault(x => x.Id == drpProdId);
                if (resultData == null)
                    ViewBag.IsWarning = "No data found";
                if (txtTotalPrice != 0 && txtQty != 0 && drpProdId != 0)
                {
                    var salesId = salesOp.AddSales(txtTotalPrice, drpProdId, txtQty, txtPrice);
                    if (salesId > 0)
                    {
                        var salesRes = salesOp.GetSalesById(salesId);

                        salesRes.Product.Qty = salesRes.Product.Qty - txtQty;
                        if(operations.UpdateSalesData(salesRes.Product))
                        {
                            return View("FinalBill", salesRes);
                        }
                        return View("Error");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                return View(resultData);
            }
            else
                ViewBag.IsWarning = "Please Select Product First";
            return View();
        }

        //[HttpPost]
        //public ActionResult FinalBill(string ProdId, string ProdName, double txtPrice, double txtTotalPrice = 0, int drpProdId = 0, int txtQty = 0)
        //{
        //    return View();
        //}

        //public JsonResult GetTotalPrice(int Qty, int Price)
        //{
        //    double total = Qty * Price;
        //    return Json(total, JsonRequestBehavior.AllowGet);
        //}
    }
}