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
                        <asp:Button ID="btnCheckBalance" class="form-cotrol" runat="server" Text="Check Balance" OnClick="btnVisible_Click"/>
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnDeposite" class="form-cotrol" runat="server" Text="Deposite Amount" OnClick="btnVisible_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="btnWithDrawl" class="form-cotrol" runat="server" Text="Withdraw Balance" OnClick="btnVisible_Click"/>
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnLogOut" class="form-cotrol" runat="server" Text="Log Out" OnClick="btnVisible_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnLogin" class="form-cotrol" runat="server" Text="Cancel" OnClick="btnVisible_Click"/>
                    </div>
                </div>
            </div>
        </div>
        <br />       
        <div class="container" id="contBalance" runat="server" visible="false">
            <h3 class="h1login">Current Balance</h3>
        </div>
        <div class="card" ID="divBalance" visible="false" runat="server">
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
        <br />
        <div class="container" id="contDepo" runat="server" visible="false">
            <h3 class="h1login">Deposite Amount to Account</h3>
        </div>
        <div class="card" ID="divDeposite" visible="false" runat="server">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtDeposite" class="form-control" placeholder="Deposite Amount" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnDepositeAmount" class="form-cotrol" runat="server" Text="Deposite Balance" OnClick="btnTransaction_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblDeposite" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="container" id="contWith" runat="server" visible="false">
            <h3 class="h1login">WithDraw Amount to Account</h3>
        </div>
        <div class="card" ID="divWith" visible="false" runat="server">
            <div class="card-body">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtWithDraw" class="form-control" placeholder="WithDraw Amount" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-6" style="margin-left:auto;margin-right:auto;">
                        <asp:Button ID="btnWithDrawAmout" class="form-cotrol" runat="server" Text="WithDraw Balance" OnClick="btnTransaction_Click"/>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblWithDraw" CssClass="form-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
