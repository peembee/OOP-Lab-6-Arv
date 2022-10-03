using System;
using System.Collections.Generic;
using System.Text;

namespace ZooGame
{
    abstract class Animal
    {
        protected string species = "Animal";
        protected string name = "Animalus";
        protected int age = 3;
        protected string favFood = "Meat";
        protected bool hungry = false;
        protected string marking = "Tamed";
        protected string mammalOrReptile = "Mammal"; 
        protected bool needMedicine = false;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string FavFood
        {
            get
            {
                return favFood;
            }
            set
            {
                favFood = value;
            }
        }
        public string Marking
        {
            get
            {
                return marking;
            }
            set
            {
                marking = value;
            }
        }
        public string MammalOrReptile
        {
            get
            {
                return mammalOrReptile;
            }
            set
            {
                mammalOrReptile = value;
            }
        }
        public bool NeedMedicineStatus
        {
            get
            {
                return needMedicine;
            }
            set
            {
                needMedicine = value;
            }
        }
        public bool setHungry
        {
            get
            {
                return hungry;
            }
            set
            {
                hungry = value;
            }
        }
        public bool Hungry()
        {
            return hungry;
        }
        public string DisplayNeedMedicineInMenu()
        {
            string medicData;
            if (needMedicine == true)
            {
               medicData = "Need medicine";
            }
            else
            {
                medicData = "No need for medicine atm";
            }
            return medicData;
        }        
        public string DisplayHungerInMenu()
        {
            string hungerData;
            if(hungry == true)
            {
                hungerData = "Hungry";
            }
            else
            {
                hungerData = "Not Hungry";
            }
            return hungerData;
        }
        public string Species() // display the specie
        {
            return species;
        }
        public string NameOfAnimal() //display the name of the animal
        {
            return name;
        }
        public virtual void MakeSound()
        {
            Console.WriteLine(name + " sounds");
        }
        public virtual void WalkAnimal()
        {
            Console.WriteLine(name + " likes being walked with");
        }
        public virtual void Play(string enterGame = "autoPlay")
        {
            Console.WriteLine(name + " playing with you");
            Console.WriteLine(name + " usually get's hungry after a playsession");
            hungry = true;
        }
        public void Eat()
        {
            if (hungry == true)
            {
                Console.WriteLine(name + " loves " + favFood);
                hungry = false;
            }
            else
            {
                Console.WriteLine("No, " + name + " is not hungry");
            }
        }
        public override string ToString()
        {
            return mammalOrReptile + ": " + "Specie: " + species + ". Name: " + name + ". Age: " + age + ". FavFood: " + favFood + ".  -- wild/tamed: " + marking + ".";
        }
    }
}
