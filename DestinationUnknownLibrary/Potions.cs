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

		public Potions(int id, string name, int price, int value, string description)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Price = price;
			Value = value;
			Description = description;
		}
		public int Value { get; set; }


		// Loads Potions
		public static void LoadPotions()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Potions.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				int value = int.Parse(tokens[3]);
				string description = tokens[4];

				Potion.Add(new Potions(id, name, price, value, description));
			}
			reader.Close();
		}
	}
}
