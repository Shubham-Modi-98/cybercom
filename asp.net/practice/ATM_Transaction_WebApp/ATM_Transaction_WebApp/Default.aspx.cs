using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM_Transaction_WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.ToString();
                int pin = Convert.ToInt32(txtPin.Text);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spFetchCustomer", con);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Pin", pin);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Session["Id"] = dr["Id"].ToString();
                            Session["Name"] = dr["Name"].ToString();
                            Session["Mobile"] = dr["Mobile"].ToString();
                            Session["Pin"] = dr["Pin"].ToString();
                            Session["Balance"] = Convert.ToDouble(dr["Balance"]);
                            Session["Limit"] = Convert.ToDouble(dr["Limit"]);
                            Response.Redirect("~/Home.aspx");
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Credentials, Please Enter Valid Details!!";
                        lblMessage.ForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                Response.Write(ex.StackTrace);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }
    }
}