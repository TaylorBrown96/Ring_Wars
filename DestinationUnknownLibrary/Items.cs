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
	public class Items : Item
	{
		// Stores all created item objects
		public static List<Items> items = new List<Items>();

		// Constructor
        public Items(int id, string name, int price, bool questItem, bool required, string description)
			:base(id,name,price,description)
		{
			Id = id;
			Name = name;
			Price = price;
			QuestItem = questItem;
			Required = required;
			Description = description;
		}

		public bool QuestItem { get; set; }
		public bool Required { get; set; }

		// Calls the DB Query and Creates the objects from the DB records
		public static void Load()
		{
			items = SqliteDataAccess.LoadItems();
		}
    }
}
