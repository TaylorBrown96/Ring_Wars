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
	public class Rooms
	{
		// Stores all created room objects
		public static List<Rooms> Room = new List<Rooms>();

		// Constructor
		public Rooms(int room_ID, string name, string description, List<int> mobs, List<int> loot, List<int> exits)
		{
			Room_ID = room_ID;
			Name = name;
			Description = description;
			Mob = mobs;
			Loot = loot;
			Exit = exits;
		}

		public int Room_ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<int> Mob { get; set; }
		public List<int> Loot { get; set; }
		public List<int> Exit { get; set; }

		public static void Load()
		{
			Room = SqliteDataAccess.LoadRooms();
		}
	}
}
