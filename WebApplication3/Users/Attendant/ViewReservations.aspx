<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Attendant.Master" CodeBehind="ViewReservations.aspx.cs" Inherits="NaviGO.Users.Attendant.ViewReservations" %>
<%@ MasterType VirtualPath="~/Attendant.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<html>
<head>
    <title></title>
</head>
<body>
   
    
        <div style="height: 184px">
          
            <asp:GridView ID="gvViewReservations" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="False" Font-Names="Calibri Light" Font-Size="Large" GridLines="Horizontal" HorizontalAlign="Center" Height="210px" OnRowCancelingEdit="gvViewReservations_RowCancelingEdit" OnRowEditing="gvViewReservations_RowEditing" OnRowUpdating="gvViewReservations_RowUpdating" Width="681px"  OnRowDeleting="gvViewReservations_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="R" HeaderText="ResNo." ReadOnly="True" />
                    <asp:BoundField DataField="firstname" HeaderText="Firstname" />
                    <asp:BoundField DataField="lastname" HeaderText="Lastname" />
                    <asp:BoundField DataField="reservationdate" HeaderText="Reservation Date" DataFormatString="{0:dd.MM.yyyy}" />
                    <asp:BoundField DataField="persons" HeaderText="Persons" />
                    <asp:CommandField ShowEditButton="True" />
                    
                    <asp:CommandField ShowDeleteButton="True" />
                    
                </Columns>
            </asp:GridView>
          
        </div>
</body>
</html>
</asp:Content>



