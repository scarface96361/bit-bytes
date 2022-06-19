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



        

        //this is the ram object, well be using it to maintain everything else in one data source
        ClickerStats Ram;

        UpgradeCosts upgradeKit;

        public MainWindow()
        {
            //here we initiallize the ram object
            Ram = new ClickerStats();
            Ram.AutoClickDelay = autoClickDelay;
            Ram.ClickScore = clickScore;
            Ram.UpgradeCost = upgradeCost;
            Ram.ClickCount = clickcount;
            Ram.AutoClickValue = AutoClickValue;
            upgradeKit = new UpgradeCosts();
            InitializeComponent();
            //clickScoredisplay.Text = clickScore.ToString();
            DataContext = Ram;
        }


        /// <summary>
        /// this method increments the click score each time the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Increment(object sender, RoutedEventArgs e)
        {
            Ram.ClickScore = Ram.ClickScore + Ram.ClickCount;
            //clickScoredisplay.Text = Ram.ClickScore.ToString();
        }

        /// <summary>
        /// This method is called by the ugrade button and increases the click counter. after each upgrade you gain one extra point per click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpgradeClicker_Click(object sender, RoutedEventArgs e)
        {
            //if(Ram.ClickScore > Ram.UpgradeCost) {
            //    Ram.ClickScore = Ram.ClickScore - Ram.UpgradeCost;
            //    Ram.ClickCount++;
               
            //    if(Ram.UpgradeCost <100){
            //        Ram.UpgradeCost++;
            //    } else {
            //        double temp = (Ram.UpgradeCost * .50);
            //        Ram.UpgradeCost = Ram.UpgradeCost + Convert.ToInt32(temp);
            //  }

            //}

            if(Ram.ClickScore >= upgradeKit.ClickUpgrade)
            {
                Ram.ClickCount++;
                
                Ram.ClickScore -= upgradeKit.ClickUpgrade;

                upgradeKit.ClickUpgrade = upgradeKit.ClickUpgrade + 1;

                UpgradeClicker.Content = "Cost of Ram" + upgradeKit.ClickUpgrade;
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
            if (Ram.ClickScore >= Ram.UpgradeCost)
            {

                Ram.ClickScore = Ram.ClickScore - Ram.UpgradeCost;


                //the following two lines of code create a threadmethods object then pass its primary thread to a thread object
                Thread_methods th = new Thread_methods(Ram);
                Thread thread1 = new Thread(new ThreadStart(th.RamThread));

                //this starts the thread running
                thread1.Start();
                Thread1Button.Visibility = Visibility.Hidden;

              
                if(Ram.UpgradeCost <100){
                    Ram.UpgradeCost++;
                } else {
                    double temp = (Ram.UpgradeCost * .50);
                    Ram.UpgradeCost = Ram.UpgradeCost + Convert.ToInt32(temp);
                }   
                
            }
        }


        /// <summary>
        /// This Method upgrades the thread delay by decreasing the waittime built in on the thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thread_Delay_Down_Click(object sender, RoutedEventArgs e)
        {
            if(Ram.ClickScore >= Ram.UpgradeCost)
            {
                double temp = (Ram.AutoClickDelay * .10); 
                Ram.AutoClickDelay = Ram.AutoClickDelay - Convert.ToInt32(temp);

                Ram.ClickScore -= Ram.UpgradeCost;
               
                if(Ram.UpgradeCost <100){
                    Ram.UpgradeCost++;
                } else {
                    double temp2 = (Ram.UpgradeCost * .50);
                    Ram.UpgradeCost = Ram.UpgradeCost + Convert.ToInt32(temp);
                }


            }
        }


        /// <summary>
        /// This method increases the value given by upgrades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if(Ram.ClickScore >= upgradeKit.AutoValueCost)
            {
                Ram.AutoClickValue++;

                Ram.ClickScore -= upgradeKit.AutoValueCost;


                if(upgradeKit.AutoValueCost <100){
                    upgradeKit.AutoValueCost++;
                } else {
                    double temp = (upgradeKit.AutoValueCost * .50);
                    upgradeKit.AutoValueCost = upgradeKit.AutoValueCost + Convert.ToInt32(temp);
                }

                ValueUpgrade.Content = "Upgrade the Thread Priority!" + "\nCost of Ram" + upgradeKit.AutoValueCost;

            }
        }
    }

 
}
