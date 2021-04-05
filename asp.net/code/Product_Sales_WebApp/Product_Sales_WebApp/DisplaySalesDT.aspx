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
                url: "ProductSalesWS.asmx/GetSalesData",
                success: function (data) {
                    $('#prodTable').DataTable({
                        data: data,
                        columns: [
                            { 'data': 'ProdName' },
                            {
                                'data': 'Image', 'render': function (data, type, full, meta) {
                                    var img = 'data:img;base64,' + data;
                                    return '<img src = "' + img + '" height="100px" width="100px" />'
                                }
                            },
                            { 'data': 'Qty' },
                            { 'data': 'TotalPrice' },
                            { 'data': 'SalesDate' }
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
            <table class="table" id="prodTable">
                <thead>
                    <tr>
                        <td>Product Name</td>
                        <td>Image</td>
                        <td>Qty</td>
                        <td>Total Price</td>
                        <td>Sales Date</td>
                    </tr>
                </thead>
            </table>
        </form>
    </div>
</body>
</html>