<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayProdDT.aspx.cs" Inherits="Product_Sales_WebApp.DisplayProdDT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display DT Product</title>

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Bootstrap CSS -->
    <script src="DataTables/jquery-3.3.1.js"></script>
    <script src="DataTables/DataTables-1.10.24/js/jquery.dataTables.js"></script>
    <link href="DataTables/DataTables-1.10.24/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="DataTables/DataTables-1.10.24/css/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="DataTables/DataTables-1.10.24/css/dataTables.bootstrap4.css" rel="stylesheet" />

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
                            { 'data': 'ProdId' },
                            { 'data': 'ProdName' },
                            {
                                'data': 'ProdImage', 'render': function (data, type, full, meta) {
                                    var img = 'data:img;base64,' + data;
                                    return '<img src = "' + img + '" height="100px" width="100px" />'
                                }
                            },
                            { 'data': 'ProdQty' },
                            { 'data': 'ProdPrice' }
                        ]
                    });
                }
            });
        });
    </script>

</head>
<body>
    <div style="margin-left: auto; margin-right: auto; padding-top: 20px;">
        <h1 style="text-align: center; color: darkgoldenrod">All Products Data</h1>
        <form id="form1" runat="server">
            <table id="prodTable" class="table">
                <thead>
                    <tr>
                        <td>Prod Id</td>
                        <td>Prod Name</td>
                        <td>Image</td>
                        <td>Quantity</td>
                        <td>Price</td>
                    </tr>
                </thead>
            </table>
        </form>
    </div>
</body>
</html>
