using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bit_bytes
{
    partial class ClickerStats : INotifyPropertyChanged
    {

        private int autoClickDelay = 10;
        /// <summary>
        /// Getter and setter for the autoClickDelay variable
        /// </summary>
        public int AutoClickDelay
        {
            get { return autoClickDelay; }
            set { autoClickDelay = value; }
        }


        private int clickcount = 1;

        /// <summary>
        /// Getter and setter for the clickcount variable
        /// </summary>
        public int ClickCount
        {
            get { return clickcount; }
            set
            {
                if (value != clickcount)
                {
                    clickcount = value;
                }
            }

        }


        private float clickScore = 0;

        /// <summary>
        /// Getter and setter for the clickscore variable. if this is changed it increases the score
        /// </summary>
        public float ClickScore
        {
            get { return clickScore; }
            set
            {
                if (value != clickScore)
                {
                    clickScore = value;
                    OnPropertyChanged("ClickScore");
                }
            }
        }



        private int upgradeCost = 10;
        /// <summary>
        /// Getter and setter for the upgrade cost variable
        /// </summary>
        public int UpgradeCost
        {
            get { return upgradeCost; }
            set
            {
                if (value != upgradeCost)
                {
                    upgradeCost = value;
                    OnPropertyChanged("UpgradeCost");
                }
            }
        }



        //This is the value that an auto clicker increments the number by
        private int autoclickValue;

       

        /// <summary>
        /// getters and setters for the autoclickValue
        /// </summary>
        public int AutoClickValue
        {
            get { return autoclickValue; }
            set { autoclickValue = value; }
        }


        //this is the property changed handler
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
