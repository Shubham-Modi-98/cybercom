using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSlideShow
{
    public partial class ImagesDB : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["csDatabaseDemo"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillImages();
            }    
        }

        protected void timerImage_Tick(object sender, EventArgs e)
        {
            int i = (int)ViewState["Index"];
            i++;
            DataRow dr = ((DataSet)ViewState["DataTable"]).Tables["images"].Select().FirstOrDefault(x => x["ImgOrder"].ToString() == i.ToString());
            if(dr != null)
            {
                ViewState["Index"] = i;
                imgSlideShow.ImageUrl = "~/Images/" + dr["Name"].ToString();
                lblName.Text = dr["Name"].ToString();
                lblOrder.Text = dr["ImgOrder"].ToString();
            }
            else
            {
                fillImages();
            }
        }

        private void fillImages()
        {
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlDataAdapter adp = new SqlDataAdapter("spGetImages", con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                adp.Fill(ds,"images");
                DataRow dr = ds.Tables["images"].Select().FirstOrDefault(x => x["ImgOrder"].ToString() == "1");
                ViewState["DataTable"] = ds;
                ViewState["Index"] = 1;
                imgSlideShow.ImageUrl = "~/Images/" + dr["Name"].ToString();
                lblName.Text = dr["Name"].ToString();
                lblOrder.Text = dr["ImgOrder"].ToString();
            }
        }

        protected void imgSlideShow_Click(object sender, ImageClickEventArgs e)
        {
            if(timerImage.Enabled)
            {
                timerImage.Enabled = false;
            }
            else
            {
                timerImage.Enabled = true;
            }
        }
    }
}