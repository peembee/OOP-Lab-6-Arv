using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ZooGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            int playerAge;
            Console.WriteLine("Welcome employee to the zoo");
            while (true)
            {
                Console.Write("\nEnter your name: ");
                playerName = Console.ReadLine();
                if (playerName.Length < 9 && playerName.Length > 0)// pass
                {
                    playerName = char.ToUpper(playerName[0]) + playerName.Substring(1); // first letter capital
                    break;
                }
                else
                {
                    Console.WriteLine("Maximum characters: 8");
                }
            }
            while (true)
            {
                Console.Write("\nEnter your age " + playerName + ": ");
                try
                {
                    playerAge = Convert.ToUInt16(Console.ReadLine());
                    if (playerAge > 9 && playerAge < 100)
                    {
                        break;
                    }
                }
                catch (Exception ex){}
                Console.WriteLine("Type your age (10 - 99)");
            }
            ZooGame zooOwner = new ZooGame(playerName, playerAge);
            zooOwner.RunGame();
            Console.WriteLine("key to exit..");
        }
    }
}
