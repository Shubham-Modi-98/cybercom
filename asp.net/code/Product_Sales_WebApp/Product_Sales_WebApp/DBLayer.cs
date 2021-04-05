using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_Sales_WebApp
{
    public class DBLayer
    {
        public DataTable GetData(string sortColumn, string sortDirection, int OffsetValue, int PagingSize, string searchby)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("spDataInDataTable", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sortColumn", sortColumn);
                com.Parameters.AddWithValue("@sortOrder", sortDirection??"ASC");
                com.Parameters.AddWithValue("@OffsetValue", OffsetValue);
                com.Parameters.AddWithValue("@PagingSize", PagingSize);
                com.Parameters.AddWithValue("@SearchText", searchby??"");
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                da.Dispose();
                conn.Close();
            }
            return dt;
        }
    }
}