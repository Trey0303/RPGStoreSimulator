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
    class Program
    {
        //allows other classes to access myInv and storeInv when 'Progam.' is typed before
        public static Items[] myInv { get; internal set; }
        public static Items[] storeInv { get; internal set; }

        static void Main(string[] args)
        {
            //storeInventory.LoadStoreItems();
            //add text file for player inventory
            Items[] myInv = LoadItems("Inventory.csv");
            Items[] storeInv = LoadItems("ShopInventory.csv");
            //string filePath = @"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.txt"; *old way


            //set Gamerunning to equal true
            bool gameRunning = true;
            //set inShop to false to know when in shop or not
            bool inShop = false;
            //to know when in player inventory
            bool playerInventory = false;
            //start off with a number of coins
            int coins = 100;

            //game will continue to run until GameRunning turns false
            while (gameRunning)
            {
                //ask for player input
                Console.WriteLine("");
                Console.WriteLine("what would you like to do?");
                //reads what player inputs
                String playerCommand = Console.ReadLine();
                //checks to see if player command matches any command on list
                String[] commandArray = { "quit", "inv", "show inv", "show inventory", "inventory", "store", "shop", "go to store", 
                    "go to shop", "buy", "purchase", "sell", "inspect", "view", "add_to_shop"};
                //array used to convert player command into an int
                int[] numberForm = { /*quit*/0, /*player inv*/1, 1, 1, 1, /*shop*/2, 2, 2, 2, 
                    /*buy*/3, 3, /*sell*/4, /*inspect*/5, 5, /*add_to_shop*/6 };

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

                    //shows player INVENTORY and balance of coins when asked
                    case 1:
                        playerInventory = true;
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
                    //go to STORE and view items and current amount of coins
                    case 2:
                        playerInventory = false;
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

                    //player wants to BUY item
                    case 3:
                        //if player is in store
                        if (inShop)
                        {
                            //buy item
                            int result = Buy.BuyItem(playerInventory, coins);
                            //int result used to keep changes made to coins
                            coins = result;
                            //refresh inventory
                            myInv = LoadItems("Inventory.csv");
                        }
                        else
                        {
                            //if player is not in store
                            Console.WriteLine("");
                            Console.WriteLine("You are not in the store.");
                            Console.WriteLine("");
                        }
                        break;

                    //player wants to SELL item
                    case 4:
                        //if player is in store
                        if (inShop)
                        {
                            playerInventory = true;
                            //sell item from inventory
                            Console.WriteLine("");
                            Console.WriteLine("Select a item to sell");

                            Console.WriteLine("");
                            Console.WriteLine("Item: " + "                              " + "Damage:" + "  " + "Cost:");
                            
                            //executes Sell in SellAnItem class
                            int result = SellAnItem.Sell(coins);
                            //int result used to keep changes made to coins
                            coins = result;
                            //refresh player inventory
                            myInv = LoadItems("Inventory.csv");

                        }
                        else
                        {
                            //if player is not in store
                            Console.WriteLine("You are not in the store.");
                        }
                        break;

                    //player wants to INSPECT/VIEW item in shop or inventory
                    case 5:
                        if (playerInventory)
                        {
                            //ask player what item they want to inspect
                            Inspect.InspectPlayer();
                        }
                        else if (inShop)
                        {
                            Inspect.InspectStore();
                        }
                        else
                        {
                            Console.WriteLine("Nothing to inspect.");
                        }
                        break;
                    //player can ADD_TO_SHOP new items
                    case 6:
                        //calls NewItem from AddToShop class
                        AddToShop.NewItem();
                        //reload store inventory
                        storeInv = LoadItems("ShopInventory.csv");
                        break;

                    //if not a valid command
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        //loads inventory/store items 
        public static Items[] LoadItems(string _filename)
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
                    tmpWeapons.name = lineValue[1];
                    //creates weapons weapon type
                    //tmpWeapons.weaponType = lineValue[1];
                    //item cost
                    int.TryParse(lineValue[4], out tmpWeapons.cost);

                    tmpWeapons.itemType = lineValue[0];

                    //if weapon can deal damage
                    if (lineValue[2] != "")
                    {
                        //deals weapons assigned damage
                        int.TryParse(lineValue[2], out tmpWeapons.damage);
                    }

                    tmpArr[i - 1] = tmpWeapons;
                }
                else
                {
                    //assume potion
                    //create potion
                    Potions tmpPotion = new Potions();
                    tmpPotion.name = lineValue[1];
                    //tmpPotion.PotionType = lineValue[1];
                    int.TryParse(lineValue[4], out tmpPotion.cost);

                    tmpPotion.itemType = lineValue[0];

                    //if weapon can deal damage
                    if (lineValue[2] != "")
                    {
                        //deals weapons assigned damage
                        int.TryParse(lineValue[2], out tmpPotion.damage);
                    }

                    //if item heals
                    if (lineValue[3] != "")
                    {
                        int.TryParse(lineValue[3], out tmpPotion.heal);

                    }

                    tmpArr[i - 1] = tmpPotion;
                }
            }
            return tmpArr;
        }
    }
}
