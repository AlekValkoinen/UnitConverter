using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for LengthUserControl.xaml
    /// </summary>
    public partial class LengthUserControl : UserControl
    {
        List<UnitInfo<ConversionFactors.LengthUnit>> lengthUnits = new();
        ContentControl Controller;
        public LengthUserControl(ContentControl controller)
        {
            InitializeComponent();
            Controller = controller;
            populateUnits();
            fromSelection.ItemsSource = lengthUnits;
            toSelection.ItemsSource = lengthUnits;
        }
        private void populateUnits()
        {
            //this is the poor part, I can add these to a text list then for each them later, there are several option, for now we will do it hardcoded, this is a bad practice, don't do as I do.
            //what I should do is make each a type so I can do a "if in is x and to is y then conversion factor = z. I'll sort this later.
            //lengthUnits.Add(new("millimeters (mm)", ConversionFactors.LengthUnit.Millimeter));
            //lengthUnits.Add(new("centimeters (cm)", ConversionFactors.LengthUnit.Centimeter));
            //lengthUnits.Add(new("meters (m)", ConversionFactors.LengthUnit.Meter));
            //lengthUnits.Add(new("kilometers (km)", ConversionFactors.LengthUnit.Kilometer));
            //lengthUnits.Add(new("feet (ft)", ConversionFactors.LengthUnit.Foot));
            //lengthUnits.Add(new("inches", ConversionFactors.LengthUnit.Inch));
            //lengthUnits.Add(new("yards (yd)", ConversionFactors.LengthUnit.Yard));
            //lengthUnits.Add(new("Miles-US) (mi)", ConversionFactors.LengthUnit.Mile));
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            //decimal multiFact = GetConversion(float inputValue);
            float inputValue = 0f;
            float.TryParse(fromTextBox.Text, out inputValue);
            if (inputValue != 0f)
            {
                ConversionFactors conversion = new();
                UnitInfo<ConversionFactors.LengthUnit>? fromUnit = fromSelection.SelectedItem as UnitInfo<ConversionFactors.LengthUnit>;
                UnitInfo<ConversionFactors.LengthUnit>? toUnit = toSelection.SelectedItem as UnitInfo<ConversionFactors.LengthUnit>;

                if (fromUnit != null && toUnit != null)
                {
                    ToTextBox.Text = conversion.Convert((decimal)inputValue, fromUnit.Unit, toUnit.Unit, conversion.GetLengthTable()).ToString();
                }
            }
        }
        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuControl mainMenu = new(Controller);
            Controller.Content = mainMenu;
        }
    }
}
