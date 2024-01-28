using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Helpers
{

    public class ConversionFactors
    {
        public enum LengthUnit
        {
            Millimeter,
            Centimeter,
            Meter,
            Kilometer,
            Inch,
            Foot,
            Yard,
            Mile
        }
        public enum AreaUnit
        {
            SquareInch,
            SquareFoot,
            SquareYard,
            SquareMile,
            SquareMillimeter,
            SquareCentimeter,
            SquareMeter,
            SquareKilometer
        }
        public enum VolumeUnit
        {
            CubicMeter,
            Liter,
            Milliliter,
            Gallon,
            Quart,
            Pint,
            CubicFoot,
            CubicYard
        }
        public enum MassUnit
        {
            Milligram,
            Gram,
            Kilogram,
            Ounce,
            Pound,
            Stone
        }

        private static readonly Dictionary<MassUnit, BigInteger> MassConversionTable = new Dictionary<MassUnit, BigInteger>
        {
            { MassUnit.Milligram, 1},
            { MassUnit.Gram, 1000 },
            { MassUnit.Kilogram, 1000000 },
            { MassUnit.Ounce, 28350 },
            { MassUnit.Pound, 453600 },
            { MassUnit.Stone, 6350400 }
        };

        private static readonly Dictionary<AreaUnit, BigInteger> AreaConversionTable = new Dictionary<AreaUnit, BigInteger>
        {
            { AreaUnit.SquareMillimeter, 1 },
            { AreaUnit.SquareCentimeter, 100 },
            { AreaUnit.SquareMeter, 1000000 },
            { AreaUnit.SquareKilometer, 1000000000000 },
            { AreaUnit.SquareInch, 64516 },
            { AreaUnit.SquareFoot, 9290304 },
            { AreaUnit.SquareYard, 83612736 },
            { AreaUnit.SquareMile, 2589988110336 }
        };
        //Yet another Enum, yay, This one for volumes

        //some values may be off, I might need to use a smaller base unit to increase accuracy but for now this will do for approx.
        private static readonly Dictionary<VolumeUnit, BigInteger> VolumeConversionTable = new Dictionary<VolumeUnit, BigInteger>
        {
            { VolumeUnit.Milliliter, 1 },
            { VolumeUnit.Liter, 1000 },
            { VolumeUnit.CubicMeter, 1000000 },
            { VolumeUnit.CubicFoot, 283168 },  // Corrected value
            { VolumeUnit.CubicYard, 764640 }, //corrected value (for simplicity of units and to avoid scientific notation in calculations I had went off liters for these, which meant off by a factor of 1000)
            { VolumeUnit.Pint, 473 }, //This is approximate for integer use, actual value 473.2
            { VolumeUnit.Quart, 946 }, //Also approx for integer use, actual value 946.4
            { VolumeUnit.Gallon, 3785 }
        };

        /** PRESERVE THIS We may want to revert to using decimal in the future, we will figure out our rounding errors later.
        //preserve the original so I can revert We are going to convert to big ints, and only work with deci when strictly needed (for fractional conversions where we get a zero back from big int)
        //private static readonly Dictionary<LengthUnit, decimal> ConversionTable = new Dictionary<LengthUnit, decimal>
        //{
        //    { LengthUnit.Millimeter, 1m },
        //    { LengthUnit.Centimeter, 0.1m },
        //    { LengthUnit.Meter, 0.001m },
        //    { LengthUnit.Kilometer, 1e+6m },
        //    { LengthUnit.Inch, 25.4m },
        //    { LengthUnit.Foot, 304.8m },
        //    { LengthUnit.Yard, 914.4m },
        //    { LengthUnit.Mile, 1609344m }
        //};
        //Preserve Convert Function for reference
        //public decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit)
        //{
        //    if (ConversionTable.TryGetValue(toUnit, out decimal toConversionFactor) &&
        //        ConversionTable.TryGetValue(fromUnit, out decimal fromConversionFactor))
        //    {
        //        return value * (fromConversionFactor / toConversionFactor);
        //        //fMe, This results in a rounding error. Lets try this anotehr way
        //    }

        //    return value;
        //}
        **/

        private static readonly Dictionary<LengthUnit, BigInteger> ConversionTable = new Dictionary<LengthUnit, BigInteger>
    {
        { LengthUnit.Millimeter, 10 },
        { LengthUnit.Centimeter, 100 },
        { LengthUnit.Meter, 10000 },
        { LengthUnit.Kilometer, 10000000 },
        { LengthUnit.Inch, 254 },
        { LengthUnit.Foot, 3048 },
        { LengthUnit.Yard, 9144 },
        { LengthUnit.Mile, 16093440 }
    };

        // allow access to the dicts
        public Dictionary<LengthUnit, BigInteger> GetLengthTable()
        {
            return ConversionTable;
        }
        public Dictionary<AreaUnit, BigInteger> GetAreaTable()
        {
            return AreaConversionTable;
        }
        public Dictionary<VolumeUnit, BigInteger> GetVolumeTable()
        {
            return VolumeConversionTable;
        }
        public Dictionary<MassUnit, BigInteger> GetMassTable()
        {
            return MassConversionTable;
        }

        //genericized this stuff so I can in theory use the same function as long as I have an Enum and a Dict
        public decimal Convert<TUnit>(decimal value, TUnit fromUnit, TUnit toUnit, Dictionary<TUnit, BigInteger> conversionTable)
            where TUnit : notnull
        {
            if (conversionTable.TryGetValue(toUnit, out BigInteger toConversionFactor) &&
                conversionTable.TryGetValue(fromUnit, out BigInteger fromConversionFactor))
            {
                BigInteger result = (BigInteger)value * fromConversionFactor / toConversionFactor;
                //if (result == 0 || result == 1)
                {
                    decimal result2 = value * ((decimal)fromConversionFactor / (decimal)toConversionFactor);
                    //Don't do this, I have a decimal number that's "magic" Even I think it's ugly, I'll refactor this as an option later and
                    //replace it with a variable. This is for functional testing only.
                    result2 = Math.Round(result2, 6);
                    return result2;
                }
                //return (decimal)result;
            }
            throw new InvalidOperationException($"Unsupported units: {fromUnit} to {toUnit}");
        }
    }
}
