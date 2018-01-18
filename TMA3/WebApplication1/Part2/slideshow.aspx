<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slideshow.aspx.cs" Inherits="WebApplication1.slideshow" %>

<!DOCTYPE html>

<link href="..\tma3_style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       

    <div>
        <header>
            <h1>  
            Assignment #3 COMP 466
            </h1>
            <h2>
            Advanced Technologies for Web-Based Systems
            </h2> 
            <h3>
            John Symborski, 3339305 
            </h3>
            <h4>
            Jan 10, 2018 -  TBD  Hours Spent: TBD
            </h4>
        </header>

        <nav>
            <div class="icon-bar4">
                <a id="home" class="inactive" style="width:100%" href="..\tma3.aspx"><i class="fa fa-home"></i></a> 
            </div>
        </nav>
    </div>
        
        <center>
            <asp:ScriptManager ID="SlideshowManager" runat="server"></asp:ScriptManager>
            <asp:Image CssClass="ImageSlide" ID="SlideshowImage" runat="server" Height="400" Width="400" ImageAlign="Middle" />
            <asp:Timer ID="SlideShowTimer" OnTick="SlideShowTimer_Tick" Enabled="false" runat="server" Interval="3000"></asp:Timer>
            <br/>
            <br/>
            <asp:Label CssClass="ImageCaption" ID="Caption" runat="server" Text=""></asp:Label>
        </center>

        <div class="controlPanel">
            <div>
                <asp:Button ID="StartStop" OnClick="StartStop_Click" runat="server" Text="Start" />
            </div>
        <div>
            <asp:DropDownList ID="SequenceOption" runat="server">
                <asp:ListItem Value="Sequential" Text="Sequential" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Random" Value="Random"></asp:ListItem>
            </asp:DropDownList> 
        </div>
        <div>
            <asp:Button ID="Previous" runat="server" OnClick="Previous_Click" Text="Previous" />
            <asp:Button ID="Next" runat="server" OnClick="Next_Click" Text="Next" />
        </div>
    </div>
       
    </form>
</body>
</html>
