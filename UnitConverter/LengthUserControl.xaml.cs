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
        List<UnitInfo> lengthUnits = new();
        public LengthUserControl()
        {
            InitializeComponent();
            populateUnits();
            fromSelection.ItemsSource = lengthUnits;
            toSelection.ItemsSource = lengthUnits;
        }
        private void populateUnits()
        {
            //this is the poor part, I can add these to a text list then for each them later, there are several option, for now we will do it hardcoded, this is a bad practice, don't do as I do.
            //what I should do is make each a type so I can do a "if in is x and to is y then conversion factor = z. I'll sort this later.
            lengthUnits.Add(new("mm", "millimeters (mm)"));
            lengthUnits.Add(new("cm", "centimeters (cm)"));
            lengthUnits.Add(new("m", "meters (m)"));
            lengthUnits.Add(new("km", "kilometers (km)"));
            lengthUnits.Add(new("ft", "feet (ft)"));
            lengthUnits.Add(new("in", "inches"));
            lengthUnits.Add(new("yd", "yards (yd)"));
            lengthUnits.Add(new("mi", "Miles-US) (mi)"));
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            //decimal multiFact = GetConversion(float inputValue);
            float inputValue = 0f;
            float.TryParse(fromTextBox.Text, out inputValue);
            if (inputValue != 0f)
            {
                ConversionFactors factors = new();
                decimal testval = GetConversion(inputValue);
                Debug.WriteLine(testval);
                ToTextBox.Text = (testval).ToString();
            }
            //ToTextBox.Text = multiFact * 
        }
        private decimal GetConversion(float inputValue)
        {
            decimal factor = 0m;
            if (fromSelection.SelectedItem == null)
            {
                return factor;
            }
            //get the selected unit abbreviation
            if(fromSelection.SelectedItem is UnitInfo selectedUnit)
            {
                ConversionFactors factors = new();
                string fromUnit = selectedUnit.Abbreviation;
                string? toUnit = default;
                if (toSelection != null && toSelection.SelectedItem is UnitInfo convertedUnit)
                {
                    toUnit = convertedUnit.Abbreviation;
                }
                if(toUnit != null)
                {
                    return (decimal)factors.Convert((decimal)inputValue, factors.GetLengthUnit(fromUnit), factors.GetLengthUnit(toUnit));

                }
                
                

                return factor;
            }

            
            return 0m;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
