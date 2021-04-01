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
                        <asp:GridView ID="grData" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" OnPageIndexChanging="grData_PageIndexChanging" PageSize="2" CellSpacing="2">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="3" PreviousPageText="Prev" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
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
                                            OnClick ="linkBtnEditDelete_Click"
                                            CommandName="EditProduct" CommandArgument='<%#Eval("ProdId") %>'>
                                            <i class="fa fa-edit" style="padding-left:10px; font-size:30px;"></i>
                                        </asp:LinkButton>
                                        &nbsp;&nbsp;
                                        <asp:LinkButton ID="linkBtnDelete" runat="server" ToolTip="Delete Product"
                                            OnClick ="linkBtnEditDelete_Click"
                                            OnClientClick ="return confirm('Are you sure want to delete product permanently?')"
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
