/**
* 17APR22
* CSC 153
* Taylor J. Brown
* This program is a maze/rpg text adventure game. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationUnknownLibrary
{
    //Creating mob dialogue Delegate
    public delegate void combatDialogue(string dialgoue);
    public class Combat
    {
        public static int Attack(int Mob_AD, int Player_AD, int roomIndex)
        {
            //Creating display lambda expression
            Action<string> Display = str => Console.WriteLine(str);

            //Creating and applying random damage number to mob and player attack
            Random rnd = new Random();
            Mob_AD = rnd.Next(0, Mob_AD);
            Rooms.Room[roomIndex].Mob[0].HP -= Player_AD;
            return Mob_AD;
        }
    }
}
