using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DestinationUnknownLibrary;

namespace ConsoleUI
{
    public class CoreGame
    {
        public static void UserMenu(Player player)
        {
            try
            {
                //Variables
                bool exit = false;
                int north;
                int east;
                int south;
                int west;

                //loading player stats
                int roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);
               
                while (exit == false)
                {
                    //main menu
                    //Display player menu
                    Console.WriteLine($"Currently, you are in the " + Rooms.Room[roomIndex].Name);
                    Console.WriteLine(Rooms.Room[roomIndex].Description);
                    Console.WriteLine("Make your choice, Ring Bearer.");
                    Console.WriteLine($"Hp: " + player.HP + "||type (help) for controls.");
                    Console.Write("> ");
                    string input = Console.ReadLine();
                    
                    //Player input options
                    switch (input.ToLower())
                    {

                    //Look Menu
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

                        //Movement
                        case "n":
                            north = Rooms.Room[roomIndex].Exit[0];

                            if (north > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == north);
                                Console.WriteLine();
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
                                Console.WriteLine();
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
                                Console.WriteLine();
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
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("There is nothing in that direction");
                            }
                            break;

                        //Attack
                        case "attack":
                            if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP > 0)
                            {
                                player.HP -= Combat.Attack(Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].AD, Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == player.Inventory[0])].Damage, Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP, roomIndex);
                                 
                                if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP <= 0)
                                {
                                    Console.WriteLine("\nYou killed the foul beast!");
                                    Console.WriteLine("You were left with: " + player.HP + "HP");
                                }
                                else
                                {
                                    Console.WriteLine("\nThe enemy still has " + Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP + "HP");
                                    Console.WriteLine("You have: " + player.HP + "HP ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The moster has already been slain!");
                            }

                            if (player.HP > 0)
                            {
                                Console.WriteLine();
                                continue;
                            }
                            Console.WriteLine("You Died!");
                            Console.Write("\nBetter luck next time!");
                            exit = true;
                            break;

                        //Settings
                        case "exit":
                            Console.WriteLine("Until next time, Ring Bearer.");
                            Console.WriteLine("Press Enter to exit the program.");
                            Console.ReadLine();
                            exit = true;
                            break;
                        case "help":
                            {
                                Console.WriteLine("Commands:");
                                Console.WriteLine("   Attack - Attacks the monster in the room");
                                // Console.WriteLine("   Pickup - Picks up the object in the room");
                                // Console.WriteLine("     Drop - Drops the item");
                                Console.WriteLine("     Look - Tells you the room description & the exits");
                                Console.WriteLine("        N - Moves you north");
                                Console.WriteLine("        E - Moves you east");
                                Console.WriteLine("        S - Moves you south");
                                Console.WriteLine("        W - Moves you west");
                                // Console.WriteLine("        I - Shows inventory");
                                Console.WriteLine("     Exit - Terminates the game");
                                Console.WriteLine("Press Enter to exit help menu.");
                                Console.ReadLine();
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Apologies. Come again?");
                                Console.WriteLine();
                                break;
                            }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
