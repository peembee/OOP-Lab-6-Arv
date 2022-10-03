using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZooGame
{
    internal class Cat : Animal
    {
        private int mostCatchedFlies;
        public Cat(string species, string name, int age, string favFood, string marking)
        {
            this.species = species;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
            this.marking = marking;
            MakeSound();
        }
        public int MostCatchedFlies
        {
            get
            {
                return mostCatchedFlies;
            }
            private set
            {
                mostCatchedFlies = value; // Only methods in this class will be allowed to change this value
            }
        }
        public override void Play(string enterGame)
        {
            hungry = true;
            int markingLevel = 1; // if user gets +4 in level, zoonimal will be tamed.
            Random randomNumber = new Random();
            int randomchoice = randomNumber.Next(1, 4);// spinns random number, if value = 1 - animal need medicine. 
            if (randomchoice == 1)  // animal need medic
            {
                needMedicine = true;
            }
            if (enterGame == "1")
            {
                randomchoice = randomNumber.Next(1, 4);
                switch (randomchoice)
                {
                    case 1:
                        Console.WriteLine("You need to go carefully to " + name + " if you want to play with him.");
                        markingLevel--;
                        break;
                    case 2:
                        Console.WriteLine("There you go, " + name + " starting to like playing with you");
                        markingLevel++;
                        break;
                    case 3:
                        Console.WriteLine("Nope, looks like " + name + " don't wanna play with you right now");
                        break;
                }
                if (markingLevel >= 2)
                {
                    Console.WriteLine("Status marking: " + marking);
                    marking = "Tamed";
                    if (markingLevel > 4)
                    {
                        markingLevel = 4; 
                    }
                }
                else if (markingLevel < 2)
                {
                    Console.WriteLine("Status marking: " + marking);
                    marking = "Wild";
                    if (markingLevel < 1)
                    {
                        markingLevel = 1;
                    }
                }              
            }
            else
            {
                flyCatch();
            }
        }
        public override void MakeSound()
        {
            Console.WriteLine(name + " says Mjaau");
        }
        private void flyCatch()
        {
            Console.Clear();
            const int givenPoints = 3;
            int points = 0;            
            Console.WriteLine(name + " is now running around and looking for flies");
            System.Threading.Thread.Sleep(500);
            Random randomNumber = new Random();
            for (int i = 0; i < 10; i++)           {         
                int randomcatch = randomNumber.Next(1, 4); // 33% chance that cat catch a fly             
                if (randomcatch == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(name + " got one!");
                    points += givenPoints;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(name + " missed that one");
                }
                Console.ResetColor();
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("**");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine( "   **");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("       **");
                System.Threading.Thread.Sleep(300);
            }            
            Console.WriteLine("You got: " + points + " points");
            if (points > mostCatchedFlies)
            {
                Console.WriteLine("You got a new record!");
                MostCatchedFlies = points;
            }
        }  
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
