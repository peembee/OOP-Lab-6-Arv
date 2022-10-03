using System;
using System.Collections.Generic;
using System.Text;

namespace ZooGame
{
    internal class Plant
    {
        private int medicinePlant;
        public int MedicinePlant
        {
            get
            {
                return medicinePlant;
            }
            private set
            {
                if (value < 0)
                {
                    medicinePlant = 0;
                }
                else
                {
                    medicinePlant = value;
                }
            }
        }
        public void growMedicine()
        {
            Console.WriteLine("A good employee takes care of our medicine");
            Console.WriteLine("Medicine plants +1");
            MedicinePlant = MedicinePlant + 1;
        }
        public bool giveMedicine()
        {
            bool needMedicine = true;
            if (medicinePlant == 0)
            {
                Console.WriteLine("Medicine Out! \nYou need to grow some more plants");
            }
            else
            {
                Console.WriteLine("Medicine has been eaten");
                Console.WriteLine("Medicine plants -1");
                MedicinePlant = MedicinePlant - 1;
                needMedicine = false;
            }
            return needMedicine;
        }
        public override string ToString()
        {
            return "\nOur medicine-plants is full of vitamins for our Zoonimals\n";
        }
    }
}
