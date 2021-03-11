using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Product_Sales_WebApp
{
    public partial class SaleProducts : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillDropDown();
            }
        }

        protected void drpProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpProducts.SelectedIndex == 0)
                {
                    Response.Write("<script>alert('Select Product First')</script>");
                }
                else
                {
                    btnBill.Enabled = false;
                    int id = Convert.ToInt32(drpProducts.SelectedValue);

                    using (connection = new SqlConnection(conString))
                    {
                        using (command = new SqlCommand("spGetProductById", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id", id);
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                panelBill.Visible = true;
                                reader.Read();
                                txtProdId.Text = Convert.ToString(reader["ProdId"]);
                                txtProdName.Text = Convert.ToString(reader["ProdName"]);
                                txtProdPrice.Text = Convert.ToString(reader["ProdPrice"]);
                                lblDbQty.Text = Convert.ToString(reader["ProdQty"]);
                            }
                        }    
                    }
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void fillDropDown()
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spAllGetIdName", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    drpProducts.DataSource = dataSet;
                    drpProducts.DataTextField = "ProdName";
                    drpProducts.DataValueField = "Id";
                    drpProducts.DataBind();
                    drpProducts.Items.Insert(0, "Select Product");
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void txtProdQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dbQty = Convert.ToInt32(lblDbQty.Text);
                int txtQty = Convert.ToInt32(txtProdQty.Text);
                if (dbQty <= 0)
                {
                    panelBill.Visible = false;
                    lblMessage.Text = "Product is Out of Stock";
                    lblMessage.ForeColor = Color.Red;
                }
                else if (txtQty <= dbQty)
                {
                    btnBill.Enabled = true;
                    decimal prodPrice = Convert.ToDecimal(txtProdPrice.Text);
                    decimal totalPrice = prodPrice * txtQty;
                    txtTotalPrice.Text = Convert.ToString(totalPrice);
                    lblMessage.Text = "";
                }
                else
                {
                    lblMessage.Text = "You cann't enter Quantity more than Stocks";
                    lblMessage.ForeColor = Color.Red;
                    SetFocus(txtProdQty);
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnBill_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(drpProducts.SelectedValue);
                using (connection = new SqlConnection(conString))
                {
                    using (command = new SqlCommand("spAddSaleProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.AddWithValue("@name", txtProdName.Text);
                        command.Parameters.AddWithValue("@qty", Convert.ToInt32(txtProdQty.Text));
                        command.Parameters.AddWithValue("@price", Convert.ToDecimal(txtProdPrice.Text));
                        command.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotalPrice.Text));
                        command.Parameters.AddWithValue("@prodId", id);
                        command.Parameters.AddWithValue("@id", -1);
                        command.Parameters["@id"].Direction = ParameterDirection.Output;
                        connection.Open();
                        int res = command.ExecuteNonQuery();
                        string storeId = Convert.ToString(command.Parameters["@id"].Value);
                        connection.Close();
                        if(res > 0)
                        {
                            Response.Redirect("~/FinalBill.aspx?prodId=" + id + "&billId=" + storeId);
                        }
                        else
                        {
                            lblMessage.Text = "Something went wrong, Please Try After Sometimes";
                            lblMessage.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}