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
    /// Interaction logic for GenericConversionControl.xaml
    /// </summary>
    public partial class GenericConversionControl : UserControl
    {
        List<object> Units = new();
        ContentControl Controller;
        ConversionModes.ConversionMode Mode;
        int regularDec = 6;
        int tempDec = 2;
        public GenericConversionControl(ContentControl controller, ConversionModes.ConversionMode mode)
        {
            InitializeComponent();
            Controller = controller;
            Mode = mode;
            PopulateList();
            fromSelection.ItemsSource = Units;
            toSelection.ItemsSource = Units;
        }
        private void PopulateList()
        {
            Units.Clear(); // Clear the list before populating
            switch (Mode)
            {
                case ConversionModes.ConversionMode.Length:
                    Units = UnitLists.PopulateLengthUnitList(Units);
                    break;
                case ConversionModes.ConversionMode.Area:
                    Units = UnitLists.PopulateAreaUnitList(Units);
                    break;
                case ConversionModes.ConversionMode.Volume:
                    Units = UnitLists.PopulateVolumeUnitList(Units);
                    break;
                case ConversionModes.ConversionMode.Mass:
                    Units = UnitLists.PopulateMassUnitList(Units);
                    break;
                case ConversionModes.ConversionMode.Time:
                    Units = UnitLists.PopulateTimeUnitList(Units);
                    break;
                case ConversionModes.ConversionMode.Temperature:
                    Units = UnitLists.PopulateTempUnitList(Units);
                break;

                // Add more cases for other modes as needed
                default:
                    throw new ArgumentException("Invalid mode", nameof(Mode));
            }
        }

            private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            float inputValue = 0f;
            float.TryParse(fromTextBox.Text, out inputValue);
            if (inputValue != 0f)
            {
                ConversionFactors conversion = new();
                //UnitInfo<ConversionFactors.MassUnit> fromUnit = fromSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit>;
                //UnitInfo<ConversionFactors.MassUnit> toUnit = toSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit>;
                //I dislike var.. but
                var fromUnit = castUnitType(Mode, true);
                var toUnit = castUnitType(Mode, false);
                var conversionTable = getDictionary(Mode, conversion);
                //fromUnit = fromSelection.SelectedItem;
                if (fromUnit != null 
                    && toUnit != null 
                    && conversionTable != null 
                    && Mode != ConversionModes.ConversionMode.Temperature)
                {
                    ToTextBox.Text = conversion.Convert((decimal)inputValue, fromUnit!.Unit, toUnit!.Unit, conversionTable).ToString();
                }
                if (toUnit != null 
                    && fromUnit != null 
                    && conversionTable != null 
                    && Mode == ConversionModes.ConversionMode.Temperature)
                {
                    ToTextBox.Text = Math.Round(conversion.ConvertTemp((decimal)inputValue, fromUnit!.Unit, toUnit!.Unit), tempDec).ToString();
                }
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenuControl mainMenu = new(Controller);
            Controller.Content = mainMenu;
        }
        //Helper function
        private dynamic castUnitType(ConversionModes.ConversionMode mode, bool from)
        {
            dynamic? unit;
            switch (mode)
            {
               
                case ConversionModes.ConversionMode.Length:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.LengthUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.LengthUnit>;
                    return unit!;
                case ConversionModes.ConversionMode.Area:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.AreaUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.AreaUnit>;
                    return unit!;
                case ConversionModes.ConversionMode.Volume:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.VolumeUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.VolumeUnit>;
                    return unit!;
                case ConversionModes.ConversionMode.Mass:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.MassUnit>;
                    return unit!;
                case ConversionModes.ConversionMode.Time:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.TimeUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.TimeUnit>;
                    return unit!;
                case ConversionModes.ConversionMode.Temperature:
                    unit = from == true ? fromSelection.SelectedItem as UnitInfo<ConversionFactors.TempUnit> : toSelection.SelectedItem as UnitInfo<ConversionFactors.TempUnit>;
                    return unit!;
            }
            return null!;
        }
        private dynamic getDictionary(ConversionModes.ConversionMode mode, ConversionFactors factors)
        {
            switch (mode)
            {
                case ConversionModes.ConversionMode.Length:
                    return factors.GetLengthTable();
                case ConversionModes.ConversionMode.Area:
                    return factors.GetAreaTable();
                case ConversionModes.ConversionMode.Volume:
                    return factors.GetVolumeTable();
                case ConversionModes.ConversionMode.Mass:
                    return factors.GetMassTable();
                case ConversionModes.ConversionMode.Time:
                    return factors.GetTimeTable();
            }
            return null!;
        }
        //private dynamic GetSelectedUnits(ConversionModes.ConversionMode mode, bool from)
        //{
        //    Type unitType;
        //    switch (mode)
        //    {
        //        case ConversionModes.ConversionMode.Length:
        //            unitType = typeof(ConversionFactors.LengthUnit);
        //            break;
        //        case ConversionModes.ConversionMode.Area:
        //            unitType = typeof(ConversionFactors.AreaUnit);
        //            break;
        //        case ConversionModes.ConversionMode.Volume:
        //            unitType = typeof(ConversionFactors.VolumeUnit);
        //            break;
        //        case ConversionModes.ConversionMode.Mass:
        //            unitType = typeof(ConversionFactors.MassUnit);
        //            break;
        //        // Add more cases for other modes as needed
        //        default:
        //            throw new ArgumentException("Invalid mode", nameof(mode));
        //    }
        //    if (from)
        //    {

        //        dynamic selectedItem = fromSelection.SelectedItem;
        //        if (selectedItem != null)
        //        {
        //            Type genericUnitInfoType = typeof(UnitInfo<>).MakeGenericType(unitType);
        //            dynamic selectedUnit = Convert.ChangeType(selectedItem, genericUnitInfoType);
        //            return selectedUnit;
        //        } 
        //    }
        //    dynamic selectedItem2 = toSelection.SelectedItem;
        //        if(selectedItem2 != null)
        //    {
        //        Type genericUnitInfoType = typeof(UnitInfo<>).MakeGenericType(unitType);
        //        dynamic selectedUnit = Convert.ChangeType(selectedItem2, genericUnitInfoType);
        //        return selectedUnit;
        //    }

        //    return null;
        //}
    }
    

}
