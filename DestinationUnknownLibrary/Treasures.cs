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
	public class Treasures : Item
	{
		// Stores all created treasure objects
		public static List<Treasures> Treasure = new List<Treasures>();

		//Constructor
		public Treasures(int id, string name, int price, bool questItem, string description)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Price = price;
			QuestItem = questItem;
			Description = description;
		}

		public bool QuestItem { get; set; }

		public static void Load()
		{
			Treasure = SqliteDataAccess.LoadTreasures();
		}
	}
}
