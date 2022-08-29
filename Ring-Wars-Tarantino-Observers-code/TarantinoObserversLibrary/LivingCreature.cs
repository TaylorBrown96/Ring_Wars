using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class LivingCreature
    {
        private string _id;
        private string _name;
        private string _hp;
        private string _ap;
        private string _inventory;
        private string _description;

        //constructor
        public LivingCreature()
        {
            _id = " ";
            _name = " ";
            _hp = " ";
            _ap = " ";
            List<String> _inventory = new List<String>();
            _description = " ";
        }

        public LivingCreature(string id, string name, string hp, string ap, string inventory, string description)
        {
            _id = id;
            _name = name;
            _hp = hp;
            _ap = ap;
            _inventory = inventory;
            _description = description;
        }

        //properties
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public string ap
        {
            get { return _ap; }
            set { _ap = value; }
        }
        public string inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        //methods
    }
}
