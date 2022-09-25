using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace DestinationUnknownLibrary
{
    public class SqliteDataAccess
    {
        // Does a select query to gather all records and their fields from the DB
        //Accessing Items Table
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

        //Accessing Weapons Table
        public static List<Weapons> LoadWeapons()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Weapon", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Weapons> weapons = new List<Weapons>();

                while (rdr.Read())
                {
                    Weapons weapon = new Weapons(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(4), rdr.GetInt32(5));
                    weapons.Add(weapon);
                }
                return weapons;
            }
        }

        //Accessing Mobs Table
        public static List<Mobs> LoadMobs()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Mob", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Mobs> mobs = new List<Mobs>();

                while (rdr.Read())
                {
                    List<string> inv = LoadMobInv(Convert.ToString(rdr.GetInt32(0)));
                    Mobs mob = new Mobs(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), inv);
                    mobs.Add(mob);
                }
                return mobs;
            }
        }

        //Accessing List for mobInventory
        public static List<string> LoadMobInv(string value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from MobInventory WHERE MobID == @mobID", con);
                cmd.Parameters.AddWithValue("@mobID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<string> inv = new List<string>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        inv.Add(rdr.GetString(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        inv.Add(rdr.GetString(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        inv.Add(rdr.GetString(4));
                    }
                    else if (!rdr.IsDBNull(5))
                    {
                        inv.Add(rdr.GetString(5));
                    }
                }
                return inv;
            }
        }
        //Accessing Potions Table
        public static List<Potions> LoadPotions()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Potion", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Potions> potions = new List<Potions>();

                while (rdr.Read())
                {
                    Potions potion = new Potions(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetString(4));
                    potions.Add(potion);
                }
                return potions;
            }
        }

        //Accessing Rooms Table
        public static List<Rooms> LoadRooms()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Room", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Rooms> rooms = new List<Rooms>();

                while (rdr.Read())
                {
                    List<int> RMob = LoadRoomMob(rdr.GetInt32(0));
                    List<int> RLoot = LoadRoomInventory(rdr.GetInt32(0));
                    List<int> RExit = LoadRoomExit(rdr.GetInt32(0));
                    Rooms room = new Rooms(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), RMob, RLoot, RExit);
                    rooms.Add(room);
                }
                return rooms;
            }
        }

        //Setting roomMob List to variable
        public static List<int> LoadRoomMob(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from Rooms WHERE RoomID == @RoomsID", con);
                cmd.Parameters.AddWithValue("@RoomsID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> RMob = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        RMob.Add(rdr.GetInt32(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        RMob.Add(rdr.GetInt32(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        RMob.Add(rdr.GetInt32(4));
                    }
                    else if (!rdr.IsDBNull(5))
                    {
                        RMob.Add(rdr.GetInt32(5));
                    }
                }
                return RMob;
            }
        }

        //Setting roomInventory List to variable
        public static List<int> LoadRoomInventory(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from Rooms WHERE RoomID == @RoomsID", con);
                cmd.Parameters.AddWithValue("@RoomsID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> RInv = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        RInv.Add(rdr.GetInt32(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        RInv.Add(rdr.GetInt32(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        RInv.Add(rdr.GetInt32(4));
                    }
                    else if (!rdr.IsDBNull(5))
                    {
                        RInv.Add(rdr.GetInt32(5));
                    }
                }
                return RInv;
            }
        }

        //Setting roomExit List to variable
        public static List<int> LoadRoomExit(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from Rooms WHERE RoomID == @RoomsID", con);
                cmd.Parameters.AddWithValue("@RoomsID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> RExit = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        RExit.Add(rdr.GetInt32(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        RExit.Add(rdr.GetInt32(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        RExit.Add(rdr.GetInt32(4));
                    }
                    else if (!rdr.IsDBNull(5))
                    {
                        RExit.Add(rdr.GetInt32(5));
                    }
                }
                return RExit;
            }
        }
        //Accessing Treasure Table
        public static List<Treasures> LoadTreasures()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Treasure", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Treasures> treasures = new List<Treasures>();

                while (rdr.Read())
                {
                    Treasures treasure = new Treasures(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetString(3)), rdr.GetString(4));
                    treasures.Add(treasure);
                }
                return treasures;
            }
        }

        //Access Player Table
        public static List<Player> LoadPlayer()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Player", con);
                var inv = new SQLiteCommand("Select MobID FROM MobInv", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                //Creating Player Object
                List<Player> players = new List<Player>();

                while (rdr.Read())
                {
                    List<int> PInv = playerInventory(rdr.GetInt32(0));
                    List<string> PQue = playerQuest(Convert.ToString(rdr.GetInt32(0)));
                    Player player = new Player(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(5), rdr.GetInt32(6), PInv, PQue);
                    players.Add(player);
                }
                return players;
            }
        }

        //Setting playerInventory List to varibale
        public static List<int> playerInventory(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from PlayerInventory WHERE InventoryID == @inventoryID", con);
                cmd.Parameters.AddWithValue("@inventoryID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> PInv = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        PInv.Add(rdr.GetInt32(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        PInv.Add(rdr.GetInt32(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        PInv.Add(rdr.GetInt32(4));
                    }
                    else if (!rdr.IsDBNull(5))
                    {
                        PInv.Add(rdr.GetInt32(5));
                    }
                }
                return PInv;
            }
        }

        //Setting playerQuest List to varibale
        public static List<string> playerQuest(string value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from MobInventory WHERE MobID == @mobID", con);
                cmd.Parameters.AddWithValue("@mobID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<string> PQue = new List<string>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(2))
                    {
                        PQue.Add(rdr.GetString(2));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        PQue.Add(rdr.GetString(3));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        PQue.Add(rdr.GetString(4));
                    }
                }
                return PQue;
            }
        }

        // Connection string
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
