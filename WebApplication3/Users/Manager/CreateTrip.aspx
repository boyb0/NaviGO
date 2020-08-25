<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateTrip.aspx.cs" Inherits="NaviGO.Users.Manager.CreateTrip" MasterPageFile="~/Manager.Master" %>
<%@ MasterType VirtualPath="~/Manager.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html>

<body>
    <div>
        <h2>Add New Trip</h2>
        <hr />
        <div class="form-group" style="display:inline-block; margin-top:50px;" >
                <div style="display:block;float:left;padding:0px 10px 0px 20px"><h4>Origin:</h4>
                    <asp:DropDownList ID="ddlOrigin" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlOrigin_SelectedIndexChanged"></asp:DropDownList>    
                    </div>
                   <div style="display:block;float:left; padding:0px 10px 0px 20px"><h4>Destination:</h4>
                    <asp:DropDownList ID="ddlDestination" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDestination_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>    
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px"><h4>Date:</h4>
                        <asp:TextBox ID="tbDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDate"
                         CssClass="text-danger" Display="Dynamic" ErrorMessage="The date field is required." />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbDate"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The date should be in format YYYY-MM-DD." ValidationExpression="\d{4}-\d{2}-\d{2}" />
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px"><h4>Departure:</h4>
                        <asp:TextBox ID="tbDeparture" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbDeparture"
                         CssClass="text-danger" Display="Dynamic" ErrorMessage="The departure field is required." />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbDeparture"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The departure should be in format HH:MM:SS." ValidationExpression="\d{2}:\d{2}:\d{2}" />
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Arrival:</h4>
                   <asp:TextBox ID="tbArrival" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbArrival"
                         CssClass="text-danger" Display="Dynamic" ErrorMessage="The arrival field is required." />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="tbArrival"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The arrival should be in format HH:MM:SS." ValidationExpression="\d{2}:\d{2}:\d{2}" />
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Price:</h4>
                    <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPrice"
                         CssClass="text-danger" Display="Dynamic" ErrorMessage="The arrival field is required." />
                    </div>
            <hr />
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Attendant:</h4>
                        <asp:DropDownList ID="ddlAttendant" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Driver:</h4>
                        <asp:DropDownList ID="ddlDriver" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Bus:</h4>
                        <asp:DropDownList ID="ddlBus" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div style="display:block;float:left; margin-left:20px; margin-top:40px">
                        <asp:Button ID="btnAddTrip" runat="server" Text="Submit" CssClass="form-control" OnClick="btnAddTrip_Click"/>
                    </div>
                               
                    
        </div>
    </div>
</body>
</html>
</asp:Content>