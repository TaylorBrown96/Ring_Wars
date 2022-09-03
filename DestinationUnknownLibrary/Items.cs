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
		public static List<Items> Item = new List<Items>();

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


		// Loads Items
		public static void LoadItems()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Items.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				bool questItem = bool.Parse(tokens[3]);
				bool required = bool.Parse(tokens[4]);
				string description = tokens[5];

				Item.Add(new Items(id, name, price, questItem, required, description));
			}
			reader.Close();
		}
	}
}
