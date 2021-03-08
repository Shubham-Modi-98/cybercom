<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagesDB.aspx.cs" Inherits="ImageSlideShow.ImagesDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-top: 30px;">
            <table style="margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="timerImage" runat="server" OnTick="timerImage_Tick" Interval="2000"></asp:Timer>
                                <b style="text-align: center;">Image Name: </b>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                <br />
                                <b style="text-align: center;">Image Order: </b>
                                <asp:Label ID="lblOrder" runat="server" Text=""></asp:Label>
                                <br />
                                <br />
                                <asp:ImageButton ID="imgSlideShow" runat="server" Width="500px" Height="450px" OnClick="imgSlideShow_Click" />
                                <%--<asp:Image ID="imgslideshow" runat="server" Width="500px" Height="450px" />--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
