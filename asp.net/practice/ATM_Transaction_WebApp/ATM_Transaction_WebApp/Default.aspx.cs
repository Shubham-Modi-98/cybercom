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

        protected void btnLoginFRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnCheckCommand = (Button)sender;
                if (btnCheckCommand.CommandName == "Login")
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
                else if(btnCheckCommand.CommandName == "Register")
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
                            SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@mobile", mobie);
                            cmd.Parameters.AddWithValue("@pin", pin);
                            cmd.Parameters.AddWithValue("@balance", balance);
                            cmd.Parameters.AddWithValue("@limit", limit);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            con.Open();
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
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
                else if (btnCheckCommand.CommandName == "ShowRegister")
                {
                    panelRegister.Visible = true;
                    panelLogin.Visible = false;

                }
                else if (btnCheckCommand.CommandName == "ShowLogin")
                {
                    panelLogin.Visible = true;
                    panelRegister.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                //Response.Write(ex.StackTrace);
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
    }
}