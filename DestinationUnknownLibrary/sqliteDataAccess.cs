using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DestinationUnknownLibrary
{
    public class SqliteDataAccess
    {
        // Does a select query to gather all records and their fields from the DB
        public static List<Items> LoadItems()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Item", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Items> items = new List<Items>();

                while (rdr.Read())
                {
                    Items item = new Items(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetString(3)), Convert.ToBoolean(rdr.GetString(4)), rdr.GetString(5));
                    items.Add(item);
                }
                return items;
            }
        }


        // Connection string
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
