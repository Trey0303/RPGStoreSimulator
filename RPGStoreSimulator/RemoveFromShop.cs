using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RPGStoreSimulator
{
    class RemoveFromShop : Program//can use int, str, etc. Also loadItems
    {
        public static void Remove()
        {
            //so that the foreach loop has something to go through
            storeInv = LoadItems("ShopInventory.csv");
            //to know if is or isnt there
            bool isItem = false;

            Console.WriteLine("");
            Console.WriteLine("Item: " + "                              " + "Damage:" + "  " + "Cost:");
            foreach (Items line in Program.storeInv)
            {
                //prints inventory
                Console.WriteLine(String.Format("{0,-20}  {1,20}  {2,5}", line.name, line.damage, line.cost));

            }

            Console.WriteLine("");
            Console.WriteLine("What would you like to remove?");
            String removeRequest = Console.ReadLine();
            int count = 0;
            //check list to see if player input matches an item name in player inventory
            foreach (Items line in Program.storeInv)
            {
                count++;
                if (removeRequest == line.name)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Item Removed");
                    Console.WriteLine("");

                    //sell item player typed and removes from inventory
                    var oldInv = File.ReadAllLines("ShopInventory.csv");
                    var newInv = oldInv.Where(line => !line.Contains(removeRequest));
                    File.WriteAllLines("ShopInventory.csv", newInv);
                    //makes sure to avoid else if statement
                    isItem = true;

                }
            }
            //if store does not have item
            if (isItem == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Shop does not have this item.");
                Console.WriteLine("");
            }
        }
    }
}
