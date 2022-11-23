/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System;

namespace ConsoleUI
{
    class Printer
    {
        //
        /*Creating Console Colors
        * Title Color (Dark Yellow)
        * Warning Message (Magenta)
        * Damage Message (Red)
        * Treasure Message (Dark Yellow)
        * Loot Message (Cyan)
        * Death Event Message (Dark Magenta)
        * Healing Message (Green)
        * Player Death Message (Dark Red)
        * Mob Dialogue (Red)
        */
        public static void Title(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Damage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Treasure(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void loot(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void DeathEvent(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Healing(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Alert(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void mobDialogue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
