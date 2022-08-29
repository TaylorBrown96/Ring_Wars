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
using DestinationUnknownLibrary;

namespace ConsoleUI
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("Welcome to Destination Unknown!\n\n\n");

			Player player = Player.LoadUser();
			Load.Game();

			bool valid = false;
			while (!valid)
			{
				Console.Write("Please enter your password: ");
				string usrinp = Console.ReadLine();

				if (usrinp == player.Password)
				{
					valid = Play(player);
				}
				else
				{
					Console.WriteLine("The password entered was incorrect\n");
				}
			}
			Console.WriteLine("Thank you for playing");
			Console.ReadKey();
		}


		public static bool Play(Player player)
		{
			Console.WriteLine("Hello " + player.Name);
			int roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);
			int count = 0;
			int north;
			int east;
			int south;
			int west;

			Console.WriteLine("\nTo get started try typing 'help'");
			while (true)
			{
				Console.Write("\n>: ");
				switch (Console.ReadLine().ToLower())
				{
					case "attack":
						player.HP = Combat.Attack(player.HP);
						if (player.HP > 0)
						{
							Console.WriteLine(player.HP);
							continue;
						}
						Console.WriteLine("You Died!");
						Console.Write("\nWould you like to respawn from the start?: " );
                        while (true)
                        {
							switch (Console.ReadLine().ToLower())
							{
								case "y":
									player.HP = 100;
									roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == 100);
									break;
								case "n":
									return true;
								default:
									Console.WriteLine("I dont know that command dork");
									continue;
							}
							break;
						}
						break;
					case "i":
						foreach (int i in player.Inventory)
						{
							if (Items.Item.FindIndex(a => a.Id == i) != -1)
							{
								Console.Write("\n   " + Items.Item[Items.Item.FindIndex(a => a.Id == i)].Name);
							}
							else if (Potions.Potion.FindIndex(a => a.Id == i) != -1)
							{
								Console.Write("\n   " + Potions.Potion[Potions.Potion.FindIndex(a => a.Id == i)].Name);
							}
							else if (Weapons.Weapon.FindIndex(a => a.Id == i) != -1)
							{
								Console.Write("\n   " + Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == i)].Name);
							}
						}
						Console.Write("\n");
						break;
					case "pickup":
						if (Rooms.Room[roomIndex].Loot[0] == -1)
						{
							Console.WriteLine("Nothing to pick up");
							break;
						}
						player.Inventory.Add(Rooms.Room[roomIndex].Loot[0]);
						Rooms.Room[roomIndex].Loot.RemoveAt(0);
						break;
					case "drop":
						if (count == 0)
						{
							Rooms.Room[roomIndex].Loot[0] = player.Inventory[0];
							count = 1;
						}
						else
						{
							Rooms.Room[roomIndex].Loot.Add(player.Inventory[0]);
						}
						player.Inventory.RemoveAt(0);
						break;
					case "look":
						north = Rooms.Room[roomIndex].Exit[0];
						east = Rooms.Room[roomIndex].Exit[1];
						south = Rooms.Room[roomIndex].Exit[2];
						west = Rooms.Room[roomIndex].Exit[3];

						Console.Write("\nRoom Name: \n   " + Rooms.Room[roomIndex].Name);
						Console.Write("\n\nRoom Description: \n   " + Rooms.Room[roomIndex].Description);
						Console.Write("\n\nItems:");
						for (int i = 0; i < Rooms.Room[roomIndex].Loot.Count; i++)
						{
							if (Rooms.Room[roomIndex].Loot[i] > 0)
							{
								if (Items.Item.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
								{
									Console.Write("\n   " + Items.Item[Items.Item.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
								}
								else if (Potions.Potion.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
								{
									Console.Write("\n   " + Potions.Potion[Potions.Potion.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
								}
								else if (Weapons.Weapon.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
								{
									Console.Write("\n   " + Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
								}
							}
						}
						Console.Write("\n\nEnemies:");
						if (Rooms.Room[roomIndex].Mob[0] > 0)
						{
							Console.Write("\n   " + Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].Name);
						}

						Console.WriteLine("\n\nExits:");
						if (north > 0)
						{
							Console.WriteLine("   North: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == north)].Name);
						}
						if (east > 0)
						{
							Console.WriteLine("   East: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == east)].Name);
						}
						if (south > 0)
						{
							Console.WriteLine("   South: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == south)].Name);
						}
						if (west > 0)
						{
							Console.WriteLine("   West: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == west)].Name);
						}
						break;
					case "n":
						north = Rooms.Room[roomIndex].Exit[0];

						if (north > 0)
						{
							roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == north);
						}
						else
						{
							Console.WriteLine("There is nothing in that direction");
						}
						break;
					case "e":
						east = Rooms.Room[roomIndex].Exit[1];
						if (east > 0)
						{
							roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == east);
						}
						else
						{
							Console.WriteLine("There is nothing in that direction");
						}
						break;
					case "s":
						south = Rooms.Room[roomIndex].Exit[2];
						if (south > 0)
						{
							roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == south);
						}
						else
						{
							Console.WriteLine("There is nothing in that direction");
						}
						break;
					case "w":
						west = Rooms.Room[roomIndex].Exit[3];
						if (west > 0)
						{
							roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == west);
						}
						else
						{
							Console.WriteLine("There is nothing in that direction");
						}
						break;
					case "exit":
						return true;
					case "help":
						Console.WriteLine("Commands:");
						Console.WriteLine("   Attack - Attacks the monster in the room");
						Console.WriteLine("   Pickup - Picks up the object in the room");
						Console.WriteLine("     Drop - Drops the item");
						Console.WriteLine("     Look - Tells you the room description & the exits");
						Console.WriteLine("        N - Moves you north");
						Console.WriteLine("        E - Moves you east");
						Console.WriteLine("        S - Moves you south");
						Console.WriteLine("        W - Moves you west");
						Console.WriteLine("        I - Shows inventory");
						Console.WriteLine("     Exit - Terminates the game");
						continue;
					default:
						Console.WriteLine("I dont know that command");
						continue;
				}
			}
		}
	}
}
