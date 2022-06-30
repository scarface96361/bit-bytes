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
         /// <summary>
        /// IncrementClickUpgrade increments the ClickUpgrade variable
        /// 
        /// If you wish to rebalance the game, tweak the increment cost and in the other increment methods in the UpgradeCosts class. 
        /// </summary>
        public void IncrementClickUpgrade()
        {
            
        }



        //The following 20 or so of the current code is all code relating to the cost of the interval
        //this interval is used to determine how often the thread increments. 
        int IntervalCosts = 10;
        public int timeinterval
        {
            get { return IntervalCosts; }
            set { IntervalCosts = value; }
        }
        /// <summary>
        /// IncrementTimeIntervalCost increments the IntervalCosts variable
        /// 
        /// If you wish to rebalance the game, tweak the increment cost and in the other increment methods in the UpgradeCosts class. 
        /// </summary>
        public void incrementTimeIntervalCost()
        {
            if (IntervalCosts < 100)
            {
              IntervalCosts++;
            }
            else
            {
                double temp2 = (IntervalCosts * .50);
                IntervalCosts = IntervalCosts + Convert.ToInt32(temp2);
            }
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
