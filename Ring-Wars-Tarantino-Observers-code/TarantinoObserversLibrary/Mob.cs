using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Mob : LivingCreature
    {
        //Fields
        private string _weapon;
        private string _loot;

        //constructor
        public Mob()
        {
            _weapon = " ";
            List<String> _loot = new List<String>();
        }

        public Mob(string weapon, string loot)
        {
            _weapon = weapon;
            _loot = loot;
        }

        //properties
        public string weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }
        public string loot
        {
            get { return _loot; }
            set { _loot = value; }
        }
        //methods

    }
}
