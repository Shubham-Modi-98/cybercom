<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewData.aspx.cs" Inherits="AutoCompleteTextBox.ViewData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Data</title>
    <link href="jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="jquery.js" type="text/javascript"></script>
    <script src="jquery-ui.min.js" type="text/javascript"></script>

    <script type="text/javascript" lang="javascript">
       $(function () {
            $('#<%= txtEmpName.ClientID %>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ShowData.asmx/GetEmployeeName",
                        data: "{'empName':'" + document.getElementById('txtEmpName').value + "'}",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("no match");
                        }
                    });
                } 
            })
        })
        //$(document).ready(function () {
        //    SearchText();
        //});
        //function SearchText() {
        //    $("#txtEmpName").autocomplete({
        //        source: function (request, response) {
        //            $.ajax({
        //                type: "POST",
        //                contentType: "application/json; charset=utf-8",
        //                url: "ShowData.asmx/GetEmployeeName",
        //                data: "{'empName':'" + request.term + "'}",
        //                dataType: "json",
        //                success: function (data) {
        //                    alert("hello")
        //                    response(data.d);
        //                },
        //                error: function (result) {
        //                    alert("no match");
        //                }
        //            });
        //        }
        //    });
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="10" cellspacing="10" align="center" style="border:0;width:50%;">
            <tr>
                <td>
                    <span style="font-weight: bold; font-size: 14pt;">Enter Employee Name:</span>
                    <asp:TextBox ID="txtEmpName" runat="server" Width="160px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
