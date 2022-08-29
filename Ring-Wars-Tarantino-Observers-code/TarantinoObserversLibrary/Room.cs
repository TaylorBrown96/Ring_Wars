using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Room
    {
        //Fields
        private string _id;
        private string _name;
        private string _description;
        private string _exits;

        //constructor
        public Room()
        {
            _id = "";
            _name = "";
            _description = "";
            List<String> _exits = new List<String>();
        }

        public Room (string id, string name, string description, string exits)
        {
            _id = id;
            _name = name;
            _description = description;
            _exits = exits;

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
        public string exits
        {
            get { return _exits; }
            set { _exits = value; }
        }

        //methods
    }
}
