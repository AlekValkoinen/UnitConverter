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
using UnitConverter.Helpers;

namespace UnitConverter.Controls
{
    /// <summary>
    /// Interaction logic for VolumeControl.xaml
    /// </summary>
    public partial class VolumeControl : UserControl
    {
        List<UnitInfo<ConversionFactors.VolumeUnit>> units = new();
        ContentControl Controller;
        public VolumeControl(ContentControl controller)
        {
            InitializeComponent();
            Controller = controller;
            PopulateUnitList();
            fromSelection.ItemsSource = units;
            toSelection.ItemsSource = units;
        }

        private void PopulateUnitList()
        {
            //the abbreviation isn't really needed where we added the CF units to thise. Refactor that out later for ease of adding Units.
            units.Add(new("ml", "Milliliter", ConversionFactors.VolumeUnit.Milliliter));
            units.Add(new("l", "Liter", ConversionFactors.VolumeUnit.Liter));
            units.Add(new("m3", "Cubic Meter", ConversionFactors.VolumeUnit.CubicMeter));
            units.Add(new("ft3", "Cubic Foot", ConversionFactors.VolumeUnit.CubicFoot));
            units.Add(new("yd3", "Cubic Yard", ConversionFactors.VolumeUnit.CubicYard));
            units.Add(new("pt", "Pint", ConversionFactors.VolumeUnit.Pint));
            units.Add(new("qt", "Quart", ConversionFactors.VolumeUnit.Quart));
            units.Add(new("gl", "Gallon", ConversionFactors.VolumeUnit.Gallon));
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            //try to get our numeric value
            float value = 0f;
            float.TryParse(fromTextBox.Text, out value);
            if (value != 0f)
            {
                ConversionFactors conversion = new();
                UnitInfo<ConversionFactors.VolumeUnit> fromUnit = fromSelection.SelectedItem as UnitInfo<ConversionFactors.VolumeUnit>;
                UnitInfo<ConversionFactors.VolumeUnit> toUnit = toSelection.SelectedItem as UnitInfo<ConversionFactors.VolumeUnit>;
                if (fromUnit != null && toUnit != null)
                {
                    ToTextBox.Text = conversion.Convert((decimal)value, fromUnit.Unit, toUnit.Unit, conversion.GetVolumeTable()).ToString();
                }
                //ToTextBox.Text = conversion.Convert(value, )
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuControl mainMenu = new(Controller);
            Controller.Content = mainMenu;
        }
    }
}
