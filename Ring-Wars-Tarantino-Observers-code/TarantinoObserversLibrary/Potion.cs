using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Potion : Item
    {
        //Fields
        private string _valueChange;
        private string _statusChange;

        //constructor
        public Potion()
        {
            _valueChange = " ";
            _statusChange = " ";
        }

        public Potion (string statusChange, string valueChange)
        {
            _valueChange = valueChange;
            _statusChange= statusChange;
        }

        //properties
        public string valueChange
        {
            get { return _valueChange; }
            set { _valueChange = value; }
        }
        public string statusChange
        {
            get { return _statusChange; }
            set { _statusChange = value; }
        }

        //methods
    }
}