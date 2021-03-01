<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ATM_Transaction_WebApp.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trasaction</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- stylesheet added -->
    <link rel="stylesheet" href="Style.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <h1 class="h1login">Transaction</h1>
    </div>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="btnCheckBalance" class="form-cotrol" runat="server" CommandName="CheckBalance" Text="Check Balance" OnClick="btnVisible_Click"/>
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnDeposite" class="form-cotrol" runat="server" CommandName="Deposite" Text="Deposite Amount" OnClick="btnVisible_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="btnWithDrawl" class="form-cotrol" runat="server" CommandName="WithDraw" Text="Withdraw Balance" OnClick="btnVisible_Click"/>
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnLogOut" class="form-cotrol" runat="server" CommandName="LogOut" Text="Log Out" OnClick="btnVisible_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnLogin" class="form-cotrol" runat="server" CommandName="Cancel" Text="Cancel" OnClick="btnVisible_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Panel ID="panelBalance" runat="server" Visible="false">
            <div class="container" id="contBalance" runat="server">
            <h3 class="h1login">Current Balance</h3>
        </div>
            <div class="card" ID="divBalance" runat="server">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblName" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblBalance" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>
        <br />
        <asp:Panel ID="panelDeposite" runat="server" Visible="false">
            <div class="container" id="contDepo" runat="server">
            <h3 class="h1login">Deposite Amount to Account</h3>
        </div>
            <div class="card" ID="divDeposite" runat="server">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtDeposite" class="form-control" placeholder="Deposite Amount" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnDepositeAmount" class="form-cotrol" runat="server" CommandName="DepositeAmount" Text="Deposite Balance" OnClick="btnTransaction_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblDeposite" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>
        <br />
        <asp:Panel ID="panelWithDraw" runat="server" Visible="false">
            <div class="container" id="contWith" runat="server">
            <h3 class="h1login">WithDraw Amount to Account</h3>
        </div>
            <div class="card" ID="divWith" runat="server">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtWithDraw" class="form-control" placeholder="WithDraw Amount" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnWithDrawAmout" class="form-cotrol" runat="server" CommandName="WithDrawAmount" Text="WithDraw Balance" OnClick="btnTransaction_Click"/>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblWithDraw" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        </asp:Panel>
    </form>
</body>
</html>
