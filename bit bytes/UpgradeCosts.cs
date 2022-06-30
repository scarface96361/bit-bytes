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

        
        //The following 20 or so of the current code is all code relating to the cost of the interval
        //this interval is used to determine how often the thread increments. 
        int IntervalCosts = 10;
        public int timeinterval
        {
            get { return IntervalCosts; }
            set { IntervalCosts = value; }
        }
        
        //the following variable is used to store the cost of upgrading the number of points received each click
        int autoValueCost = 20;

        /// <summary>
        /// Public getters and setters for the autovalueCost
        /// </summary>
        public int AutoValueCost
        {
            get { return autoValueCost; }
            set { autoValueCost = value;}
        }

        //the following 3 methods are all handling incrementing the cost to upgrade. These are useful for rebalancing the game

        /// <summary>
        /// IncrementClickUpgrade increments the ClickUpgrade variable
        /// 
        /// If you wish to rebalance the game, tweak the increment cost and in the other increment methods in the UpgradeCosts class. 
        /// </summary>
        public void IncrementClickUpgrade()
        {
            clickUpgrade++;
        }
        /// <summary>
        /// IncrementTimeIntervalCost increments the IntervalCosts variable
        /// 
        /// If you wish to rebalance the game, tweak the increment cost and in the other increment methods in the UpgradeCosts class. 
        /// </summary>
        public void incrementTimeIntervalCost()
        {
            if (IntervalCosts < 20)
            {
              IntervalCosts++;
            }
            else
            {
                double temp2 = (IntervalCosts * .50);
                IntervalCosts = IntervalCosts + Convert.ToInt32(temp2);
            }
        }
        /// <summary>
        /// IncrementAutoValueCost increments the autoValueCost variable
        /// 
        /// If you wish to rebalance the game, tweak the increment cost and in the other increment methods in the UpgradeCosts class. 
        /// </summary>
        public void IncrementAutoValueCost()
        {
            if(autoValueCost <100){
                autoValueCost++;
            } else {
                double temp = (autoValueCost * .50);
                autoValueCost = autoValueCost + Convert.ToInt32(temp);
            }
        }


    }
}
