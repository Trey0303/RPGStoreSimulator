﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Threading;


namespace RPGStoreSimulator
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            //storeInventory.LoadStoreItems();
            //add text file for player inventory
            Items[] myInv = LoadItems("Inventory.csv");
            Items[] storeInv = LoadItems("ShopInventory.csv");
            //string filePath = @"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.txt"; *old way

            
            //set Gamerunning to equal true
            bool gameRunning = true;
            //set inShop to false
            bool inShop = false;

            //start off with a number of coins
            int coins = 100;

            //game will continue to run until GameRunning turns false
            while (gameRunning)
            {
                //ask for player input
                Console.WriteLine("what would you like to do?");
                //reads what player inputs
                String playerCommand = Console.ReadLine();
                //checks to see if player command matches any command on list
                String[] commandArray = { "quit", "inv", "show inv", "show inventory", "inventory", "store", "shop", "buy", "purchase", "sell"};
                //array used to convert player command into an int
                int[] numberForm = { 0, 1, 1, 1, 1, 2, 2, 3, 3, 4 };

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
                        Console.WriteLine("");
                        Console.WriteLine("Coins: " + coins);
                        Console.WriteLine("");
                        Console.WriteLine("Item: " + "                              " + "Damage:");
                        foreach (Items line in myInv)
                        {
                            Console.WriteLine(String.Format("{0,-20}  {1,20}", line.name, line.damage));
                        }
                        break;
                    case 2:
                        //check shop/store inventory
                        inShop = true;
                        Console.WriteLine("");
                        Console.WriteLine("Coins: " + coins);
                        Console.WriteLine("");
                        Console.WriteLine("Item: " + "                              " + "Damage:" + "  " + "Cost:");
                        foreach (Items line in storeInv)
                        {
                            //prints inventory
                            Console.WriteLine(String.Format("{0,-20}  {1,20}  {2,5}", line.name, line.damage, line.cost));

                        }
                        break;
                    case 3:
                        //if player is in store
                        if (inShop)
                        {
                            //buy item from store
                            Console.WriteLine("");
                            Console.WriteLine("What would you like to buy?");
                            String playerBuyRequest = Console.ReadLine();
                            //check list to see if player input matches an item name in store inventory
                            foreach (Items line in storeInv)
                            {
                                if(playerBuyRequest == line.name)
                                {
                                    //myInv = CheckAndEdit.checkEdit("Inventory.csv");
                                    Console.WriteLine("added new item to player inventory");
                                    Console.WriteLine("");
                                    //player coins subtracted by item cost
                                    coins = coins - line.cost;
                                }

                            }

                        }
                        else
                        {
                            //if player is not in store
                            Console.WriteLine("You are not in the store.");
                        }
                        break;
                    case 4:
                        //if player is in store
                        if (inShop)
                        {
                            //sell item from inventory
                            Console.WriteLine("");
                            Console.WriteLine("Select a item to sell");

                            Console.WriteLine("");
                            Console.WriteLine("Item: " + "                              " + "Damage:" + "  " + "Cost:");
                            //print player inventory
                            foreach (Items line in myInv)
                            {
                                //prints inventory name, damage, and cost
                                Console.WriteLine(String.Format("{0,-20}  {1,20}  {2,5}", line.name, line.damage, line.cost));
                                //Console.WriteLine(line.name + "  " + line.damage + "        " + line.cost);

                            }

                            Console.WriteLine("What would you like to sell?");
                            String playerSellRequest = Console.ReadLine();
                            //check list to see if player input matches an item name in player inventory
                            foreach (Items line in myInv)
                            {
                                if (playerSellRequest == line.name)
                                {
                                    //myInv = CheckAndEdit.checkEdit("Inventory.csv");
                                    Console.WriteLine("item sold");
                                    Console.WriteLine("");
                                    //player coins added by item cost
                                    coins = coins + line.cost;
                                }

                            }

                        }
                        else
                        {
                            //if player is not in store
                            Console.WriteLine("You are not in the store.");
                        }
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
                    int.TryParse(lineValue[5], out tmpWeapons.cost);

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
                    int.TryParse(lineValue[5], out tmpPotion.cost);

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
