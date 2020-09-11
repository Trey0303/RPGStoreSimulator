using System;
using System.Collections.Generic;
using System.Text;

namespace RPGStoreSimulator
{
    class Potions: Items
    {
        public int heal;
        public string PotionType;

        //if potion does not have parameters
        public Potions()
        {
            name = "?";
            PotionType = "?";
            heal = 0;
        }

        //if potion has paramerters
        public Potions(string _type,int _potionEffect, string _name)
        {
            name = _name;
            PotionType = _type;
            heal = _potionEffect;
        }
    }
}
