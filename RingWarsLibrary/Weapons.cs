/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Collections.Generic;

namespace RingWarsLibrary
{
	public class Weapons : Item
	{
		// Stores all created weapon objects
		public static List<Item> Weapon = new List<Item>();

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
	}
}
