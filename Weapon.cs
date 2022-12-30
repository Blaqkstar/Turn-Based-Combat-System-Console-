using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_System
{
    internal class Weapon
    {
        // FIELDS
        private string name = "UNDEFINED";
        private string description = "UNDEFINED";

        // PROPERTIES
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
    }
}
