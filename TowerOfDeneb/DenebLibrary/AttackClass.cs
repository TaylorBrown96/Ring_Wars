using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DenebLibrary
{
    public class AttackClass
    {
        //the majority of this is to add depth later to the attacking system
        public static int monsterHP = 20;
        public static int monsterDamage = 3;
        public static int monsterDefense = 3;
        public static int yourAttack = 4;
        public static int yourHP = 20;
        public static int yourDefense = 4;
        public static bool runaway = false;
        public static Random rand = new Random();

        public static void FightMonster()
        {
            do
            {
                string attacker = RandomBoolean.RandomBool();
                if (attacker == "True")
                {
                    Console.WriteLine("You attack");
                    int dice = rand.Next(6) + 1 + rand.Next(6) + 1;
                    int attackValue = yourAttack + dice;
                    Console.WriteLine("Rolled Values:" + dice);
                    Console.WriteLine("Your attack value: " + attackValue);
                    if (attackValue > monsterDefense)
                    {
                        Console.WriteLine("Your attack was successful.");
                        monsterHP = monsterHP - yourAttack;
                        Console.WriteLine("Monsters remaining Life Points: " + monsterHP);
                    }
                    else
                    {
                        Console.WriteLine("Your attack had no effect.");
                    }
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "run":
                            Console.WriteLine("You ran away, what a loser! -4 Life Points");
                            yourHP -= 4;
                            runaway = true;
                            break;
                        default:
                            Console.WriteLine("This is not an applicable choice");
                            break;
                    }

                }
            }
            while (yourHP > 0 && monsterHP > 0 && !runaway);
            {
                {
                    if (yourHP <= 0)
                    {
                        Console.WriteLine("You died, Hah!");
                    }
                    if (monsterHP <= 0)
                    {
                        Console.WriteLine("You killed the monster, how fortunate!");
                    }
                }
            }
        }
    }
}