/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/
using System;
using System.Windows;
using System.Runtime.InteropServices;
using RingWarsLibrary;

namespace ConsoleUI
{
    internal class Program
    {
        //Creating display lambda expression
        public static Action<string> Display = str => Console.WriteLine(str); //Display for strings
        public static Action<string> inputDisplay = str => Console.Write(str); //Display for inputs strings

        public static Player player = null;

        [STAThread]
        static void Main(string[] args)
        {
            //Loading game world and player
            Console.Title = "Ring Wars";
            Load.Game();
            player = Player.Load();

            bool keep_going = true;
            while (keep_going)
            {
                Console.WriteLine("How would you like to play ring wars?");
                Console.WriteLine("\t1. Console");
                Console.WriteLine("\t2. WPF App");
                Console.WriteLine("\t3. Winform");
                Console.WriteLine("\t4. Exit");
                Console.Write(">");
                string usrInp = Console.ReadLine();

                switch (usrInp)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        LoadWPF();
                        break;
                    case "3":
                        break;
                    case "4":
                        keep_going = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option!");
                        break;
                }
            }
        }

        public static void LogIn()
        {
            //Asks the user for password input
            //If password is correct, display title card.
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
                                   ▀                   ";

                    Printer.Title(title);
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

        private static void LoadWPF()
        {
            //ShowWindow(GetConsoleWindow(), SW_HIDE);
            Application app = new Application();
            app.Run(new WPFLogin.MainWindow(player));
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Hide and Show states
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
    }
}
