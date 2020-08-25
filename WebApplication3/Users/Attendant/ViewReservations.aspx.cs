using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Attendant
{
    public partial class ViewReservations : System.Web.UI.Page
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
                ispolniTabela();


            }

        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        

        protected void ispolniTabela()
        {
            DataTable ourDataTable = null;
            string query = "select distinct reservations.resid as R, firstname, lastname, reservationdate, persons from attendantreservations, reservations where now()::date <= reservations.reservationdate and attendantreservations.resid = reservations.resid";

            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvViewReservations.DataSource = ourDataTable;
                gvViewReservations.DataBind();

                ViewState["dataset"] = ourDataTable;
                conn.Close();
            }
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ispolniTabela();
        }

        protected void gvViewReservations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvViewReservations.EditIndex = e.NewEditIndex;
            gvViewReservations.DataSource = ds;
            gvViewReservations.DataBind();
        }
        

        protected void gvViewReservations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvViewReservations.EditIndex = -1;
            gvViewReservations.DataSource = ds;
            gvViewReservations.DataBind();
        }

        protected void gvViewReservations_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE reservations SET \"reservationdate\" = :rd, persons = :p WHERE reservations.resid = :rid", conn);

                TextBox tb = (TextBox)gvViewReservations.Rows[e.RowIndex].Cells[3].Controls[0];
                cmd1.Parameters.Add(new NpgsqlParameter("rd", NpgsqlTypes.NpgsqlDbType.Date));
                cmd1.Parameters[0].Value = Convert.ToDateTime(tb.Text);

                tb = (TextBox)gvViewReservations.Rows[e.RowIndex].Cells[4].Controls[0];
                cmd1.Parameters.Add(new NpgsqlParameter("p", Convert.ToInt16(tb.Text)));
                int rd1;
                Int32.TryParse(gvViewReservations.Rows[e.RowIndex].Cells[0].Text, out rd1);
                cmd1.Parameters.Add(new NpgsqlParameter("rid",rd1));

                

                NpgsqlCommand cmd2 = new NpgsqlCommand("UPDATE attendantreservations SET \"firstname\" =:fn, \"lastname\" =:ln  WHERE attendantreservations.resid = :rid", conn);

                tb = (TextBox)gvViewReservations.Rows[e.RowIndex].Cells[1].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("fn", NpgsqlTypes.NpgsqlDbType.Text));
                cmd2.Parameters[0].Value = tb.Text;

                tb = (TextBox)gvViewReservations.Rows[e.RowIndex].Cells[2].Controls[0];
                cmd2.Parameters.Add(new NpgsqlParameter("ln", NpgsqlTypes.NpgsqlDbType.Text));
                cmd2.Parameters[1].Value = tb.Text;

                int rd2;
                Int32.TryParse(gvViewReservations.Rows[e.RowIndex].Cells[0].Text, out rd2);
                cmd2.Parameters.Add(new NpgsqlParameter("rid", rd2));



                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                gvViewReservations.EditIndex = -1;
                conn.Close();
                ispolniTabela();
            }
        }

        protected void gvViewReservations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd1 = new NpgsqlCommand("DELETE FROM attendantreservations WHERE attendantreservations.resid=:rid", conn);

                int rd1;
                Int32.TryParse(gvViewReservations.Rows[e.RowIndex].Cells[0].Text, out rd1);
                cmd1.Parameters.Add(new NpgsqlParameter("rid", rd1));



                NpgsqlCommand cmd2 = new NpgsqlCommand("DELETE FROM seats_reserved WHERE seats_reserved.resid=:rid", conn);

                int rd2;
                Int32.TryParse(gvViewReservations.Rows[e.RowIndex].Cells[0].Text, out rd2);
                cmd2.Parameters.Add(new NpgsqlParameter("rid", rd2));

                NpgsqlCommand cmd3 = new NpgsqlCommand("DELETE FROM reservations WHERE reservations.resid=:rid", conn);

                int rd3;
                Int32.TryParse(gvViewReservations.Rows[e.RowIndex].Cells[0].Text, out rd3);
                cmd3.Parameters.Add(new NpgsqlParameter("rid", rd3));

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                gvViewReservations.EditIndex = -1;
                conn.Close();
                ispolniTabela();
            }

        }

    }
}