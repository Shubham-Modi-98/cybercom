using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Product_Sales_WebApp
{
    /// <summary>
    /// Summary description for ProductDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProductDataService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetDataForDataTable()
        {
            HttpContext context = HttpContext.Current;
            context.Response.ContentType = "text/plain";
            //List of Column shown in the Table (user for finding the name of column on Sorting)  
            List<string> columns = new List<string>();
            columns.Add("ProdId");
            columns.Add("ProdName");
            columns.Add("ProdImage");
            columns.Add("ProdQty");
            columns.Add("ProdPrice");
            //This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables  
            Int32 ajaxDraw = Convert.ToInt32(context.Request.Form["draw"]);
            //OffsetValue  
            Int32 OffsetValue = Convert.ToInt32(context.Request.Form["start"]);
            //No of Records shown per page  
            Int32 PagingSize = Convert.ToInt32(context.Request.Form["length"]);
            //Getting value from the seatch TextBox  
            string searchby = context.Request.Form["search[value]"];
            //Index of the Column on which Sorting needs to perform  
            string sortColumn = context.Request.Form["order[0][column]"];
            //Finding the column name from the list based upon the column Index  
            sortColumn = columns[Convert.ToInt32(sortColumn)];
            //Sorting Direction  
            string sortDirection = context.Request.Form["order[0][dir]"];
            //Get the Data from the Database  
            DBLayer objDBLayer = new DBLayer();
            DataTable dt = objDBLayer.GetData(sortColumn, sortDirection, OffsetValue, PagingSize, searchby);
            Int32 recordTotal = 0;
            List<Product> lstProduct = new List<Product>();
            //Binding the Data from datatable to the List  
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product prod = new Product();
                    //prod.Id = Convert.IsDBNull(dt.Rows[i]["Id"]) ? default(int) : Convert.ToInt32(dt.Rows[i]["Id"]);
                    prod.ProdId = Convert.IsDBNull(dt.Rows[i]["ProdId"]) ? default(string) : Convert.ToString(dt.Rows[i]["ProdId"]);
                    prod.ProdName = Convert.IsDBNull(dt.Rows[i]["ProdName"]) ? default(string) : Convert.ToString(dt.Rows[i]["ProdName"]);
                    prod.ProdImage = Convert.IsDBNull(dt.Rows[i]["ProdImage"]) ? default(string) : Convert.ToBase64String((byte[])dt.Rows[i]["ProdImage"]);
                    prod.ProdQty = Convert.IsDBNull(dt.Rows[i]["ProdQty"]) ? default(int) : Convert.ToInt32(dt.Rows[i]["ProdQty"]);
                    prod.ProdPrice = Convert.IsDBNull(dt.Rows[i]["ProdPrice"]) ? default(decimal) : Convert.ToDecimal(dt.Rows[i]["ProdPrice"]);
                    lstProduct.Add(prod);
                }
                recordTotal = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["FilterTotalCount"]) : 0;
            }
            Int32 recordFiltered = recordTotal;
            DataTableResponse objDataTableResponse = new DataTableResponse()
            {
                draw = ajaxDraw,
                recordsFiltered = recordTotal,
                recordsTotal = recordTotal,
                data = lstProduct
            };
            //writing the response
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(objDataTableResponse));  
            //JavaScriptSerializer javaScript = new JavaScriptSerializer();
            //Context.Response.Write(javaScript.Serialize(objDataTableResponse));
        }
    }
}
