<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NaviGO.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #main
        {
            height:500px;
        }
        #left
        {
            float:left;
        }
        #right
        {
           padding-top:26px;
           margin-left:550px;
           position:absolute;

        }
        h3
        {
            font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
            font-size:25px;
            color:darksalmon;
        }
    </style>
    <div id="main">
    <div id="left">
    <div id="left-text">
    <h3>Need More Informations?<br /> Contact Us</h3>
    <hr style="width:410px; margin-left:0px;" />
    <h4>By Phone:</h4>
    <address>
        <strong>Tel:</strong><span>+389 2 3255-300</span><br />
        <strong>Fax:</strong><span>+ 389 2 3255-721</span>
    </address>
    <h4>By Mail:</h4>
    <address>
        <strong>Support:</strong>   <a href="mailto:support@navigo.com">support@navigo.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:marketing@navigo.com">marketing@navigo.com</a><br />
        <strong>CEO:</strong> <a href="mailto:ceo@navigo.com">ceo@navigo.com</a>
    </address>
    </div>
    <div id="right-gif" style="float:right; width:150px; margin-right:0px; margin-top:-130px">
        <img src="/img/airplane.gif" style="width:150px"/>
    </div>
    </div>
    <div id="right" >
    <h3>Our Location</h3>
    <hr style="width:410px; margin-left:0px;" />
    <div>
    <address>
        St."Dame Gruev" no.10<br />
        1000 Skopje<br />
        Republic of Macedonia<br />
    </address>
    
    </div>
    <div style="float:right; margin-top:-80px; margin-right:-15px">
        <a href="https://goo.gl/maps/jideSEwewJn" target="_blank"><img src="/img/map.jpg" style="width:220px; border-radius:50%; border-style:solid;border-color:darksalmon; border-width:4px"/></a>
    </div>
        <h4>Click on the map to get the exact location!</h4>
    </div>
        
   </div>
</asp:Content>
