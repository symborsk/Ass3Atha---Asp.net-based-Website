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
                 <div style="float:right">
                    <asp:Button ID="Login" runat="server" OnClick="Login_Click" Text="Login"/>
                    <asp:Button ID="CreateUser" runat="server" OnClick="CreateUser_Click" Text="Create User"/>
                </div>    
                <asp:Image ID="Image1" AlternateText="Rubber Ducky Photo" runat="server"  BorderStyle="Dotted" ImageUrl="~/Part3/Images/plain-duck.jpg" Height="100px" />
                <h1>  
                    Rubber Ducky's Computers Are Us!
                </h1>
          
                
                <h2>
                    Your one stop shop for computer parts!
                </h2> 
        </header>

        <div id="modalDialogComputer" class="modalAddComputer" runat="server" visible="false">
            <asp:Panel ID="Panel1" runat="server" CssClass="modalForm">
                <asp:Image ID="Image2" style="margin-top:10px" AlternateText="Rubber Ducky Photo" runat="server"  BorderStyle="Dotted" ImageUrl="~/Part3/Images/plain-duck.jpg" Height="60px" />
                <h1> Rubber Ducky's Computers Are Us!</h1>
                <h2>Computer Configuration</h2>
                <h3>Choose our configurations and feel free to customize</h3>
                
                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="ComputerConfig" runat="server" Text="Computer Config"></asp:Label>
                    <asp:DropDownList ID="ComputerDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="RamLabel" runat="server" Text="Ram: "></asp:Label>
                    <asp:DropDownList ID="RamDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="CPULabel" runat="server" Text="CPU: "></asp:Label>
                    <asp:DropDownList ID="CpuDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="DsiplayLabel" runat="server" Text="Display: "></asp:Label>
                    <asp:DropDownList ID="DisplayDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="HardDriveLabel" runat="server" Text="Hard Drive: "></asp:Label>
                    <asp:DropDownList ID="HardDriveDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="GPULabel" runat="server" Text="GPU: "></asp:Label>
                    <asp:DropDownList ID="GPUDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class ="dropDownItemLabel">
                    <asp:Label CssClass="ModalLabel" ID="OSLabel" runat="server" Text="OS: "></asp:Label>
                    <asp:DropDownList ID="OSDropDown" OnSelectedIndexChanged="ComputerDropDown_SelectedIndexChanged" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="DropDownItemLabel">
                    <asp:Label ID="TotalCostModal" runat="server" Text="Total Cost: $0.00"></asp:Label>
                </div>
            
                <div style="text-align:center">
                    <asp:Button CssClass="modalButtons" ID="AddComputer" runat="server" OnClick="AddComputer_Click" Text="Add Parts To Cart" />
                    <asp:Button CssClass="modalButtons" ID="CancelComputer" runat="server" OnClick="CancelComputer_Click" Text="Cancel" />
                </div> 
            </asp:Panel>
        </div>

        <div id="ShoppingCartContents" class="modalAddComputer" runat="server" visible="false">
            <asp:Panel ID="ModalShoppingCart" runat="server" CssClass="modalForm">         
                <asp:ListView ID="ShoppingCartData" runat="server">               
                    <LayoutTemplate>                  
                         <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>                 
                    </LayoutTemplate>

                    <ItemTemplate>
                        <div class="ComputerComponent">   
                                <image width="50" height="50" src="Images\<%#Eval("Type")%>.jpg"></image><br/>
                                <p><%#Eval("Name")%></p>
                                <b><%#Eval("Price")%></b><br />   
                                <b> Quantity: <%#Eval("Count")%></b><br />
                               <div style="text-align:center"> 
                                 <asp:Button CommandArgument=<%#Eval("idComponent")%> runat="server" OnClick="DeleteItemFromCart" Text="Remove" />
                                </div>
                        </div>           
                    </ItemTemplate>

                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                </asp:ListView>

                 <div style="text-align:center">
                    <asp:Button CssClass="modalButtons" ID="SubmitCart" runat="server" OnClick="SubmitCart_Click" Text="Submit Cart" />
                    <asp:Button CssClass="modalButtons" ID="CloseCart" runat="server" OnClick="CloseCart_Click" Text="Close Cart" />
                </div>
            </asp:Panel>
        </div>
                  
        <div class="HeaderRight">
            <div class="ShoppingCart">
                <i runat="server" class="fa fa-shopping-cart" aria-hidden="true"></i>
                <asp:Label ID="ShoppingCart" onClick="ViewShoppingCartContents" runat="server" Text="Items: 0 - $0.0"></asp:Label>
                <asp:Button ID="ViewCartContent" runat="server" OnClick="ViewShoppingCartContents" Text="View Content" />
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
                <a id="ContactsLink" href="#" runat="server" onserverclick="ContactsLink_ServerClick">Contacts</a>
                <a id="FeedbackLink" href="#" runat="server" onserverclick="FeedbackLink_ServerClick" >Feedback Form</a>
            </div>
        </nav>

        <div id="ComputerComponentContent" runat="server">           
            <asp:ListView ID="ProductsList" runat="server">               
                <LayoutTemplate>                  
                     <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>                 
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="ComputerComponent">
                        <image width="100" height="100" src="Images\<%#Eval("Type")%>.jpg"></image><br/>
                        <p><%#Eval("Name")%></p>
                        <b><%#Eval("Price")%></b><br/>                       
                        <asp:Button CommandArgument=<%#Eval("idComponent")%> runat="server" OnClick="AddItemToCart_OnClick" Text="Add To Cart" />
                    </div>   
                </ItemTemplate>

                <EmptyDataTemplate>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>

        <div  id="computerDisplayList" runat="server"  visible="false">
            <div style="text-align:center">
                <asp:Button ID="AddComputerButton" CssClass="addComputerButton" runat="server" OnClick="AddComputerConfiguration_Click" Text="Add Computer To Cart" />
            </div>
                
            <div id="computerConfigList" class="ComputerList" runat="server">
            </div>
        </div>


        <div id="ContactsPage" style="text-align:center" runat="server"  visible="false">
            <h1 style="text-align:center">Contacts: </h1>

            <h5>Mr. Rubber Ducky CEO, 780-777-77777, duck@gmail.com</h5>
            <br />
            <br />
            <h5>Mr.Webbed Website Designer, 403-333-3333, webbed@gmail.com</h5>
            <br />
            <br />
            <h5>Mr.Quacktastic Salesman, 403-222-2222, quack@gmail.com</h5>
        </div>

        <div style="text-align:center" id="FeedbackForm" runat="server"  visible="false">
            <asp:Panel ID="FeedbackPanel" runat="server">
                <h1 style="text-align:center">Give us your feedback: </h1>
                <asp:TextBox Height="300" Width="400" ID="FeedbackFormTextbox" runat="server" TextMode="MultiLine">

                </asp:TextBox>
                <div style="text-align:center">
                    <asp:Button CssClass="addComputerButton" ID="SubmitFormFeedback" OnClick="SubmitFormFeedback_Click" runat="server" Text="Send Feedback"/>
                </div>
            </asp:Panel>
        </div>

    </form>
</body>
</html>
