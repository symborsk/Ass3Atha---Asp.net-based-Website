<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="WebApplication1.Part3.RegisterUser" %>

<link href="..\tma3_style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register User Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div class="icon-bar4">
                    <a  style="width:100%" id="home" href="ComputerStore.aspx"><i class="fa fa-mail-reply"></i></a> 
                </div>
            </nav>

            <h1>Register User:</h1>
            <div>
                <asp:Label ID="InformationText" runat="server" Text="" Font-Bold="True"></asp:Label>
            </div>
            
            <div>
                <asp:Label ID="Label1" runat="server" Text="Username: " Width="180"></asp:Label>
                <asp:TextBox ID="UsernameText" runat="server" Width="300" Height="20" TextMode="SingleLine"></asp:TextBox>
            </div>

            <div style="display:inline">
                <asp:Label ID="Label2" runat="server" Text="Password: " Width="180"></asp:Label>
                <asp:TextBox ID="Password" runat="server" Width="300" Height="20" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label3" runat="server" Text="Confirm Password: " Width="180"></asp:Label>
                <asp:TextBox ID="PasswordConfirm" runat="server" Width="300" Height="20"  TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label4" runat="server" Text="Email Address: " Width="180"></asp:Label>
                <asp:TextBox ID="Email" runat="server" Width="300" Height="20" TextMode="Email"></asp:TextBox>
            </div>

            
            <div style="width:25%;text-align:center">
                <asp:Button Height="30" CssClass="addComputerButton" ID="CreateUserButton" runat="server" OnClick="CreateUserButton_Click" Text="Create User" />
            </div>
            

        </div>
    </form>
</body>
</html>
