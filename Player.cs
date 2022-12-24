using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_System
{
    internal class Player
    {
        // fields
        private int hp = 0;
        private int maxHP = 0;
        private bool alive = false;
        private int mp = 0;
        private int maxMP = 0;
        private int ap = 0;
        private int maxAP = 0;
        private int atk = 0;
        private double crit = 4.95;
        private int def = 0;
        private int con = 5;
        private int str = 5;
        private int dex = 5;
        private int intel = 5;
        private int wis = 5;
        private int init = 0;
        private int pots = 2;
        private string name = "UNDEFINED";

        // properties
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public int MP
        {
            get { return mp; }
            set { mp = value; }
        }

        public int MaxMP
        {
            get { return maxMP; }
            set { maxMP = value; }
        }

        public int AP
        {
            get { return ap; }
            set { ap = value; }
        }

        public int MaxAP
        {
            get { return maxAP; }
            set { maxAP = value; }
        }

        public int ATK
        {
            get { return atk; }
            set { atk = value; }
        }

        public double CRIT
        {
            get { return crit; }
            set { crit = value; }
        }

        public int DEF
        {
            get { return def; }
            set { def = value; }
        }

        public int CON
        {
            get { return con; }
            set { con = value; }
        }

        public int STR
        {
            get { return str; }
            set { str = value; }
        }

        public int DEX
        {
            get { return def; }
            set { def = value; }
        }

        public int INTEL
        {
            get { return intel; }
            set { intel = value; }
        }

        public int WIS
        {
            get { return wis; }
            set { wis = value; }
        }

        public int Init
        {
            get { return init; }
            set { init = value; }
        }

        public int Pots
        {
            get { return pots; }
            set { pots = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
