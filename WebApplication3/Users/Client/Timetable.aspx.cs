using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Client
{
    public partial class Timetable : System.Web.UI.Page
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
                ddlMonth.SelectedIndex = System.DateTime.Today.Month - 1;
                ddlDay.SelectedIndex = System.DateTime.Today.Day - 1;
                string date = System.DateTime.Today.Year.ToString() + "-" + ddlMonth.SelectedItem.Value.ToString() + "-" + ddlDay.SelectedItem.Value.ToString();
                ispolniTabela(date);

            }          
            
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        protected void ispolniTabela(string date)
        {
            DataTable ourDataTable = null;
            /*string query = "SELECT ob.city as origin, db.city as destination, tripdate, arrival, departure, price" +
                 "FROM trips, busstations as ob, busstations as db" +
                 "WHERE trips.origin_busstationid = ob.busstationid and trips.destination_busstationid = db.busstationid";*/
            string query = "SELECT trips.tripid, ob.city AS origin, db.city AS destination, trips.tripdate, trips.departure, trips.arrival, trips.price, (52-trips.passengerno) AS free FROM trips INNER JOIN busstations ob ON trips.origin_busstationid = ob.busstationid INNER JOIN busstations db ON trips.destination_busstationid = db.busstationid and trips.tripdate = '"+date+"'";

            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvTimetable.DataSource = ourDataTable;
                gvTimetable.DataBind();
            
                
                conn.Close();
            }
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = System.DateTime.Today.Year.ToString() + "-" + ddlMonth.SelectedItem.Value.ToString() + "-" + ddlDay.SelectedItem.Value.ToString();
            ispolniTabela(date);
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT tripid, routeid FROM trips INNER JOIN busstations ob ON trips.origin_busstationid = ob.busstationid INNER JOIN busstations db ON trips.destination_busstationid = db.busstationid and trips.tripdate = '" + date + "'", conn);
                using (var reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt16(reader.GetValue(1));
                        string tripid = Convert.ToString(reader.GetInt32(0));
                        ListItem li = new ListItem(tripid, id.ToString());
                        lstTripNo.Items.Add(li);

                    }

                }
            }
        }
        protected void btnInsert_Command(object sender, CommandEventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres;";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                int tid = Convert.ToInt16(lstTripNo.SelectedItem.Text);
                int rid = Convert.ToInt16(lstTripNo.SelectedItem.Value);
                string data = DateTime.Now.ToString();
                int uid = 0;
                int pid = 0;
                NpgsqlCommand cmd1 = new NpgsqlCommand("insert into reservations(tripid, routeid, paymenttype,reservationdate, persons) values (:tid,:rid,'Credit card',:data,:p) returning resid", conn);

                cmd1.Parameters.Add(new NpgsqlParameter("tid", tid));
                cmd1.Parameters.Add(new NpgsqlParameter("rid", rid));
                cmd1.Parameters.Add(new NpgsqlParameter("data", data));
                cmd1.Parameters.Add(new NpgsqlParameter("p", Convert.ToInt16(tbPersons.Text)));
                int reid = 0;
                reid = Convert.ToInt16(cmd1.ExecuteScalar());
                string uname = ((string)Session["user"]).Split(' ')[0];
                NpgsqlCommand cmd2 = new NpgsqlCommand("select p.userid as uid, p.passengerid as pid from passengers as p, users as u where p.userid=u.userid and u.username = '" + uname + "'", conn);
                using (var reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uid = Convert.ToInt16(reader.GetValue(0));
                        pid = Convert.ToInt16(reader.GetValue(1));

                    }
                }
                int persons = Convert.ToInt16(tbPersons.Text);
                NpgsqlCommand cmdx = new NpgsqlCommand("SELECT busid FROM trips_use_busses WHERE routeid="+rid+" AND tripid="+tid,conn);
                int busid = Convert.ToInt16(cmdx.ExecuteScalar());
                NpgsqlCommand cmdy = new NpgsqlCommand("SELECT seatid from seats where busid="+busid,conn);
                int seatid = 0;
                LinkedList<int> seats = new LinkedList<int>();
                using (var reader = cmdy.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        seatid = Convert.ToInt16(reader.GetValue(0));
                        seats.AddLast(seatid);
                      
                    }
                }
                for(int i=0;i<persons;i++)
                {
                    seatid = seats.ElementAt<int>(i);
                    NpgsqlCommand cmdz = new NpgsqlCommand("INSERT INTO seats_reserved (seatid, resid, tripid, routeid) values (:seatid, :resid, :tripid, :routeid)", conn);
                    cmdz.Parameters.Add(new NpgsqlParameter("seatid", seatid));
                    cmdz.Parameters.Add(new NpgsqlParameter("resid", reid));
                    cmdz.Parameters.Add(new NpgsqlParameter("tripid", tid));
                    cmdz.Parameters.Add(new NpgsqlParameter("routeid", rid));
                    cmdz.ExecuteScalar();
                }
                NpgsqlCommand cmd3 = new NpgsqlCommand("insert into passengerreservations(resid,userid,passengerid) values (:reid,:uid,:pid)", conn);

                cmd3.Parameters.Add(new NpgsqlParameter("reid", reid));
                cmd3.Parameters.Add(new NpgsqlParameter("uid", uid));
                cmd3.Parameters.Add(new NpgsqlParameter("pid", pid));
                cmd3.ExecuteNonQuery();

                NpgsqlCommand cmd4 = new NpgsqlCommand("SELECT passengerno FROM trips WHERE tripid="+tid,conn);
                int pasno = Convert.ToInt32(cmd4.ExecuteScalar());
                pasno += Convert.ToInt16(tbPersons.Text);
                NpgsqlCommand cmd5 = new NpgsqlCommand("UPDATE trips SET passengerno = "+ pasno +" WHERE tripid="+tid, conn);
                cmd5.ExecuteScalar();
                string dt = System.DateTime.Today.Year.ToString() + "-" + ddlMonth.SelectedItem.Value.ToString() + "-" + ddlDay.SelectedItem.Value.ToString();
                ispolniTabela(dt);
            }
        }
        protected void lstTripNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}