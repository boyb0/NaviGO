<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Attendant.Master" CodeBehind="MakeReservation.aspx.cs" Inherits="NaviGO.Users.Attendant.MakeReservation" %>
<%@ MasterType VirtualPath="~/Attendant.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <br />
    <div style="font-size:18px">
        <h2>Choose a date:</h2>
        <span>Month: <asp:DropDownList ID="ddlMonth" runat="server" CssClass="btn btn-primary dropdown-toggle" >
            <asp:ListItem Value="01">January</asp:ListItem>
            <asp:ListItem Value="02">February</asp:ListItem>
            <asp:ListItem Value="03">March</asp:ListItem>
            <asp:ListItem Value="04">April</asp:ListItem>
            <asp:ListItem Value="05">May</asp:ListItem>
            <asp:ListItem Value="06">June</asp:ListItem>
            <asp:ListItem Value="07">July</asp:ListItem>
            <asp:ListItem Value="08">August</asp:ListItem>
            <asp:ListItem Value="09">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList></span> <span style="padding-left:18px">Day: <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="True" CssClass="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged">
            <asp:ListItem Value="01">1</asp:ListItem>
            <asp:ListItem Value="02">2</asp:ListItem>
            <asp:ListItem Value="03">3</asp:ListItem>
            <asp:ListItem Value="04">4</asp:ListItem>
            <asp:ListItem Value="05">5</asp:ListItem>
            <asp:ListItem Value="06">6</asp:ListItem>
            <asp:ListItem Value="07">7</asp:ListItem>
            <asp:ListItem Value="08">8</asp:ListItem>
            <asp:ListItem Value="09">9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList></span>

    </div>
            <hr />

    <div class="table-responsive" style="margin-top:10px">
    <asp:GridView ID="gvTimetable" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="False" Font-Names="Calibri Light" Font-Size="Large" GridLines="Horizontal" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="tripid" HeaderText="TripNo." />
            <asp:BoundField DataField="origin" HeaderText="Origin" />
            <asp:BoundField DataField="destination" HeaderText="Destination" />
            <asp:BoundField DataField="tripdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
            <asp:BoundField DataField="departure" DataFormatString="{0:HH\:mm}" HeaderText="Departure" />
            <asp:BoundField DataField="arrival" DataFormatString="{0:HH\:mm}" HeaderText="Arrival" />
            <asp:BoundField DataField="price" HeaderText="Price (MKD)" />
            <asp:BoundField DataField="free" HeaderText="Free Seats" />
        </Columns>
        <HeaderStyle BackColor="Black" HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Left" />
        </asp:GridView>
    </div>
        <div class="form-group" style="display:inline-block; margin-top:50px;" >
                <div style="display:block;float:left; padding:0px 10px 0px 20px" ><h4>Select Trip No.</h4>
                        <asp:ListBox ID="lstTripNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstTripNo_SelectedIndexChanged" CssClass="form-control"></asp:ListBox>
                    </div>
                   <div style="display:block;float:left; padding:0px 10px 0px 20px" ><h4>Passenger&#39;s firstname:</h4>
                        <asp:TextBox ID="tbFirstname" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px"><h4>Passenger&#39;s lastname:</h4>
                        <asp:TextBox ID="tbLastname" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px"><h4>Persons:</h4>
                        <asp:TextBox ID="tbPersons" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div style="display:block;float:left; padding:0px 10px 0px 20px;"><h4>Payment type:</h4>
                        <asp:RadioButtonList ID="rblPaymentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPaymentType_SelectedIndexChanged" >
                            <asp:ListItem>Cash</asp:ListItem>
                            <asp:ListItem>Credit card</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div style="display:block;float:left; margin-left:20px; margin-top:40px"><asp:Button ID="btnInsert" runat="server" Text="Make" OnCommand="btnInsert_Command" Width="80px" CssClass="btn btn-default"></asp:Button></div>
                               
                    
        </div>
    

</asp:Content>