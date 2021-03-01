<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATM_Transaction_WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- stylesheet added -->
    <link rel="stylesheet" href="Style.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panelLogin" runat="server">
            <div class="container">
                <h1 class="h1login">Welcome Back,</h1>
            </div>
            <div class="card">
                <div class="card-body">

                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtName" class="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtPin" class="form-control" placeholder="Pin Number" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Button ID="btnLogin" class="form-cotrol" runat="server" CommandName="Login" Text="Sign In" OnClick="btnLoginFRegister_Click" />
                        </div>
                    </div>
                    <p class="pText">OR</p>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Button ID="btnLogOut" class="form-cotrol" runat="server" CommandName="ShowRegister" Text="Sign Up" OnClick="btnLoginFRegister_Click" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="panelRegister" runat="server" Visible="false">
            <div class="container">
                <h1 class="h1login">Create New Account</h1>
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="TextBox1" class="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobie Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="TextBox2" class="form-control" placeholder="Pin Number" TextMode="Number" MaxLength="4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtBalance" class="form-control" placeholder="Balance Amount" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtLimit" class="form-control" placeholder="Withdrawl Limit Amount" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Button ID="btnRegister" class="form-cotrol" runat="server" CommandName="Register" Text="Sign Up" OnClick="btnLoginFRegister_Click" />
                        </div>
                    </div>
                    <p class="pText">OR</p>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Button ID="btnCancel" class="form-cotrol" runat="server" CommandName="ShowLogin" Text="Sign In" OnClick="btnLoginFRegister_Click" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-12">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
