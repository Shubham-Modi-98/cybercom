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
    /// Summary description for SalesData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SalesData : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetSalesData()
        {
            string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
            SqlCommand command = null;
            SqlConnection connection = null;
            List<string> lstName = new List<string>();
            List<Product> lstProduct = new List<Product>();
            using (connection = new SqlConnection(conString))
            {
                command = new SqlCommand("spFetchProdData", connection);
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
                    
                    product.ProdId = Convert.ToString(reader[0]);
                    product.ProdName = Convert.ToString(reader[1]);
                    product.ProdPrice = Convert.ToDecimal(reader[2]);
                    product.ProdImage = Convert.ToBase64String((byte[])reader[3]);
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
    }
}
