using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AutoCompleteTextBox
{
    /// <summary>
    /// Summary description for ShowData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ShowData : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetEmployeeName(string empName)
       {
            List<string> emplaoyeeNames = new List<string>();
            string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("getEmployeeByName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", empName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emplaoyeeNames.Add(reader["Name"].ToString());
                }
            }
            return emplaoyeeNames;
        }
    }
}
