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
    //Creating Delegate
    public delegate void combatDialogue(string dialgoue);
    public class Combat
    {
        public static int Attack(int Mob_AD, int Player_AD, int Mob_HP, int roomIndex)
        {
            //Creating display lambda expression
            Action<string> Display = str => Console.WriteLine(str);

            Random rnd = new Random();
            Mob_AD = rnd.Next(0, Mob_AD);
            Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP -= Player_AD;
            Display("The Monster did " + Mob_AD + " damage to you.");
            Display("You did " + Player_AD + " damage to the monster.");
            return Mob_AD;
        }

        //Declaring mob dialogue delegate
        public static string mobDialogue(combatDialogue bugDialogue)
        {
            string dialogue = "buzz!";
            bugDialogue(dialogue);
            return dialogue;
        }
    }
}
