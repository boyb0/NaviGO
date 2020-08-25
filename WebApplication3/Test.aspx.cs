using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
                DataTable ourDataTable = null;
                string query = "select tr.tripid, tr.price from trips tr, Route_passes_BusStations as rpb, busstations as bss, Route as ro, (select sum(p.price) as s, count(p.tripid) as c from(select trips.price, trips.tripid " +
                    "from trips, Route_passes_BusStations as RB, busstations as bs, Route as R where extract(month from trips.tripdate) = '01' and RB.RouteID = R.RouteID and rb.busstationid = bs.busstationid and bs.City = 'Skopje' and trips.routeid = r.routeid) as p) as fin " +
                    "where extract(month from tr.tripdate)= '01' and tr.price < fin.s / fin.c and rpb.RouteID = ro.RouteID and rpb.busstationid = bss.busstationid and bss.City = 'Skopje' and tr.routeid = ro.routeid ";
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
}