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
        public static int Attack(int HP)
        {
            Random rnd = new Random();
            HP -= rnd.Next(1,21);
            return HP;
        }
    }
}
