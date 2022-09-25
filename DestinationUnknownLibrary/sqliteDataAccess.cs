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
                rdr.Close();

                return items;
            }
        }

        public static List<Mobs> LoadMobs()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Mobs",con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Mobs> items = new List<Mobs>();
                while (rdr.Read())
                {
                    List<int> inv = LoadMobInv(Convert.ToString(rdr.GetInt32(0)));
                    Mobs mob = new Mobs(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), inv);
                    items.Add(mob);
                }
                rdr.Close();

                return items;
            }
        }

        public static List<int> LoadMobInv(string value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM MobInventory WHERE MobID == @mobID", con);
                cmd.Parameters.AddWithValue("@mobID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> inv = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        inv.Add(rdr.GetInt32(1));
                    }
                    else if (!rdr.IsDBNull(2))
                    {
                        inv.Add(rdr.GetInt32(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        inv.Add(rdr.GetInt32(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        inv.Add(rdr.GetInt32(4));
                    }
                }
                return inv;
            }
        }



        // Connection string
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
