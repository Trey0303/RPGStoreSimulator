using System;
using System.Collections.Generic;
using System.Text;

namespace RPGStoreSimulator
{
    class Inspect: Program
    {

        
        public static void InspectPlayer(){
            //so that the foreach loop has something to go through
            myInv = LoadItems("Inventory.csv");
            //know if it can be viewed
            bool inspectedItem = false;
            //ask player what item they want to inspect
            Console.WriteLine("");
            Console.WriteLine("Which item would you like to inspect?");
            String viewItem = Console.ReadLine();
            foreach (Items myItem in Program.myInv)
            {
                if (viewItem == myItem.name)
                {
                    Console.WriteLine("You have inspected " + myItem.name);
                    inspectedItem = true;
                }
            }
            if (inspectedItem == false)
            {
                Console.WriteLine("Nothing to inspect.");
            }
        }

        public static void InspectStore()
        {
            //so that the foreach loop has something to go through
            storeInv = LoadItems("ShopInventory.csv");
            //know if it can be viewed
            bool inspectedItem = false;
            //ask player what item they want to inspect
            Console.WriteLine("");
            Console.WriteLine("Which item would you like to inspect?");
            String viewItem = Console.ReadLine();
            foreach (Items storeItem in Program.storeInv)
            {
                if (viewItem == storeItem.name)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have inspected " + storeItem.name);
                    Console.WriteLine("");
                    inspectedItem = true;
                }
            }
            if (inspectedItem == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Nothing to inspect.");
                Console.WriteLine("");
            }
        }

    }
}
