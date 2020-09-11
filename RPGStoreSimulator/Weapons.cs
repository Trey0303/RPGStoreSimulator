using System;
using System.Collections.Generic;
using System.Text;

namespace RPGStoreSimulator
{
    class Weapons: Items
    {
        public string weaponType;
        public int damage;

        //if weapon does not have parameters
        public Weapons()
        {
            this.name = "?";
            this.weaponType = "?";
            this.damage = 2;
        }

        //if weapon has paramerters
        public Weapons(string _name, string _type, int _weapDamage)
        {
            this.name = _name;
            this.weaponType = _type;
            this.damage = _weapDamage;
        }
    }
}
