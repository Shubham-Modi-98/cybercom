using ProductSales.Db.DbOperations;
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
        ProductOp productOp = null;
        SalesOp salesOp = null;
        public SalesController()
        {
            productOp = new ProductOp();
            salesOp = new SalesOp();
        }
        public ActionResult Index()
        {
            var resultList = productOp.GetProducts();
            if (resultList != null)
                ViewBag.List = resultList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(double txtTotalPrice = 0, int drpProdId = 0, int txtQty = 0, double txtPrice = 0)
        {
            var resultList = productOp.GetProducts();
            if (resultList != null)
                ViewBag.List = resultList;
            if (drpProdId != 0)
            {
                var resultData = productOp.GetProducts().FirstOrDefault(x => x.Id == drpProdId);
                if (resultData == null)
                    ViewBag.IsWarning = "No data found";
                if (txtTotalPrice != 0 && txtQty != 0 && drpProdId != 0)
                {
                    var salesId = salesOp.AddSales(txtTotalPrice, drpProdId, txtQty, txtPrice);
                    if (salesId > 0)
                    {
                        var salesRes = salesOp.GetSalesById(salesId);

                        salesRes.Product.Qty = salesRes.Product.Qty - txtQty;
                        if (productOp.UpdateSalesData(salesRes.Product))
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

        public ActionResult Display()
        {
            #region Connect to Db here and Call
            //using (var contex = new ProdSalesEntities())
            //{
            //    var result = contex.Database.SqlQuery<spGetProduct_Result>("spGetProduct").ToList();
            //    if (result != null)
            //    {
            //        return View(result);
            //    }
            //    return View("Error");
            //}
            #endregion

            //Create method in Operation Class and Call
            var result = salesOp.GetProducts();
            if (result != null)
            {
                return View(result);
            }
            return View("Error");

        }

        [ChildActionOnly]
        public PartialViewResult DisplaySales(string prodName)
        {
            #region Connect to Db and Create List data
            //using (var contex = new ProdSalesEntities())
            //{
            //    //var result = contex.Database.SqlQuery<spGetProduct_Result>("spGetProduct").ToList();
            //    //List<spGetSalesDataByName_Result> resultSet = null;
            //    SqlParameter[] param = new SqlParameter[] {
            //        new SqlParameter("@name",prodName??(object)DBNull.Value)
            //    };
            //    var resultSet = contex.Database.SqlQuery<spGetSalesDataByName_Result>("spGetSalesDataByName @name", param).ToList();
            //    return PartialView("DisplaySales", resultSet);
            //}
            #endregion

            //Create method in Operation Class and Call
            var resultSet = salesOp.GetSalesDataByName(prodName);
            return PartialView("DisplaySales", resultSet);  
        }
    }
}