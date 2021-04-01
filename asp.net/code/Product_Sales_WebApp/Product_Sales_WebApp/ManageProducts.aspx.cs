using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

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

        //OnRowCommand="grData_RowCommand"
        //protected void grData_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        string prodId = Convert.ToString(e.CommandArgument);
        //        if (e.CommandName == "DeleteProduct")
        //        {
        //            //var val = "<script>confirm('Are you sure want to delete Product?')</script>";
        //            using (connection = new SqlConnection(conString))
        //            {
        //                command = new SqlCommand("spDeleteProductId", connection);
        //                command.CommandType = CommandType.StoredProcedure;
        //                command.Parameters.AddWithValue("@prodId", prodId);
        //                connection.Open();
        //                command.ExecuteNonQuery();
        //                connection.Close();
        //                //lblMessage.Text = "Record Deleted!";
        //                //MessageBox.Show(prodId + " - Product Deleted Successfully");
        //                Response.Write("<script>alert('" + prodId + " - Product Deleted Successfully')</script>");
        //                fillAllProduct();
        //            }
        //        }
        //        else
        //        {
        //            Response.Redirect("~/AddProduct.aspx?ProductNo=" + prodId);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        lblMessage.Text = exception.Message.Trim();
        //        lblMessage.ForeColor = Color.Red;
        //    }
        //}

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

        protected void grData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grData.PageIndex = e.NewPageIndex;
            fillAllProduct();
        }

        protected void linkBtnEditDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button buttonData = (Button)sender;
                string prodId = Convert.ToString(buttonData.CommandArgument);
                if (buttonData.CommandName == "DeleteProduct")
                {
                    //var val = "<script>confirm('Are you sure want to delete Product?')</script>";
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
                else if(buttonData.CommandName == "DeleteProduct")
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
    }
}