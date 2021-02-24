<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="ATM_Transaction_WebApp.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- stylesheet added -->
    <link rel="stylesheet" href="Style.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
     <div class="container">
         <h1 class="h1login">Create New Account</h1>
     </div>
    <div class="card">
        <div class="card-body">
            <form id="form1" runat="server">
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtName" class="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobie Number" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:TextBox ID="txtPin" class="form-control" placeholder="Pin Number" TextMode="Number" MaxLength ="4" runat="server"></asp:TextBox>
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
                        <asp:Button ID="btnRegister" class="form-cotrol" runat="server" Text="Create Account" OnClick="btnRegister_Click"/>
                    </div>
                </div>
                <p class="pText">OR</p> 
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Button ID="btnLogin" class="form-cotrol" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-12">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </form>
        </div>
    </div>
</body>
</html>
