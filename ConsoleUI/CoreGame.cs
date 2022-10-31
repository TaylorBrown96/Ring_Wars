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
                Action<string> Display = str => Console.WriteLine(str);
                Action<string> inputDisplay = str => Console.Write(str);

                // loading player stats
                int roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);

                // Main menu
                // Display player menu
                Display($"Currently, you are in the " + Rooms.Room[roomIndex].Name);
                Display(Rooms.Room[roomIndex].Description);
                Printer.Title("Make your choice, Ring Bearer.");
                Display($"Hp: " + player.HP + "||type (help) for controls.");

                // While the user is still alive, the text adventure will still ask the user for input.
                while (exit == false)
                {
                    inputDisplay("> ");
                    string input = Console.ReadLine();
                     
                    /* Player Menu Switch
                     * Look
                     * Movement
                     * Attack
                     * Exit/Help
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
                            Display("\nRoom Name: \n   " + Rooms.Room[roomIndex].Name);
                            Display("\n\nRoom Description: \n   " + Rooms.Room[roomIndex].Description);
                            Display("\n\nItems:");
                            for (int i = 0; i < Rooms.Room[roomIndex].Loot.Count; i++)
                            {
                                if (Rooms.Room[roomIndex].Loot[i] > 0)
                                {
                                    if (Items.items.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
                                    {
                                        Display("\n   " + Items.items[Items.items.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
                                    }
                                    else if (Potions.Potion.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
                                    {
                                        Display("\n   " + Potions.Potion[Potions.Potion.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
                                    }
                                    else if (Weapons.Weapon.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i]) != -1)
                                    {
                                        Display("\n   " + Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == Rooms.Room[roomIndex].Loot[i])].Name);
                                    }
                                }
                            }
                            Display("\n\nEnemies:");
                            if (Rooms.Room[roomIndex].Mob[0] > 0)
                            {
                                Display("\n   " + Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].Name);
                            }
                                Display("\n\nExits:");
                            if (north > 0)
                            {
                                Display("   North: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == north)].Name);
                            }
                            if (east > 0)
                            {
                                Display("   East: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == east)].Name);
                            }
                            if (south > 0)
                            {
                                Display("   South: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == south)].Name);
                            }
                            if (west > 0)
                            {
                                Display("   West: " + Rooms.Room[Rooms.Room.FindIndex(a => a.Room_ID == west)].Name);
                            }
                            break;

                        // Movement character case
                        case "n":
                            north = Rooms.Room[roomIndex].Exit[0];
                            if (north > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == north);
                                Display("");
                            }
                            else
                            {
                                Display("There is nothing in that direction");
                            }
                            break;
                        case "e":
                            east = Rooms.Room[roomIndex].Exit[1];
                            if (east > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == east);
                                Display("");
                            }
                            else
                            {
                                Display("There is nothing in that direction");
                            }
                            break;
                        case "s":
                            south = Rooms.Room[roomIndex].Exit[2];
                            if (south > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == south);
                                Display("");
                            }
                            else
                            {
                                Display("There is nothing in that direction");
                            }
                            break;
                        case "w":
                            west = Rooms.Room[roomIndex].Exit[3];
                            if (west > 0)
                            {
                                roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == west);
                                Display("");
                            }
                            else
                            {
                                Display("There is nothing in that direction");
                            }
                            break;

                        // Attack case
                        case "attack":
                            if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP > 0)
                            {
                                player.HP -= Combat.Attack(Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].AD, Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == player.Inventory[0])].Damage, Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP, roomIndex);
                                 
                                if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP <= 0)
                                {
                                    Printer.DeathEvent("\nYou killed the foul beast!");
                                    Display("You were left with: " + player.HP + "HP");
                                    
                                }
                                else
                                {
                                    Display("\nThe enemy still has " + Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP + "HP");
                                    Display("You have: " + player.HP + "HP ");
                                    Printer.mobDialogue(Combat.mobDialogue(mobDialogueAlert));
                                }
                            }
                            else
                            {
                                Printer.Warning("The moster has already been slain!");
                            }
                            if (player.HP > 0)
                            {
                                Display("");
                                continue;
                            }

                            // Displaying death message
                            Printer.playerDeath("You Died!");
                            Printer.playerDeath("\nBetter luck next time!");
                            Printer.playerDeath("Press Enter to exit the program.");
                            Console.ReadLine();
                            exit = true;
                            break;

                        // Exit case
                        case "exit":
                            Printer.Title("Until next time, Ring Bearer.");
                            Printer.Title("Press Enter to exit the program.");
                            Console.ReadLine();
                            Display("");
                            exit = true;
                            break;

                        // Help Case
                        case "help":
                            {
                                Display("Commands:");
                                Display("   Attack - Attacks the monster in the room");
                                // Console.WriteLine("   Pickup - Picks up the object in the room");
                                // Console.WriteLine("     Drop - Drops the item");
                                Display("     Look - Tells you the room description & the exits");
                                Display("        N - Moves you north");
                                Display("        E - Moves you east");
                                Display("        S - Moves you south");
                                Display("        W - Moves you west");
                                // Console.WriteLine("        I - Shows inventory");
                                Display("     Exit - Terminates the game");
                                Display("Press Enter to exit help menu.");
                                Console.ReadLine();
                            }
                            break;

                        // If no case match, display default message
                        default:
                            {
                                Display("Apologies. Come again?");
                                Display("");
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
