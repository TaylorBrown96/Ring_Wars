using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
    /**
    * 2/12/2022
    * CSC 153
    * Kalie Kirch
    * The beggining of my Text adventure program for the semester project.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int roomIndex = 0;
            //These are the arrays for the data
            string filePath = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\rooms.txt";
            List <string> rooms = File.ReadAllLines(filePath).ToList();
            string filePath2 = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\weapons.txt";
            List <string> weapons = File.ReadAllLines(filePath2).ToList();
            string filePath3 = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\potions.txt";
            List <string> potions = File.ReadAllLines(filePath3).ToList();
            string filePath4 = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\treasures.txt";
            List<string> treasures = File.ReadAllLines(filePath4).ToList();
            //New Alphabetical weapons
            var sortedWeapons = weapons.OrderBy(x => x.ToLower()).ToArray();

            //Lists for catalogs
            string catalogPath = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\items.txt";
            List<string> items = File.ReadAllLines(catalogPath).ToList();
            string catalogPath2 = @"D:\Kalie's Data\Desktop\C# projects\TowerOfDeneb\ConsoleUI\monsters.txt";
            List<string> monsters = File.ReadAllLines(catalogPath2).ToList();
            //Main Menu

            while (exit == false)
            {
                Console.WriteLine($"You are currently inside: {rooms[roomIndex]}");
                Console.WriteLine("1. Display Rooms");
                Console.WriteLine("2. Display Weapons");
                Console.WriteLine("3. Display Potions");
                Console.WriteLine("4. Display Treasures");
                Console.WriteLine("5. Display Items");
                Console.WriteLine("6. Display Bestiary(Monsters)");
                Console.WriteLine("7. Exit");
                Console.WriteLine("8. Attack");
                Console.Write("Enter your choice ");
                string input = Console.ReadLine();


                switch (input.ToLower())
                {
                    case "1":
                        foreach (string value in rooms)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                        //use new array to display weapons alphabetically
                    case "2":
                        foreach (string value in sortedWeapons)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "3":
                        foreach (string value in potions)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "4":
                        foreach (string value in treasures)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "5":
                        foreach (string value in items)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "6":
                        foreach (string value in monsters)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "rooms":
                        foreach (string value in rooms)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                        //use new array to display weapons alphabetically
                    case "weapons":
                        foreach (string value in sortedWeapons)
                        { 
                            Console.WriteLine(value);
                        }
                        break;

                    case "potions":
                        foreach (string value in potions)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "treasures":
                        foreach (string value in treasures)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "items":
                        foreach (string value in items)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "bestiary":
                        foreach (string value in monsters)
                        {
                            Console.WriteLine(value);
                        }
                        break;

                    case "7":
                        exit = true;
                        break;
                    case "8":
                        AttackClass.FightMonster();
                        break;

                    case "n":
                        if (roomIndex != 4)
                        {
                            roomIndex++;
                        }
                        else
                        {
                            Console.WriteLine("You can not go north anymore!");
                        }
                        break;

                    case "s":
                        if (roomIndex != 0)
                        {
                            roomIndex--;
                        }
                        else
                        {
                            Console.WriteLine("You can no longer leave the tower, this journey is final");
                        }
                        break;

                    default:
                        Console.WriteLine("This is not an applicable choice");
                        break;
                }
            }
        }
    }
}
