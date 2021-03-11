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
    public partial class FinalBill : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = Convert.ToString(Request.QueryString["billId"]);
                string prodId = Convert.ToString(Request.QueryString["prodId"]);
                if ((id == "" || string.IsNullOrEmpty(id)) && (prodId == "" || string.IsNullOrEmpty(prodId)))
                {
                    Response.Redirect("~/SaleProducts.aspx");
                }
                else
                {
                    getFinalBill(id);
                }
            }
        }

        private void getFinalBill(string billId)
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    using (command = new SqlCommand("spGetSaleById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@salesId", Convert.ToInt32(billId));
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            lblBillId.Text = Guid.NewGuid().ToString().Trim();
                            lblProdId.Text = Convert.ToString(reader["ProdId"]);
                            lblProdName.Text = Convert.ToString(reader["ProdName"]);
                            lblProdQty.Text = Convert.ToString(reader["Qty"]);
                            lblProdPrice.Text = Convert.ToString(reader["Price"]);
                            lblTotalAmount.Text = Convert.ToString(reader["TotalPrice"]);
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