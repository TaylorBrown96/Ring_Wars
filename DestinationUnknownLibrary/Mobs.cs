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
	public class Mobs : LivingCreature
	{
		// Stores all created mob objects
		public static List<Mobs> Mob = new List<Mobs>();

		public Mobs(int id, string name, string race, int hp, int ad, string weapon, string description, List<int> inventory) 
			: base(id, name, race, hp)
		{
			Id = id;
			Name = name;
			Race = race;
			HP = hp;
			AD = ad;
			Weapon = weapon;
			Description = description;
			Inventory = inventory;
		}

		public int AD { get; set; }
		public string Weapon { get; set; }
		public string Description { get; set; }
		public List<int> Inventory { get; set; }

        // Calls the DB Query and Creates the objects from the DB records
        public static void Load()
        {
            Mob = SqliteDataAccess.LoadMobs();
        }
	}
}
