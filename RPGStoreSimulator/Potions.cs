using System;
using System.Collections.Generic;
using System.Text;

namespace RPGStoreSimulator
{
    class Potions: Items
    {
        
        public string PotionType;

        //if potion does not have parameters
        public Potions()
        {
            name = "?";
            PotionType = "?";
            heal = 0;
            cost = 0;
            damage = 0;
            
        }

        //if potion has paramerters
        public Potions(string _itemType, string _type, int _potionEffect, string _name, int _cost, int _damage)
        {
            itemType = _itemType;
            name = _name;
            PotionType = _type;
            heal = _potionEffect;
            cost = _cost;
            damage = _damage;
        }
    }
}
