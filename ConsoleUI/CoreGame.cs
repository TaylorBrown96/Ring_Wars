using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DestinationUnknownLibrary;
using System.Diagnostics;
using System.Globalization;
using System.Drawing;

namespace ConsoleUI
{
    // Creating user Delegate
    public delegate void userInfo(string str);
    public class CoreGame
    {
        // Sets up combat delegate alert
        private static void mobDialogueAlert(string mobDialogue)
        {
            Console.Write(mobDialogue);
        }

        // User interfaces and navigation
        public static void UserMenu(Player player)
        {
            try
            {
                // Declaring and assigning Variables
                bool exit = false;
                int north;
                int east;
                int south;
                int west;
                
                // Creating display lambda expression
                Action<string> Display = str => Console.Write(str);
                Action<string> inputDisplay = str => Console.Write(str);

                // loading player stats
                int roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);

                // Main menu
                // Display player menu
                Display($"Currently, you are in the " + Rooms.Room[roomIndex].Name + "\n");
                Display(Rooms.Room[roomIndex].Description + "\n");
                Printer.Title("Make your choice, Ring Bearer." + "\n");
                Display($"Hp: " + player.HP + "||type (help) for controls." + "\n");

                // While the user is still alive, the text adventure will still ask the user for input.
                while (exit == false)
                {
                    inputDisplay("> ");
                    string input = Console.ReadLine();
                     
                    /* Player Menu Switch
                     * Look
                     * Inventory
                     * Drop 
                     * Pickup
                     * Movement
                     * Attack
                     * Exit
                     * Help
                     */
                    switch (input.ToLower())
                    {

                        // Look Menu
                        case "look":
                            // Assigning exits for each direction according to the current room.
                            north = Rooms.Room[roomIndex].Exit[0];
                            east = Rooms.Room[roomIndex].Exit[1];
                            south = Rooms.Room[roomIndex].Exit[2];
                            west = Rooms.Room[roomIndex].Exit[3];

                            // Printing out current room objects
                            Display("\nRoom Name: \n   " + Rooms.Room[roomIndex].Name + "\n");
                            Display("\n\nRoom Description: \n   " + Rooms.Room[roomIndex].Description + "\n");
                            Display("\n\nItems:" + "\n");
                            for (int i = 0; i < Rooms.Room[roomIndex].Loot.Count; i++)
                            {
                                Display("   " + Rooms.Room[roomIndex].Loot[i].Name + "\n");

                            }
                            Display("\n\nEnemies:");
                            if (Rooms.Room[roomIndex].Mob.Count > 0)
                            {
                                Display("\n   " + Rooms.Room[roomIndex].Mob[0].Name + "\n");
                            }
                                Display("\n\nExits:\n");
                            if (north > 0)
                            {
                                Display("   North: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == north)].Name + "\n");
                            }
                            if (east > 0)
                            {
                                Display("   East: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == east)].Name + "\n");
                            }
                            if (south > 0)
                            {
                                Display("   South: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == south)].Name + "\n");
                            }
                            if (west > 0)
                            {
                                Display("   West: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == west)].Name + "\n");
                            }
                            Console.WriteLine();
                            break;

                        case "i":
                            if (player.Inventory.Count > 0)
                            {
                                Display("\nInventory:\n");
                                foreach(Item item in player.Inventory)
                                {
                                    Display("   " + item.Name + "\n");
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                Display("You dont have anything in your inventory!\n");
                            }
                            break;

                        case "drop":
                            if (player.Inventory[0] != null)
                            {
                                Printer.loot("You just dropped a "); Display(player.Inventory[0].Name);
                                Rooms.Room[roomIndex].Loot.Add(player.Inventory[0]);
                                player.Inventory.RemoveAt(0);
                                Console.WriteLine("\n");
                            }
                            else
                            {
                                Printer.Warning("There is nothing to drop\n");
                            }
                            break;

                        case "pickup":
                            if (Rooms.Room[roomIndex].Loot.Count != 0)
                            {
                                if (Rooms.Room[roomIndex].Loot[0].Id >= 200 && Rooms.Room[roomIndex].Loot[0].Id <= 299)
                                {
                                    Printer.loot("You just picked up a "); Display(Rooms.Room[roomIndex].Loot[0].Name);
                                    player.Inventory.Insert(0, Rooms.Room[roomIndex].Loot[0]);
                                    Rooms.Room[roomIndex].Loot.RemoveAt(0);
                                    Console.WriteLine("\n");
                                }
                                else
                                {
                                    Printer.loot("You just picked up a "); Display(Rooms.Room[roomIndex].Loot[0].Name);
                                    player.Inventory.Add(Rooms.Room[roomIndex].Loot[0]);
                                    Rooms.Room[roomIndex].Loot.RemoveAt(0);
                                    Console.WriteLine("\n");
                                }
                                
                            }
                            else
                            {
                                Printer.Alert("There is nothing to pick up\n\n");
                            }
                            break;

                        // Movement direction character
                        case "n":
                            north = Rooms.Room[roomIndex].Exit[0];
                            if (north > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == north);
                                Display("\n");
                            }
                            else
                            {
                                Display("There is nothing in that direction" + "\n");
                            }
                            break;

                        case "e":
                            east = Rooms.Room[roomIndex].Exit[1];
                            if (east > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == east);
                                Display("\n");
                            }
                            else
                            {
                                Display("There is nothing in that direction\n");
                            }
                            break;

                        case "s":
                            south = Rooms.Room[roomIndex].Exit[2];
                            if (south > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == south);
                                Display("\n");
                            }
                            else
                            {
                                Display("There is nothing in that direction\n");
                            }
                            break;

                        case "w":
                            west = Rooms.Room[roomIndex].Exit[3];
                            if (west > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == west);
                                Display("\n");
                            }
                            else
                            {
                                Display("There is nothing in that direction\n");
                            }
                            break;

                        // Attack case
                        case "attack":
                            if (Rooms.Room[roomIndex].Mob.Count == 0)
                            {
                                Printer.Warning("The moster has already been slain!\n");
                                continue;
                            }
                            if (player.Inventory[0].Id == 200)
                            {
                                if (Rooms.Room[roomIndex].Mob[0].HP > 0)
                                {
                                    Weapons weapon = (Weapons)player.Inventory[0];
                                    int Player_AD = weapon.Damage;

                                    Mobs mob = (Mobs)Rooms.Room[roomIndex].Mob[0];
                                    int Mob_AD = Combat.Attack(mob.AD, Player_AD, roomIndex);

                                    player.HP -= Mob_AD;
                                    Display("The Monster did "); Printer.Damage(Convert.ToString(Mob_AD)); Display(" damage to you.\n");
                                    Display("You did "); Printer.Damage(Convert.ToString(Player_AD)); Display(" damage to the monster.\n");
                                }

                                if (Rooms.Room[roomIndex].Mob[0].HP <= 0)
                                {
                                    Mobs mob = (Mobs)Rooms.Room[roomIndex].Mob[0];
                                    foreach (Item item in mob.Inventory)
                                    {
                                        Rooms.Room[roomIndex].Loot.Add(item);
                                    }

                                    Rooms.Room[roomIndex].Mob.RemoveAt(0);
                                    Printer.DeathEvent("\nYou killed the foul beast!");
                                    Display("\nYou were left with: "); Printer.Healing(Convert.ToString(player.HP)); Display("HP\n\n");
                                    
                                }
                                else
                                {
                                    Display("\nThe enemy still has " + Rooms.Room[roomIndex].Mob[0].HP + "HP\n");
                                    Display("You have: "); Printer.Healing(Convert.ToString(player.HP)); Display("HP\n\n");
                                }
                            }
                            else if (player.Inventory[0].Id != 200)
                            {
                                Printer.Warning("You need to pick your weapon back up!\n");
                            }
                            if (player.HP > 0)
                            {
                                Display("");
                                continue;
                            }

                            // Displaying death message
                            Printer.Alert("You Died!");
                            Printer.Alert("\nBetter luck next time!");
                            Printer.Alert("Press Enter to exit the program.");
                            Console.ReadLine();
                            exit = true;
                            break;

                        // Exit case
                        case "exit":
                            Printer.Title("Until next time, Ring Bearer.");
                            Printer.Title("Press Enter to exit the program.");
                            Console.ReadLine();
                            Display("\n");
                            exit = true;
                            break;

                        // Help Case
                        case "help":
                            {
                                Display("Commands:]\n");
                                Display("   Attack - Attacks the monster in the room\n");
                                Display("   Pickup - Picks up the first object in the room\n");
                                Display("     Drop - Drops the first item in your inventory\n");
                                Display("     Look - Tells you the room description & the exits\n");
                                Display("        N - Moves you north\n");
                                Display("        E - Moves you east\n");
                                Display("        S - Moves you south\n");
                                Display("        W - Moves you west\n");
                                Display("        I - Shows inventory\n");
                                Display("     Exit - Terminates the game\n");
                                Display("Press Enter to exit help menu.\n");
                                Console.ReadLine();
                            }
                            break;

                        // If no case match, display default message
                        default:
                            {
                                Display("Apologies. Come again?\n");
                                Display("\n");
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
