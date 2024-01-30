using MahApps.Metro.Controls;
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
using UnitConverter.Controls;
using UnitConverter.Helpers;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl
    {
        ContentControl contentControl;
        public MainMenuControl(ContentControl contentControl)
        {
            InitializeComponent();
            this.contentControl = contentControl;
        }

        private void catLength_Click(object sender, RoutedEventArgs e)
        {
            //LengthUserControl lengthPage = new(contentControl);
            GenericConversionControl lengthControl = new(contentControl, ConversionModes.ConversionMode.Length);
            contentControl.Content = lengthControl;
        }

        private void catArea_Click(object sender, RoutedEventArgs e)
        {
            GenericConversionControl areaControl = new(contentControl, ConversionModes.ConversionMode.Area);
            contentControl.Content = areaControl;
        }

        private void catVolume_Click(object sender, RoutedEventArgs e)
        {
            GenericConversionControl volumeControl = new(contentControl, ConversionModes.ConversionMode.Volume);
            contentControl.Content = volumeControl;
        }

        private void catMass_Click(object sender, RoutedEventArgs e)
        {
            GenericConversionControl massControl = new(contentControl, ConversionModes.ConversionMode.Mass);
            contentControl.Content = massControl;
        }

        private void catTime_Click(object sender, RoutedEventArgs e)
        {
            GenericConversionControl TimeControl = new(contentControl, ConversionModes.ConversionMode.Time);
            contentControl.Content = TimeControl;
        }

        private void catTemp_Click(object sender, RoutedEventArgs e)
        {
            GenericConversionControl tempControl = new(contentControl, ConversionModes.ConversionMode.Temperature);
            contentControl.Content = tempControl;
        }
    }
}
