using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZooGame
{
    internal class Crocodile : Animal
    {
        private int highestPoints;
        public Crocodile(string species, string name, int age, string favFood, string marking, string mammalOrReptile = "Reptile")
        {
            this.species = species;
            this.name = name;
            this.age = age;
            this.favFood = favFood;
            this.marking = marking;
            this.mammalOrReptile = mammalOrReptile;
            MakeSound();
        }
        public int HighestPoints
        {
            get
            {
                return highestPoints;
            }
            private set
            {
                highestPoints = value; // Only methods in this class will be allowed to change this value
            }
        }
        public override void MakeSound()
        {
            Console.WriteLine(name + " says RAOW");
        }
        public override void Play(string enterGame)
        {
            hungry = true;
            int markingLevel = 1; // if user gets +5 in level, zoonimal will be tamed.
            Random randomNumber = new Random();// spinns random number, if value = 1 - animal need medicine. 
            int randomchoice = randomNumber.Next(1, 4);
            if (randomchoice == 1) // animal need medic
            {
                needMedicine = true;
            }
            if (enterGame == "1")
            {
                randomchoice = randomNumber.Next(1, 4);
                switch (randomchoice)
                {
                    case 1:
                        Console.WriteLine("You try to play catch with " + name + ", all he's do is just sit and stare at you..");
                        markingLevel--;
                        break;
                    case 2:
                        Console.WriteLine(name + "does not look like he want to play with you");
                        break;
                    case 3:
                        Console.WriteLine("You are really good to play with a " + marking + " " + species);
                        markingLevel++;
                        break;
                }
                if (markingLevel >3)
                {
                    Console.WriteLine("Status marking: " + marking);
                    marking = "Tamed";
                    if(markingLevel > 5)
                    {
                        markingLevel = 5;
                    }
                }
                else if (markingLevel <=3)
                {
                    Console.WriteLine("Status marking: " + marking);
                    marking = "Wild";
                    if(markingLevel <1)
                    {
                        markingLevel = 1;
                    }
                }
                Console.ReadKey();
            }
            else if (enterGame == "2")
            {
                crocoQuiz();
            }
        }
        private void crocoQuiz()  // each question will be in a local method.
        {
            Console.Clear();
            string chooseOption;
            const int givenPoint = 2;
            int points = 0;
            
            Console.WriteLine("WelCome to the CRoCoQuiz");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Game start in 2 seconds..");
            System.Threading.Thread.Sleep(2000);
            question1();
            System.Threading.Thread.Sleep(1000);
            question2();
            System.Threading.Thread.Sleep(1000);
            question3();
            System.Threading.Thread.Sleep(1000);
            question4();
            System.Threading.Thread.Sleep(1000);
            question5();
            System.Threading.Thread.Sleep(1000);
            question6();
            System.Threading.Thread.Sleep(1000);
            question7();

            void question1()
            {
                Console.WriteLine("The oldest saltwater crocodile lived up to: ");
                Console.WriteLine("#1 98 years old \n#2 54 years old \n#3 140 years old");
                validator("3"); //right answer is 3
            }
            void question2 ()
            {
                Console.WriteLine("how many different crocodile species do we have according to 'krokodil.nu'  ");
                Console.WriteLine("#1 17  \n#2 27 \n#3 13");
                validator("2"); //right answer is 2
            }
            void question3()
            {
                Console.WriteLine("How fast can a saltwater crocodile swim? ");
                Console.WriteLine("#1 29 km/h \n#2 19 km/h \n#3 14 km/h");
                validator("1"); //right answer is 1
            }
            void question4()    
            {
                Console.WriteLine("What does is call when a crocodile perform a spinning maneuver to subdue and dismember prey");
                Console.WriteLine("#1 Death roll \n#2 Spinnerbite \n#3 Rollingbite");
                validator("1"); //right answer is 

            }
            void question5()
            {
                Console.WriteLine("The Freshwater crocodile usually weigh up to:");
                Console.WriteLine("#1 100 - 130 kg \n#2 50 - 80 kg \n#3 70 - 100 kg");
                validator("3"); //right answer is 3
            }
            void question6()
            {
                Console.WriteLine("The biggest crocodile alive was about (1.1):");
                Console.WriteLine("#1 6.17 m \n#2 7.17 m \n#3 5.17 m");
                validator("1"); //right answer is 1
            }
            void question7()
            {
                Console.WriteLine("The biggest crocodile alive weigh about (1.2):");
                Console.WriteLine("#1 1075 kg \n#2 856 kg \n#3 560 kg");
                validator("1"); //right answer is 1
            }
            void validator(string correctAnswer) // Local method will validate the input from user, then validate if user got the right answer.
            {
                while (true)
                {
                    Console.Write("Your answer: ");
                    chooseOption = Console.ReadLine();
                    if (chooseOption == "1" || chooseOption == "2" || chooseOption == "3")
                    {
                        if (chooseOption == correctAnswer)
                        {
                            Console.WriteLine("Right answer! You got 2 points.");
                            points += givenPoint;
                        }
                        else { Console.WriteLine("Right answer was #" + correctAnswer); }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("try again");
                    }
                }
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You got " + points + " points");
            if (points > highestPoints)
            {
                Console.WriteLine("You got a new highpoint!");
                HighestPoints = points;
            }
            Console.WriteLine("Back to menu, push key");
            Console.ReadKey();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
