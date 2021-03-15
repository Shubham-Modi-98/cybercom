<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplaySales.aspx.cs" Inherits="Product_Sales_WebApp.DisplaySales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Data Page</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Sales Products Data</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed;">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align: center; color: darkorange; font-style: oblique;">Sales Data List</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align:baseline;text-align:left;">
                        <asp:GridView ID="grData" runat="server" AutoGenerateColumns="False" OnRowDataBound="grData_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                            <Columns>
                                <asp:BoundField HeaderText="#" DataField="RowNo" ItemStyle-Width="10%" />
                                <asp:TemplateField HeaderText="Product Image">
                                    <ItemTemplate>
                                        <asp:Image ID="imgProduct" Height="150px" Width="150px" runat="server"
                                            ImageUrl='<%#"ProductImageHandler.ashx?ImgId="+Eval("ProdId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdName" runat="server" Text='<%#Eval("ProdName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Product Price" DataField="ProdPrice" ItemStyle-Width="20%"/>
                                <asp:TemplateField HeaderText="Sale Qty" ItemStyle-Width="50%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesData" runat="server" Text=""></asp:Label>
                                        <%--<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
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
