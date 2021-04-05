<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductData.aspx.cs" Inherits="Product_Sales_WebApp.ProductData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="DataTables/jquery-3.3.1.js"></script>
    <script src="DataTables/DataTables-1.10.24/js/jquery.dataTables.js"></script>
    <link href="DataTables/DataTables-1.10.24/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="DataTables/DataTables-1.10.24/css/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="DataTables/DataTables-1.10.24/css/dataTables.bootstrap4.css" rel="stylesheet" />

    <script type="text/javascript">    
        $(document).ready(function () {    
            //Once the document is ready call Bind DataTable    
            BindDataTable()    
        });    
    
        function BindDataTable() {    
            $('#tblDataTable').DataTable({    
                "processing": true,    
                "serverSide": true,    
                "ajax": {    
                    url: "ProductDataService.asmx/GetDataForDataTable", type: "post" },    
                "columns": [    
                    { "data": "ProdId" },    
                    { "data": "ProdName" },    
                    {
                        'data': 'ProdImage', 'render': function (data, type, full, meta) {
                            var img = 'data:img;base64,' + data;
                            return '<img src = "' + img + '" height="100px" width="100px" />'
                        }
                    },   
                    { "data": "ProdQty" },  
                    { "data": "ProdPrice" }    
                ]    
            });    
        }    
    </script>

</head>
<body>    
    <form id="form1" runat="server">    
        <div>    
            <!--Structure of the table with only header-->    
            <table id="tblDataTable" class="display">    
                <thead>    
                    <tr>    
                        <th>Prod Id</th>    
                        <th>Prod Name</th>    
                        <th>Image</th>    
                        <th>Qty</th>    
                        <th>Price</th>    
                    </tr>         
                </thead>    
            </table>    
        </div>    
    </form>    
</body></html>
