using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RPGStoreSimulator
{
    class Program
    {
        

        static void Main(string[] args)
        {
            

            //set Gamerunning to equal true
            bool GameRunning = true;

            //add text file for player inventory
            string filePath = @"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.txt";
            //string[] lines = File.ReadAllLines(filePath);
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            //game will continue to run until GameRunning turns false
            while (GameRunning)
            {
                //ask for player input
                Console.WriteLine("what would you like to do?");
                //reads what player inputs
                String playerCommand = Console.ReadLine();
                //checks to see if player command matches any command on list
                String[] commandArray = { "quit", "inv", "show inv", "show inventory", "inventory", "store" , "shop"};
                //array used to convert player command into an int
                int[] numberForm = { 0, 1, 1, 1, 1, 2, 2};

                int strToInt = -1;
                for(int i = 0; i < commandArray.Length; i++)
                {
                    if(playerCommand == commandArray[i])
                    {
                        strToInt = numberForm[i];
                    }
                }
                switch (strToInt)
                {
                    //if player types "quit" game will stop running
                    case 0:
                        GameRunning = false;
                        break;
                    //shows player inventory when asked
                    case 1:
                        foreach (String line in lines)
                        {
                            Console.WriteLine(line);
                        }
                        break;
                    case 2:
                        break;
                }
            }

        }
    }
}
