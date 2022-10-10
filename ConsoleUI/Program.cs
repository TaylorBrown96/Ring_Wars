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
using DestinationUnknownLibrary;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating display lambda expression
            Action<string> Display = str => Console.WriteLine(str); //Display for strings
            Action<string> inputDisplay = str => Console.Write(str); //Display for inputs
            //load the game world
            Console.Title = "Ring Wars";
            Load.Game();
            Player player = Player.Load();

            while (true)
            {
                inputDisplay("Please enter your password: ");
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

                    Display(title);

                    Display("\nWelcome to Ring Wars! You will fight incredible monsters and find treasure all the like!\n");
                    CoreGame.UserMenu(player);
                    break;
                }
                else
                {
                    Display("The password entered was incorrect\n");
                }
            }
        }
    }
}
