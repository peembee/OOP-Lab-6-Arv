using System;
using System.Collections.Generic;
using System.Text;

namespace ZooGame
{
    internal class Employee : Animal
    {
        private int employeeLevel;
        private double employeeLength;  // save the length of the player
        private string employeeAdress = "No adress added"; //save the adress of the player
        private int employeeSalary = 137; // save the salary of the player
        public Employee(string playerName, int playerAge, double EmployeeLength, string species = "Human")
        {
            this.species = species;
            this.name = playerName;
            this.age = playerAge;
            this.EmployeeLength = EmployeeLength;
            this.marking = "";
            MakeSound();
        }
        public int EmployeeLevel
        {
            get
            {
                return employeeLevel;
            }
            set
            {
                employeeLevel = value;
            }
        }
        public double EmployeeLength
        {
            get
            {
                return employeeLength;
            }
            set
            {
                employeeLength = value;
            }
        }
        public string EmployeeAdress
        {
            get
            {
                return employeeAdress;
            }
            set
            {
                if (EmployeeAdress.Length < 5 ^ EmployeeAdress.Length > 20)
                {
                    employeeAdress = "No adress added";
                }
                else
                {
                    employeeAdress = value;
                }
            }
        }
        public int EmployeeSalary
        {
            get
            {
                return employeeSalary;
            }
            set
            {
                if (EmployeeSalary < 137 ^ EmployeeSalary > 180)
                {
                    employeeSalary = 137;
                }
                else
                {
                    employeeSalary = value;
                }
            }
        }
        public override void MakeSound()
        {
            Console.WriteLine(name + " says Hey!");
        }
        public void ShowEmployeeData()
        {
            Console.WriteLine("Level: " + EmployeeLevel);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Length: " + employeeLength + " cm");
            Console.WriteLine("Adress: " + employeeAdress);
            Console.WriteLine("Salary: " + employeeSalary + " kr/h");
        }
        public override string ToString()
        {
            return "Employee: " + name + " - Age: " + age + " Level " + employeeLevel;
        }
    }
}
