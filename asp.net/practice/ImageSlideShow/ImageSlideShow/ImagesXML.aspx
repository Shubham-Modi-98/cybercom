<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagesXML.aspx.cs" Inherits="ImageSlideShow.ImagesXML" %>

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
                                <asp:Image ID="imgSlideShow" runat="server" Width="500px" Height="450px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <p style="text-align: center; margin-left: auto; margin-right: auto;">
                            <asp:Button BackColor="LawnGreen" ID="btnSlideShow" class="btn btn-success" runat="server" Text="Stop Slide Show" OnClick="btnSlideShow_Click" />
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
