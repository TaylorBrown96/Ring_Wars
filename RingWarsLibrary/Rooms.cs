/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System.Collections.Generic;

namespace RingWarsLibrary
{
    public class Rooms
    {
        // Stores all created room objects
        public static List<Rooms> Room = new List<Rooms>();

        // Constructor
        public Rooms(int room_ID, string name, string description, List<LivingCreature> mobs, List<Item> loot, List<int> exits)
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
        public List<LivingCreature> Mob { get; set; }
        public List<Item> Loot { get; set; }
        public List<int> Exit { get; set; }

        public static void Load()
        {
            Room = SqliteDataAccess.LoadRooms();
        }
    }
}
