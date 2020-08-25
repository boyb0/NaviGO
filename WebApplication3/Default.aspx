    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NaviGO._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .container
        {
            position: relative;
            text-align:center;        }
        .bottom
        {
            position: absolute;
            bottom: 42px;
            
        }
        .login
        {
            font-size:30px;
            color:blanchedalmond;
            background-color:black;
            margin-bottom:-12px;
            padding-left:15px;
            text-align:left;
            width:350px;
            margin-left:792px;

            
        }
        .kopce1
        {
            position:absolute;
            left:360px;
            bottom:40px;
            color:forestgreen;
            
        }
        .kopce2
        {
            position:absolute;
            right:360px;
            bottom:-2px;
        }
        .account
        {
            font-size:30px;
            color:blanchedalmond;
            background-color:black;
            margin-bottom:-12px;
            padding-left:15px;
            text-align:left;
            width:350px;
        }
        .welcome
        {
            margin: 0 auto;
            margin-left:5px;
            margin-bottom:-20px;
        }
        h1
        {
            text-align: center;
            font-weight: normal;
            color: #fff;
            text-transform: uppercase;
            font-size: 2em;
            white-space: nowrap;
            font-size: 4vw;
            z-index: 1000;
            font-family: Georgia, serif;
            text-shadow: 5px 5px 0 rgba(0, 0, 0, 0.7);
        }
        h3
        {
            font-family:Impact;
            font-size:30px;
        }
        #left-side
        {
            float:left;
        }
        #center-side
        {
            margin-left: auto;
            margin-right: auto;
            width: 270px;
            margin-top:-28px;
            
        }
        #right-side
        {
            float:right;
            margin-top:-835px;
            font-size:5px;
        }
        .par
        {
            width:270px;
            text-align:left;
            font-size:5px;
            padding-top:10px;
            font-family:Calibri;
        }

     </style>
  <div class ="container">
  <img  src="/img/bus1.jpg" style="width:100%">
  <div class="bottom"><div class="welcome"><h1>Welcome to NaviGO</h1></div><br /><div class="account"><p>Don't have an account?</p> </div></div>
  <div class ="kopce1"><asp:Button ID="btnRegister" runat="server" Text="REGISTER" PostBackUrl="~/Account/Register.aspx" Height="42px" Width="103px" BackColor="#339966" CssClass="btn active" Font-Bold="True" Font-Names="Century Gothic" /></div>
  <div class="login"><p>Already our user?</p></div>
  <div class ="kopce2"><asp:Button ID="btnLogin" runat="server" Text="SIGN IN" PostBackUrl="~/Account/Login.aspx" Height="42px" Width="103px" BackColor="#669999" CssClass="btn" Font-Bold="True" Font-Names="Century Gothic" /></div>

</div>
    <div class="jumbotron" style="">
        <div id="left-side"><h3>Our Mission</h3><img src ="/img/bus4.jpg" style="height:270px; border-bottom:solid; border-color:#669999; border-width:8px">
            <p class="par">We are a global mobility provider, offering new alternatives for convenient, affordable and eco-friendly travel. 
                Thanks to a unique business model and innovative technology, we have quickly established one of the largest long-distance mobility networks in the world – and our journey has just begun.</p>
        </div>
        <div id="center-side"><h3>Customer Statisfaction</h3><img src ="/img/customers.jpg" style="height:270px; border-bottom:solid;  border-color:#339966; border-width:8px">
            <p class="par">At NaviGO, we go to great lengths to ensure our passengers are satisfied. The success of our efforts was recently confirmed by a survey completed by 20,000 of our passengers. 
                In addition to the large amount of positive feedback we received, we were able to find out more about your needs. 
                We are constantly trying to improve the quality of customer experience, from the booking process right through to any queries you may have after your journey with us.</p>
        </div>
        <div id="right-side"><h3>Go Green!</h3><img src ="/img/nature.jpg" style="height:270px; border-bottom:solid; border-color:#669999; border-width:8px">
            <p class="par">NaviGO busses are demonstrably efficient in terms of fuel consumption and they emit an extremely low level of greenhouse gases. 
                It is of course difficult to travel without producing any CO2 emissions at all, even in the most environmentally friendly bus. 
                Due to this fact, we offer each of our passengers the option of offsetting the climate impact of your NaviGO journey when booking.
                
            </p>
        </div>
    </div>

</asp:Content>
