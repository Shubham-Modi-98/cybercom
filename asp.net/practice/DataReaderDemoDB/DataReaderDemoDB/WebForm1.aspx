<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DataReaderDemoDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvStud" runat="server">

                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text="Id:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpId_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="I" OnClick="btnIUD_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="U" OnClick="btnIUD_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="D" OnClick="btnIUD_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
