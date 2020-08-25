using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Dispatcher
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.Logout += new EventHandler(lbLogout_Click);
        }
        protected void Page_Load()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");

            }
            if (!IsPostBack)
            {
                this.Master.IdentifyUser = ((string)Session["user"]).Split(' ')[0];
                ispolniTabela();
            }
        }
        protected void ispolniTabela()
        {
                DataTable ourDataTable = null;
                string query = "SELECT tripid, ob.city AS origin, db.city AS destination, trips.tripdate, trips.departure, trips.arrival, trips.price, trips.passengerno FROM trips INNER JOIN busstations ob ON trips.origin_busstationid = ob.busstationid INNER JOIN busstations db ON trips.destination_busstationid = db.busstationid WHERE now()::date <= trips.tripdate";
                string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    ourDataTable = new DataTable();
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                    ourAdapter.SelectCommand = cmd;
                    ourAdapter.Fill(ourDataTable);
                    gvEditTrips.DataSource = ourDataTable;
                    gvEditTrips.DataBind();

                    ViewState["dataset"] = ourDataTable;
                    conn.Close();
                }
            
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        protected void gvEditTrips_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvEditTrips_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvEditTrips.EditIndex = e.NewEditIndex;
            gvEditTrips.DataSource = ds;
            gvEditTrips.DataBind();
        }

        protected void gvEditTrips_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int euid = 0;
            int eeid = 0;
            string uname = ((string)Session["user"]).Split(' ')[0];
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand("UPDATE trips SET  \"tripdate\" = :td, passengerno = :pn, price = :p, \"departure\" = :d, \"arrival\" = :a  WHERE trips.tripid = :tid",conn);

                TextBox tb = (TextBox)gvEditTrips.Rows[e.RowIndex].Cells[3].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("td", NpgsqlTypes.NpgsqlDbType.Date));
                cmd2.Parameters[0].Value = Convert.ToDateTime(tb.Text);

                tb = (TextBox)gvEditTrips.Rows[e.RowIndex].Cells[4].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("d", NpgsqlTypes.NpgsqlDbType.Time));
                cmd2.Parameters[1].Value = Convert.ToDateTime(tb.Text);

                tb = (TextBox)gvEditTrips.Rows[e.RowIndex].Cells[5].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("a", NpgsqlTypes.NpgsqlDbType.Time));
                cmd2.Parameters[2].Value = Convert.ToDateTime(tb.Text);

                tb = (TextBox)gvEditTrips.Rows[e.RowIndex].Cells[6].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("p", Convert.ToInt16(tb.Text)));

                tb = (TextBox)gvEditTrips.Rows[e.RowIndex].Cells[7].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("pn", Convert.ToInt16(tb.Text)));

                int rd1;
                Int32.TryParse(gvEditTrips.Rows[e.RowIndex].Cells[0].Text, out rd1);
                cmd2.Parameters.Add(new NpgsqlParameter("tid", rd1));

                cmd2.ExecuteNonQuery();
                gvEditTrips.EditIndex = -1;
                conn.Close();
                ispolniTabela();


            }
        }
        protected void gvEditTrips_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvEditTrips.EditIndex = -1;
            gvEditTrips.DataSource = ds;
            gvEditTrips.DataBind();
        }
    }
}