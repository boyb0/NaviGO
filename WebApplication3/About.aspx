<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NaviGO.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .m-par
        {
            float:left;
            width:500px;
            margin-left:40px;
            font-size:17px;
            font-family:Calibri;
        }
        .m-img
        {
            margin-left:580px;
        }
        h3
        {
            font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
            font-size:25px;
            color:darksalmon;
        }
        .s-par
        {
            float:right;
            width:500px;
            font-size:17px;
            font-family:Calibri;
            margin-right:180px;
            margin-top:-230px;

        }
        .s-img
        {
            margin-left:40px;
        }
        .bozo
        {
            float:left;
            margin-left:35px;
            text-align:center;
        }
        .ana
        {
            margin-left: auto;
            margin-right: auto;
            width: 270px;
            text-align:center;
        }
        .zoc
        {
            float:right;
            text-align:center;
            margin-right:35px;
            margin-top:-377px;
            
        }
        h4
        {
              font-style:oblique;
        }
        .par
        {
            width:300px;
        }
    </style>
    <h3>NaviGO Mobility</h3>
    <hr style="width:240px; margin-left:0px;" />
    <div id="mobility" style="height:auto">
    <div class="m-par">
    <p>NaviGO Mobility is a young mobility provider that has been changing the way millions of people travel in Europe since 2013 via its NaviGO brand. 
        As a unique combination of tech-startup, e-commerce platform and transportation company, NaviGO quickly became Macedonia’s largest intercity bus network, helping over 1 million people reach their destinations. 
        Thanks to a user-friendly booking system and extensive daily route network, NaviGO Mobility offers travelers the opportunity to experience the world no matter their budget. 
        Our buses comply with the highest safety and environmental standards, so that we can offer a sustainable, convenient and comfortable alternative to private transportation. </p></div>
    <div class="m-img">
        <img src="/img/mobility.jpg" style="width:350px; border-bottom:solid; border-bottom-color:darksalmon; border-width:8px" />
    </div>
    </div>
    <div style="padding-top:50px; height:420px">
    <h3>Our Road to Success</h3>
    <hr style="width:240px; margin-left:0px;" />
    <div class="s-img">
        <img src="/img/success.jpg" style="width:350px; border-bottom:solid; border-bottom-color:darksalmon; border-width:8px" />
    </div>
    <div class="s-par">
    <p>
        Our success can be attributed to the digitization of traditional bus travel. With technological advancements like our e-ticketing system, the NaviGO-App, free Wi-Fi on board, GPS Live Tracking and an automated Delay-Management System, NaviGO continues to revolutionize the bus travel industry. 
        Through smart network planning and dynamic price management, we are able to provide our customers with the best offers possible. Our NaviGO network relies on close partnerships with small and medium-sized enterprises and often family-owned businesses – our regional bus partners – who are responsible for the NaviGO fleet. 
        Through these partnerships, the innovation and start-up spirit of the NaviGO Mobility brands meet with the long-standing experience of traditional industry.
    </p>
    </div>
        </div>
     <div style="padding-top:50px; height:550px">
    <h3>Founders</h3>
    <hr style="width:240px; margin-left:0px;" />
    <div class="bozo">
        <img src="/img/bojan.jpg" style="width:210px; border:solid; border-color:darksalmon; border-width:5px; border-radius:50%"/>
        <h4>Bojan Bogdanovic</h4>
        <p class="par">Bojan is in charge of the international operations and expansion. Back in 2016, together with Ana, he discussed and brainstormed the opportunities that a deregulated market could bring. 
            As a fan of alternative mobility concepts, he doesn’t own a car and cycles to the office.</p>
    </div>
    <div class="ana">
        <img src="/img/ana.jpg" style="width:210px; border:solid; border-color:darksalmon; border-width:5px; border-radius:50%" />
        <h4>Ana Trajkovska</h4>
        <p class="par">Ana is responsible for Corporate Development and Human Resources. Before founding NaviGO, she and Bojan travelled the world as strategy consultants. 
            During her studies she organized ski bus trips to Bansko, which was her first experience with the industry.</p>
    </div>
     <div class="zoc">
         <img src="/img/filip.jpg" style="width:210px; border:solid; border-color:darksalmon; border-width:5px; border-radius:50%" />
         <h4>Filip Jordanov</h4>
         <p class="par">Filip takes care of IT, Mobile and Software Development. During his studies he founded a successful IT start-up with his schoolmate Bojan. 
             He eventually sacrificed his long time job at Netcetera – and his car – to create Macedonia's largest long-distance bus provider.</p>
     </div>
   </div>
</asp:Content>
