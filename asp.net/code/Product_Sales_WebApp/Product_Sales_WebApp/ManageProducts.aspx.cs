using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Product_Sales_WebApp
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillAllProduct();
            }
        }

        protected void grData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string prodId = Convert.ToString(e.CommandArgument);
                if (e.CommandName == "DeleteProduct")
                {
                    using (connection = new SqlConnection(conString))
                    {
                        command = new SqlCommand("spDeleteProductId", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@prodId", prodId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        //lblMessage.Text = "Record Deleted!";
                        //MessageBox.Show(prodId + " - Product Deleted Successfully");
                        Response.Write("<script>alert('" + prodId + " - Product Deleted Successfully')</script>");
                        fillAllProduct();
                    }
                }
                else
                {
                    Response.Redirect("~/AddProduct.aspx?ProductNo=" + prodId);
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void fillAllProduct()
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spGetAllProduct", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    grData.DataSource = dataSet;
                    grData.DataBind();
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