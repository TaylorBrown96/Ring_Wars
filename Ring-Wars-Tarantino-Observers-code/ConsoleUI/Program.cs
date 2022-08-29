/**
* 2/10/22
* CSC 153
* Kent Jones Jr
* A text adventure of the first area of the Tarantino Observers.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TarantinoObserversLibrary;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //load the game world
                Load.loadRoom();
                Load.loadItems();
                Load.loadTreasures();
                Load.loadWeapons();
                Load.loadPotions();
                Load.loadMobs();

                //Main Menu
                Console.WriteLine("Are you new to Tarantino Observers?");
                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "yes":
                        {
                            //Introduction
                            Introductions.WelcomeUser();
                            MovementMenu.UserMenu();
                            break;
                        }
                    case "no":
                        {

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("I'm sorry, come again?");
                            break;
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
