using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;
using AutoClassLibrary;

namespace AutoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car car;
        public MainWindow()
        {
            car = new Car("123", "abc", "name");
            car.DiabetesAlert();
            InitializeComponent();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblLights.Visibility = Visibility.Hidden;
            
            
            
        }

        private void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            

            lblLights.Visibility = Visibility.Visible;


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //wy�wietla na ekranie ostrze�enie �e co� si� dzieje z opaski
            //popup
            //zapytanie
            //tak/nie, na odpowiedź 5min (sek)
            string message = "The state of the driver is worsening. You have 5 minutes to take action. Are you able to do it?";
            string title = "Diabetes Alert";
            if(MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                car.DiabetesAlert();
                DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 505);
                dispatcherTimer.Start();

                DispatcherTimer dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer1.Tick += new EventHandler(dispatcherTimer_Tick1);
                dispatcherTimer1.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer1.Start();

                imgTriangle.Visibility = Visibility.Visible;
                imgUnlocked.Visibility = Visibility.Visible;
                imgLIghts.Visibility = Visibility.Visible;
            }

            


            //MessageBox.Show("The state of the driver is worsening, you have 5 minutes to intervene");
            //car.DiabetesAlert();
        }
    }
}
