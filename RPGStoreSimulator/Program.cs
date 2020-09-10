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
                    //if player input is valid
                    if(playerCommand == commandArray[i])
                    {
                        //check which command play requested and convert into an int
                        strToInt = numberForm[i];
                    }
                }
                //takes converted int and checks what player wants to do it
                switch (strToInt)
                {
                    //if player types "quit" game will stop running
                    case 0:
                        GameRunning = false;
                        break;
                    //shows player inventory when asked
                    case 1:
                        Items.Inventory();
                        break;
                    case 2:
                        //check shop/store
                        break;
                }
            }

        }
    }
}
