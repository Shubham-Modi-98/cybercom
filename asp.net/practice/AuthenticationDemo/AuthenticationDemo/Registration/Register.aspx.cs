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

namespace AuthenticationDemo.Registration
{
    public partial class Register : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataAdapter adapter = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
                
            //}
        }

        [Obsolete]
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ))
            {
                string encPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                addUser(txtName.Text, txtEmail.Text, encPassword);
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text))
                    SetFocus(txtName);
                else
                    SetFocus(txtEmail);
                
                lblMessage.Text = "All Fields are Required!";
                lblEmail.ForeColor = Color.Red;
            }
        }

        private void addUser(string name, string email, string password)
        {
            try
            {
                using (connection = new SqlConnection(conString))
                {
                    command = new SqlCommand("spAddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@id", -1);
                    command.Parameters["@id"].Direction = ParameterDirection.Output;
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    string userId = command.Parameters["@id"].Value.ToString();
                    connection.Close();
                    if (res > 0)
                    {
                        lblMessage.Text = "User Added Successfully, Your Id No. is- " + userId;
                        lblEmail.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Something went Wrong, Try Again!";
                        lblEmail.ForeColor = Color.Red;
                    }
                    txtName.Text = "";
                    txtEmail.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.Trim();
                lblEmail.ForeColor = Color.Red;
            }
        }
    }
}