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


        //Accessing Weapons Table
        public static List<Weapons> LoadWeapons()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Weapons", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Weapons> weapons = new List<Weapons>();

                while (rdr.Read())
                {
                    Weapons weapon = new Weapons(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetString(4), rdr.GetInt32(5));
                    weapons.Add(weapon);
                }
                return weapons;
            }
        }

        //Accessing Potions Table
        public static List<Potions> LoadPotions()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Potions", con);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Potions> potions = new List<Potions>();

                while (rdr.Read())
                {
                    Potions potion = new Potions(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4));
                    potions.Add(potion);
                }
                return potions;
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

        public static List<Mobs> LoadMobs()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Mobs", con);
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

        //Access Player Table
        public static Player LoadPlayer()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Player", con);;
                SQLiteDataReader rdr = cmd.ExecuteReader();

                //Creating Player Object
                int id = 0;
                string name = "";
                string password = "";
                string race = "";
                string Class = "";
                int hp = 0;
                int Location = 0;
                List<int> PInv = new List<int>();
                List<string> PQue = new List<string>();

                while (rdr.Read())
                {
                    PInv = playerInventory(rdr.GetInt32(0));
                    PQue = playerQuest(Convert.ToString(rdr.GetInt32(0)));
                    id = rdr.GetInt32(0);
                    name = rdr.GetString(1);
                    password = rdr.GetString(2);
                    race = rdr.GetString(3);
                    Class = rdr.GetString(4);
                    hp = rdr.GetInt32(5);
                    Location = rdr.GetInt32(6);
                }

                Player player = new Player(id,name,password,race,Class,hp,Location,PInv,PQue);
                return player;
            }
        }

        //Setting playerInventory List to varibale
        public static List<int> playerInventory(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from PlayerInventory WHERE PlayerID == @playerID", con);
                cmd.Parameters.AddWithValue("@playerID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> PInv = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        PInv.Add(rdr.GetInt32(1));
                    }
                    else if (!rdr.IsDBNull(2))
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
                var cmd = new SQLiteCommand("Select * from PlayerQuests WHERE PlayerID == @playerID", con);
                cmd.Parameters.AddWithValue("@playerID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<string> PQue = new List<string>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        PQue.Add(rdr.GetString(1));
                    }
                }
                return PQue;
            }
        }

        //Accessing Rooms Table
        public static List<Rooms> LoadRooms()
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Rooms", con);
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
                var cmd = new SQLiteCommand("Select * from RoomMobs WHERE RoomID == @RoomID", con);
                cmd.Parameters.AddWithValue("@RoomID", value);
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
                var cmd = new SQLiteCommand("Select * from RoomInventory WHERE RoomID == @RoomsID", con);
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
                var cmd = new SQLiteCommand("Select * from RoomExits WHERE RoomID == @RoomsID", con);
                cmd.Parameters.AddWithValue("@RoomsID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> RExit = new List<int>();
                while (rdr.Read())
                {
                    RExit.Add(rdr.GetInt32(1));
                    RExit.Add(rdr.GetInt32(3));
                    RExit.Add(rdr.GetInt32(5));
                    RExit.Add(rdr.GetInt32(7));
                }
                return RExit;
            }
        }


        // Connection string
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
