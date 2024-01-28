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
//Gonna add conversion factors to limit typing, this is not a great practice, but will speed this up

namespace UnitConverter.Controls
{
    /// <summary>
    /// Interaction logic for MassConversionControl.xaml
    /// </summary>
    public partial class MassConversionControl : UserControl
    {
        ContentControl Controller;
        List<UnitInfo<ConversionFactors.MassUnit>> Units = new();
        public MassConversionControl(ContentControl controller)
        {
            InitializeComponent();
            Controller = controller;
            PopulateUnitList();
            fromSelection.ItemsSource = Units;
            toSelection.ItemsSource = Units;
        }
        private void PopulateUnitList()
        {
            Units.Add(new("Milligram", ConversionFactors.MassUnit.Milligram));
            Units.Add(new("Gram", ConversionFactors.MassUnit.Gram));
            Units.Add(new("Kilogram", ConversionFactors.MassUnit.Kilogram));
            Units.Add(new("Ounce", ConversionFactors.MassUnit.Ounce));
            Units.Add(new("Pound", ConversionFactors.MassUnit.Pound));
            Units.Add(new("Stone", ConversionFactors.MassUnit.Stone));
        }
        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuControl mainMenu = new(Controller);
            Controller.Content = mainMenu;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            float inputValue = 0f;
            float.TryParse(fromTextBox.Text, out inputValue);
            if(inputValue != 0f)
            {
                ConversionFactors conversion = new();
                UnitInfo<ConversionFactors.MassUnit> fromUnit = fromSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit>;
                UnitInfo<ConversionFactors.MassUnit> toUnit = toSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit>;
                if (fromUnit != null && toUnit != null)
                {
                    ToTextBox.Text = conversion.Convert((decimal)inputValue, fromUnit.Unit, toUnit.Unit, conversion.GetMassTable()).ToString();
                }
            }
        }
    }
}
