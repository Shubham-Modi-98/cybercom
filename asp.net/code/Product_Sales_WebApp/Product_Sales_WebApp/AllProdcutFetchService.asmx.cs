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
    /// Summary description for AllProdcutFetchService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AllProdcutFetchService : System.Web.Services.WebService
    {

        [WebMethod]
        public void fetchAllProd()
        {
            string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
            SqlCommand command = null;
            SqlConnection connection = null;
            List<Prod> lstProduct = new List<Prod>();
            using (connection = new SqlConnection(conString))
            {
                command = new SqlCommand("selectAllProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Prod product = new Prod()
                    {
                        prodId = Convert.ToString(reader["ProdId"].ToString()),
                        prodName = Convert.ToString(reader["ProdName"].ToString()),
                        prodQty = Convert.ToInt32(reader["ProdQty"].ToString()),
                        prodPrice = Convert.ToDecimal(reader["ProdPrice"].ToString()),
                        prodImage = Convert.ToBase64String((byte[])reader["ProdImage"])
                    };
                    lstProduct.Add(product);
                }
                connection.Close();
            }
            JavaScriptSerializer javaScript = new JavaScriptSerializer();
            Context.Response.Write(javaScript.Serialize(lstProduct));
        }
    }
}
