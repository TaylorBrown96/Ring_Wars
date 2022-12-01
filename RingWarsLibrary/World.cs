/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/


namespace RingWarsLibrary
{
    // Loads all objects in game
    public class Load 
    {
        public static void Game()
        {
            Rooms.Load();
        }
    }


    // Parent class for living creatures
    public class LivingCreature
    {
        public LivingCreature(int id, string name, string race, double hp)
        {
            Id = id;
            Name = name;
            Race = race;
            HP = hp;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public double HP { get; set; }
    }


    // Parent class for all items
    public class Item
    {
        public Item(int id, string name, int price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
