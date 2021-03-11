using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace AuthenticationDemo
{
    public partial class Home : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;
        DataSet dataSet = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkUser();
            }
        }

        protected void grUserData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow gRow = grUserData.Rows[e.RowIndex];
                TextBox txtName = gRow.FindControl("txtNameEdit") as TextBox;
                TextBox lblEmail = gRow.FindControl("lblEmailEdit") as TextBox;
                if (txtName.Text != "" && lblEmail.Text != "")
                {
                    using (connection = new SqlConnection(conString))
                    {
                        command = new SqlCommand("spUpdateUser", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@name", txtName.Text);
                        command.Parameters.AddWithValue("@email", lblEmail.Text);
                        connection.Open();
                        int res = command.ExecuteNonQuery();
                        connection.Close();
                        if (res > 0)
                        {
                            lblMessage.Text = "Record Updated";
                            lblMessage.ForeColor = Color.Green;
                            grUserData.EditIndex = -1;
                            checkUser();
                        }
                        else
                        {
                            lblMessage.Text = "Try Again!!";
                            lblMessage.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Name cannot empty";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void grUserData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grUserData.EditIndex = e.NewEditIndex;
            checkUser();
        }

        protected void grUserData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow gRow = grUserData.Rows[e.RowIndex];
                TextBox lblEmail = gRow.FindControl("lblEmailEdit") as TextBox;
                using (connection = new SqlConnection(conString))
                {
                    command = new SqlCommand("spDeleteUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", lblEmail.Text);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    connection.Close();
                    if (res > 0)
                    {
                        lblMessage.Text = "Record Updated";
                        lblMessage.ForeColor = Color.Green;
                        grUserData.EditIndex = -1;
                        checkUser();
                    }
                    else
                    {
                        lblMessage.Text = "Try Again!!";
                        lblMessage.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void grUserData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grUserData.EditIndex = -1;
            checkUser();
        }

        private void checkUser()
        {
            string userName = Convert.ToString(Session["UserName"]);
            string userEmail = Convert.ToString(Session["Email"]);
            if (userName != "" && userEmail != "")
            {
                h3Content.InnerText = "Welcome, " + userName;
                if (userName.Equals("Admin"))
                {
                    fillAllDataInGrid();
                }
                else
                {
                    fillSingleUserGrid(userEmail);
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void fillAllDataInGrid()
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spGetAllData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    grUserData.DataSource = dataSet;
                    grUserData.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void fillSingleUserGrid(string email)
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    adapter = new SqlDataAdapter("spGetUserData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@email", email);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    grUserData.DataSource = dataSet;
                    grUserData.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            Session.Abandon();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
    }
}