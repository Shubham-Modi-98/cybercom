<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleProducts.aspx.cs" Inherits="Product_Sales_WebApp.SaleProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sale Products Page</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Sale Products</h1>
        <form id="form1" runat="server">
            <%--<asp:Label ID="lblDbQty" runat="server" Visible="false"></asp:Label>--%>
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed; width: 40%">
                <tr>
                    <td colspan="2">
                        <h2 style="text-align: center; color: darkorange; font-style: oblique;">Select Product</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; margin-left: auto; margin-right: autop; padding-bottom: 30px; padding-top: 20px;">
                        <asp:DropDownList ID="drpProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpProducts_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>

                <asp:Panel ID="panelBill" runat="server" Visible="false">

                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblProdId" runat="server" Text="Product Id"></asp:Label>&nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProdId" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>&nbsp;
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProdName" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblProdQty" runat="server" Text="Prouct Qty"></asp:Label>&nbsp;

                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtProdQty" runat="server" Width="150px" AutoPostBack="True" OnTextChanged="txtProdQty_TextChanged"></asp:TextBox>
                            
                            

                            <asp:RequiredFieldValidator ID="rfvProdQty" runat="server" ErrorMessage="Quantity is Required"
                                Text="*" ForeColor="Red" ControlToValidate="txtProdQty" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RequiredFieldValidator>

                            <asp:RangeValidator ID="rgProdQty" runat="server" ErrorMessage="Quatity must be greater than 0"
                                MinimumValue="1" MaximumValue="100000" Type="Integer" Text="*" ForeColor="Red" ControlToValidate="txtProdQty" Display="Dynamic" Font-Bold="true" ValidationGroup="FormValidation"></asp:RangeValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                        </td>
                        <td class="auto-style1" style="text-align: left">
                            <asp:Label ID="lblDbQty" runat="server" Text =""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>&nbsp;
                        </td>
                        <td class="auto-style1" style="text-align: left">
                            <asp:TextBox ID="txtProdPrice" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Price"></asp:Label>&nbsp;
                        </td>
                        <td class="auto-style1" style="text-align: left">
                            <asp:TextBox ID="txtTotalPrice" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-top: 15px;">
                            <asp:Button ID="btnBill" runat="server" Text="Generate Bill" OnClick="btnBill_Click" Width="150px" Height="40px" />
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
