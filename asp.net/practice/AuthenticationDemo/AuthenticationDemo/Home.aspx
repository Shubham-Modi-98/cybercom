<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AuthenticationDemo.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: auto; margin-right: auto; padding-top: 15px;">
            <h3 style="text-align: left; padding-left: 20px; color: brown">Welcome, <%=Session["UserName"].ToString() %></h3>
            <table style="margin-left: auto; margin-right: auto; padding-top: 15px; border: dotted; align-content: center;">
                <tr>
                    <td>
                        <asp:GridView ID="grUserData" runat="server"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
