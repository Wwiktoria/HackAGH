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
using AutoClassLibrary;
namespace AutoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void Notify(string num)
        {
            MessageBox.Show($"Sent an emergency message {num} at {DateTime.Now.ToString("HH:mm:ss")}");
        }

        Car car;
        public MainWindow()
        {
            car = new Car("123", "abc", "name", new List<string>() {"123432567","120909123"});
            InitializeComponent();
        }

        private void BtnDiabetes_Click(object sender, RoutedEventArgs e)
        {
            //wy�wietla na ekranie ostrze�enie �e co� si� dzieje z opaski
            //popup
            //zapytanie
            //tak/nie, na odpowiedź 5min (sek)
            string message = "The state of the driver is worsening. Are you able to intervene within 5 minutes?";
            string title = "Diabetes Alert";
            if(MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                foreach (string num in car.EmergencyPeopleTel)
                {
                    Notify(num);
                }
                car.DiabetesAlert();
                imgUnlocked.Visibility = Visibility.Visible;
                imgTri.Visibility = Visibility.Visible;
                
            }
            
            //MessageBox.Show("The state of the driver is worsening, you have 5 minutes to intervene");
            //car.DiabetesAlert();
        }

        private void BtnTheft_Click(object sender, RoutedEventArgs e)
        {
            string message = "Are you sure your car was stolen?";
            string title = "Theft Alert";
            if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                car.Theft();
                MessageBox.Show("Your car has been stopped. Be sure to contact the authorities");

            }
        }

        private void BtnEmergency_Click(object sender, RoutedEventArgs e)
        {
            foreach (string num in car.EmergencyPeopleTel)
            {
                Notify(num);
            }
            car.Emergency();
            MessageBox.Show("Your family members from emergency list have been informed about the emergency.");
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            car.UpdateReport();
        }
    }
}
