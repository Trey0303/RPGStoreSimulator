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
            this.name = "?";
            this.weaponType = "?";
            this.damage = 1;
            this.cost = 0;
        }

        //if weapon has paramerters
        public Weapons(string _name, string _type, int _weapDamage, int _cost)
        {
            this.name = _name;
            this.weaponType = _type;
            this.damage = _weapDamage;
            this.cost = _cost;
        }
    }
}
