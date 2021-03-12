using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Sales_WebApp
{
    public partial class AddProduct : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["ProductSalesCS"].ConnectionString;
        SqlCommand command = null;
        SqlConnection connection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string prodId = Convert.ToString(Request.QueryString["ProductNo"]);
            if (!IsPostBack)
            {
                if (prodId == "" || string.IsNullOrEmpty(prodId))
                {
                    btnAddEditProduct.Text = "Add Product";
                }
                else
                {
                    rfvFile.Enabled = false;
                    btnAddEditProduct.Text = "Update Product";
                    linkViewProduct.Visible = false;
                    txtProdId.ReadOnly = true;
                    fillProductById(prodId);
                }
            }
        }

        protected void btnAddEditProduct_Click(object sender, EventArgs e)
        {
            try
                {
                string prodId = Convert.ToString(Request.QueryString["ProductNo"]);

                if (Page.IsValid)
                {
                    byte[] byteArray = null;
                    if (prodId == "" || string.IsNullOrEmpty(prodId))
                    {
                        using (connection = new SqlConnection(conString))
                        {
                            using (command = new SqlCommand("spInsertProduct", connection))
                            {
                                HttpPostedFile postedFile = fileProdImage.PostedFile;
                                string imgName = Path.GetFileName(postedFile.FileName);
                                string extension = Path.GetExtension(imgName);
                                int imgSize = postedFile.ContentLength;

                                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jfif"
                                    || extension.ToLower() == ".png" || extension.ToLower() == ".bmp")
                                {
                                    Stream inputStream = postedFile.InputStream;
                                    BinaryReader binaryReader = new BinaryReader(inputStream);
                                    byteArray = binaryReader.ReadBytes((int)inputStream.Length);
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@prodId", txtProdId.Text);
                                    command.Parameters.AddWithValue("@prodName", txtProdName.Text);
                                    command.Parameters.AddWithValue("@prodQty", Convert.ToInt32(txtProdQty.Text));
                                    command.Parameters.AddWithValue("@prodPrice", Convert.ToDecimal(txtProdPrice.Text));
                                    command.Parameters.AddWithValue("@prodImage", byteArray);
                                    //command.Parameters.AddWithValue("@pId", "-1");
                                    command.Parameters.Add("@pId", SqlDbType.NVarChar, 50);
                                    command.Parameters["@pId"].Direction = ParameterDirection.Output;
                                    connection.Open();
                                    int res = command.ExecuteNonQuery();
                                    string productId = Convert.ToString(command.Parameters["@pId"].Value);
                                    connection.Close();
                                    if (res > 0 )
                                    {
                                        lblMessage.Text = "Product with ProductId: " + productId + " Added Successfully.";
                                        lblMessage.ForeColor = Color.Green;
                                        clearFields();
                                    }
                                    else
                                    {
                                        lblMessage.Text = "Something went wrong to Add, Please Try after few Minutes";
                                        lblMessage.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMessage.Text = "Only Images can be uploaded";
                                    lblMessage.ForeColor = Color.Red;
                                }
                            }
                        }
                    }
                    else
                    {
                        using (connection = new SqlConnection(conString))
                        {
                            using (command = new SqlCommand())
                            {
                                command.Connection = connection;
                                if (fileProdImage.HasFile)
                                {
                                    HttpPostedFile postedFile = fileProdImage.PostedFile;
                                    string imgName = Path.GetFileName(postedFile.FileName);
                                    string extension = Path.GetExtension(imgName);
                                    int imgSize = postedFile.ContentLength;

                                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jfif"
                                        || extension.ToLower() == ".png" || extension.ToLower() == ".bmp")
                                    {
                                        Stream inputStream = postedFile.InputStream;
                                        BinaryReader binaryReader = new BinaryReader(inputStream);
                                        byteArray = binaryReader.ReadBytes((int)inputStream.Length);
                                        command.CommandText = "spUpdateProductWithImage";
                                        command.Parameters.AddWithValue("@image", byteArray);
                                    }
                                }
                                else
                                {
                                    command.CommandText = "spUpdateProduct";
                                }

                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@prodId", prodId);
                                command.Parameters.AddWithValue("@name", txtProdName.Text);
                                command.Parameters.AddWithValue("@qty", Convert.ToInt32(txtProdQty.Text));
                                command.Parameters.AddWithValue("@price", Convert.ToDecimal(txtProdPrice.Text));
                                connection.Open();
                                int res = command.ExecuteNonQuery();
                                connection.Close();
                                if (res > 0)
                                {
                                    Response.Redirect("~/ManageProducts.aspx");
                                }
                                else
                                {
                                    lblMessage.Text = "Something went wrong to Add, Please Try after few Minutes";
                                    lblMessage.ForeColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void fillProductById(string prodId)
        {

            try
            {
                using (connection = new SqlConnection(conString))
                {
                    using (command = new SqlCommand("spGetProductByProdId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@prodId", prodId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            txtProdId.Text = prodId;
                            txtProdName.Text = reader["ProdName"].ToString();
                            txtProdQty.Text = reader["ProdQty"].ToString();
                            txtProdPrice.Text = reader["ProdPrice"].ToString();
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message.Trim();
                lblMessage.ForeColor = Color.Red;
            }
            
        }

        private void clearFields()
        {
            txtProdId.Text = "";
            txtProdName.Text = "";
            txtProdQty.Text = "";
            txtProdPrice.Text = "";
        }
    }
}