/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace RingWarsLibrary
{
    public class SqliteDataAccess
    {
        // Accessing Item Table
        public static Items GetItem(string itemID)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Item WHERE ItemID == @item", con);
                cmd.Parameters.AddWithValue("@item", itemID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                Items item;

                rdr.Read();
                item = new Items(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetString(3)), Convert.ToBoolean(rdr.GetString(4)), rdr.GetString(5));
                rdr.Close();

                return item;
            }
        }


        // Accessing Weapons Table
        public static Weapons GetWeapon(string weaponID)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Weapons WHERE WeaponID == @weapon", con);
                cmd.Parameters.AddWithValue("@weapon", weaponID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                Weapons weapon;

                rdr.Read();
                weapon = new Weapons(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),rdr.GetInt32(3), rdr.GetString(4), rdr.GetInt32(5));
                rdr.Close();

                return weapon;
            }
        }

        // Accessing Potion Table
        public static Potions GetPotion(string potionID)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Potions WHERE PotionID == @potion", con);
                cmd.Parameters.AddWithValue("@potion", potionID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                Potions potion;

                rdr.Read();
                potion = new Potions(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetString(4));
                rdr.Close();

                return potion;
            }
        }

        // Accessing Treasure Table
        public static Treasures GetTreasure(string treasureID)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Treasure WHERE TreasureID == @treasure", con);
                cmd.Parameters.AddWithValue("@treasure", treasureID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                Treasures treasure;

                rdr.Read();
                treasure = new Treasures(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), Convert.ToBoolean(rdr.GetString(3)), rdr.GetString(4));
                rdr.Close();

                return treasure;
            }
        }

        // Accessing Mob Table
        public static Mobs GetMob(string mobID)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Mobs WHERE MobID == @mob", con);
                cmd.Parameters.AddWithValue("@mob", mobID);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                Mobs mob;

                rdr.Read();
                List<Item> inv = LoadMobInv(Convert.ToString(rdr.GetInt32(0)));
                mob = new Mobs(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetString(5), rdr.GetString(6), inv);
                rdr.Close();

                return mob;
            }
        }

        public static List<Item> LoadMobInv(string value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT * FROM MobInventory WHERE MobID == @mobID", con);
                cmd.Parameters.AddWithValue("@mobID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Item> inv = new List<Item>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        inv.Add(GetItem(Convert.ToString(rdr.GetInt32(1))));
                    }
                    else if (!rdr.IsDBNull(2))
                    {
                        inv.Add(GetWeapon(Convert.ToString(rdr.GetInt32(2))));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        inv.Add(GetPotion(Convert.ToString(rdr.GetInt32(3))));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        inv.Add(GetTreasure(Convert.ToString(rdr.GetInt32(4))));
                    }
                }
                return inv;
            }
        }

        // Access Player Table
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
                List<Item> PInv = new List<Item>();
                List<int> PQue = new List<int>();

                while (rdr.Read())
                {
                    PInv = PlayerInventory(rdr.GetInt32(0));
                    PQue = PlayerQuest(rdr.GetInt32(0));
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

        // Setting playerInventory List to varibale
        public static List<Item> PlayerInventory(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from PlayerInventory WHERE PlayerID == @playerID", con);
                cmd.Parameters.AddWithValue("@playerID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Item> PInv = new List<Item>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        PInv.Add(GetItem(Convert.ToString(rdr.GetInt32(1))));
                    }
                    else if (!rdr.IsDBNull(2))
                    {
                        PInv.Add(GetWeapon(Convert.ToString(rdr.GetInt32(2))));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        PInv.Add(GetPotion(Convert.ToString(rdr.GetInt32(3))));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        PInv.Add(GetTreasure(Convert.ToString(rdr.GetInt32(4))));
                    }
                }
                return PInv;
            }
        }

        // Setting playerQuest List to varibale
        public static List<int> PlayerQuest(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from PlayerQuests WHERE PlayerID == @playerID", con);
                cmd.Parameters.AddWithValue("@playerID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<int> PQue = new List<int>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        PQue.Add(rdr.GetInt32(1));
                    }
                }
                return PQue;
            }
        }

        public static Player InsertPlayer(int id, string name, string password, string race, string Pclass, int hp, int location, List<Item> inv, List<int> quests)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var playerTable = new SQLiteCommand("INSERT into Player VALUES(@id, @name, @password, @race, @Pclass, @hp, @location)", con);
                playerTable.Parameters.AddWithValue("@id",id);
                playerTable.Parameters.AddWithValue("@name", name);
                playerTable.Parameters.AddWithValue("@password", password);
                playerTable.Parameters.AddWithValue("@race", race);
                playerTable.Parameters.AddWithValue("@Pclass", Pclass);
                playerTable.Parameters.AddWithValue("@hp", hp);
                playerTable.Parameters.AddWithValue("@location", location);
                playerTable.ExecuteNonQuery();

                foreach (Item item in inv)
                {
                    if (item.Id >= 500 && item.Id <= 599) // Item
                    {
                        var PlayerInv = new SQLiteCommand("INSERT into PlayerInventory VALUES(@id, @item, null, null, null)", con);
                        PlayerInv.Parameters.AddWithValue("@id", id);
                        PlayerInv.Parameters.AddWithValue("@item", item.Id);
                        PlayerInv.ExecuteNonQuery();
                    }
                    else if (item.Id >= 200 && item.Id <= 299) // Potion
                    {
                        var PlayerInv = new SQLiteCommand("INSERT into PlayerInventory VALUES(@id, null, @item, null, null)", con);
                        PlayerInv.Parameters.AddWithValue("@id", id);
                        PlayerInv.Parameters.AddWithValue("@item", item.Id);
                        PlayerInv.ExecuteNonQuery();
                    }
                    else if (item.Id >= 300 && item.Id <= 399) // Weapon
                    {
                        var PlayerInv = new SQLiteCommand("INSERT into PlayerInventory VALUES(@id, null, null, @item, null)", con);
                        PlayerInv.Parameters.AddWithValue("@id", id);
                        PlayerInv.Parameters.AddWithValue("@item", item.Id);
                        PlayerInv.ExecuteNonQuery();
                    }
                    else if (item.Id >= 400 && item.Id <= 499) // Treasure
                    {
                        var PlayerInv = new SQLiteCommand("INSERT into PlayerInventory VALUES(@id, null, null, null, @item)", con);
                        PlayerInv.Parameters.AddWithValue("@id", id);
                        PlayerInv.Parameters.AddWithValue("@item", item.Id);
                        PlayerInv.ExecuteNonQuery();
                    }
                }
                
                foreach(int quest in quests)
                {
                    var PlayerQuest = new SQLiteCommand("INSERT into PlayerQuests VALUES(@id, @quest)", con);
                    PlayerQuest.Parameters.AddWithValue("@id",id);
                    PlayerQuest.Parameters.AddWithValue("@quest", quest);
                    PlayerQuest.ExecuteNonQuery();
                }
                con.Close();

                Player player = new Player(id, name, password, race, Pclass, hp, location, inv, quests);

                return player;
            }
        }

        // Accessing Rooms Table
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
                    List<LivingCreature> RMob = LoadRoomMob(rdr.GetInt32(0));
                    List<Item> RLoot = LoadRoomInventory(rdr.GetInt32(0));
                    List<int> RExit = LoadRoomExit(rdr.GetInt32(0));
                    Rooms room = new Rooms(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), RMob, RLoot, RExit);
                    rooms.Add(room);
                }
                return rooms;
            }
        }

        //Setting roomMob List to variable
        public static List<LivingCreature> LoadRoomMob(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from RoomMobs WHERE RoomID == @RoomID", con);
                cmd.Parameters.AddWithValue("@RoomID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<LivingCreature> RMob = new List<LivingCreature>();
                while (rdr.Read())
                {
                   if (!rdr.IsDBNull(2))
                    {
                        RMob.Add(GetMob(Convert.ToString(rdr.GetInt32(2))));
                    }
                }
                return RMob;
            }
        }

        //Setting roomInventory List to variable
        public static List<Item> LoadRoomInventory(int value)
        {
            using (var con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Open();
                var cmd = new SQLiteCommand("Select * from RoomInventory WHERE RoomID == @RoomsID", con);
                cmd.Parameters.AddWithValue("@RoomsID", value);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                List<Item> RInv = new List<Item>();
                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(1))
                    {
                        RInv.Add(GetItem(Convert.ToString(rdr.GetInt32(1))));
                    }
                    else if (!rdr.IsDBNull(2))
                    {
                        RInv.Add(GetWeapon(Convert.ToString(rdr.GetInt32(2))));
                    }
                    else if (!rdr.IsDBNull(3))
                    {
                        RInv.Add(GetPotion(Convert.ToString(rdr.GetInt32(3))));
                    }
                    else if (!rdr.IsDBNull(4))
                    {
                        RInv.Add(GetTreasure(Convert.ToString(rdr.GetInt32(4))));
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
