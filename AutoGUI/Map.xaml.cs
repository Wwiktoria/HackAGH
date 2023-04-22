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
using System.Windows.Shapes;
using AutoClassLibrary;
using Microsoft.Maps.MapControl.WPF;

namespace AutoGUI
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        private Car car;
        public Map(Car car)
        {
            this.car = car;
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            Location currentLocation = new Location(car.Latitude, car.Longitude);
            PshPin.Location = currentLocation;
            MapLoc.Center = currentLocation;
        }
    }
}
