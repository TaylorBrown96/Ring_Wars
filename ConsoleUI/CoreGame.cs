using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DestinationUnknownLibrary;
using System.Diagnostics;
using System.Globalization;

namespace ConsoleUI
{
    public delegate void userInfo(string str);
    public class CoreGame
    {
        private static void mobDialogueAlert(string mobDialogue)
        {
            Console.Write(mobDialogue);
        }
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

                //Creating display lambda expression
                Action<string> Display = str => Console.WriteLine(str);
                Action<string> inputDisplay = str => Console.Write(str);

                //loading player stats
                int roomIndex = Rooms.Room.FindIndex(a => a.Room_ID == player.Location);

                //main menu
                //Display player menu
                Display($"Currently, you are in the " + Rooms.Room[roomIndex].Name);
                Display(Rooms.Room[roomIndex].Description);
                Display("Make your choice, Ring Bearer.");
                Display($"Hp: " + player.HP + "||type (help) for controls.");

                while (exit == false)
                {
                    inputDisplay("> ");
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

                        //Movement
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

                        //Attack
                        case "attack":
                            if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP > 0)
                            {
                                player.HP -= Combat.Attack(Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].AD, Weapons.Weapon[Weapons.Weapon.FindIndex(a => a.Id == player.Inventory[0])].Damage, Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP, roomIndex);
                                 
                                if (Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP <= 0)
                                {
                                    Display("\nYou killed the foul beast!");
                                    Display("You were left with: " + player.HP + "HP");
                                    
                                }
                                else
                                {
                                    Display("\nThe enemy still has " + Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP + "HP");
                                    Display("You have: " + player.HP + "HP ");
                                    Display(Combat.mobDialogue(mobDialogueAlert));
                                }
                            }
                            else
                            {
                                Display("The moster has already been slain!");
                            }

                            if (player.HP > 0)
                            {
                                Display("");
                                continue;
                            }
                            Display("You Died!");
                            Display("\nBetter luck next time!");
                            exit = true;
                            break;

                        //Settings
                        case "exit":
                            Display("Until next time, Ring Bearer.");
                            Display("Press Enter to exit the program.");
                            Display("");
                            exit = true;
                            break;
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
