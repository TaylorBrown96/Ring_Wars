﻿/**
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
using DestinationUnknownLibrary;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //load the game world
            Console.Title = "Ring Wars";
            Load.Game();
            Player player = Player.LoadUser();


            foreach (Items i in Items.items)
            {
                Console.WriteLine(i.Id);
                Console.WriteLine(i.Name);
                Console.WriteLine(i.Price);
                Console.WriteLine(i.QuestItem);
                Console.WriteLine(i.Required);
                Console.WriteLine(i.Description);
            }

            while (true)
            {
                Console.Write("Please enter your password: ");
                string usrinp = Console.ReadLine();

                if (usrinp == player.Password)
                {
                    string title = @"
█▄▄▄▄ ▄█    ▄     ▄▀        ▄ ▄   ██   █▄▄▄▄   ▄▄▄▄▄   
█  ▄▀ ██     █  ▄▀         █   █  █ █  █  ▄▀  █     ▀▄ 
█▀▀▌  ██ ██   █ █ ▀▄      █ ▄   █ █▄▄█ █▀▀▌ ▄  ▀▀▀▀▄   
█  █  ▐█ █ █  █ █   █     █  █  █ █  █ █  █  ▀▄▄▄▄▀    
  █    ▐ █  █ █  ███       █ █ █     █   █             
 ▀       █   ██             ▀ ▀     █   ▀              
                                   ▀                    ";

                    Console.WriteLine(title);


                    Console.WriteLine("\nWelcome to Ring Wars! You will fight incredible monsters and find treasure all the like!\n");
                    CoreGame.UserMenu(player);
                    break;
                }
                else
                {
                    Console.WriteLine("The password entered was incorrect\n");
                }
            }
        }
    }
}