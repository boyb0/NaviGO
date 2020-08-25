<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="NaviGO.Users.Manager.Feedback" MasterPageFile="~/Manager.Master" %>
<%@ MasterType VirtualPath="~/Manager.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html>
<body>
    <div>
        <asp:GridView ID="gvFeedbacks" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="False" Font-Names="Calibri Light" Font-Size="Large" GridLines="Horizontal" HorizontalAlign="Center" Height="210px" OnRowCancelingEdit="gvEditTrips_RowCancelingEdit" OnRowEditing="gvEditTrips_RowEditing" OnRowUpdating="gvEditTrips_RowUpdating" Width="681px"  AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="feedid" HeaderText="Feedback No." ReadOnly="True"/>
                 <asp:BoundField DataField="email" HeaderText="User's Email" ReadOnly="True"/>
                <asp:BoundField DataField="message" HeaderText="User's Message" ReadOnly="True"/>
                <asp:BoundField DataField="answer" HeaderText="Answer"/>
                <asp:CommandField ShowEditButton="True" EditText="Answer" />
            </Columns>
        </asp:GridView>
    </div>
</body>
</html>
</asp:Content>
