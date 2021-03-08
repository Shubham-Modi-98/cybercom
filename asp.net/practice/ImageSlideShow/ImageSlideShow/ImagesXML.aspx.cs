using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSlideShow
{
    public partial class ImagesXML : System.Web.UI.Page
    {
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
             
            DataRow dr = ((DataSet)ViewState["DataTable"]).Tables[0].Select().FirstOrDefault(x => x["order"].ToString() == i.ToString());
            if(dr != null)
            {
                ViewState["Index"] = i;
                imgSlideShow.ImageUrl = "~/Images/" + dr["name"].ToString();
                lblName.Text = dr["name"].ToString();
                lblOrder.Text = dr["order"].ToString();
            }
            else
            {
                fillImages();
            }
        }

        private void fillImages()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/ImageData.xml"));
            ViewState["DataTable"] = ds;
            ViewState["Index"] = 1;
            DataRow dr = ds.Tables[0].Select().FirstOrDefault(x => x["order"].ToString() == "1");
            imgSlideShow.ImageUrl = "~/Images/" + dr["name"].ToString();
            lblName.Text = dr["name"].ToString();
            lblOrder.Text = dr["order"].ToString();
        }

        protected void btnSlideShow_Click(object sender, EventArgs e)
        {
            if(timerImage.Enabled)
            {
                timerImage.Enabled = false;
                btnSlideShow.Text = "Start Slide Show";
            }
            else
            {
                timerImage.Enabled = true;
                btnSlideShow.Text = "Stop Slide Show";
            }
        }
    }
}