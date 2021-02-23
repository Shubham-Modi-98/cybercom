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

namespace DataAdapterDemo
{
    public partial class HomePage : System.Web.UI.Page
    {
        public static string cs = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                getAllData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (drpGender.SelectedValue == "Selected")
                {
                    lblMessage.Text = "Please Select Gender First..";
                    lblMessage.ForeColor = Color.Red;
                }
                else
                {
                    
                    string insertQuery = "Insert into Test values (@name,@email,@gender,@city)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@gender", drpGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblMessage.Text = "Record Inserted..";
                    lblMessage.ForeColor = Color.Green;
                    getAllData();
                    txtFirstName.Text = "";
                    txtEmail.Text = "";
                    txtCity.Text = "";
                    drpGender.ClearSelection();
                }
            }
        }
        private void getAllData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string selectQuery = "select * from Test";
                SqlDataAdapter adp = new SqlDataAdapter(selectQuery, con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                grData.DataSource = ds;
                grData.DataBind();
            }
        }
    }
}