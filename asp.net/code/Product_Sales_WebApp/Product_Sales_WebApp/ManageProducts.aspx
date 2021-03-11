<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="Product_Sales_WebApp.ManageProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Products Page</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Manage Products</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align: center; color: darkorange; font-style: oblique;">All Products List</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grData" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="grData_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                            <Columns>
                                <asp:BoundField HeaderText="Product Id" DataField="ProdId" />
                                <asp:BoundField HeaderText="Product Name" DataField="ProdName" />
                                <asp:BoundField HeaderText="Quantity" DataField="ProdQty" />
                                <asp:BoundField HeaderText="Price" DataField="ProdPrice" />
                                <asp:TemplateField HeaderText="Product Image">
                                    <ItemTemplate>
                                        <asp:Image ID="imgProduct" Height="150px" Width="150px" runat="server"
                                            ImageUrl='<%#"ProductImageHandler.ashx?ImgId="+Eval("ProdId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit Product">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBtnEdit" runat="server" ToolTip="Edit Product"
                                            CommandName="EditProduct" CommandArgument='<%#Eval("ProdId") %>'>
                                            <i class="fa fa-edit" style="padding-left:10px; font-size:30px;"></i>
                                        </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="linkBtnDelete" runat="server" ToolTip="Delete Product"
                                            CommandName="DeleteProduct" CommandArgument='<%#Eval("ProdId") %>'>
                                            <i class="fa fa-trash" style="font-size:30px;color:red;"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; padding-bottom: 20px">
                <tr>
                    <td style="text-align: center; font-style: normal; font-weight: 600;">
                        <asp:LinkButton ID="linkViewProduct" runat="server" PostBackUrl="~/AddProduct.aspx">Add Products</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
