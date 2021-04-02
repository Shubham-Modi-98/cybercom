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
                url: "AllProdcutFetchService.asmx/fetchAllProd",
                success: function (data) {
                    $('#prodTable').DataTable({
                        data: data,
                        columns: [
                            { 'data': 'prodId' },
                            { 'data': 'prodName' },
                            { 'data': 'prodQty' },
                            { 'data': 'prodPrice' },
                            {
                                'data': 'prodImage', 'render': function (data, type, full, meta) {
                                    var img = 'data:img;base64,' + data;
                                    return '<img src = "' + img + '" height="100px" width="100px" />'
                                }
                                //function (ProdName) {
                                //    var date = new Date(parseInt(date.substr(6)));
                                //    var month = date.getMonth() + 1;
                                //    return date.getDate() + "/" + month + "/" + date.getFullYear();
                                //}
                            }
                        ]
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table" id="prodTable">
                <thead>
                    <tr>
                        <td>Product Id</td>
                        <td>Name</td>
                        <td>Qty</td>
                        <td>Price</td>
                        <td>Image</td>
                    </tr>
                </thead>
            </table>
        </div>
    </form>
</body>
</html>
