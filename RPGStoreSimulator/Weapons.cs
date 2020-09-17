using System;
using System.Collections.Generic;
using System.Text;

namespace RPGStoreSimulator
{
    class Weapons: Items
    {
        public string weaponType;
        

        //if weapon does not have parameters
        public Weapons()
        {
            itemType = "?";
            name = "?";
            weaponType = "?";
            damage = 1;
            cost = 0;
        }

        //if weapon has paramerters
        public Weapons(string _itemType, string _name, string _type, int _weapDamage, int _cost)
        {
            itemType = _itemType;
            name = _name;
            this.weaponType = _type;
            damage = _weapDamage;
            cost = _cost;
        }
    }
}
