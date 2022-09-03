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

		public Mobs(int id, string name, string race, int hp, int ad, string weapon, string description, List<string> inventory) 
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
		public List<string> Inventory { get; set; }


		// Loads Mobs
		public static void LoadMobs()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Mobs.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				List<string> inv = new List<string>();
				for (int i = 7; i < tokens.Length; i++)
				{
					inv.Add(tokens[i]);
				}

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				string race = tokens[2];
				int hp = int.Parse(tokens[3]);
				int ad = int.Parse(tokens[4]);
				string weapon = tokens[5];
				string description = tokens[6];

				Mob.Add(new Mobs(id, name, race, hp, ad, weapon, description, inv));
			}
			reader.Close();
		}
	}
}
