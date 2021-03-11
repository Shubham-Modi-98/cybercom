<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalBill.aspx.cs" Inherits="Product_Sales_WebApp.FinalBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank you!</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Thank You for Shopping with Us!</h1>
        <form id="form1" runat="server">
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed; width: 40%">
                <tr>
                    <td colspan="2">
                        <h2 style="text-align: center; color: darkorange; font-style: oblique;">Modi Sales</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <p style="text-align: center; color: darkorange;">Final Bill :- <%=DateTime.Now.ToString()%></p>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblBill" runat="server" Text="Bill Id"></asp:Label>&nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblBillId" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblId" runat="server" Text="Product Id"></asp:Label>&nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblProdId" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblName" runat="server" Text="Product Name"></asp:Label>&nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblProdName" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblQty" runat="server" Text="Prouct Qty"></asp:Label>&nbsp;

                    </td>
                    <td style="text-align: left">
                        <asp:Label ID="lblProdQty" runat="server" Font-Bold="true"></asp:Label>&nbsp;

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblPrice" runat="server" Text="Product Price"></asp:Label>&nbsp;
                    </td>
                    <td class="auto-style1" style="text-align: left">
                        <asp:Label ID="lblProdPrice" runat="server" Font-Bold="true"></asp:Label>&nbsp;

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblAmount" runat="server" Text="Total Price"></asp:Label>&nbsp;
                    </td>
                    <td class="auto-style1" style="text-align: left">
                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>&nbsp;

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:LinkButton ID="linkAdd" runat="server" PostBackUrl="~/AddProduct.aspx">Print</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
