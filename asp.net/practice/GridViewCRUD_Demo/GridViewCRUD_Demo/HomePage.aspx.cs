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

namespace GridViewCRUD_Demo
{
    public partial class HomePage : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getData();
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        SqlCommand command = new SqlCommand("storeData", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@name", txtName.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@salary", Convert.ToDecimal(txtSalary.Text));
                        command.Parameters.AddWithValue("@id", -1);
                        command.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        int res = command.ExecuteNonQuery();
                        string id = command.Parameters["@id"].Value.ToString();
                        con.Close();
                        if (res > 0)
                        {
                            lblMessage.Text = "Record added Successfully, Id is- " + id;
                            lblMessage.ForeColor = Color.Green;
                            getData();
                        }
                        else
                        {
                            lblMessage.Text = "Something Wrong, Try Again!!";
                            lblMessage.ForeColor = Color.Red;
                        }
                        clearFields();
                    }
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
                    SqlDataAdapter adapter = new SqlDataAdapter("getData", con);
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

        private void clearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";    
        }

        protected void grData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow gvRow = grData.Rows[e.RowIndex];
                Label lblId = gvRow.FindControl("lblIdItem") as Label;
                string id = lblId.Text.ToString();
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("deleteData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //GridViewRow gvRow = grData.Rows[e.RowIndex];
                    //Label lblId = gvRow.FindControl("lblIdItem") as Label;
                    //string id = lblId.Text.ToString();
                    cmd.Parameters.AddWithValue("@id", lblId.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    grData.EditIndex = -1;
                    getData();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblGridMessage.ForeColor = Color.Red;
            }
        }

        protected void grData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grData.EditIndex = e.NewEditIndex;
                getData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblGridMessage.ForeColor = Color.Red;
            }   
        }

        protected void grData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grData.EditIndex = -1;
                getData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblGridMessage.ForeColor = Color.Red;
            }
        }

        protected void grData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("updateData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    GridViewRow gvRow = grData.Rows[e.RowIndex];
                    Label lblId = gvRow.FindControl("lblIdEdit") as Label;
                    TextBox txtName = gvRow.FindControl("txtNameEdit") as TextBox;
                    TextBox txtEmail = gvRow.FindControl("txtEmailEdit") as TextBox;
                    TextBox txtSalary = gvRow.FindControl("txtSalaryEdit") as TextBox;
                    if (txtName.Text != "" && txtEmail.Text != "" && txtSalary.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@id", lblId.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(txtSalary.Text));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    grData.EditIndex = -1;
                    getData();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblGridMessage.ForeColor = Color.Red;
            }
        }
    }
}