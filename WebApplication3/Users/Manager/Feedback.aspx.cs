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
    public partial class Feedback : System.Web.UI.Page
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        protected void ispolniTabela()
        {
            DataTable ourDataTable = null;
            string query = "SELECT feedid, email, message, answer FROM feedback";
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                ourDataTable = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataAdapter ourAdapter = new NpgsqlDataAdapter();
                ourAdapter.SelectCommand = cmd;
                ourAdapter.Fill(ourDataTable);
                gvFeedbacks.DataSource = ourDataTable;
                gvFeedbacks.DataBind();

                ViewState["dataset"] = ourDataTable;
                conn.Close();
            }

        }

        protected void gvEditTrips_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvFeedbacks.EditIndex = -1;
            gvFeedbacks.DataSource = ds;
            gvFeedbacks.DataBind();
        }


        protected void gvEditTrips_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable ds = (DataTable)ViewState["dataset"];
            gvFeedbacks.EditIndex = e.NewEditIndex;
            gvFeedbacks.DataSource = ds;
            gvFeedbacks.DataBind();
        }

        protected void gvEditTrips_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE feedback SET \"answer\" = :a  WHERE feedid = :fid", conn);
                TextBox tb = (TextBox)gvFeedbacks.Rows[e.RowIndex].Cells[3].Controls[0];
                cmd.Parameters.Add(new NpgsqlParameter("a", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[0].Value = tb.Text;

                int rd1;
                Int32.TryParse(gvFeedbacks.Rows[e.RowIndex].Cells[0].Text, out rd1);
                cmd.Parameters.Add(new NpgsqlParameter("fid", rd1));
                cmd.ExecuteNonQuery();
                gvFeedbacks.EditIndex = -1;
                conn.Close();
                ispolniTabela();
            }
        }
    }
}