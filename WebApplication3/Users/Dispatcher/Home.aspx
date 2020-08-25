<%@ Page Title="Home" Language="C#" AutoEventWireup="true" MasterPageFile="~/Dispatcher.Master"  CodeBehind="Home.aspx.cs" Inherits="NaviGO.Users.Dispatcher.Home" %>
<%@ MasterType VirtualPath="~/Dispatcher.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
          <br />
        <br />
            <asp:GridView ID="gvEditTrips" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="False" Font-Names="Calibri Light" Font-Size="Large" GridLines="Horizontal" HorizontalAlign="Center" Height="210px" OnRowCancelingEdit="gvEditTrips_RowCancelingEdit" OnRowEditing="gvEditTrips_RowEditing" OnRowUpdating="gvEditTrips_RowUpdating" Width="681px"  OnRowDeleting="gvEditTrips_RowDeleting" AllowSorting="True" >
                <Columns>
                    <asp:BoundField DataField="tripid" HeaderText="Trip No." ReadOnly="True"/>
                    <asp:BoundField DataField="origin" HeaderText="Origin" ReadOnly="True" />
                    <asp:BoundField DataField="destination" HeaderText="Destination" ReadOnly="True" />
                    <asp:BoundField DataField="tripdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                    <asp:BoundField DataField="departure" DataFormatString="{0:HH\:mm}" HeaderText="Departure" />
                    <asp:BoundField DataField="arrival" DataFormatString="{0:HH\:mm}" HeaderText="Arrival" />
                    <asp:BoundField DataField="price" HeaderText="Price (MKD)" />
                    <asp:BoundField DataField="passengerno" HeaderText="Number of Passengers" />
                    <asp:CommandField ShowEditButton="True" />
                    
                    <asp:CommandField ShowDeleteButton="True" />
                    
                </Columns>
            </asp:GridView>
          
        </div>
</asp:Content>