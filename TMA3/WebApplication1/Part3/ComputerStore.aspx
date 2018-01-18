<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComputerStore.aspx.cs" Inherits="WebApplication1.Part3.ComputerStore" %>

<link href="..\tma3_style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <header>
                <asp:Image ID="Image1" AlternateText="Rubber Ducky Photo" runat="server"  BorderStyle="Dotted" ImageUrl="~/Part3/Images/plain-duck.jpg" Height="100px" />
                <h1>  
                    Rubber Ducky's Computers Are Us!
                </h1>
                <h2>
                    Your one stop shop for computer parts!
                </h2> 
        </header>

        
        <div class="HeaderRight">
            <div class ="ShoppingCart">
                <i class="fa fa-shopping-cart" aria-hidden="true"></i>
                <asp:Label ID="ShoppingCart" onClick="ViewShoppingCartContents" runat="server" Text="Items: 0 - $0.0"></asp:Label>
            </div>
            <br />
            <div class="SearchBar" id="search" runat="server">         
                 <asp:TextBox ID="txtSearchMaster" runat="server"></asp:TextBox>
                 <asp:Button ID="btnSearch" OnClick="DisplaySearchResults" runat="server" Text="Search"/>
            </div>
        </div>

        <nav>
            <div class="icon-bar4">
                <a id="home" class="active" href="..\tma3.aspx"><i class="fa fa-home"></i></a> 
                <div class="dropdown">
                    <button id ="btnComputerParts" class="dropbtn inactive">
                        Computer Parts
                        <i class="fa fa-caret-down"></i>
                    </button>
                    <div class="dropContent">
                        <a id=computers href ='#' onserverclick="UpdateViewComputer" runat="server">Computers</a>
                        <a id=ram onserverclick="UpdateViewRam" runat="server">RAM</a>
                        <a id=hardDrives onserverclick="UpdateViewHardDrive" runat="server">Hard Drives</a>
                        <a id=CPU onserverclick="UpdateViewCPU" runat="server">CPUs</a>
                        <a id=displays onserverclick="UpdateViewDisplay" runat="server">Displays</a>
                        <a id=GPUs onserverclick="UpdateViewGPU" runat="server">GPUs</a>
                        <a id=OS onserverclick="UpdateViewOS" runat="server">OSs</a>
                    </div>
                </div>
                <a href="#">Contacts</a>
                <a href="@">Feedback Form</a>
            </div>
        </nav>
        <div id="StoreContent" runat="server">
           
            <asp:ListView ID="ProductsList" runat="server">
                
                <LayoutTemplate>                  
                     <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>                 
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="ComputerComponent">
                        <image width="100" height="100" src="Images\<%#Eval("Type")%>.jpg"></image><br/>
                        <p><%#Eval("Name")%></p>
                        <b><%#Eval("Price")%></b><br/>                       
                        <asp:Button CommandArgument=<%#Eval("idComponent")%> runat="server" OnClick="AddItemToCart" Text="Add To Cart" />
                    </div>   
                </ItemTemplate>

                <EmptyDataTemplate>
                </EmptyDataTemplate>
            </asp:ListView>

            <div  id="computerDisplayList" runat="server" class="ComputerList">

            </div> 
        </div>
    </form>
</body>
</html>
