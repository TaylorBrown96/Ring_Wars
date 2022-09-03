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
	public class Weapons : Item
	{
		// Stores all created weapon objects
		public static List<Weapons> Weapon = new List<Weapons>();

		public Weapons(int id, string name, string description, string dmgtype, int price, int damage)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Description = description;
			DmgType = dmgtype;
			Price = price;
			Damage = damage;
		}
		public string DmgType { get; set; }
		public int Damage { get; set; }


		// Loads Weapons
		public static void LoadWeapons()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Weapons.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int weaponID = int.Parse(tokens[0]);
				string name = tokens[1];
				string description = tokens[2];
				string dmgType = tokens[3];
				int price = int.Parse(tokens[4]);
				int damage = int.Parse(tokens[5]);

				Weapon.Add(new Weapons(weaponID, name, description, dmgType, price, damage));
			}
			reader.Close();
		}
	}
}
