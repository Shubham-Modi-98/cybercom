<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplaySalesDT.aspx.cs" Inherits="Product_Sales_WebApp.DisplaySalesDT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Data DataTable</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/dt/dt-1.10.24/datatables.min.css"/>
    <script type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.10.24/datatables.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "SalesData.asmx/GetSalesData",
                success: function (data) {
                    $('#prodTable').DataTable({
                        data: data,
                        columns: [
                            { 'data': 'ProdId' },
                            { 'data': 'ProdName' },
                            { 'data': 'ProdPrice' },
                            {
                                'data': 'ProdImage', 'render': function (data, type, full, meta) {
                                    var img = 'data:img;base64,' + data;
                                    return '<img src = "' + img + '" height="100px" width="100px" />'
                                }
                            }
                        ]
                    });
                }
            });
        });
    </script>
</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">Sales Products Data</h1>
        <form id="form1" runat="server">
            <table id="prodTable" class="table">
                <thead>
                    <tr>
                        <td>Prod Id</td>
                        <td>Prod Name</td>
                        <td>Price</td>
                        <td>Image</td>
                    </tr>
                </thead>
            </table>

            <%--<table style="margin-left: auto; margin-right: auto; padding-top: 10px; border: dashed;">
                <tr>
                    <td colspan="2">
                        <h1 style="text-align: center; color: darkorange; font-style: oblique;">Sales Data List</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align:baseline;text-align:left;">
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <thead>
                    <tr>
                        <td>No</td>
                        <td>Prod Id</td>
                        <td>Product Name</td>
                    </tr>
                </thead>
            </table>
            <table style="margin-left: auto; margin-right: auto; padding-top: 10px; padding-bottom: 20px">
                <tr>
                    <td style="text-align: center; font-style: normal; font-weight: 600;">
                        <asp:LinkButton ID="linkViewProduct" runat="server" PostBackUrl="~/AddProduct.aspx">Add Products</asp:LinkButton>
                    </td>
                </tr>
            </table>--%>
        </form>
    </div>
</body>
</html>
