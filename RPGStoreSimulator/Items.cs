using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RPGStoreSimulator
{
    class Items
    {
        public static void Inventory()
        {
            //add text file for player inventory
            string filePath = @"C:\Users\treyp\source\repos\RPGStoreSimulator\RPGStoreSimulator\Inventory.txt";
            //string[] lines = File.ReadAllLines(filePath);
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            //writes out inventory line by line
            foreach (String line in lines)
            {
                Console.WriteLine(line);
            }

        }
    }
}
