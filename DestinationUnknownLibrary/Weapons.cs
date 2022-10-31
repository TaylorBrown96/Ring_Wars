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

		//Constructor
		public Weapons(int id, string name, string description, int price, string dmgtype, int damage)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Description = description;
			Price = price;
            DmgType = dmgtype;
            Damage = damage;
		}

		public string DmgType { get; set; }
		public int Damage { get; set; }

		public static void Load()
		{
			Weapon = SqliteDataAccess.LoadWeapons();
		}
	}
}
