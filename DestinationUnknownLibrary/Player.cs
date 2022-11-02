﻿/**
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
	public class Player : LivingCreature
	{
		public Player(int id, string name, string password, string race, string Pclass, int hp, int location, List<int> inventory, List<int> quests)
			: base(id, name, race, hp)
		{
			Id = id;
			Name = name;
			Password = password;
			Race = race;
			Class = Pclass;
			HP = hp;
			Location = location;
			Inventory = inventory;
			Quests = quests;
		}

		public string Password { get; set; }
		public string Class { get; set; }
		public int Location { get; set; }
		public List<int> Inventory { get; set; }
		public List<int> Quests { get; set; }


		// Loads User profile
		public static Player Load()
		{
			Player player = SqliteDataAccess.LoadPlayer();
            if (player.Name == "")
            {
                player = CreatePlayer();
            }

			return player;
		}

		public static Player CreatePlayer()
		{
            int id = 0;
            string name = "";
            string password = "";
            string race = "";
            string Pclass = "";
            int hp = 100;
            int location = 0;
            List<int> inv = new List<int>();
            List<int> quests = new List<int>();

            id = 0;

            Console.Write("Please enter a username: ");
            name = Console.ReadLine();

            bool valid = false;
            password = "";
            string specialChar = "!@#$%^&*()-_=+[{]};:,<.>/?|`~";
            while (!valid)
            {
                Console.Write("Please enter a password: ");
                password = Console.ReadLine();
                if (!password.Any(char.IsUpper))
                {
                    Console.WriteLine("Your password must contain an uppercase letter\n");
                    continue;
                }
                else if (!password.Any(char.IsLower))
                {
                    Console.WriteLine("Your password must contain a lowercase letter\n");
                    continue;
                }
                foreach (char c in specialChar)
                {
                    if (password.Contains(c))
                    {
                        valid = true;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("Your password must contain a special character\n");
                }
            }

            race = "";

            valid = false;
            while (!valid)
            {
                Console.WriteLine("\nOptions: Elf, Human, Dwarf, Ogre, and Worgen");
                Console.Write("Please enter in a race: ");
                race = Console.ReadLine();
                switch (race.ToLower())
                {
                    case "elf":
                        valid = true;
                        break;
                    case "human":
                        valid = true;
                        break;
                    case "dwarf":
                        valid = true;
                        break;
                    case "ogre":
                        valid = true;
                        break;
                    case "worgen":
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid option!");
                        continue;
                }
            }

            Pclass = "";
            valid = false;
            while (!valid)
            {
                Console.WriteLine("\nOptions: Warrior, Hunter, Mage, Rouge, and Shawman");
                Console.Write("Please enter in a class: ");
                Pclass = Console.ReadLine();

                switch (Pclass.ToLower())
                {
                    case "warrior":
                        valid = true;
                        break;
                    case "hunter":
                        valid = true;
                        break;
                    case "mage":
                        valid = true;
                        break;
                    case "rouge":
                        valid = true;
                        break;
                    case "shawman":
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid option!");
                        continue;
                }
            }
            Console.WriteLine();

            hp = 100;
            location = 100;
            inv.Add(200);
            inv.Add(300);
            inv.Add(302);

            Player player = SqliteDataAccess.InsertPlayer(id, name, password, race, Pclass, hp, location, inv, quests);

            return player;
		}
	}
}
