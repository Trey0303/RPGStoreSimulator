using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace RPGStoreSimulator
{
    class Buy: Program
    {
        public static int BuyItem(bool playerInventory, int coins )
        {
            //so that the foreach loop has a list to go through
            myInv = LoadItems("Inventory.csv");
            storeInv = LoadItems("ShopInventory.csv");

            playerInventory = false;
            //shows shop/store inventory
            Console.WriteLine("");
            Console.WriteLine("Coins: " + coins);
            Console.WriteLine("");
            Console.WriteLine("Item: " + "                              " + "Damage:" + "  " + "Cost:");
            foreach (Items line in Program.storeInv)
            {
                //prints inventory
                Console.WriteLine(String.Format("{0,-20}  {1,20}  {2,5}", line.name, line.damage, line.cost));

            }

            //buy item from store
            Console.WriteLine("");
            Console.WriteLine("What would you like to buy?");
            String playerBuyRequest = Console.ReadLine();
            int count = 0;
            bool thereIsItem = false;
            bool moreThanZero = false;
            //check list to see if player input matches an item name in store inventory
            foreach (Items item in Program.storeInv)
            {
                if (playerBuyRequest == item.name)
                {
                    thereIsItem = true;
                    //checks every item in player inventory to see if player already has item
                    foreach (Items myItem in myInv)
                    {

                        //if item player wants is not equal to item in inventory
                        if (playerBuyRequest != myItem.name)
                        {
                            //increase count
                            count++;

                            //if player does not have item in inventory
                            if (count == myInv.Length)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("added new item to player inventory");
                                Console.WriteLine("");

                                //add bought item
                                StreamWriter writer;//adds to text file inventory
                                writer = new StreamWriter("Inventory.csv", true);
                                //puts item values in order of text file
                                writer.WriteLine(item.itemType + "," + item.name + "," + item.damage + "," + item.heal + "," + item.cost);
                                //stops writing in document
                                writer.Close();
                                //update inventory to view newly added item without have to restart game
                                myInv = LoadItems("Inventory.csv");
                                //player coins subtracted by item cost
                                coins = coins - item.cost;
                                //prevent "You already have this item." prompt
                                count++;
                                //prevents duplicate
                                moreThanZero = true;

                                //return coins;

                            }
                        }
                    }
                    //if already in player inventory
                    if (count < myInv.Length)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You already have this item.");
                        Console.WriteLine("");
                        //prevents duplicate
                        moreThanZero = true;

                        //return coins;

                    }

                }

            }
            //if store doesnt not have this item
            if (thereIsItem != true)
            {
                Console.WriteLine("");
                Console.WriteLine("Store does not carry this item.");
                Console.WriteLine("");
            }
            else if (moreThanZero != true)//if there is no item in player inventory
            {
                //check list to see if player input matches an item name in store inventory
                foreach (Items item in Program.storeInv)
                {
                    if (playerBuyRequest == item.name)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("added new item to player inventory");
                        Console.WriteLine("");

                        //add bought item
                        StreamWriter writer;//adds to text file inventory
                        writer = new StreamWriter("Inventory.csv", true);
                        //puts item values in order of text file
                        writer.WriteLine(item.itemType + "," + item.name + "," + item.damage + "," + item.heal + "," + item.cost);
                        //stops writing in document
                        writer.Close();
                        //update inventory to view newly added item without have to restart game
                        myInv = LoadItems("Inventory.csv");
                        //player coins subtracted by item cost
                        coins = coins - item.cost;

                        //return coins;

                    }
                }
            }
            return coins;
        }
    }
}
