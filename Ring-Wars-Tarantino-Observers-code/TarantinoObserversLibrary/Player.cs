using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarantinoObserversLibrary
{
    public class Player : LivingCreature
    {
        //Fields
        private string _password;
        private string _class;
        private string _location;
        private string _weapon;
        private string _inventory;
        private string _quests;

        //constructor
        public Player()
        {
            _password = "";
            _class = "";
            _location = "";
            _weapon = " ";
            _quests = "";
        }

        public Player(string password, string Class, string location, string weapon, string quests)
        {
            _password = password;
            _class = Class;
            _location = location;
            _weapon = weapon;
            _inventory = inventory;
            _quests = quests;
        }

        //properties
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string weapon
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string quests
        {
            get { return _quests; }
            set { _quests = value; }
        }
        //methods
    }
}