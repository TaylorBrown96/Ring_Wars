/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using System;

namespace RingWarsLibrary
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
