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
    public partial class Registration : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            string mobie = txtMobile.Text.ToString();
            float balance = float.Parse(txtBalance.Text);
            float limit = float.Parse(txtLimit.Text);
            int pin = int.Parse(txtPin.Text);
            if (pin.ToString().Length == '4')
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddCustomer",con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@mobile", mobie);
                    cmd.Parameters.AddWithValue("@pin", pin);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if(res > 0)
                    {
                        lblMessage.Text = "Account Created Successfully...";
                        lblMessage.ForeColor = Color.DarkGreen;
                        clearFields();
                    }
                    else
                    {
                        lblMessage.Text = "Something went Wrong, TryAgain!!";
                        lblMessage.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                lblMessage.Text = "Pin Length must be 4 digit";
                lblMessage.ForeColor = Color.DarkGoldenrod;
                SetFocus(txtPin);
            }
        }
        private void clearFields()
        {
            txtName.Text = "";
            txtMobile.Text = "";
            txtPin.Text = "";
            txtBalance.Text = "";
            txtLimit.Text = "";
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}