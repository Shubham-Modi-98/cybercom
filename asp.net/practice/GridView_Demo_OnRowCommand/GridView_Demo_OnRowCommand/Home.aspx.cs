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

namespace GridView_Demo_OnRowCommand
{
    public partial class Home : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        SqlDataAdapter adapter = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
                if (Request.QueryString["id"] != null)
                {
                    btnAddEmployee.Text = "Update Employee";
                    getDataById(Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    btnAddEmployee.Text = "Add Employee";
                }
            }
        }

        protected void btnAddEditEmployee_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Request.QueryString["id"] == null)
                    {
                        using (connection = new SqlConnection(conString))
                        {
                            command = new SqlCommand("spStoreDataTest", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@email", txtEmail.Text);
                            command.Parameters.AddWithValue("@salary", Convert.ToDecimal(txtSalary.Text));
                            command.Parameters.AddWithValue("@id", -1);
                            //Or you can use Add

                            //command.Parameters.Add("@id", SqlDbType.Int);

                            command.Parameters["@id"].Direction = ParameterDirection.Output;
                            connection.Open();
                            int res = command.ExecuteNonQuery();
                            string id = command.Parameters["@id"].Value.ToString();
                            connection.Close();
                            if (res > 0)
                            {
                                lblMessage.Text = "Record added Successfully, Id is: " + id;
                                lblMessage.ForeColor = Color.Green;

                            }
                            else
                            {
                                lblMessage.Text = "Something Wrong, Try Again!!";
                                lblMessage.ForeColor = Color.Red;
                            }
                            clearFields();
                        }
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        using (connection = new SqlConnection(conString))
                        {
                            command = new SqlCommand("spUpdateDataTest", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@email", txtEmail.Text);
                            command.Parameters.AddWithValue("@salary", Convert.ToDecimal(txtSalary.Text));
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            int res = command.ExecuteNonQuery();
                            //connection.Close();
                            if (res > 0)
                            {
                                Response.Redirect("~/Home.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Error in Update";
                                lblMessage.ForeColor = Color.Red;
                            }
                        }
                    }
                    getData();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                Response.Write("Please Enable Javascript in Browser");
            }
        }

        private void getData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spGetDataTest", con);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    grData.DataSource = dataSet;
                    grData.DataBind();
                    //SqlCommand command = new SqlCommand("getData", con);
                    //command.CommandType = CommandType.StoredProcedure;
                    //con.Open();
                    //SqlDataReader reader = command.ExecuteReader();
                    //while(reader.HasRows)
                    //{
                    //    grData.DataSource = reader;
                    //    grData.DataBind();
                    //}
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void getDataById(int id)
        {
            using (connection = new SqlConnection(conString))
            {
                command = new SqlCommand("spGetDataByIdTest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtSalary.Text = reader["Salary"].ToString();
                    }
                    reader.Close();
                    command.Dispose();
                }
                connection.Close();
            }
        }

        private void clearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
        }

        protected void grData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteEmployee")
            {
                int dId = Convert.ToInt32(e.CommandArgument);
                using (connection = new SqlConnection(conString))
                {
                    command = new SqlCommand("spDeleteDataTest", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", dId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    lblGridMessage.Text = "Record Deleted!";
                    getData();
                }
            }
            else
            {
                int dId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Home.aspx?id=" + dId.ToString());
            }
        }
    }
}