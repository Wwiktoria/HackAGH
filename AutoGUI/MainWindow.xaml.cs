using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net.Sockets;
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
using System.Xml.Linq;
using AutoClassLibrary;
using static System.Net.Mime.MediaTypeNames;

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
            car = new Car("123", "abc", "name", 50.068118856575516, 19.912615579968698, new List<string>() {"123432567","120909123"});
            InitializeComponent();
            SetBackgroundImage(imagePaths[0]);
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
                lblLights.Visibility= Visibility.Visible;
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
                (new Map(car)).ShowDialog();
            }
            lblLights.Visibility = Visibility.Visible;
        }

        private void BtnEmergency_Click(object sender, RoutedEventArgs e)
        {
            foreach (string num in car.EmergencyPeopleTel)
            {
                Notify(num);
            }
            car.Emergency();
            MessageBox.Show("Your family members from emergency list have been informed about the emergency.");

            lblLights.Visibility = Visibility.Visible;
            
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            (new Map(car)).ShowDialog();
        }

        private int currentImageIndex = 0;
        private string[] imagePaths = {  ("..\\..\\Images\\lightsOff.png"),
    ("..\\..\\Images\\loghtsON.png"),
    ("..\\..\\Images\\Emergency.png") };
        private string[] imagePaths1 = { "..\\..\\Images\\unlocked1.png",
"..\\..\\Images\\Locked.png"
        };
        private string[] imagePaths2 = { "C:\\Users\\Administrator\\Documents\\GitHub\\HackAGH\\AutoGUI\\Images\\puste.png","C:\\Users\\Administrator\\Documents\\GitHub\\HackAGH\\AutoGUI\\Images\\alarm.png"
        };

        private void SetBackgroundImage(string imagePath)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            brush.Stretch = Stretch.Uniform;
            btnLights.Background = brush;
        }

        private void SetBackgroundImage1(string imagePath1)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(imagePath1, UriKind.Relative));
            brush.Stretch = Stretch.Uniform;
            btnLocked.Background = brush;
        }

        private void SetBackgroundImage2(string imagePath2)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(imagePath2, UriKind.Relative));
            brush.Stretch = Stretch.Uniform;
            btnEmergency1.Background = brush;
        }
        private void btnLights_Click(object sender, RoutedEventArgs e)
        {
            // zmień obrazek tła przycisku
            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
            {
                currentImageIndex = 0;
            }
            SetBackgroundImage(imagePaths[currentImageIndex]);
        }

        private void btnLocked_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imagePaths1.Length)
            {
                currentImageIndex = 0;
            }
            SetBackgroundImage1(imagePaths1[currentImageIndex]);
        }

        private void btnEmergency1_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imagePaths2.Length)
            {
                currentImageIndex = 0;
            }
            SetBackgroundImage2(imagePaths2[currentImageIndex]);
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            car.UpdateReport();
        }
    }
    }

