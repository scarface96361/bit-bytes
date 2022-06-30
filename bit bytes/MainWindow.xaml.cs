using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bit_bytes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int autoClickDelay = 10000;
        int clickcount = 1;
        float clickScore = 1;
        int upgradeCost = 10;
        int AutoClickValue = 1;


        //the following variables will be used to store if certain buttons have already been pushed
        bool AutoClickEnabled = false;

        

        //this is the ram object, well be using it to maintain everything else in one data source
        ClickerStats Values;

        //this object stores the costs of upgrading
        UpgradeCosts upgradecosts;

        public MainWindow()
        {
            //here we initiallize the ram object
            Values = new ClickerStats();
            Values.AutoClickDelay = autoClickDelay;
            Values.ClickScore = clickScore;
            Values.UpgradeCost = upgradeCost;
            Values.ClickCount = clickcount;
            Values.AutoClickValue = AutoClickValue;
            upgradecosts = new UpgradeCosts();
            InitializeComponent();
            //clickScoredisplay.Text = clickScore.ToString();
            DataContext = Values;
        }


        /// <summary>
        /// this method increments the click score each time the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Increment(object sender, RoutedEventArgs e)
        {
            Values.ClickScore = Values.ClickScore + Values.ClickCount;
            //clickScoredisplay.Text = Ram.ClickScore.ToString();
        }

        /// <summary>
        /// This method is called by the ugrade button and increases the click counter. after each upgrade you gain one extra point per click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpgradeClicker_Click(object sender, RoutedEventArgs e)
        {
           

            if(Values.ClickScore >= upgradecosts.ClickUpgrade)
            {
                Values.ClickCount++;
                
                Values.ClickScore -= upgradecosts.ClickUpgrade;

                //the following line of code increments the cost to upgrade your click value. to balance please go to incrementClickUpgrade Method in UpgradeCosts
                upgradecosts.IncrementClickUpgrade();

                UpgradeClicker.Text = "Upgrade the Value of manual Clicks  Cost:  " + upgradecosts.ClickUpgrade;
            }
           
        }


        /// <summary>
        /// This method is run by the experimental button in the XAML file. it increments the upgrade cost by 3 Times what it was before and creates a second thread that increments the
        /// Score higher every 10000 ms by default. it also makes its calling button invisible so as not to cause threading issues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thread1Button_Click(object sender, RoutedEventArgs e)
        {
            if (AutoClickEnabled == false)
            {

                if (Values.ClickScore >= upgradecosts.timeinterval)
                {

                    Values.ClickScore = Values.ClickScore - upgradecosts.timeinterval;


                    //the following two lines of code create a threadmethods object then pass its primary thread to a thread object
                    Thread_methods th = new Thread_methods(Values);
                    Thread thread1 = new Thread(new ThreadStart(th.RamThread));

                    //this starts the thread running
                    thread1.Start();
                    //Thread1Button.Visibility = Visibility.Hidden;

                    upgradecosts.incrementTimeIntervalCost();
                    Thread1ButtonText.Text = "Upgrade the Autoclicker Delay Cost " + upgradecosts.timeinterval;


                }

                //this line sets the autoclick enabled true so the above code will only run once per program load
                AutoClickEnabled = true;
            }// if autoClickEnabled is true then this method will instead call to reduce the thread delay
            else
            {
                ThreadDelayReducer();
            }
        }


        /// <summary>
        /// this method reduces the thread wait time by 10% 
        /// 
        /// This is part of a refactor im currently implementing. it may be moved over to its own class and object at a later date but for now it exists in main.
        /// We will see how i refactor in the future
        /// </summary>
        private void ThreadDelayReducer()
        {
            if(Values.ClickScore >= upgradecosts.timeinterval)
            {
                double temp = (Values.AutoClickDelay * .10); 
                Values.AutoClickDelay = Values.AutoClickDelay - Convert.ToInt32(temp);

                Values.ClickScore -= Values.UpgradeCost;

                upgradecosts.incrementTimeIntervalCost();
                Thread1ButtonText.Text = "Upgrade the Autoclicker Delay Cost " + upgradecosts.timeinterval;

            }
        }


        /// <summary>
        /// This method increases the value given by upgrades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if(Values.ClickScore >= upgradecosts.AutoValueCost)
            {
                Values.AutoClickValue++;

                Values.ClickScore -= upgradecosts.AutoValueCost;

                //this line of code calls to increment the autoclicker value in the upgradeCosts Class
                upgradecosts.IncrementAutoValueCost();
                ValueUpgrade.Text = "Upgrade the Thread Priority! " + "Cost of Ram " + upgradecosts.AutoValueCost;

            }
        }
    }

 
}
