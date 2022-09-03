/**
* 17APR22
* CSC 153
* Taylor J. Brown
* This program is a maze/rpg text adventure game. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DestinationUnknownLibrary
{
    // Loads all objects in game
    public class Load 
    {
        public static void Game()
        {
            Rooms.LoadRooms();
            Weapons.LoadWeapons();
            Potions.LoadPotions();
            Treasures.LoadTreasure();
            Items.LoadItems();
            Mobs.LoadMobs();
        }
    }


    // Parent class for living creatures
    public class LivingCreature
    {
        public LivingCreature(int id, string name, string race, int hp)
        {
            Id = id;
            Name = name;
            Race = race;
            HP = hp;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int HP { get; set; }
    }


    // Parent class for all items
    public class Item
    {
        public Item(int id, string name, int price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
