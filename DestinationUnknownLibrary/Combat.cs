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
    public class Combat
    {
        public static int Attack(int Mob_AD, int Player_AD, int Mob_HP, int roomIndex)
        {
            Random rnd = new Random();

            Mob_AD = rnd.Next(0,Mob_AD);
            Mobs.Mob[Mobs.Mob.FindIndex(a => a.Id == Rooms.Room[roomIndex].Mob[0])].HP -= Player_AD;

            Console.WriteLine("The Monster did " + Mob_AD + " damage to you.");
            Console.WriteLine("You did " + Player_AD + " damage to the monster.");
            return Mob_AD;
        }
    }
}
