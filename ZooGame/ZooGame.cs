using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ZooGame
{
    internal class ZooGame
    {
        private string playerName; // saving players name
        private int playerAge; // saving players age
        string pickAnimal = ""; // animal picker
        private List<Animal> zooAnimalList = new List<Animal>(); // Lilst to save all animal-objects in.

        Crocodile crocodile; // declare objects.
        Cat cat;
        Dog dog;
        ShibaPup shibapup;
        DogePup dogePup;
        Employee employee;
        Plant medicPlant = new Plant();
        public ZooGame(string playerName, int age) // intro to the game, welcomes the gameplayer
        {
            this.playerName = playerName;
            this.playerAge = age;
            addToList(); // calling method to add animals to List: <zooAnimalList>            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Welcome to the Zoo Game " + playerName);
            Console.WriteLine("  As an employee at this ZOO ");
            Console.WriteLine("                             ");
            Console.WriteLine("   You need to take care     ");
            Console.WriteLine("                             ");
            Console.WriteLine("      of our Animals         ");
            Console.WriteLine("                             ");
            Console.WriteLine(" key     to    enter    game ");
            Console.ReadKey();
            Console.ResetColor();
        }
        private void addToList() // adding each object to the list
        {
            crocodile = new Crocodile("Crocodile", "Croco", 40, "Meat", "Wild"); // adding animals
            //System.Threading.Thread.Sleep(500);
            cat = new Cat("Cat", "Simba", 3, "Fish", "Wild");
            //System.Threading.Thread.Sleep(500);
            dog = new Dog("Dog", "Rex", 6, "Meat", "Tamed");
            //System.Threading.Thread.Sleep(500);
            shibapup = new ShibaPup("Puppy", "Shiba", 6, "HotDog", "Tamed");
            //System.Threading.Thread.Sleep(500);
            dogePup = new DogePup("Puppy", "Doge", 8, "Meat", "Tamed");
            //System.Threading.Thread.Sleep(500);
            employee = new Employee(playerName, playerAge, 130);
            zooAnimalList.Add(crocodile);
            zooAnimalList.Add(cat);
            zooAnimalList.Add(dog);
            zooAnimalList.Add(shibapup);
            zooAnimalList.Add(dogePup);
            zooAnimalList.Add(employee);
        }
        public void RunGame()
        {
            int navigateMenu;
            bool closeGame = false;
            do
            {
                while (true)
                {
                    Console.Clear();
                    pickAnimal = "";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exit game, enter #0   ");
                    Console.WriteLine("");
                    Console.WriteLine(employee);
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var showAnimals in zooAnimalList)
                    {
                        if (employee.Name == showAnimals.Name)
                        {
                            // ignore employee data
                        }
                        else
                        {
                            Console.WriteLine(showAnimals.Species() + " - " + showAnimals.NameOfAnimal() + ": " + showAnimals.DisplayHungerInMenu() + " - " + showAnimals.DisplayNeedMedicineInMenu());
                            Console.WriteLine("---------------------------------------------");
                        }
                    }
                    Console.WriteLine("---");
                    Console.WriteLine("Medicineplants: " + medicPlant.MedicinePlant);
                    Console.WriteLine("---");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n#1 :Play with Zoonimal  ");
                    Console.WriteLine("#2 :Sound of Zoonimals    ");
                    Console.WriteLine("#3 :Feed Zoonimal (food/medic)");
                    Console.WriteLine("#4 :Walk Zoonimal         ");
                    Console.WriteLine("#5 :Marking etc info");
                    Console.WriteLine("#6 :Zoonimal information");
                    Console.WriteLine("#7 :Change animal data    ");
                    Console.WriteLine("#8 :Employee data");
                    Console.WriteLine("#9 :Change employee data  ");
                    Console.WriteLine("#10:Grow medicine plant");
                    Console.ResetColor();
                    Console.Write("pick number..: ");
                    try
                    {
                        navigateMenu = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        errorMessage();
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                Console.Clear();
                switch (navigateMenu)
                {
                    case 0:
                        closeGame = true;
                        break;
                    case 1:

                        playWithAnimal();
                        break;
                    case 2:
                        listenToAnimals();
                        break;
                    case 3:
                        feedAnimal();
                        break;
                    case 4:
                        walkWithAnimal();
                        break;
                    case 5:                      
                        markingInformation();
                        break;
                    case 6:
                        displayAllZooAnimals();
                        Console.ReadKey();
                        break;
                    case 7:
                        changeAnimalData();
                        break;
                    case 8:
                        employeeData();
                        break;
                    case 9:
                        changeEmployeeData();
                        break;
                    case 10:
                        growMedicine();
                        break;
                    default:
                        errorMessage();
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            } while (closeGame == false);
        }
        private void playWithAnimal()
        {
            string enterGame = "";
            pickAnimal = animalPicker();
            foreach(var showHungerOnPickedAnimal in zooAnimalList)
            {
                if (pickAnimal == showHungerOnPickedAnimal.Name)
                {
                    if (showHungerOnPickedAnimal.Hungry() == true)
                    {
                        Console.WriteLine("Need to eat before playing");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            employee.EmployeeLevel = employee.EmployeeLevel + 1; // employee play with animals - level increases 
            if (pickAnimal == crocodile.NameOfAnimal())
            {
                while (true)
                {
                    Console.WriteLine("#1 - Play with " + crocodile.Name);
                    Console.WriteLine("#2 - Play CroCoQuiZ");
                    Console.Write("\nChoose Number: ");
                    enterGame = Console.ReadLine();
                    if (enterGame == "1" || enterGame == "2")
                    {
                        break;
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                crocodile.Play(enterGame);
            }
            else if (pickAnimal == cat.NameOfAnimal())
            {
                while (true)
                {
                    Console.WriteLine("#1 - Play with " + cat.Name);
                    Console.WriteLine("#2 - Play catch fly");
                    Console.Write("\nChoose Number: ");
                    enterGame = Console.ReadLine();
                    if (enterGame == "1" || enterGame == "2")
                    {
                        break;
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                cat.Play(enterGame);
            }
            else if (pickAnimal == dog.NameOfAnimal())
            {
                while (true)
                {
                    Console.WriteLine("#1 - Play with " + dog.Name);
                    Console.WriteLine("#2 - Jump Contest ");
                    Console.Write("\nChoose Number: ");
                    enterGame = Console.ReadLine();
                    if (enterGame == "1" || enterGame == "2")
                    {
                        break;
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                dog.Play(enterGame);
            }
            else if (pickAnimal == shibapup.NameOfAnimal())
            {
                while (true)
                {
                    Console.WriteLine("#1 - Play with " + shibapup.Name);
                    Console.WriteLine("#2 - Dog Show");
                    Console.Write("\nChoose Number: ");
                    enterGame = Console.ReadLine();
                    if (enterGame == "1" || enterGame == "2")
                    {
                        break;
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                shibapup.Play(enterGame);
            }
            else if (pickAnimal == dogePup.NameOfAnimal())
            {
                while (true)
                {
                    Console.WriteLine("#1 - Play with " + dogePup.Name);
                    Console.WriteLine("#2 - Go Hunt ");
                    Console.Write("\nChoose Number: ");
                    enterGame = Console.ReadLine();
                    if (enterGame == "1" || enterGame == "2")
                    {
                        break;
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                dogePup.Play(enterGame);
            }
            Console.WriteLine("Key to menu");
            Console.ReadKey();
        }
        private void listenToAnimals()
        {
            string userInput;
            Console.WriteLine("Do you want to hear all animals at the same time?");
            Console.WriteLine("#1 - Yes");
            Console.WriteLine("#2 - no, i just want to hear one specific animal");
            Console.Write("Enter # ");
            userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            if (userInput == "1" || userInput == "yes")
            {
                foreach (var makeSound in zooAnimalList)
                {
                    if (employee.Name == makeSound.Name)
                    {
                        // ignore print
                    }
                    else
                    {
                        makeSound.MakeSound();
                    }                    
                }
            }
            else
            {
                animalPicker();
                if (pickAnimal == crocodile.NameOfAnimal())
                {
                    crocodile.MakeSound();
                }
                else if (pickAnimal == cat.NameOfAnimal())
                {
                    cat.MakeSound();
                }
                else if (pickAnimal == dog.NameOfAnimal())
                {
                    dog.MakeSound();
                }
                else if (pickAnimal == shibapup.NameOfAnimal())
                {
                    shibapup.MakeSound();
                }
                else if (pickAnimal == dogePup.NameOfAnimal())
                {
                    dogePup.MakeSound();
                }
                else
                {
                    Console.WriteLine("Did not find that one");
                }
            }
            Console.WriteLine("Key to menu");
            Console.ReadKey();
        }
        private void feedAnimal()
        {
            pickAnimal = animalPicker();
            foreach(var choosenAnimals in zooAnimalList)
            {
                if (pickAnimal == choosenAnimals.Name)
                {
                    if (choosenAnimals.Hungry() == false && choosenAnimals.NeedMedicineStatus == false)
                    {
                        Console.WriteLine(choosenAnimals.Name + " is not hungry right now");
                        Console.WriteLine("Key to menu");
                        Console.ReadKey();
                        return;
                    }
                    else if(choosenAnimals.Hungry() == false && choosenAnimals.NeedMedicineStatus == true)
                    {
                        Console.WriteLine(choosenAnimals.Name + " is not hungry but needs medicine");
                        choosenAnimals.NeedMedicineStatus = medicPlant.giveMedicine();
                        Console.WriteLine("Key to menu");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        break;
                    }                        
                }
            }
            if (pickAnimal == crocodile.NameOfAnimal())
            {
                crocodile.Eat();               
            }
            else if (pickAnimal == cat.NameOfAnimal())
            {
                cat.Eat();
            }
            else if (pickAnimal == dog.NameOfAnimal())
            {
                dog.Eat();
            }
            else if (pickAnimal == shibapup.NameOfAnimal())
            {
                shibapup.Eat();
            }
            else
            {
                dogePup.Eat();
            }
            employee.EmployeeLevel = employee.EmployeeLevel + 1; // employee play with animals - level increases 
            Console.WriteLine("Key to menu");
            Console.ReadKey();
        }
        private void growMedicine()
        {
            Console.WriteLine(medicPlant);
            medicPlant.growMedicine();
            Console.WriteLine("Key to menu..");
            Console.ReadKey();
        }
        private void walkWithAnimal()
        {
            animalPicker();
            if (pickAnimal == crocodile.NameOfAnimal())
            {
                crocodile.WalkAnimal();

            }
            else if (pickAnimal == cat.NameOfAnimal())
            {
                cat.WalkAnimal();
            }
            else if (pickAnimal == dog.NameOfAnimal())
            {
                dog.WalkAnimal();
            }
            else if (pickAnimal == shibapup.NameOfAnimal())
            {
                shibapup.WalkAnimal();
            }
            else
            {
                dogePup.WalkAnimal();
            }
            Console.WriteLine("key to menu");
            Console.ReadKey();
        }
        private void markingInformation()
        {
            foreach (var animals in zooAnimalList)
            {
                if (animals.Name == employee.Name) { /* ignore print */ }
                else
                {
                    Console.WriteLine(animals.Species() + ": " + animals.Name + " - " + animals.Marking);
                }
            }
            Console.ReadKey();
        }
        private void displayAllZooAnimals()
        {
            foreach (var zoonimals in zooAnimalList)
            {
                if (employee.Name == zoonimals.Name)
                {
                    // no print
                }
                else
                {
                    Console.WriteLine(zoonimals);
                }               
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("RECORDS:");
            Console.WriteLine("--------");
            Console.WriteLine(cat.Name + " - Catched Flies Record: " + cat.MostCatchedFlies);
            Console.WriteLine(crocodile.Name + " - CroCO QUIZ Highest points: " + crocodile.HighestPoints);
            Console.WriteLine(dog.Name + " - Total jump points: " + dog.HighestJumpPoints);
            Console.WriteLine(shibapup.Name + " - Highest Point: " + shibapup.HighestPoints);
            Console.WriteLine(dogePup.Name + " - Hunting Level: " + dogePup.HuntingLevel);
            Console.WriteLine("--------------------");
        }
        private void changeAnimalData()
        {
            int pickNumber; // saves data from what user wants to do
            string userInputString;
            int userInputInt;
            string selectedAnimal = animalPicker();
            Console.WriteLine("Which Zoonimal-data would you like to change");
            Console.WriteLine("#1 - Name");
            Console.WriteLine("#2 - Age");
            Console.WriteLine("#3 - Change Favorite Food");
            Console.WriteLine("#4 - Change Marking");
            while (true)
            {
                Console.Write("Pick number: ");
                try
                {
                    pickNumber = Convert.ToInt16(Console.ReadLine());
                    if (pickNumber > 0 && pickNumber < 5)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            switch (pickNumber)
            {
                case 1:
                    while (true)
                    {
                        Console.Write("Enter new name: ");
                        userInputString = Console.ReadLine();
                        if (userInputString.Length > 0 && userInputString.Length < 9)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Minimum 1 characters and Maximum characters: 8");
                        }
                    }
                    foreach (var animalName in zooAnimalList) // searching for the right name, then change the name
                    {
                        if (selectedAnimal == animalName.Name)
                        {
                            userInputString = char.ToUpper(userInputString[0]) + userInputString.Substring(1);
                            animalName.Name = userInputString;
                        }
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.Write("Enter new age : ");
                        try
                        {
                            userInputInt = Convert.ToUInt16(Console.ReadLine());
                            if (userInputInt > 0 && userInputInt < 61)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Accepted age (1 - 60)");
                            }
                        }
                        catch (Exception)
                        {
                            errorMessage();
                        }
                    }
                    foreach (var animalName in zooAnimalList) // searching for the right name, then change the name
                    {
                        if (selectedAnimal == animalName.Name)
                        {
                            animalName.Age = userInputInt;
                        }
                    }
                    break;
                case 3:
                    while (true)
                    {
                        Console.Write("Enter new Favorite Food: ");
                        userInputString = Console.ReadLine();
                        if (userInputString.Length > 0 && userInputString.Length < 16)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Minimum 1 characters and Maximum characters: 15");
                        }
                    }
                    foreach (var animalName in zooAnimalList) // searching for the right name, then change the name
                    {
                        if (selectedAnimal == animalName.Name)
                        {
                            animalName.FavFood = userInputString;
                        }
                    }
                    break;
                case 4:
                    while (true)
                    {
                        Console.WriteLine("#1 - Wild");
                        Console.WriteLine("#2 - Tamed");
                        Console.Write("Enter new Marking: ");
                        userInputString = Console.ReadLine();
                        userInputString = userInputString.ToLower();
                        if (userInputString == "1" ^ userInputString == "wild")
                        {
                            userInputString = "Wild";
                            foreach (var animalName in zooAnimalList) // searching for the right name, then change the name
                            {
                                if (selectedAnimal == animalName.Name)
                                {
                                    animalName.Marking = userInputString;
                                }
                            }
                            break;
                        }
                        else if (userInputString == "2" ^ userInputString == "tamed")
                        {
                            userInputString = "Tamed";
                            foreach (var animalName in zooAnimalList) // searching for the right name, then change the name
                            {
                                if (selectedAnimal == animalName.Name)
                                {
                                    animalName.Marking = userInputString;
                                }
                            }
                            break;
                        }
                        else
                        {
                            errorMessage();
                        }
                    }
                    break;
            }
        }
        private void employeeData()
        {
            employee.ShowEmployeeData();
            Console.ReadKey();
        }
        private void changeEmployeeData()
        {
            int userInputInt = 0;  // input from user with an integer
            string userInputString = ""; // input from user with an string
            while (true)
            {
                Console.WriteLine("Which data would you like to change");
                Console.WriteLine("#1 - Name");
                Console.WriteLine("#2 - Age");
                Console.WriteLine("#3 - Lenght");
                Console.WriteLine("#4 - Adress");
                Console.WriteLine("#5 - Salary");
                Console.Write("Pick number: ");
                try
                {
                    userInputInt = Convert.ToUInt16(Console.ReadLine());
                    if (userInputInt > 0 && userInputInt < 6)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    errorMessage();
                }
            }
            switch (userInputInt)
            {
                case 1:
                    while (true)
                    {
                        Console.Write("Enter new name: ");
                        userInputString = Console.ReadLine();
                        if (userInputString.Length > 0 && userInputString.Length < 9)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Minimum 1 characters and Maximum characters: 8");
                        }
                    }
                    userInputString = char.ToUpper(userInputString[0]) + userInputString.Substring(1);
                    employee.Name = userInputString;
                    break;
                case 2:
                    while (true)
                    {
                        Console.Write("Enter new age : ");
                        try
                        {
                            userInputInt = Convert.ToUInt16(Console.ReadLine());
                            if (userInputInt > 9 && userInputInt < 100)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Type your age (10 - 99)");
                            }
                        }
                        catch (Exception)
                        {

                            errorMessage();
                        }
                    }
                    employee.Age = userInputInt;
                    break;
                case 3:
                    double userLength = 0;
                    while (true)
                    {
                        Console.Write("Enter new length in Cm: ");
                        try
                        {
                            userLength = Convert.ToDouble(Console.ReadLine());
                            if (userLength > 129 && userLength < 221)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("---------");
                                Console.WriteLine("accepted length: 130cm - 220cm");
                                Console.WriteLine("---------");
                            }
                        }
                        catch (Exception)
                        {

                            errorMessage();
                        }
                    }
                    employee.EmployeeLength = userLength;
                    break;
                case 4:
                    while (true)
                    {
                        Console.Write("Enter new adress : ");
                        userInputString = Console.ReadLine();
                        if (userInputString.Length < 5 ^ userInputString.Length > 20)
                        {
                            Console.WriteLine("Adress must be minimum 5 characters and maximum 20 characters");
                        }
                        else
                        {
                            break;
                        }
                    }
                    employee.EmployeeAdress = userInputString;
                    break;
                case 5:
                    while (true)
                    {
                        Console.Write("Enter new salary: ");
                        try
                        {
                            userInputInt = Convert.ToUInt16(Console.ReadLine());
                            if (userInputInt < 137 ^ userInputInt > 180)
                            {
                                Console.WriteLine("Accepted salary: 137kr/h - 180kr/h");
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            errorMessage();
                        }
                    }
                    employee.EmployeeSalary = userInputInt;
                    break;
                default:
                    {
                        errorMessage();
                        break;
                    }
            }            
        }
        private string animalPicker() // asking player what animal player wants to interact with
        {
            foreach (var zoonimals in zooAnimalList) // displaying list to user
            {
                if (zoonimals.Species() == "Human") { /* do nothing */ }
                else
                {
                    Console.WriteLine(zoonimals.Species() + " : " + zoonimals.NameOfAnimal());
                }
            }
            while (true)
            {
                bool outOfLoop = false; // getting out of last loop, needs to activate.
                Console.WriteLine("---------------");
                Console.Write("Enter zoonimals name: ");
                pickAnimal = Console.ReadLine();
                if (pickAnimal.Length == 0)
                {
                    errorMessage();
                }
                else
                {
                    pickAnimal = pickAnimal.ToLower();
                    pickAnimal = char.ToUpper(pickAnimal[0]) + pickAnimal.Substring(1); // capitalize first letter to match the animals name.
                    foreach (var getName in zooAnimalList)
                    {
                        if (pickAnimal == getName.NameOfAnimal())
                        {
                            outOfLoop = true;
                            break;
                        }

                    }
                    if (outOfLoop == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Did not find that one, try again..");
                    }
                }
            }
            return pickAnimal;
        }
        private void errorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----");
            Console.WriteLine("Non accepted input");
            Console.WriteLine("----");
            Console.ResetColor();
        }
    }
}
