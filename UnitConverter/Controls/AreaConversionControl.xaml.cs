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
        List<UnitInfo<ConversionFactors.AreaUnit>> unitList = new();
        ContentControl Controller;
        public AreaConversionControl(ContentControl controller)
        {
            InitializeComponent();
            Controller = controller;
            PopulateUnitList();
            fromSelection.ItemsSource = unitList;
            toSelection.ItemsSource = unitList;
            //fromSelection.ItemsSource = 
        }
        public void PopulateUnitList()
        {
            unitList.Add(new("in", "Square Inch", ConversionFactors.AreaUnit.SquareInch));
            unitList.Add(new("ft", "Square foot", ConversionFactors.AreaUnit.SquareFoot));
            unitList.Add(new("yd", "Square yard", ConversionFactors.AreaUnit.SquareYard));
            unitList.Add(new("mi", "Square Mile", ConversionFactors.AreaUnit.SquareMile));
            unitList.Add(new("mm", "Square Millimeter", ConversionFactors.AreaUnit.SquareMillimeter));
            unitList.Add(new("cm", "Square Centimeter", ConversionFactors.AreaUnit.SquareCentimeter));
            unitList.Add(new("m", "Square Meter", ConversionFactors.AreaUnit.SquareMeter));
            unitList.Add(new("km", "Square Kilometer", ConversionFactors.AreaUnit.SquareKilometer));
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
                UnitInfo<ConversionFactors.AreaUnit> fromUnit = fromSelection.SelectedItem as UnitInfo<ConversionFactors.AreaUnit>;
                UnitInfo<ConversionFactors.AreaUnit> toUnit = toSelection.SelectedItem as UnitInfo<ConversionFactors.AreaUnit>;
                if (fromUnit != null && toUnit != null)
                {
                    ToTextBox.Text = conversions.Convert((decimal)valToConvert, fromUnit.Unit, toUnit.Unit, conversions.GetAreaTable()).ToString();
                }

            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuControl menu;
            menu = new MainMenuControl(Controller);
            Controller.Content = menu;
        }
    }
}
