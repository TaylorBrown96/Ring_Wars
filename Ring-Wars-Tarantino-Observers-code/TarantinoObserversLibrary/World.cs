using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public static class World
    {
        public static List <Room> rooms = new List <Room> ();
        public static List <Mob> mobs = new List <Mob> ();
        public static List <Weapon> weapons = new List <Weapon> ();
        public static List <Potion> potion = new List <Potion> ();
        public static List <Treasure> treasure = new List <Treasure> ();
        public static List <Item> item = new List <Item> ();  
    }
}
