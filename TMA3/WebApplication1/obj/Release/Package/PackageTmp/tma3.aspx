<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tma3.aspx.cs" Inherits="TMA3.HostPage" %>

<!DOCTYPE html>

<link href="tma3_style.css" rel="stylesheet" type="text/css">
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
                    <a id="home" class="active" href="tma3.aspx"><i class="fa fa-home"></i></a> 
                    <a id="VisitTracker" onserverclick="PersistentCookie_OnClick" runat="server">Visit Tracker</a>
                    <a href="Part2\slideshow.aspx">Slide Show</a>
                    <a href="Part3\ComputerStore.aspx">Computer Store</a>
                </div>
            </nav>

            <div id="contentWindow" runat="server">
            </div>
        </div>
    </form>
</body>
</html>
