using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TarantinoObserversLibrary
{
    public class Introductions
    {
        public static void WelcomeUser()
        {
            //Declaring variables
            StreamWriter outputFile;
            bool classCheck = false;
            bool passCheck = false;
            int upperCase = 0;
            int lowerCase = 0;
            int specialCase = 0;
            //string specialCases = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";

            //Getting player information
            //name
            outputFile = File.CreateText("Observer_Cirtificate.txt");
            Console.WriteLine("Greetings, Observer!");
            Console.WriteLine("What is your name?");
            Console.Write("> ");
            string nameInput = Console.ReadLine();
            outputFile.WriteLine("Observer name:" + nameInput);
            Console.WriteLine(nameInput + ". A name that will ring across the land!");
            Console.WriteLine();

            //Password
            while (passCheck == false)
            {
                Console.WriteLine("This is your observer handbook. Create a password so that only you may access it's contents.");
                Console.WriteLine("The password must include 1 Capital Letter, 1 lowercase letter, and 1 Special Character.");
                Console.Write("> ");
                string passwordInput = Console.ReadLine();
                foreach (char ch in passwordInput)
                {
                    if (char.IsUpper(ch))
                    {
                        upperCase++;
                    }

                    if (char.IsLower(ch))
                    {
                        lowerCase++;
                    }
                }
                if (upperCase >= 1 && lowerCase >= 1)
                    {
                        outputFile.WriteLine("Your password is: " + passwordInput);
                        passCheck = true;
                    }
                //if (passwordInput.Contains(specialCases))
                //    {
                //        specialCase++;
                //    }
                else
                {
                    Console.WriteLine("Sorry, you password is missing something.");
                    upperCase = 0;
                    lowerCase = 0;
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Keep that password safe, okay?");
            Console.WriteLine();

            //Class
            while (classCheck == false)
            {
                Console.WriteLine("Finally, what class of Observer are you? (Offensive), (NoteTaker), or (Versatile)?");
                Console.Write("> ");
                string classInput = Console.ReadLine();
                switch (classInput.ToLower())
                {
                    case "offensive":
                        {
                            Console.WriteLine("You're ready to bring the fight to the Monster if things get rough.");
                            Console.WriteLine();
                            classCheck = true;
                        }
                        break;
                    case "notetaker":
                        {
                            Console.WriteLine("Faster on your feet and quicker to persuade a peacful resolve.");
                            Console.WriteLine();
                            classCheck = true;
                        }
                        break;
                    case "versatile":
                        {
                            Console.WriteLine("A balanced observer, I see.");
                            Console.WriteLine();
                            classCheck = true;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("I'm sorry, come again?");
                            Console.WriteLine();
                        }
                        break;
                }
                outputFile.WriteLine("Your Class is:" + classInput);
            }
            outputFile.Close();
            Console.WriteLine("Finalized! You are now officially an Observer of the Tarantino Family! Now get out there and observe some monsters!");
            Console.WriteLine("Remember! Communication amongst monsters is key!");
            Console.WriteLine();
        }
    }
}
