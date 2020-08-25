using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Client
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
                lblMessage.Text = "";
            }
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                int userid=0;
                int passid=0;
                string email="";
                string username = ((string)Session["user"]).Split(' ')[0];
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT users.userid, passengerid, email FROM users, passengers WHERE users.userid=passengers.userid and username='"+username+"'", conn);
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                        userid = Convert.ToInt32(reader.GetValue(0));
                        passid = Convert.ToInt32(reader.GetValue(1));
                        userid = 9;
                        passid = 3;
                            email = reader.GetString(2);
                        }
                    }
                    NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT into feedback (passenger_userid, passengerid, employee_userid, employeeid, email, message) values (:pui, :pi, :eui, :ei, :m , :f)", conn);
                    cmd1.Parameters.Add(new NpgsqlParameter("pui", userid));
                    cmd1.Parameters.Add(new NpgsqlParameter("pi", passid));
                    cmd1.Parameters.Add(new NpgsqlParameter("eui", 1));
                    cmd1.Parameters.Add(new NpgsqlParameter("ei", 1));
                    cmd1.Parameters.Add(new NpgsqlParameter("m", email));
                    cmd1.Parameters.Add(new NpgsqlParameter("f", tbFeedback.Text));
                    cmd1.ExecuteNonQuery();
                    lblMessage.Text = "Your feedback has been successfully sent to us. Thank you.";
                }
                catch (Exception)
                {   
                    lblMessage.Text = "Your feedback failed to be sent. Try again later.";
                }
            }
        }
    }
}