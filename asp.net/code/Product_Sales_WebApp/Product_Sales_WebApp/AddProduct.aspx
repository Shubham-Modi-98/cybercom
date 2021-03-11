<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Product_Sales_WebApp.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product Page</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Add Product</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align: center; color: darkorange; font-style: oblique;">Fill Form</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProdId" runat="server" Text="Product Id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProdId" runat="server" PlaceHolder="Enter Product Id" Width="150px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvProdId" runat="server" ErrorMessage="Product Id is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtProdId" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProdName" runat="server" PlaceHolder="Enter Product Name" Width="150px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvProdName" runat="server" ErrorMessage="Name is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtProdName" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProdQty" runat="server" Text="Prouct Qty"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProdQty" runat="server" PlaceHolder="Enter Quantity" Width="150px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvProdQty" runat="server" ErrorMessage="Quantity is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtProdQty" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rgProdQty" runat="server" ErrorMessage="Quatity must be greater than 0"
                            MinimumValue="0" MaximumValue="100000" Type="Integer" Text="*" ForeColor="Red" ControlToValidate="txtProdQty" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtProdPrice" runat="server" PlaceHolder="Enter Price" Width="150px"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="rfvProductPrice" runat="server" ErrorMessage="Price is Required"
                            Text="*" ForeColor="Red" ControlToValidate="txtProdPrice" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>

                        <asp:RangeValidator ID="rgProdPrice" runat="server" ErrorMessage="Price must be greater than 0"
                            MinimumValue="0" MaximumValue="2500000" Type="Double" Text="*" ForeColor="Red" ControlToValidate="txtProdPrice" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProdImage" runat="server" Text="Upload Image"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:FileUpload ID="fileProdImage" runat="server" />

                        <asp:RequiredFieldValidator ID="rfvFile" runat="server" ErrorMessage="Image is Required"
                            Text="*" ForeColor="Red" ControlToValidate="fileProdImage" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-top: 15px;">
                        <asp:Button ID="btnAddEditProduct" runat="server" Text="Add Product" OnClick="btnAddEditProduct_Click" ValidationGroup="FormValidation" Width="150px" Height="40px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:ValidationSummary ID="vSummaryForm" ValidationGroup="FormValidation" ShowValidationErrors="true" ShowMessageBox="true" ShowSummary="true" ForeColor="Red" Font-Bold="true" runat="server" />
                    </td>
                </tr>
            </table>
            <table style="margin-left: auto; margin-right: auto; padding-top: 20px; padding-bottom: 20px">
                <tr>
                    <td style="text-align: center; font-style: normal; font-weight: 600">
                        <asp:LinkButton ID="linkViewProduct" runat="server" PostBackUrl="~/ManageProducts.aspx">View All Products</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; font-style: normal; font-weight: 600">
                        <asp:LinkButton ID="linkSaleProduct" runat="server" PostBackUrl="~/SaleProducts.aspx">Sales Product</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
