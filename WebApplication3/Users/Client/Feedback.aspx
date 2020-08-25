<%@ Page Title="Feedback" Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" MasterPageFile="~/Client.Master" Inherits="NaviGO.Users.Client.Feedback" %>
<%@ MasterType VirtualPath="~/Client.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group" style="height:300px">
            <div class="col-md-10">
                <h2>Have a compliment or a complaint for us?</h2>
                <p>Write us your impressions about our service and we will answer you in fastest period of time.</p>
                <asp:TextBox runat="server" ID="tbFeedback" CssClass="form-control" TextMode="MultiLine" Rows="4" EnableViewState="False" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFeedback"
                    CssClass="text-danger" ErrorMessage="You can not send an empty feedback." />
            <div style="margin-left:0px">
            <div>
            <asp:Button ID="btnSend" runat="server" Text="Send" Width="100px" OnClick="btnSend_Click" CssClass="btn btn-default" /></div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <div style="margin-left:515px; margin-top:-43px"> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></div>
            </div>
            </div>
        </div>
</asp:Content>