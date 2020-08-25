using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NaviGO.Models;
using Npgsql;
using System.Collections.Generic;

namespace NaviGO.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                lblMessage.Text = "";
                Session["user"] = null;
            
        }
        protected void LogIn(object sender, EventArgs e)
        {
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                int flag = 0;
                NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT username, password FROM users", conn);
                LinkedList<string> listUsers = new LinkedList<string>();
                using (var reader = cmd1.ExecuteReader())
                    while (reader.Read())
                    {
                        if(reader.GetString(0).Equals(username))
                        {
                            flag = 1;
                            if(reader.GetString(1).Equals(password))
                            {
                                if(Session["user"] == null)
                                Session["user"] = reader.GetString(0) + " " + reader.GetString(1);
                                if(reader.GetString(0).Equals("manager"))
                                {
                                    Response.Redirect("~/Users/Manager/Home.aspx");
                                }
                                else if(reader.GetString(0).Contains("dispatc"))
                                {
                                    Response.Redirect("~/Users/Dispatcher/Home.aspx");
                                }
                                else if(reader.GetString(0).Contains("attendant"))
                                {
                                    Response.Redirect("~/Users/Attendant/Home.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Users/Client/Home.aspx");
                                }
                                break;
                            }
                            else
                            {
                                lblMessage.Text = "Incorrect password.";
                                break;
                            }
                        }
                       
                    }
                    if(flag==0)
                    {
                    lblMessage.Text = "The user doesn't exist.";
                    }
                conn.Close();
                
            }


        }
    }
}