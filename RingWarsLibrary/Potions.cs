/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Collections.Generic;

namespace RingWarsLibrary
{
	public class Potions : Item
	{
		// Stores all created potion objects
		public static List<Item> Potion = new List<Item>();

		//Constructor
		public Potions(int id, string name, int price, int effects, string description)
			: base(id, name, price, description)
		{
			Id = id;
			Name = name;
			Price = price;
			Effects = effects;
			Description = description;
		}

		public int Effects { get; set; }
	}
}
