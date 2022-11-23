/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Collections.Generic;

namespace RingWarsLibrary
{
	public class Items : Item
	{
		// Stores all created item objects
		public static List<Item> items = new List<Item>();

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
    }
}
