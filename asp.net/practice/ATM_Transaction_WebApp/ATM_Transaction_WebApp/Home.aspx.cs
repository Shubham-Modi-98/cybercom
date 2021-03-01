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
    public partial class Home : System.Web.UI.Page
    {
        public int id;
        public string name = string.Empty;
        public string mobile = string.Empty;
        public int pin = 0;
        public double balance = 0.0;
        public double limit = 0.0;
        public static string connectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            { 
                id = Convert.ToInt32(Session["Id"]);
                name = Session["Name"].ToString();
                mobile = Session["Mobile"].ToString();
                pin = Convert.ToInt32(Session["Pin"]);
                balance = Convert.ToDouble(Session["Balance"]);
                limit = Convert.ToDouble(Session["Limit"]);
            }
        }

        protected void btnVisible_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnCheckId = (Button)sender;
                if (btnCheckId.CommandName == "CheckBalance")
                {
                    panelBalance.Visible = true;
                    panelDeposite.Visible = false;
                    panelWithDraw.Visible = false;

                    lblName.Text = "Customer Name: " + name;
                    lblBalance.Text = "Current Balance: " + balance;
                }
                else if (btnCheckId.CommandName == "Deposite")
                {
                    panelDeposite.Visible = true;
                    panelBalance.Visible = false;
                    panelWithDraw.Visible = false;
                }
                else if (btnCheckId.CommandName == "WithDraw")
                {
                    panelWithDraw.Visible = true;
                    panelBalance.Visible = false;
                    panelDeposite.Visible = false;
                }
                else if (btnCheckId.CommandName == "LogOut")
                {
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    panelBalance.Visible = false;
                    panelDeposite.Visible = false;
                    panelWithDraw.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                Button bId = (Button)sender;
                if (bId.CommandName == "DepositeAmount")
                {
                    double depoAmount = Convert.ToDouble(txtDeposite.Text);
                    if (depoAmount == null || depoAmount < 0)
                    {
                        lblDeposite.Text = "Please Enter Valid Amount";
                        lblDeposite.ForeColor = Color.Red;
                        SetFocus(txtDeposite.Text);
                    }
                    else
                    {
                        balance = balance + depoAmount;
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand("spUpdateBalance", con);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Balance", balance);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            con.Open();
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                Session["Balance"] = balance;
                                lblDeposite.Text = depoAmount.ToString() + " Rs. Deposited to Account";
                                lblDeposite.ForeColor = Color.Green;
                                txtDeposite.Text = "";
                            }
                            else
                            {
                                lblDeposite.Text = "Error to Deposite Amount";
                                lblDeposite.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                else if (bId.CommandName == "WithDrawAmout")
                {
                    double withAmount = Convert.ToDouble(txtWithDraw.Text);
                    if (withAmount == null || withAmount < 0)
                    {
                        lblWithDraw.Text = "Please Enter Valid Amount";
                        lblWithDraw.ForeColor = Color.Red;
                        SetFocus(txtWithDraw.Text);
                    }
                    else if (withAmount > limit)
                    {
                        lblWithDraw.Text = "You can't withdraw more than Limit";
                        lblWithDraw.ForeColor = Color.Red;
                    }
                    else
                    {
                        balance = balance - withAmount;
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand("spUpdateBalance", con);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Balance", balance);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            con.Open();
                            int res = cmd.ExecuteNonQuery();
                            if (res > 0)
                            {
                                Session["Balance"] = balance;
                                lblWithDraw.Text = withAmount.ToString() + " Rs. WithDraw to Account";
                                lblWithDraw.ForeColor = Color.Green;
                                txtWithDraw.Text = "";
                            }
                            else
                            {
                                lblWithDraw.Text = "Error to Deposite Amount";
                                lblWithDraw.ForeColor = Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
        }

        //private void fetchUpdatedData()
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spUpdateFetchUser", con);
        //        cmd.Parameters.AddWithValue("@Id", id);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                Session["Balance"] = balance;
        //                Response.Redirect("~/Home.aspx");
        //            }
        //        }
        //    }
        //}
    }
}