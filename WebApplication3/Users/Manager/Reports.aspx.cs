using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Manager
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)

        {
            Master.Logout += new EventHandler(lbLogout_Click);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                this.Master.IdentifyUser = ((string)Session["user"]).Split(' ')[0];

            }
            if (!IsPostBack)
            {
                string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT busstationid, city FROM busstations", conn);
                    using (var reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bsid = Convert.ToInt16(reader.GetValue(0));
                            ListItem li = new ListItem(reader.GetString(1), bsid.ToString());
                            ddlBusStation1.Items.Add(li);
                            ddlCity6.Items.Add(li);
                            ddlDestination4.Items.Add(li);
                        }
                    }
                    NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT distinct manufacturer FROM busses", conn);
                    using (var reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            ListItem li = new ListItem(reader.GetString(0));
                            ddlBusManufacturer4.Items.Add(li);
                        }
                    }
                    for(int i=0;i<24;i++)
                    {
                        ListItem li;
                        if (i<10)
                        {
                            li = new ListItem("0" + i + ":00");
                        }
                        else
                        {
                            li = new ListItem(i + ":00");
                        }
                        ddlArrival4.Items.Add(li);
                        ddlTime1.Items.Add(li);
                    }
                    string[] months = { "x", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                    for(int i=1;i<=12;i++)
                    {
                        ListItem li;
                        if(i<10)
                            li = new ListItem(months[i], "0"+i.ToString());
                        else
                            li = new ListItem(months[i],i.ToString());
                        ddlMonth5.Items.Add(li);
                        ddlMonth6.Items.Add(li);
                    }
                }
            }
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnQuery1_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT count(TripID) FROM Trips as T, busstations as bs WHERE T.origin_busstationid = bs.busstationid and T.departure >= '"+ddlTime1.SelectedItem.Text+"' and bs.city = '"+ddlBusStation1.SelectedItem.Text+"'; ", conn);
                lblQuery1.Text = Convert.ToString(cmd1.ExecuteScalar());
            }
        }

        protected void btnQuery2_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            DataTable ourDataTable = null;
            string query = "SELECT username, count(ResID) FROM Users as U, PassengerReservations as PR WHERE U.UserID = PR.UserID GROUP BY username HAVING count(ResID) > "+tbNoReservations2.Text;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvQuery2.DataSource = ourDataTable;
                gvQuery2.DataBind();
                conn.Close();
            }
        }

        protected void btnQuery3_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            DataTable ourDataTable = null;
            string query = "SELECT fin.FirstName, fin.LastName, max(fin.uu) " +
                "FROM(SELECT Users.firstname, users.lastname, count(users.userid) as uu " +
                "FROM Users, (SELECT UserID, reservations.ResID, reservationdate, count(reservations.resid) " +
                "FROM Reservations, AttendantReservations " +
                "WHERE Reservations.ResID = AttendantReservations.ResID and extract(month from now()::date) = extract(month from reservationdate) " +
                "group by AttendantReservations.resid, reservations.resid) as AR " +
                "WHERE users.UserID = AR.UserID " +
                "GROUP BY users.FirstName, users.LastName) as fin " +
                "group by fin.FirstName, fin.LastName;";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvQuery3.DataSource = ourDataTable;
                gvQuery3.DataBind();
                conn.Close();
            }
        }

        protected void btnQuery4_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); 
                NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT count(B.BusID) FROM Trips_use_Busses as TB, Busses as B, (SELECT TripID FROM Trips as T, BusStations as BS " +
                    "WHERE T.Destination_BusStationID = BS.BusStationID and T.Arrival = '"+ddlArrival4.SelectedItem.Text+"' and bs.City = '"+ddlDestination4.SelectedItem.Text+"') as TBS WHERE Airconditioning = "+rblAirconditioning4.SelectedItem.Value+" and Manufacturer = '"+ddlBusManufacturer4.SelectedItem.Text +"' and B.BusID = TB.BusID and TBS.TripID = TB.TripID", conn);
                lblQuery4.Text = Convert.ToString(cmd1.ExecuteScalar());
            }
        }

        protected void btnQuery5_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            DataTable ourDataTable = null;
            string query = "SELECT O.City || '-' || D.City as origindestination, count(RSeatID) as brsedista FROM Trips as T, seats_reserved as SR, BusStations as O, BusStations as D WHERE T.Origin_BusStationID = O.BusStationID and T.Destination_BusStationID = D.BusStationID and extract(month from T.tripdate)= '"+ddlMonth5.SelectedItem.Value+"' and t.tripid = sr.tripid and t.routeid = sr.routeid GROUP BY O.City, D.City, t.tripid ";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvQuery5.DataSource = ourDataTable;
                gvQuery5.DataBind();
                conn.Close();
            }
        }

        protected void btnQuery6_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            DataTable ourDataTable = null;
            string query = "select tr.tripid, tr.price from trips tr, Route_passes_BusStations as rpb, busstations as bss, Route as ro, (select sum(p.price) as s, count(p.tripid) as c from(select trips.price, trips.tripid " +
                "from trips, Route_passes_BusStations as RB, busstations as bs, Route as R where extract(month from trips.tripdate) = '"+ddlMonth6.SelectedItem.Value+"' and RB.RouteID = R.RouteID and rb.busstationid = bs.busstationid and bs.City = '"+ddlCity6.SelectedItem.Text+"' and trips.routeid = r.routeid) as p) as fin " +
                "where extract(month from tr.tripdate)= '" + ddlMonth6.SelectedItem.Value + "' and tr.price < fin.s / fin.c and rpb.RouteID = ro.RouteID and rpb.busstationid = bss.busstationid and bss.City = '"+ddlCity6.SelectedItem.Text+"' and tr.routeid = ro.routeid ";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvQuery6.DataSource = ourDataTable;
                gvQuery6.DataBind();
                conn.Close();
            }
        }
    }
}