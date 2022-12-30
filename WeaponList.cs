using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_System
{
    internal class Fists : Weapon
    {
        private int minDmg = 2;
        private int maxDmg = 5;
        private int atkCost = 2;

        public int MinDmg { get { return minDmg; } set { minDmg = value; } }   
        public int MaxDmg { get { return maxDmg; } set { minDmg = value; } }
        public int AtkCost { get { return atkCost; } set { atkCost = value; } }
    }
    internal class Knife : Weapon
    {
        private int minDmg = 3;
        private int maxDmg = 6;
        private int atkCost = 3;

        public int MinDmg { get { return minDmg; } set { minDmg = value; } }
        public int MaxDmg { get { return maxDmg; } set { minDmg = value; } }
        public int AtkCost { get { return atkCost; } set { atkCost = value; } }
    }
    internal class Sword : Weapon
    {
        private int minDmg = 4;
        private int maxDmg = 7;
        private int atkCost = 4;

        public int MinDmg { get { return minDmg; } set { minDmg = value; } }
        public int MaxDmg { get { return maxDmg; } set { minDmg = value; } }
        public int AtkCost { get { return atkCost; } set { atkCost = value; } }
    }
    internal class Axe : Weapon
    {
        private int minDmg = 5;
        private int maxDmg = 8;
        private int atkCost = 5;

        public int MinDmg { get { return minDmg; } set { minDmg = value; } }
        public int MaxDmg { get { return maxDmg; } set { minDmg = value; } }
        public int AtkCost { get { return atkCost; } set { atkCost = value; } }
    }

    internal class Warhammer : Weapon
    {
        private int minDmg = 6;
        private int maxDmg = 9;
        private int atkCost = 6;

        public int MinDmg { get { return minDmg; } set { minDmg = value; } }
        public int MaxDmg { get { return maxDmg; } set { minDmg = value; } }
        public int AtkCost { get { return atkCost; } set { atkCost = value; } }
    }
}
