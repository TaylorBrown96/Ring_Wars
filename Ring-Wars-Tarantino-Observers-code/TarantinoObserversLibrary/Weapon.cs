using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Weapon : Item
    {
        //Fields
        private string _damageType;
        private string _damage;

        //constructor
        public Weapon()
        {
            _damageType = "";
            _damage = " ";
        }

        public Weapon(string damageType, string damage)
        {
            _damageType = damageType;
            _damage = damage;
        }

        //properties
        public string damageType
        {
            get { return _damageType; }
            set { _damageType = value; }
        }

        public string damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        //methods
    }
}
