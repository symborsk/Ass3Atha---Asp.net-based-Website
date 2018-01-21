<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriorOrders.aspx.cs" Inherits="WebApplication1.Part3.PriorOrders" %>

<link href="..\tma3_style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users Prior Orders</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <div class="icon-bar4">
                <a  style="width:100%" id="home" href="ComputerStore.aspx"><i class="fa fa-mail-reply"></i></a> 
            </div>
        </nav>
        
        <div id="PriorOrderList" runat="server">
        </div>
    </form>
</body>
</html>
