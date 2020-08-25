using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Npgsql;
using Owin;
using NaviGO.Models;
using System.Collections.Generic;

namespace NaviGO.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            lblMessage.Text = "";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string user = Username.Text;
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT username FROM users",conn);
                LinkedList < string > listUsers = new LinkedList<string>();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        listUsers.AddLast(reader.GetString(0));
                        //Console.WriteLine(reader.GetString(0));
                    }
                // Vnesi nov user
                if (!listUsers.Contains(user))
                {
                    try
                    {
                        NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO users (username,password,firstname,lastname,email) values (:un, :pw, :fn, :ln, :em)", conn);
                        cmd1.Parameters.Add(new NpgsqlParameter("un", Username.Text));
                        cmd1.Parameters.Add(new NpgsqlParameter("pw", Password.Text));
                        cmd1.Parameters.Add(new NpgsqlParameter("em", Email.Text));
                        cmd1.Parameters.Add(new NpgsqlParameter("fn", FirstName.Text));
                        cmd1.Parameters.Add(new NpgsqlParameter("ln", LastName.Text));
                        cmd1.ExecuteNonQuery();
                        NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT userid FROM users WHERE username = '" + user + "'", conn);
                        int id = Convert.ToInt16(cmd2.ExecuteScalar());
                        //lblMessage.Text = Convert.ToString(id);
                        //int id = 24;
                        NpgsqlCommand cmd3 = new NpgsqlCommand("INSERT INTO user_phoneno (userid,phoneno) values (:ui, :pn)", conn);
                        cmd3.Parameters.Add(new NpgsqlParameter("ui", id));
                        cmd3.Parameters.Add(new NpgsqlParameter("pn", PhoneNo.Text));
                        cmd3.ExecuteNonQuery();
                        NpgsqlCommand cmd4 = new NpgsqlCommand("INSERT INTO passengers (userid) values(:ui)", conn);
                        cmd4.Parameters.Add(new NpgsqlParameter("ui", id));
                        cmd4.ExecuteNonQuery();
                        lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#77F902");
                        lblMessage.Text = "Your registration has been successfully completed. Please go to the home page and log in.";
                    }
                    catch (Exception)
                    {
                        lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F15864");
                        lblMessage.Text = "Your registration failed.";
                    }
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E8BA25");
                    lblMessage.Text = "The username is already taken!";
                }
                conn.Close();
            }
        }
    }
}