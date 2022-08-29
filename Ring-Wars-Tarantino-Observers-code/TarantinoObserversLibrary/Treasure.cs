using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Treasure : Item
    {
        //Fields
        private string _questItem;
        private string _value;

        //constructor
        public Treasure()
        {
            _questItem = " ";
            _value = "";
        }

        public Treasure(string questItem, string value)
        {
            _questItem = questItem;
            _value = value;
        }
        //properties
        public string questItem
        {
            get { return _questItem; }
            set { _questItem = value; }
        }
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        //methods
    }
}