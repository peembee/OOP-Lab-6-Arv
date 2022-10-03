using System;
using System.Collections.Generic;
using System.Text;

namespace ZooGame
{
    internal class Dog : Animal 
    {
        private double highestJumpPoints;
        public Dog(string species, string name, int age, string favFood, string marking)
        {
            this.species = species;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
            this.marking = marking;
            MakeSound();
        }
        public double HighestJumpPoints
        {
            get
            {
                return highestJumpPoints;
            }
            private set // Only methods in this class will be allowed to change this value
            {
                highestJumpPoints = value;
            }
        }
        public override void Play(string enterGame)
        {
            hungry = true;
            Random randomNumber = new Random();  
            int randomchoice = randomNumber.Next(1, 4);// spinns random number, if value = 1 - animal need medicine. 
            if (randomchoice == 1)  // animal need medic
            {
                needMedicine = true;
            }
            Console.WriteLine("#1 - Play with " + name);
            Console.WriteLine();
            if(enterGame == "1")
            {
                randomchoice = randomNumber.Next(1, 4);
                switch (randomchoice)
                {
                    case 1:
                        Console.WriteLine(name + " and you are playing catch");
                        break;
                    case 2:
                        Console.WriteLine(name + " playing with you");
                        break;
                    case 3:
                        Console.WriteLine("You and " + name + " are training on the jumps ");
                        break;
                }
            }
            else
            {
                jumpContest();
            }
        }
        public override void MakeSound()
        {
            Console.WriteLine(name + " says VOOFVOOF");
        }
        private void jumpContest()
        {            
            double points = 0;
            int loopCount = 1;
            Console.Clear();
            Console.WriteLine(name + " will now start to jump as high as possible");
            System.Threading.Thread.Sleep(300);
            Random randomNumber = new Random();            
            for (int i = 0; i < 10; i++)
            {
                double dogJump = randomNumber.NextDouble() * (0.5 - 2) + 2;  // random number between 0.5 to 2 will appear
                dogJump = Math.Round(dogJump, 2); // jump in meters with 2 decimals
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("**");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("   **");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("       **");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("Jump number " + loopCount + ": " + dogJump + " meters high" );
                loopCount++;
                points += dogJump;
                points = Math.Round(points, 2); // jump in meters with 2 decimals. missleading calculations without this
            }            
            Console.WriteLine("Total points: " + points);
            if (points > HighestJumpPoints)
            {
                Console.WriteLine("You got a new record!");
                HighestJumpPoints = points;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
