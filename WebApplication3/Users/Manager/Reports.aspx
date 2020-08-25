<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="NaviGO.Users.Manager.Reports" MasterPageFile="~/Manager.Master" %>
<%@ MasterType VirtualPath="~/Manager.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html>

<body>
    <h2>NaviGO Reports</h2>
    <hr />
    <div style="display:inline-block; width:100%; margin-left:20px; margin-top:50px">
        <div style="display:inline-block; width:50%; height:600px; float:left;">
        <div>
            <h4 style="padding-right:20px"><img src="/img/attention.png" style="width:35px" /> Number of trips that started from the selected bus station and on the selected time or later.</h4>
            Bus Station:<asp:DropDownList ID="ddlBusStation1" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>&nbsp; Time:<asp:DropDownList ID="ddlTime1" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList><br /><br />
            <asp:Button ID="btnQuery1" runat="server" Text="View" CssClass="form-control" Width="120px" OnClick="btnQuery1_Click" />&nbsp;&nbsp;Number of trips:<asp:Label ID="lblQuery1" runat="server" Text="" ></asp:Label>
        </div>   
        </div>
        <div style="display:inline-block; width:50%;height:600px; float:left">
        <div>
            <h4><img src="/img/attention.png" style="width:35px" /> List of all passengers (NaviGO Mobility users) that have made more than certain number of reservations, together with their number of reservations, in ascending order.</h4>
            Number of Reservations: <asp:TextBox ID="tbNoReservations2" runat="server" CssClass="form-control"></asp:TextBox> &nbsp; &nbsp; <asp:Button ID="btnQuery2" runat="server" Text="View" Width="120px" CssClass="form-control" OnClick="btnQuery2_Click"/><br /><br />
            <asp:GridView ID="gvQuery2" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="True">
            </asp:GridView>
        </div>
        </div>
        <div style="display:inline-block; width:50%;height:600px; float:left">
        <div>
            <h4 style="padding-right:20px"><img src="/img/attention.png" style="width:35px" /> List of all attendants that have made a reservation in the current month, together with the number of their reservations.</h4>
            <asp:Button ID="btnQuery3" runat="server" Text="View" CssClass="form-control" Width="120px" OnClick="btnQuery3_Click" />
            <asp:GridView ID="gvQuery3" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="True"></asp:GridView>
        </div>   
        </div>
        <div style="display:inline-block; width:50%;height:600px; float:left">
        <div>
            <h4><img src="/img/attention.png" style="width:35px" /> Number of busses by certain manufacturer that have/have not airconditioning, arrived in certain city in certain time</h4>  
            Bus Manufacturer: <asp:DropDownList ID="ddlBusManufacturer4" Width="250px" runat="server" CssClass="form-control"></asp:DropDownList> &nbsp; &nbsp; Airconditioning: <asp:RadioButtonList ID="rblAirconditioning4" runat="server" RepeatDirection="Vertical">
            <asp:ListItem Value="true">Yes</asp:ListItem>
            <asp:ListItem Value="false">No</asp:ListItem>
            </asp:RadioButtonList>  Destination:<asp:DropDownList ID="ddlDestination4" Width="250px" runat="server" CssClass="form-control"></asp:DropDownList>  Arrival:<asp:DropDownList ID="ddlArrival4" Width="250px" runat="server" CssClass="form-control"></asp:DropDownList><br /><asp:Button ID="btnQuery4" runat="server" Text="View" CssClass="form-control" Width="120px" OnClick="btnQuery4_Click"/><br />
            Number of busses:&nbsp;<asp:Label ID="lblQuery4" runat="server" Text=""></asp:Label>
        </div>
        </div>
        <div style="display:inline-block; width:50%;height:600px; float:left">
        <div>
            <h4 style="padding-right:20px"><img src="/img/attention.png" style="width:35px" /> Number of reserved seats for every trip that is in format ORIGIN - DESTINATION, for particular month.</h4>
            Month: <asp:DropDownList ID="ddlMonth5" runat="server" Width="250px" CssClass="form-control"></asp:DropDownList><br />
            <asp:Button ID="btnQuery5" runat="server" Text="View" CssClass="form-control" Width="120px" OnClick="btnQuery5_Click"/><br />
            <asp:GridView ID="gvQuery5" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="True"></asp:GridView>
        </div>
        </div>
        <div style="display:inline-block; width:50%;height:600px; float:left">
          <div>         
            <h4><img src="/img/attention.png" style="width:35px" /> List of all trips that passes through particular city, which ticket price is smaller than the average price of tickets for particular month.</h4>
              City:<asp:DropDownList ID="ddlCity6" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>  Month:<asp:DropDownList ID="ddlMonth6" runat="server" Width="250px" CssClass="form-control"></asp:DropDownList> &nbsp; &nbsp <asp:Button ID="btnQuery6" runat="server" Text="View" CssClass="form-control" Width="120px" OnClick="btnQuery6_Click"/>
              <asp:GridView ID="gvQuery6" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="True"></asp:GridView>
        </div>
        </div>

    </div>
</body>
</html>
</asp:Content>