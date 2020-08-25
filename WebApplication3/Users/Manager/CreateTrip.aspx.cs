using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Manager
{
    public partial class CreateTrip : System.Web.UI.Page
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
            int auid = 0;
            int aeid = 0;
            int did = 0;
            int bid = 0;
            int bsid = 0;
            if (!IsPostBack)
            {
                string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT attendants.userid, attendants.employeeid, users.firstname, users.lastname FROM users,attendants WHERE users.userid = attendants.userid",conn);
                    using (var reader = cmd1.ExecuteReader())
                    {

                        while(reader.Read())
                        {
                            auid = Convert.ToInt16(reader.GetValue(0));
                            aeid = Convert.ToInt16(reader.GetValue(1));
                            ListItem li = new ListItem(reader.GetString(2) + " " + reader.GetString(3), auid.ToString() + " " + aeid.ToString());
                            ddlAttendant.Items.Add(li);
                        }
                    }
                    NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT driverid, firstname, lastname FROM drivers", conn);
                    using (var reader = cmd2.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            did = Convert.ToInt16(reader.GetValue(0));            
                            ListItem li = new ListItem(reader.GetString(1) + " " + reader.GetString(2), did.ToString());
                            ddlDriver.Items.Add(li);
                        }
                    }
                    NpgsqlCommand cmd3 = new NpgsqlCommand("SELECT busid, registertable, manufacturer FROM busses", conn);
                    using (var reader = cmd3.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            bid = Convert.ToInt16(reader.GetValue(0));
                            ListItem li = new ListItem(reader.GetString(1) + "-" + reader.GetString(2), bid.ToString());
                            ddlBus.Items.Add(li);
                        }
                    }
                    NpgsqlCommand cmd4 = new NpgsqlCommand("SELECT busstationid, city FROM busstations", conn);
                    using (var reader = cmd4.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bsid = Convert.ToInt16(reader.GetValue(0));
                            ListItem li = new ListItem(reader.GetString(1), bsid.ToString());
                            ddlOrigin.Items.Add(li);
                            ddlDestination.Items.Add(li);
                        }
                    }
                }
            }
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        protected void ddlOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListItem li in ddlDestination.Items)
            {
                if(li.Text == ddlOrigin.SelectedItem.Text)
                {
                    li.Attributes.Add("disabled", "disabled");
                }
            }
        }

        protected void ddlDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem li in ddlOrigin.Items)
            {
                if (li.Text == ddlDestination.SelectedItem.Text)
                {
                    li.Attributes.Add("disabled", "disabled");
                }
            }
        }

        protected void btnAddTrip_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                int a_userid= Convert.ToInt16(ddlAttendant.SelectedItem.Value.Split(' ')[0]);
                int a_empid = Convert.ToInt16(ddlAttendant.SelectedItem.Value.Split(' ')[1]);
                NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO trips (routeid,manager_userid,manager_employeeid,attendant_userid,attendant_employeeid,origin_busstationid,destination_busstationid," +
                    "tripdate,passengerno,price,departure,arrival) VALUES (1,1,1,:auid,:aeid,:o,:d,:dat,0,:pr,:dep,:arr) RETURNING tripid",conn);
                cmd1.Parameters.Add(new NpgsqlParameter("auid",a_userid));
                cmd1.Parameters.Add(new NpgsqlParameter("aeid", a_empid));
                cmd1.Parameters.Add(new NpgsqlParameter("o", Convert.ToInt16(ddlOrigin.SelectedItem.Value)));
                cmd1.Parameters.Add(new NpgsqlParameter("d", Convert.ToInt16(ddlDestination.SelectedItem.Value)));
                cmd1.Parameters.Add(new NpgsqlParameter("dat", tbDate.Text));
                cmd1.Parameters.Add(new NpgsqlParameter("pr", Convert.ToInt32(tbPrice.Text)));
                cmd1.Parameters.Add(new NpgsqlParameter("dep", tbDeparture.Text));
                cmd1.Parameters.Add(new NpgsqlParameter("arr", tbArrival.Text));
                int tid = 0;
                tid = Convert.ToInt16(cmd1.ExecuteScalar());

                NpgsqlCommand cmd2 = new NpgsqlCommand("INSERT INTO drivers_drive_trips (tripid,routeid,driverid) VALUES (:tid,0,:did)", conn);
                cmd2.Parameters.Add(new NpgsqlParameter("tid", tid));
                cmd2.Parameters.Add(new NpgsqlParameter("did", Convert.ToInt16(ddlDriver.SelectedItem.Value)));
                cmd2.ExecuteNonQuery();
                NpgsqlCommand cmd3 = new NpgsqlCommand("INSERT INTO trips_use_busses (tripid,routeid,busid) VALUES (:tid,0,:bid)", conn);
                cmd3.Parameters.Add(new NpgsqlParameter("tid", tid));
                cmd3.Parameters.Add(new NpgsqlParameter("bid", Convert.ToInt16(ddlBus.SelectedItem.Value)));
                cmd3.ExecuteNonQuery();
            }
        }
    }
}