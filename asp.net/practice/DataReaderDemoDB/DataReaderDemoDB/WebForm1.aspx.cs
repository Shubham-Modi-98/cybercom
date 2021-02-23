using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataReaderDemoDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static SqlConnection con = new SqlConnection();
        public SqlCommand cmd = null;
        public static string q = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["cs"].ToString();
                FillGrid();
                FillDrp();
            }
        }

        private void FillDrp()
        {
            q = "select id from stud";
            SqlDataAdapter adp = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            drpId.Items.Clear();
            drpId.Items.Add("Select...");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem l = new ListItem(dt.Rows[i][0].ToString());
                drpId.Items.Add(l);
            }
        }

        private void FillGrid()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "Select * from stud";
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                gvStud.DataSource = dr;
                gvStud.DataBind();
            }
            dr.Close();
            con.Close();
        }

        protected void btnIUD_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (b.CommandName == "I")
                {
                    q = "insert into stud values(@n,@c)";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@c", txtCity.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        FillGrid();
                        FillDrp();
                    }
                }
                else if (b.CommandName == "U")
                {
                    q = "update stud set name=@n,city=@c where id=@i";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@c", txtCity.Text);
                    cmd.Parameters.AddWithValue("@i", drpId.SelectedValue);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        FillGrid();
                        FillDrp();
                    }
                }
                else if (b.CommandName == "D")
                {
                    q = "delete from stud where id=@i";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@i", drpId.SelectedValue);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        FillGrid();
                        FillDrp();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                txtName.Text = "";
                txtCity.Text = "";
            }
        }

        protected void drpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                q = "select * from stud where id=@sid";
                cmd.CommandText = q;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@sid", drpId.SelectedValue);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["Name"].ToString();
                        txtCity.Text = dr["City"].ToString();

                    }
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}