using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Threading;

namespace RPGStoreSimulator
{
    class SellAnItem: Program
    {
        public static int Sell(int coins)
        {
            //so that the foreach loop has something to go through
            myInv = LoadItems("Inventory.csv");
            //to know if is or isnt there
            bool isItem = false;

            foreach (Items line in Program.myInv)
            {
                //prints inventory name, damage, and cost
                Console.WriteLine(String.Format("{0,-20}  {1,20}  {2,5}", line.name, line.damage, line.cost));
                //Console.WriteLine(line.name + "  " + line.damage + "        " + line.cost);

            }

            Console.WriteLine("");
            Console.WriteLine("What would you like to sell?");
            String playerSellRequest = Console.ReadLine();
            int count = 0;
            //check list to see if player input matches an item name in player inventory
            foreach (Items line in Program.myInv)
            {
                count++;
                if (playerSellRequest == line.name)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Item sold");
                    Console.WriteLine("");

                    //player coins added by item cost
                    coins = coins + line.cost;

                    //sell item player typed and removes from inventory
                    var oldInv = File.ReadAllLines("Inventory.csv");
                    var newInv = oldInv.Where(line => !line.Contains(playerSellRequest));
                    File.WriteAllLines("Inventory.csv", newInv);
                    //makes sure to avoid else if statement
                    isItem = true;

                }
                //if player inventory does not have item
                else if (isItem = false && count == myInv.Length)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You dont own this item.");
                    Console.WriteLine("");
                }
            }
            return coins;
        }
    }
}
