using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace NaviGO
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* lstVozaci.Items.Clear();
            var connString = "Host=localhost;Username=postgres;Password=likeg6;Database=postgres";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();


                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT firstname FROM users", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = reader.GetString(0);
                        //Console.WriteLine(reader.GetString(0));
                        lstVozaci.Items.Add(li);
                    }
            }*/

        }

        protected void lstVozaci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}