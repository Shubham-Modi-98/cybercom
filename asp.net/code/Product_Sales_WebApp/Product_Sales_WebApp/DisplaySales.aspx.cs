using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Sales_WebApp
{
    public partial class DisplaySales : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        static int rowCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAllProduct();
            }
        }

        private void fillAllProduct()
        {
            try
            {
                List<string> lstName = new List<string>();
                using (connection = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spFetchProdData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    rowCount = dataSet.Tables[0].Rows.Count;
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

        protected void grData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblno = e.Row.FindControl("lblNo") as Label;
                    Label lblPname = e.Row.FindControl("lblProdName") as Label;
                    Label lblSalesData = e.Row.FindControl("lblSalesData") as Label;
                    //Label lblSdate = e.Row.FindControl("lblSalesDate") as Label;
                    //Label lblTprice = e.Row.FindControl("lblTotal") as Label;
                    //Label lblSqty = e.Row.FindControl("lblSalesQty") as Label;
                    rowCount = rowCount + 1;
                    using (connection = new SqlConnection(conString))
                    {
                        using (command = new SqlCommand("spGetSalesDataByName", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@name", lblPname.Text);
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    //lblSalesData.Text += "x&nbsp;" + Convert.ToString(reader["Qty"]) + "&nbsp; = &nbsp;" + Convert.ToString(reader["TotalPrice"]) +
                                    //    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(reader["SalesDate"]) + "<br/>";

                                    DateTime sDate = DateTime.Parse(reader["SalesDate"].ToString());  
                                    
                                    lblSalesData.Text += sDate.ToShortDateString() +
                                        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(reader["TotalPrice"]) + "<br/>";
                                }
                            }
                            connection.Close();
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