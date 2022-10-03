using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ZooGame
{
    internal class ShibaPup : Dog
    {
        private int highestPoints;
        public ShibaPup(string species, string name, int age, string favFood, string marking) : base(species, name, age, favFood, marking)
        {
            this.species = species;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
            this.marking = marking;
        }
        public int HighestPoints
        {
            get
            {
                return highestPoints;
            }
            private set // Only methods in this class will be allowed to change this value
            {
                highestPoints = value;
            }
        }
        public override void Play(string enterGame)
        {
            hungry = true;
            Random randomNumber = new Random(); 
            int randomchoice = randomNumber.Next(1, 4); // spinns random number, if value = 1 - animal need medicine. 
            if (randomchoice == 1) // animal need medic
            {
                needMedicine = true;
            }
            Console.WriteLine("#1 - Play with " + name);
            Console.WriteLine();
            if (enterGame == "1")
            {
                randomchoice = randomNumber.Next(1, 4);
                switch (randomchoice)
                {
                    case 1:
                        Console.WriteLine(name + "does not want to play right now");
                        break;
                    case 2:
                        Console.WriteLine(name + " likes playing with you");
                        break;
                    case 3:
                        Console.WriteLine("You and " + name + " are training for the Puppy Show");
                        break;
                }
            }
            else
            {
                dogShow();
            }
        }
        private void dogShow()
        {
            int totalpoints = 0;
            int points = 0;
            int loopCount = 1;
            Console.Clear();
            Console.WriteLine(name + " Will now enter the show");
            System.Threading.Thread.Sleep(300);
            Random randomNumber = new Random();
            for (int i = 0; i < 10; i++)
            {
                points = randomNumber.Next(2, 11);  // random number between 2 to 10 will appear
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("**");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("   **");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("       **");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("Stage" + loopCount + ": "+ name + " got " + points + " points ");
                loopCount++;
                totalpoints += points;              
            }
            Console.WriteLine("Total points: " + totalpoints);
            if (totalpoints > HighestPoints)
            {
                Console.WriteLine("You got a new record!");
                HighestPoints = points;
            }
        }
        public override string ToString()
        {
            return mammalOrReptile + ": " + "Specie: " + species + ". Name: " + name + ". Age: " + age + " months. FavFood: " + favFood + ".  -- wild/tamed: " + marking + ".";
        }
    }
}
