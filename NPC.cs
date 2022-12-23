using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_System
{
    internal class NPC : Player
    {
        // fields
        private string faction = "UNDEFINED";
        private string mode = "UNDEFINED";

        // properties
        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}
