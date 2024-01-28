using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnitConverter.Helpers.ConversionFactors;

namespace UnitConverter.Helpers
{
    public static class UnitLists
    {
        public static List<object> PopulateAreaUnitList(List<object> unitList)
        {
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Inch", ConversionFactors.AreaUnit.SquareInch));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square foot", ConversionFactors.AreaUnit.SquareFoot));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square yard", ConversionFactors.AreaUnit.SquareYard));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Mile", ConversionFactors.AreaUnit.SquareMile));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Millimeter", ConversionFactors.AreaUnit.SquareMillimeter));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Centimeter", ConversionFactors.AreaUnit.SquareCentimeter));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Meter", ConversionFactors.AreaUnit.SquareMeter));
            unitList.Add(new UnitInfo<ConversionFactors.AreaUnit>("Square Kilometer", ConversionFactors.AreaUnit.SquareKilometer));
            return unitList;
        }
        public static List<object> PopulateLengthUnitList(List<object> unitList)
        {
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("millimeters (mm)", ConversionFactors.LengthUnit.Millimeter));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("centimeters (cm)", ConversionFactors.LengthUnit.Centimeter));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("meters (m)", ConversionFactors.LengthUnit.Meter));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("kilometers (km)", ConversionFactors.LengthUnit.Kilometer));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("feet (ft)", ConversionFactors.LengthUnit.Foot));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("inches", ConversionFactors.LengthUnit.Inch));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("yards (yd)", ConversionFactors.LengthUnit.Yard));
            unitList.Add(new UnitInfo<ConversionFactors.LengthUnit>("Miles-US) (mi)", ConversionFactors.LengthUnit.Mile));
            return unitList;
        }
        public static List<object> PopulateVolumeUnitList(List<object> unitList)
        {
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Milliliter", ConversionFactors.VolumeUnit.Milliliter));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Liter", ConversionFactors.VolumeUnit.Liter));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Cubic Meter", ConversionFactors.VolumeUnit.CubicMeter));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Cubic Foot", ConversionFactors.VolumeUnit.CubicFoot));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Cubic Yard", ConversionFactors.VolumeUnit.CubicYard));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Pint", ConversionFactors.VolumeUnit.Pint));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Quart", ConversionFactors.VolumeUnit.Quart));
            unitList.Add(new UnitInfo<ConversionFactors.VolumeUnit>("Gallon", ConversionFactors.VolumeUnit.Gallon));
            return unitList;
        }
        public static List<object> PopulateMassUnitList(List<object> unitList)
        {
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Milligram", ConversionFactors.MassUnit.Milligram));
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Gram", ConversionFactors.MassUnit.Gram));
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Kilogram", ConversionFactors.MassUnit.Kilogram));
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Ounce", ConversionFactors.MassUnit.Ounce));
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Pound", ConversionFactors.MassUnit.Pound));
            unitList.Add(new UnitInfo<ConversionFactors.MassUnit>("Stone", ConversionFactors.MassUnit.Stone));
            return unitList;
        }
    }
}
