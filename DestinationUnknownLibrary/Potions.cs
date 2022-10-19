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
	public class Potions : Item
	{
		// Stores all created potion objects
		public static List<Potions> Potion = new List<Potions>();

		public Potions(int id, string name, int price, string effects, string description)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Price = price;
			Effects = effects;
			Description = description;
		}
		public string Effects { get; set; }

		// Calls the DB Query and Creates the objects from the DB records
		public static void Load()
		{
			Potion = SqliteDataAccess.LoadPotions();
		}
	}
}
