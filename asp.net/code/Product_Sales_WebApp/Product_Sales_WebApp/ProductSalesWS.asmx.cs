using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Product_Sales_WebApp
{
    /// <summary>
    /// Summary description for ProductSalesWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProductSalesWS : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetSalesData()
        {
            string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
            SqlCommand command = null;
            SqlConnection connection = null;
            List<Sales> lstProduct = new List<Sales>();
            using (connection = new SqlConnection(conString))
            {
                //command = new SqlCommand("spAllDataDT", connection);
                command = new SqlCommand("spGetSalesGroupByDate", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sales tblData = new Sales()
                    {
                        //SalesId = Convert.ToInt32(reader["SalesId"]),
                        Qty = Convert.ToInt32(reader["Qty"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"]),
                        SalesDate = ((DateTime)reader["SalesDate"]).ToShortDateString(),
                        ProdName = Convert.ToString(reader["ProdName"]),
                        Image = Convert.ToBase64String((byte[])reader["ProdImage"])
                    };
                    lstProduct.Add(tblData);
                }
                connection.Close();
            }
            JavaScriptSerializer javaScript = new JavaScriptSerializer();
            Context.Response.Write(javaScript.Serialize(lstProduct));
        }

        [WebMethod]
        public void fetchAllProd()
        {
            string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
            SqlCommand command = null;
            SqlConnection connection = null;
            List<string> lstName = new List<string>();
            List<Product> lstProduct = new List<Product>();
            using (connection = new SqlConnection(conString))
            {
                command = new SqlCommand("spGetAllProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Product product = new Product();
                    //product.ProdId = Convert.ToString(reader["ProdId"]);
                    //product.ProdName = Convert.ToString(reader["ProdName"]);
                    //product.ProdPrice = Convert.ToDecimal(reader["ProdPrice"]);
                    //product.ProdImage = (byte[])reader["ProdImage"];
                    
                    product.ProdId = Convert.ToString(reader["ProdId"]);
                    product.ProdName = Convert.ToString(reader["ProdName"]);
                    product.ProdImage = Convert.ToBase64String((byte[])reader["ProdImage"]);
                    product.ProdPrice = Convert.ToDecimal(reader["ProdPrice"]);
                    product.ProdQty = Convert.ToInt32(reader["ProdQty"]);
                    lstName.Add(product.ProdName);
                    lstProduct.Add(product);
                }
                connection.Close();
            }
            JavaScriptSerializer javaScript = new JavaScriptSerializer();
            Context.Response.Write(javaScript.Serialize(lstProduct));

            //using (connection = new SqlConnection(conString))
            //{
            //    foreach (var item in lstName)
            //    {
            //        using (command = new SqlCommand("spGetSalesDataByName", connection))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;
            //            command.Parameters.AddWithValue("@name", item);
            //            connection.Open();
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    //lblSalesData.Text += "x&nbsp;" + Convert.ToString(reader["Qty"]) + "&nbsp; = &nbsp;" + Convert.ToString(reader["TotalPrice"]) +
            //                    //    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(reader["SalesDate"]) + "<br/>";

            //                    DateTime sDate = DateTime.Parse(reader["SalesDate"].ToString());

            //                    lblSalesData.Text += sDate.ToShortDateString() +
            //                        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(reader["TotalPrice"]) + "<br/>";
            //                }
            //            }
            //            connection.Close();
            //        }
            //    }
            //}
        }

        //[WebMethod]
        //public string fetchSales(string prodName)
        //{
        //    string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        //    SqlCommand command = null;
        //    SqlConnection connection = null;
        //    List<Sales> lstSales = new List<Sales>();
        //    using (connection = new SqlConnection(conString))
        //    {
        //        command = new SqlCommand("spGetSalesDataByName", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@name", prodName);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Sales sales = new Sales()
        //            {
        //                TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString()),
        //                SalesDate = ((DateTime)reader["SalesDate"]).ToShortDateString()
        //            };
        //            lstSales.Add(sales);
        //        }
        //        connection.Close();
        //    }
        //    JavaScriptSerializer javaScript = new JavaScriptSerializer();
        //    //Context.Response.Write(javaScript.Serialize(lstSales));
        //    return javaScript.Serialize(lstSales);
        //}
    }
}
