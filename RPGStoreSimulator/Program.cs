using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CsvHelper;
using System.Linq;


namespace RPGStoreSimulator
{
    class Program
    {

        
        static void Main(string[] args)
        {
            //add text file for player inventory
            Items[] myInv = LoadItems(@"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.csv");
            //string filePath = @"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.txt"; *old way


            //set Gamerunning to equal true
            bool gameRunning = true;



            //game will continue to run until GameRunning turns false
            while (gameRunning)
            {
                //ask for player input
                Console.WriteLine("what would you like to do?");
                //reads what player inputs
                String playerCommand = Console.ReadLine();
                //checks to see if player command matches any command on list
                String[] commandArray = { "quit", "inv", "show inv", "show inventory", "inventory", "store", "shop" };
                //array used to convert player command into an int
                int[] numberForm = { 0, 1, 1, 1, 1, 2, 2 };

                int strToInt = -1;
                for (int i = 0; i < commandArray.Length; i++)
                {
                    //if player input is valid
                    if (playerCommand == commandArray[i])
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
                        gameRunning = false;
                        break;
                    //shows player inventory when asked
                    case 1:
                        //writes out the name of every item in inventory 
                        foreach (Items line in myInv)
                        {
                            Console.WriteLine(line.name);
                        }
                        break;
                    case 2:
                        //check shop/store
                        break;
                }
            }

        }

        //loads inventory of items for player to call
        private static Items[] LoadItems(string _filename)
        {
            
            Items[] tmpArr;

            //calls text file and stores it in an array called lines
            string[] lines = File.ReadAllLines(_filename);

            //has tmpArr equal the same length of text file
            tmpArr = new Items[lines.Length - 1];
            //will go through array 
            for (int i = 1; i < lines.Length; i++)
            {
                //knows when a word starts and ends
                string[] lineValue = lines[i].Split(',');

                //if first word is w it will know that that item is a weapon
                if (lineValue[0] == "w")
                {
                    //create weapon
                    Weapons tmpWeapons = new Weapons();
                    //creates weapons assigned name
                    tmpWeapons.name = lineValue[2];
                    //creates weapons weapon type
                    tmpWeapons.weaponType = lineValue[1];

                    //if weapon can deal damage
                    if (lineValue[3] != "")
                    {
                        //deals weapons assigned damage
                        int.TryParse(lineValue[3], out tmpWeapons.damage);
                    }
                    tmpArr[i - 1] = tmpWeapons;
                }
                else
                {
                    //assume potion
                    //create potion
                    Potions tmpPotion = new Potions();
                    tmpPotion.name = lineValue[2];
                    tmpPotion.PotionType = lineValue[1];
                    

                    if (lineValue[4] != "")
                    {
                        int.TryParse(lineValue[4], out tmpPotion.heal);
                    }
                    tmpArr[i - 1] = tmpPotion;
                }
            }
            return tmpArr;
        }
    }
}
