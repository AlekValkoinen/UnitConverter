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
    /// Interaction logic for AreaConversionControl.xaml
    /// </summary>
    public partial class AreaConversionControl : UserControl
    {
        List<UnitInfo> unitList = new();
        public AreaConversionControl()
        {
            InitializeComponent();
            PopulateUnitList();
            fromSelection.ItemsSource = unitList;
            toSelection.ItemsSource = unitList;
            //fromSelection.ItemsSource = 
        }
        public void PopulateUnitList()
        {
            unitList.Add(new("in", "Square Inch"));
            unitList.Add(new("ft", "Square foot"));
            unitList.Add(new("mi", "Square Mile"));
            unitList.Add(new("mm", "Square Millimeter"));
            unitList.Add(new("cm", "Square Centimeter"));
            unitList.Add(new("m", "Square Meter"));
            unitList.Add(new("km", "Square Kilometer"));
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            //check that we have a value to convert
            float valToConvert = -1;
            float.TryParse(fromTextBox.Text, out valToConvert);
            if (valToConvert != 0f) 
            {
                //we have a value to convert, now we need to determine which entry from the list to use, Let's see if we can do this a better way for the future.
                //now to try to convert
                ConversionFactors conversions = new();
                UnitInfo fromUnit = fromSelection.SelectedItem as UnitInfo;
                UnitInfo toUnit = toSelection.SelectedItem as UnitInfo;
                if (fromUnit != null && toUnit != null)
                {
                    ToTextBox.Text = conversions.Convert((decimal)valToConvert, conversions.GetAreaUnit(fromUnit.Abbreviation), conversions.GetAreaUnit(toUnit.Abbreviation)).ToString();
                }

            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
