/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Collections.Generic;

namespace RingWarsLibrary
{
	public class Treasures : Item
	{
		// Stores all created treasure objects
		public static List<Item> Treasure = new List<Item>();

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
	}
}
