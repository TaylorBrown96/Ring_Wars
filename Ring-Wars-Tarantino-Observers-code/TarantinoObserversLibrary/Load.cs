using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TarantinoObserversLibrary
{
    public static class Load
    {
        public static void loadRoom()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Rooms.csv"))
            while (!reader.EndOfStream)
            {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID, Name, Description, exits)
                        World.rooms.Add(new Room(tokens[0], tokens[1], tokens[2], tokens[3]));
                    }
                    else
                    {
                        firstLine = false;
                    }
            }
        }
        public static void loadWeapons()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Weapons.csv"))
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID, Name, Description, Damage Type, price, Damage)
                        World.weapons.Add(new Weapon(tokens[3], tokens[5]));
                    }
                    else
                    {
                        firstLine = false;
                    }
                }
        }
        public static void loadMobs()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Mobs.csv"))
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID, Name, Race, Class, HP, AC, Weapon, Inventory, Description)
                        World.mobs.Add(new Mob(tokens[0], tokens[1]));
                    }
                    else
                    {
                        firstLine = false;
                    }
                }
        }

        public static void loadPotions()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Potions.csv"))
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID,Name,Description,Value Change,Price)
                        World.potion.Add(new Potion(tokens[0], tokens[1]));
                    }
                    else
                    {
                        firstLine = false;
                    }
                }
        }

        public static void loadTreasures()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Treasures.csv"))
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID,Name,Description,Quest Item,Price)
                        World.treasure.Add(new Treasure(tokens[0], tokens[1]));
                    }
                    else
                    {
                        firstLine = false;
                    }
                }
        }

        public static void loadItems()
        {
            bool firstLine = true;
            using (StreamReader reader = File.OpenText(@"C:\Users\Parker Pawn\source\repos\TarantinoObservers\TarantinoObserversLibrary\LoadFiles\Items.csv"))
                while (!reader.EndOfStream)
                {
                    string[] tokens = reader.ReadLine().Split(',');
                    if (firstLine != true)
                    {
                        //Tokens in order (ID,Name,Description,Item Type,Price)
                        World.item.Add(new Item(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4]));
                    }
                    else
                    {
                        firstLine = false;
                    }
                }
        }
    }
}
