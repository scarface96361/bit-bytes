using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bit_bytes
{
    internal class UpgradeCosts
    {
        int clickUpgrade = 5;
        public int ClickUpgrade {
            get { return clickUpgrade; } 
            set { clickUpgrade = value; }
        }


        int IntervalCosts = 10;

        public int timeinterval
        {
            get { return IntervalCosts; }
            set { IntervalCosts = value; }
        }

        int autoValueCost = 20;

        public int AutoValueCost
        {
            get { return autoValueCost; }
            set { autoValueCost = value;}
        }


    }
}
