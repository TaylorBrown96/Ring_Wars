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


		// Loads Rooms
		public static void LoadRooms()
		{
			string line;
			StreamReader room = File.OpenText("Game_Data/Rooms.csv");
			StreamReader room_Mobs = File.OpenText("Game_Data/Room_Mobs.csv");
			StreamReader room_Loot = File.OpenText("Game_Data/Room_Loot.csv");
			while ((line = room.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				List<int> mobs = new List<int>();
				List<int> loot = new List<int>();
				List<int> exits = new List<int>();
				int roomID = int.Parse(tokens[0]);
				string name = tokens[1];
				string description = tokens[2];

				int north = int.Parse(tokens[3]);
				int east = int.Parse(tokens[4]);
				int south = int.Parse(tokens[5]);
				int west = int.Parse(tokens[6]);

				exits.Add(north);
				exits.Add(east);
				exits.Add(south);
				exits.Add(west);
				while ((line = room_Mobs.ReadLine()) != null)
				{
					string[] mob = line.Split(',');
					for (int i = 0; i < mob.Length; i++)
					{
						mobs.Add(int.Parse(mob[i]));
					}
					while ((line = room_Loot.ReadLine()) != null)
					{
						string[] room_loot = line.Split(',');
						for (int i = 0; i < room_loot.Length; i++)
						{
							loot.Add(int.Parse(room_loot[i]));
						}
						break;
					}
					break;
				}
				Rooms.Room.Add(new Rooms(roomID, name, description, mobs, loot, exits));
			}
			room.Close();
			room_Mobs.Close();
			room_Loot.Close();
		}
	}
}
