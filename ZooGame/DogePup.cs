using System;
using System.Collections.Generic;
using System.Text;

namespace ZooGame
{
    internal class DogePup : Dog
    {
        private int huntingLevel;
        public DogePup(string species, string name, int age, string favFood, string marking) : base(species, name, age, favFood, marking)
        {
            this.species = species;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
            this.marking = marking;
        }
        public int HuntingLevel
        {
            get
            {
                return huntingLevel;
            }
            private set // Only methods in this class will be allowed to change this value
            {
                huntingLevel = value;
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
                        Console.WriteLine(name + " looks a little grumpy, better to leave him alone");
                        break;
                    case 2:
                        Console.WriteLine(name + " are running around you and try to bit his tail");
                        break;
                    case 3:
                        Console.WriteLine("You and " + name + " are training for the hunting");
                        Console.WriteLine("Hunting level + 1");
                        HuntingLevel = HuntingLevel + 1;
                        break;
                }               
            }
            else
            {
                goHunt();
            }
        }
        private void goHunt()
        {
            Console.Clear();
            int animalsCatched = 0;
            int loopCount = 1;
            Console.WriteLine("You and " + name + " are now walking to the forest");
            Console.WriteLine("Releaseing " + name + " now");          
            System.Threading.Thread.Sleep(300);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" hunting opportunity: " + loopCount + " of 10");
                loopCount++;
                int hunt = huntingAnimal(HuntingLevel);
                System.Threading.Thread.Sleep(500);
                if (hunt == 1)
                {
                    Console.WriteLine("You catched an animal.");
                    animalsCatched++;
                }
                else
                {
                    Console.WriteLine("Animal run away");
                }
                Console.WriteLine();
            }
            Console.WriteLine("You catched " + animalsCatched + " animals"); // Hunting level increases due to how many animals there were catched
            if (animalsCatched == 0)
            {
                Console.WriteLine("Better luck next time.. ");
                Console.WriteLine("Hunting level + 1");
                HuntingLevel = HuntingLevel + 1;
            }
            else if(animalsCatched > 0 && animalsCatched <= 8)
            {
                Console.WriteLine("Hunting level + 2");
                HuntingLevel = HuntingLevel + 2;
            }
            else if (animalsCatched > 8 && animalsCatched <= 9)
            {
                Console.WriteLine("Hunting level + 5");
                HuntingLevel = HuntingLevel + 5;
            }
            else
            {
                Console.WriteLine("Hunting level + 10");
                HuntingLevel = HuntingLevel + 10;
            }            
            int huntingAnimal(int huntingLevel) // depends on what level dog is, higher level = easier catch
            {
                Random randomNumber = new Random();
                int chaseAnimal;
                if (huntingLevel <=10) //  20% chance to catch animal
                {
                    chaseAnimal = randomNumber.Next(1, 6);
                }
                else if(huntingLevel > 10 && huntingLevel < 20) //  33% chance to catch animal
                {
                    chaseAnimal = randomNumber.Next(1, 4);
                }
                else //  50% chance to catch animal
                {
                    chaseAnimal = randomNumber.Next(1, 3);
                }
                return chaseAnimal;
            }
        }
        public override string ToString()
        {
            return mammalOrReptile + ": " + "Specie: " + species + ". Name: " + name + ". Age: " + age + " months. FavFood: " + favFood + ".  -- wild/tamed: " + marking + ".";
        }
    }
}
