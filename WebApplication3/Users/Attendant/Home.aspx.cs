using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaviGO.Users.Attendant
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)

        {
            Master.Logout += new EventHandler(lbLogout_Click);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            lblPasswordMessage.Text = "";
            if (Session["user"]==null)
            {
                    Response.Redirect("~/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                this.Master.IdentifyUser = ((string)Session["user"]).Split(' ')[0];

            }
            if (!IsPostBack)
            {
                this.Master.IdentifyUser = ((string)Session["user"]).Split(' ')[0];

                string fname = "";
                string lname = "";
                string email = "";
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string uname = ((string)Session["user"]).Split(' ')[0];
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT username, firstname, lastname, email FROM users WHERE users.username='" + uname + "'", conn);
                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            fname = reader.GetString(1);
                            lname = reader.GetString(2);
                            email = reader.GetString(3);

                        }
                    }
                    tbUsername.Text = uname;
                    tbEmail.Text = email;
                    tbFirstName.Text = fname;
                    tbLastName.Text = lname;
                    conn.Close();
                }
            }
            if (!IsPostBack)
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string uname = ((string)Session["user"]).Split(' ')[0];
                    NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT users.userid, phoneno FROM users, user_phoneno WHERE username = '" + uname + "' AND users.userid = user_phoneno.userid", conn);
                    using (var reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt16(reader.GetValue(0));
                            string phoneno = reader.GetString(1);
                            ListItem li = new ListItem(phoneno, id.ToString());
                            lstPhoneNo.Items.Add(li);

                        }
                    }
                    conn.Close();
                }
            }

        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE users SET \"email\" = :e, \"firstname\" = :f, \"lastname\" = :l WHERE users.username = '" + tbUsername.Text + "'", conn);
                cmd.Parameters.Add(new NpgsqlParameter("e", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[0].Value = tbEmail.Text;
                cmd.Parameters.Add(new NpgsqlParameter("f", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[1].Value = tbFirstName.Text;
                cmd.Parameters.Add(new NpgsqlParameter("l", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[2].Value = tbLastName.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string userpw = ((string)Session["user"]).Split(' ')[1];
            if (userpw.Equals(tbOldPassword.Text))
            {
                string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE users SET \"password\" = :p  WHERE users.username = '" + tbUsername.Text + "'", conn);
                    cmd.Parameters.Add(new NpgsqlParameter("p", NpgsqlTypes.NpgsqlDbType.Text));
                    cmd.Parameters[0].Value = tbNewPassword.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else
            {
                lblPasswordMessage.Text = "Wrong old password!";
            }
        }

        protected void btnNewPhoneNo_Click(object sender, EventArgs e)
        {
            int id = 0;
            string user = ((string)Session["user"]).Split(' ')[0];
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT userid FROM users WHERE username = '" + user + "'", conn);
                id = Convert.ToInt16(cmd2.ExecuteScalar());
                NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT into user_phoneno (userid, phoneno) values (:ui, :pn)", conn);
                cmd1.Parameters.Add(new NpgsqlParameter("ui", id));
                cmd1.Parameters.Add(new NpgsqlParameter("pn", tbNewPhoneNo.Text));
                cmd1.ExecuteNonQuery();
            }
            ListItem li = new ListItem(tbNewPhoneNo.Text, id.ToString());
            lstPhoneNo.Items.Add(li);

        }

        protected void btnDeletePhoneNo_Click(object sender, EventArgs e)
        {
            string connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlCommand cmd1 = new NpgsqlCommand("DELETE FROM user_phoneno WHERE userid=:uid and \"phoneno\"=:pn", conn);
                int rd1;
                Int32.TryParse(lstPhoneNo.SelectedItem.Value, out rd1);
                cmd1.Parameters.Add(new NpgsqlParameter("uid", rd1));
                cmd1.Parameters.Add(new NpgsqlParameter("pn", lstPhoneNo.SelectedItem.Text));
                cmd1.ExecuteNonQuery();
            }
            lstPhoneNo.Items.Remove(lstPhoneNo.SelectedItem);
        }
    }
}