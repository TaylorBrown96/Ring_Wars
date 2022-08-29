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


		// Loads Treasures
		public static void LoadTreasure()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Treasures.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				bool questItem = bool.Parse(tokens[3]);
				string description = tokens[4];

				Treasure.Add(new Treasures(id, name, price, questItem, description));
			}
			reader.Close();
		}
	}
}
