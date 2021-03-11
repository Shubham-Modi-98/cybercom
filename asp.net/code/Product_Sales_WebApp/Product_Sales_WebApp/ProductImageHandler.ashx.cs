using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Product_Sales_WebApp
{
    /// <summary>
    /// Summary description for ProductImageHandler
    /// </summary>
    public class ProductImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
            SqlCommand command = null;
            SqlConnection connection = null;
            using (connection = new SqlConnection(conString))
            {
                string imgId = context.Request.QueryString["ImgId"];
                using (command = new SqlCommand("spGetProductImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@prodId", imgId);   
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        context.Response.BinaryWrite((byte[])reader["ProdImage"]);
                        connection.Close();
                    }
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}