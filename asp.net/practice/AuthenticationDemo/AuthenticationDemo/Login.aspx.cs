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
    public partial class Login : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                
            //}
        }

        [Obsolete]
        protected void btnLoginUser_Click(object sender, EventArgs e)
        {
            string encPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
            userAuthenticate(txtEmail.Text, encPassword);
        }

        private void userAuthenticate(string email, string password)
        {
            if (!(string.IsNullOrWhiteSpace(txtEmail.Text) ))
            {
                using (connection = new SqlConnection(conString))
                {
                    command = new SqlCommand("spUserAuth", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        bool locked = Convert.ToBoolean(reader["Locked"]);
                        bool auth = Convert.ToBoolean(reader["Auth"]);
                        int attempt = Convert.ToInt32(reader["Attempt"]);
                        if(auth)
                        {
                            string userName = Convert.ToString(reader["UserName"].ToString());
                            Session["UserName"] = userName;
                            FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
                        }
                        else if(locked)
                        {
                            lblMessage.Text = "Account is Locked Please,Try to contact Developers";
                            lblMessage.ForeColor = Color.Red;
                        }
                        else if(attempt > 0)
                        {
                            int reAttempt = 4 - attempt;
                            lblMessage.Text = "Invalid Credentials," +
                                reAttempt.ToString() + "attempt(s) left";
                            lblMessage.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblMessage.Text = "Invalid Credentials";
                            lblMessage.ForeColor = Color.Red;
                        }
                    }
                    connection.Close();
                }
            }
            else
            {
                SetFocus(txtEmail);
                lblMessage.Text = "Fields are Required!";
            }
        }
    }
}