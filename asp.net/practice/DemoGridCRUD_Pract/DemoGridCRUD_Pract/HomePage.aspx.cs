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

namespace DemoGridCRUD_Pract
{
    public partial class HomePage : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        public SqlCommand command = null;
        public SqlDataAdapter adapter = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDrpCourse();
                fillGridView();
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (drpCourse.SelectedIndex != 0)
                    {
                        using (SqlConnection con = new SqlConnection(connString))
                        {
                            command = new SqlCommand("addStudent", con);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@roll", txtUniqueNo.Text);
                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@php", Convert.ToInt32(txtPhpScore.Text));
                            command.Parameters.AddWithValue("@asp", Convert.ToInt32(txtAspScore.Text));
                            command.Parameters.AddWithValue("@js", Convert.ToInt32(txtJsScore.Text));
                            command.Parameters.AddWithValue("@cid", Convert.ToInt32(drpCourse.SelectedValue));
                            //command.Parameters.AddWithValue("@no", "-1");
                            //command.Parameters["@no"].Direction = ParameterDirection.Output;
                            //string uNo = command.Parameters["@no"].ToString();
                            con.Open();
                            int res = command.ExecuteNonQuery();
                            if (res > 0)
                            {
                                lblMessage.Text = "Record Inserted Successfully, Your Account no is: " + txtUniqueNo.Text;
                                lblMessage.ForeColor = Color.Green;
                                fillDrpCourse();
                                fillGridView();
                                clearFields();
                            }
                            else
                            {
                                lblMessage.Text = "Something went Wrong!";
                                lblMessage.ForeColor = Color.Red;
                                clearFields();
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please select Course";
                        lblMessage.ForeColor = Color.Red;
                        SetFocus(drpCourse);
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.Trim();
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
        private void fillDrpCourse()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    //Fill DropDown using DataSet

                    //adapter = new SqlDataAdapter("getCourseData", con);
                    //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //DataSet dataSet = new DataSet();
                    //adapter.Fill(dataSet);
                    //drpCourse.DataSource = dataSet;
                    //drpCourse.DataTextField = "Course";
                    //drpCourse.DataValueField = "Id";
                    //drpCourse.DataBind();

                    //Fill DropDown using DataReader, SqlCommand
                    command = new SqlCommand("getCourseData", con);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    drpCourse.DataSource = command.ExecuteReader();
                    drpCourse.DataTextField = "Course";
                    drpCourse.DataValueField = "Id";
                    drpCourse.DataBind();
                    con.Close();
                    drpCourse.Items.Insert(0, "Select Course");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void fillGridView()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    adapter = new SqlDataAdapter("getData", con);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    grStudentData.DataSource = dataSet;
                    grStudentData.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void clearFields()
        {
            txtUniqueNo.Text = "";
            txtName.Text = "";
            txtPhpScore.Text = "";
            txtAspScore.Text = "";
            txtJsScore.Text = "";
            drpCourse.SelectedIndex = 0;
        }

        protected void grStudentData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grStudentData.EditIndex = e.NewEditIndex;
            string course = (((GridViewRow)grStudentData.Rows[e.NewEditIndex]).FindControl("lblCourseItem") as Label).Text;
            fillGridView();

            GridViewRow gRow = grStudentData.Rows[e.NewEditIndex];
            using (SqlConnection con = new SqlConnection(connString))
            {
                //Fill DropDown using DataSet
                if (gRow.RowType == DataControlRowType.DataRow)
                {
                    DropDownList drpEdit = gRow.FindControl("drpCourseEdit") as DropDownList;
                    adapter = new SqlDataAdapter("select * from tblStudCourse", con);
                    //adapter.SelectCommand.Parameters.AddWithValue("@roll", uNo)  and RollNo = @roll;
                    //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    drpEdit.DataSource = dataSet;
                    drpEdit.DataTextField = "Course";
                    drpEdit.DataValueField = "Id";
                    drpEdit.DataBind();

                    //drpEdit.Items.Insert(0, "Select Index");
                    drpEdit.SelectedValue = drpCourse.Items.FindByText(course).Value;
                    
                    //drpCourse.ClearSelection();
                    //drpCourse.Items.FindByText(course).Selected = true; 
                }
            }
        }

        protected void grStudentData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow grRow = grStudentData.Rows[e.RowIndex];
            Label no = grRow.FindControl("lblNumberItem") as Label;
            using(SqlConnection con = new SqlConnection(connString))
            {
                command = new SqlCommand("deleteRecord", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@roll", no.Text);
                con.Open();
                int res = command.ExecuteNonQuery();
                con.Close();
                if(res > 0)
                {
                    lblMessage.Text = "Unique No. "+ no.Text + " Deleted Successfully";
                    lblMessage.ForeColor = Color.Green;
                    fillDrpCourse();
                    fillGridView();
                }
                else
                {
                    lblMessage.Text = "Something went Wrong!";
                    lblMessage.ForeColor = Color.Red;
                    clearFields();
                }
            }
        }

        protected void grStudentData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grStudentData.EditIndex = -1;
            fillGridView();
        }

        protected void grStudentData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow grRows = grStudentData.Rows[e.RowIndex];
                Label no = grRows.FindControl("lblNumberEdit") as Label;
                TextBox name = grRows.FindControl("txtNameEdit") as TextBox;
                DropDownList course = grRows.FindControl("drpCourseEdit") as DropDownList;
                TextBox php = grRows.FindControl("txtPhpEdit") as TextBox;
                TextBox asp = grRows.FindControl("txtAspEdit") as TextBox;
                TextBox js = grRows.FindControl("txtJsEdit") as TextBox;
                if(name.Text != "" && php.Text != "" && asp.Text != "" && js.Text != "" )
                {
                    using(SqlConnection con = new SqlConnection(connString))
                    {
                        command = new SqlCommand("updateRecord", con);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@name", name.Text);
                        command.Parameters.AddWithValue("@cid", course.SelectedItem.Value);
                        command.Parameters.AddWithValue("@php", Convert.ToInt32(php.Text));
                        command.Parameters.AddWithValue("@asp", Convert.ToInt32(asp.Text));
                        command.Parameters.AddWithValue("@js", Convert.ToInt32(js.Text));
                        command.Parameters.AddWithValue("@roll", no.Text);
                        con.Open();
                        int res = command.ExecuteNonQuery();
                        con.Close();
                        if(res > 0)
                        {
                            lblMessage.Text = "Unique No.:"+ no.Text +" Updated Successfully";
                            lblMessage.ForeColor = Color.Green;
                            fillDrpCourse();
                        }
                        else
                        {
                            lblMessage.Text = "Something went Wrong!";
                            lblMessage.ForeColor = Color.Red;
                        }
                    }
                }
                grStudentData.EditIndex = -1;
                fillGridView();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void grStudentData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(connString))
            //    {
            //        //Fill DropDown using DataSet
            //        if (e.Row.RowType == DataControlRowType.DataRow)
            //        {
            //            DropDownList drpEdit = e.Row.FindControl("drpCourseItem") as DropDownList;
            //            adapter = new SqlDataAdapter("select RollNo, Course, CourseId from tblStudCourse as sc, tblStudent as s where CourseId = sc.Id", con);
            //            DataSet dataSet = new DataSet();
            //            adapter.Fill(dataSet);
            //            drpEdit.DataSource = dataSet;
            //            drpEdit.DataTextField = "Course";
            //            drpEdit.DataValueField = "CourseId";
            //            drpEdit.DataBind();
            //            drpEdit.Items.Insert(0, "Select Course");

            //            string course = (e.Row.FindControl("lblCourseItem") as Label).Text;
            //            drpCourse.Items.FindByText(course).Selected = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.Message.Trim();
            //    lblMessage.ForeColor = Color.Red;
            //}
        }
    }
}