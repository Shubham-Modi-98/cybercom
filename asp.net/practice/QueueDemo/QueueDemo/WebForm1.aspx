<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="QueueDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top:20px; width:auto; margin-left:auto; margin-right:auto;">
            <table style="border:1px solid black; text-align:center;">
                <tr>
                    <td>Cunter 1</td>
                    <td>Cunter 2</td>
                    <td>Cunter 3</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCounter1" runat="server" Width="150px" ForeColor="White" BackColor="Blue" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCounter2" runat="server" Width="150px" ForeColor="White" BackColor="Blue" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCounter3" runat="server" Width="150px" ForeColor="White" BackColor="Blue" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnNext1" runat="server" Text="Next" Width="150px" OnClick="btnNext_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnNext2" runat="server" Text="Next" Width="150px" OnClick="btnNext_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnNext3" runat="server" Text="Next" Width="150px" OnClick="btnNext_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="txtMessage" runat="server" ForeColor="White" BackColor="Green" Font-Size="Large" Width="500px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="listNames" runat="server" Width="150px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnPrintToken" runat="server" Text="Print Token" OnClick="btnPrintToken_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblStatus" runat="server" Font-Size="Larger" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
