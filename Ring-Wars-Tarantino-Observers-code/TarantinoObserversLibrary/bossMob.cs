using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class bossMob : Mob
    {
        //Fields
        private string _bossWeapon;
        private string _battleCry;

        //constructor
        public bossMob()
        {
            _bossWeapon = " ";
            _battleCry = " ";
        }

        public bossMob(string bossWeapon, string battleCry)
        {
            _bossWeapon = bossWeapon;
            _battleCry = battleCry;
        }

        //properties
        public string bossWeapon
        {
            get { return _bossWeapon; }
            set { _bossWeapon = value; }
        }
        public string battleCry
        {
            get { return _battleCry; }
            set { _battleCry = value; }
        }
        //constructor
    }
}
