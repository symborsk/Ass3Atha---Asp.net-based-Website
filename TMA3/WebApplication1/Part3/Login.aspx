<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Part3.Login" %>

<link href="..\tma3_style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Login Form</title>
</head>

<body>
    <form id="form1" runat="server">
        
        <nav>
            <div class="icon-bar4">
                <a  style="width:100%" id="home" href="ComputerStore.aspx"><i class="fa fa-mail-reply"></i></a> 
            </div>
        </nav>
        
        <div id="LoginSection" runat="server">
            <div style="width: 400px; margin-left: auto; margin-right:auto;">    
                <asp:Image style="margin:10px;text-align:center" ID="Image4" AlternateText="Rubber Ducky Photo" runat="server"  BorderStyle="Dotted" ImageUrl="~/Part3/Images/plain-duck.jpg" Height="200px" ClientIDMode="Static" ImageAlign="Middle" TabIndex="2" Width="400px" />
                <asp:Login style="text-align:center" ID="loginForm" runat="server" OnAuthenticate="loginForm_Authenticate" LoginButtonStyle-BorderStyle="Ridge" PasswordRecoveryText="Recover Password?" PasswordRecoveryUrl="~/Part3/RecoverPassword.aspx" TextBoxStyle-BorderColor="#373737" Width="400" TitleTextStyle-VerticalAlign="Middle" LoginButtonType="Button" DisplayRememberMe="True" LoginButtonStyle-Height="30" LabelStyle-HorizontalAlign="Center" TitleTextStyle-HorizontalAlign="Center" HyperLinkStyle-HorizontalAlign="Center" FailureTextStyle-HorizontalAlign="Center" CheckBoxStyle-HorizontalAlign="Center" FailureTextStyle-VerticalAlign="Middle" HyperLinkStyle-VerticalAlign="Middle" LabelStyle-VerticalAlign="Middle" TextLayout="TextOnLeft" LoginButtonStyle-CssClass="addComputerButton" LoginButtonStyle-Width="385" RememberMeSet="True" CreateUserText="No Account?" CreateUserUrl="~/Part3/RegisterUser.aspx" DestinationPageUrl="~/Part3/ComputerStore.aspx">              
                </asp:Login>
            </div>
       </div>

    </form>
</body>
</html>
