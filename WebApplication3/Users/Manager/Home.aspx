<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NaviGO.Users.Manager.Home" MasterPageFile="~/Manager.Master" %>
<%@ MasterType VirtualPath="~/Manager.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h1>My Profile</h1>
    <hr / >
    <div style="display:inline-block;">
    <div style="width:780px; display:inline-block; border-style:dashed; border-width:1px; padding:20px; ">
        <div style="width:220px;  display:block; float:left;">
            <img src="/img/avatar.jpg" style="width:220px"/>
            <div style="margin-top:82px; margin-left:55px; ">
            <asp:Button ID="btnInfo" runat="server" Text="Update Info" Width="100px" CssClass="btn btn-default" OnClick="btnInfo_Click" ValidationGroup="Group1"/>
                </div>
        </div>
        <div style="width:500px;  display:block; float:left; padding-left:30px; margin-top:-20px">
            <h2>Personal Informations</h2>
            <hr style="width:400px; margin-left:-2px"/>
            <div class="form-horizontal">
 
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbUsername" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbUsername" TextMode="SingleLine" CssClass="form-control" Enabled="False" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." ValidationGroup="Group1" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbFirstName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbFirstName"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The first name field is required." ValidationGroup="Group1" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbLastName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLastName"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The last name field is required." ValidationGroup="Group1" />
            </div>
        </div>
               </div>
        </div>
    </div>
    <div style="display:inline-block; width:300px; margin-left:40px; border-style:dashed; border-width:1px; padding:20px;   ">
       <h2>Change Password</h2>
       <hr / >
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbOldPassword" CssClass=" control-label">Old Password</asp:Label>
            
                <asp:TextBox runat="server" ID="tbOldPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbOldPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="Group2"/>
            
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbNewPassword" CssClass=" control-label">New Password</asp:Label>
            
                <asp:TextBox runat="server" ID="tbNewPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNewPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="Group2" />
            
        </div>
        <asp:Label ID="lblPasswordMessage" runat="server" Text=""></asp:Label>
        <div style="margin-top:50px; margin-left:55px">
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Width="140px" CssClass="btn btn-default" ValidationGroup="Group2" OnClick="btnChangePassword_Click" />
                </div>
    </div>
    <div style="display:inline-block; width:500px; border-style:dashed; border-width:1px; padding:20px;">
        <h2>Your phone numbers</h2>
        <hr />
        <asp:ListBox ID="lstPhoneNo" runat="server" Width="400px"  ForeColor="Black" Font-Size="20px" AutoPostBack="False" CssClass="form-control"></asp:ListBox>
        <br />
        <asp:Label runat="server" AssociatedControlID="tbNewPhoneNo" CssClass=" control-label">New Phone Number</asp:Label>
        <asp:TextBox runat="server" ID="tbNewPhoneNo" TextMode="Phone" CssClass="form-control" EnableViewState="False"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNewPhoneNo"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The phone number field is required." ValidationGroup="Group3" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="tbNewPhoneNo"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The phone number should be in format 07XYYYYYY." ValidationExpression="07\d{1}\d{3}\d{3}" ValidationGroup="Group3" />
        <br />        
        <asp:Button ID="btnNewPhoneNo" runat="server" Text="Add Phone No." CssClass="btn btn-default" ValidationGroup="Group3" Font-Size="15px" EnableViewState="False" OnClick="btnNewPhoneNo_Click" /> &nbsp;
        <asp:Button ID="btnDeletePhoneNo" runat="server" Text="Delete" CssClass="btn btn-default" OnClick="btnDeletePhoneNo_Click" />
    </div>
        
    </div>
</asp:Content>