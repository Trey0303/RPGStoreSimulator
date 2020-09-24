using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPGStoreSimulator
{
    class AddToShop
    {
        public static void NewItem()
        {
            //create name
            Console.WriteLine("");
            Console.WriteLine("name: ");
            String createName = Console.ReadLine();
            //need to have it so that if player enters anything other than w/p item wont be created
            //create item type
            Console.WriteLine("item is a weapon or potion? w/p: ");
            String createType = Console.ReadLine();
            //probably will need to somehow figure out to turn into int
            //create damage
            Console.WriteLine("number of damage: ");
            String createDamage = Console.ReadLine();
            int damageNumber = 0;
            //probably will need to somehow figure out to turn into int
            //create heal
            Console.WriteLine("health regain: ");
            String createHeal = Console.ReadLine();
            int healNumber = 0;
            //probably will need to somehow figure out to turn into int
            //create cost
            Console.WriteLine("name your price: ");
            String createCost = Console.ReadLine();
            int costNumber = 0;
            //use streamWriter to store player inputs somehow


            //check if weapon type input is valid
            if (createType == "w" || createType == "p")
            {
                //check if cost input is valid
                if (int.TryParse(createDamage, out damageNumber))
                {
                    //check if cost input is valid
                    if (int.TryParse(createHeal, out healNumber))
                    {
                        //check if cost input is valid
                        if (int.TryParse(createCost, out costNumber))
                        {
                            //add created item
                            StreamWriter writerShop;//adds to text file inventory
                            writerShop = new StreamWriter("ShopInventory.csv", true);
                            Console.WriteLine("");
                            Console.WriteLine("added new item to shop");
                            Console.WriteLine("");
                            //puts item values in order of text file
                            writerShop.WriteLine(createType + "," + createName + "," + createDamage + "," + createHeal + "," + createCost);
                            //stops writing in document
                            writerShop.Close();
                            
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Cost input invalid, too big of a number");
                            Console.WriteLine("or input was not a number");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Health input invalid, too big of a number");
                        Console.WriteLine("or input was not a number");
                        Console.WriteLine("");
                    }

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Damage input invalid, too big of a number ");
                    Console.WriteLine("or input was not a number");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Weapon input invalid, type w or p");
                Console.WriteLine("");
            }
        }
    }   
}
