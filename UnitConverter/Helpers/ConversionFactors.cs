using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Helpers
{

    internal class ConversionFactors
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


        private static readonly Dictionary<LengthUnit, BigInteger> ConversionTable = new Dictionary<LengthUnit, BigInteger>
    {
        { LengthUnit.Millimeter, 1 },
        { LengthUnit.Centimeter, 10 },
        { LengthUnit.Meter, 1000 },
        { LengthUnit.Kilometer, 1000000 },
        { LengthUnit.Inch, 25400 },
        { LengthUnit.Foot, 304800 },
        { LengthUnit.Yard, 914400 },
        { LengthUnit.Mile, 1609344000 }
    };

        public decimal Convert(decimal value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            if (ConversionTable.TryGetValue(toUnit, out BigInteger toConversionFactor) &&
                ConversionTable.TryGetValue(fromUnit, out BigInteger fromConversionFactor))
            {
                BigInteger result = (BigInteger)value * fromConversionFactor / toConversionFactor;
                if (result == 0)
                {
                    decimal result2 = value * ((decimal)fromConversionFactor / (decimal)toConversionFactor);
                    return result2;
                }
                return (decimal)result;
            }

            throw new InvalidOperationException($"Unsupported units: {fromUnit} to {toUnit}");
        }
        //Doing the bad, we're going to overload the convert method
        public decimal Convert(decimal value, AreaUnit fromUnit, AreaUnit toUnit)
        {
            if (AreaConversionTable.TryGetValue(toUnit, out BigInteger toConversionFactor) &&
                AreaConversionTable.TryGetValue(fromUnit, out BigInteger fromConversionFactor))
            {
                BigInteger result = (BigInteger)value * fromConversionFactor / toConversionFactor;
                if (result == 0)
                {
                    decimal result2 = value * ((decimal)fromConversionFactor / (decimal)toConversionFactor);
                    return result2;
                }
                return (decimal)result;
            }

            throw new InvalidOperationException($"Unsupported units: {fromUnit} to {toUnit}");
        }
        public ConversionFactors.LengthUnit GetLengthUnit(string toUnit)
        {
            if (toUnit == "mm")
            {
                return LengthUnit.Millimeter;
            }
            if (toUnit == "cm")
            {
                return LengthUnit.Centimeter;
            }
            if (toUnit == "m")
            {
                return LengthUnit.Meter;
            }
            if (toUnit == "km")
            {
                return LengthUnit.Kilometer;
            }
            if (toUnit == "in")
            {
                return LengthUnit.Inch;
            }
            if (toUnit == "ft")
            {
                return LengthUnit.Foot;
            }
            if (toUnit == "yd")
            {
                return LengthUnit.Yard;
            }
            if (toUnit == "mi")
            {
                return LengthUnit.Mile;
            }
            return LengthUnit.Millimeter;
        }

        public ConversionFactors.AreaUnit GetAreaUnit(string toUnit)
        {
            if (toUnit == "mm")
            {
                return AreaUnit.SquareMillimeter;
            }
            if (toUnit == "cm")
            {
                return AreaUnit.SquareCentimeter;
            }
            if (toUnit == "m")
            {
                return AreaUnit.SquareMeter;
            }
            if (toUnit == "km")
            {
                return AreaUnit.SquareKilometer;
            }
            if (toUnit == "in")
            {
                return AreaUnit.SquareInch;
            }
            if (toUnit == "ft")
            {
                return AreaUnit.SquareFoot;
            }
            if (toUnit == "yd")
            {
                return AreaUnit.SquareYard;
            }
            if (toUnit == "mi")
            {
                return AreaUnit.SquareMile;
            }
            return AreaUnit.SquareMillimeter;
        }

    }
    //works but too much like actual work, not readable, and generally just bad practice, replace this madness.
    //internal class ConversionFactors
    //{
    //    string mm = "mm";
    //    string cm = "cm";
    //    string m = "m";
    //    string km = "km";
    //    string inch = "in";
    //    string foot = "ft";
    //    string yard = "yd";
    //    string mile = "mi";

    //    public float FromMillimeters(string toUnit)
    //    {
    //        if (toUnit == cm)
    //        {
    //            return 0.1f;
    //        }
    //        if (toUnit == m)
    //        {
    //            return 0.001f;
    //        }
    //        if (toUnit == km)
    //        {
    //            return 1 / 1e+6f;
    //        }
    //        if (toUnit == inch)
    //        {
    //            return 1 / 25.4f;
    //        }
    //        if(toUnit == foot)
    //        {
    //            return 1 / 304.8f;
    //        }
    //        if(toUnit == yard)
    //        {
    //            return 1 / 914.4f;
    //        }
    //        if (toUnit == mile)
    //        {
    //            //return 1 / 1.609e+6f;
    //            return 1 / 1609344f;
    //        }
    //        return 1f;
    //    }
    //    public float FromCentimeters(string toUnit)
    //    {
    //        if (toUnit == mm)
    //        {
    //            return 10f;
    //        }
    //        if (toUnit == m)
    //        {
    //            return 0.01f;
    //        }
    //        if (toUnit == km)
    //        {
    //            return 1e-5f;
    //        }
    //        if (toUnit == inch)
    //        {
    //            return 1 / 2.54f;
    //        }
    //        if (toUnit == foot)
    //        {
    //            return 1 / 30.48f;
    //        }
    //        if (toUnit == yard)
    //        {
    //            return 1 / 91.44f;
    //        }
    //        if (toUnit == mile)
    //        {
    //            return 1 / 160934.4f;
    //        }
    //        return 1f;
    //    }
    //    public float FromMeters(string toUnit)
    //    {
    //        if (toUnit == mm)
    //        {
    //            return 1000f;
    //        }
    //        if (toUnit == cm)
    //        {
    //            return 100f;
    //        }
    //        if (toUnit == km)
    //        {
    //            return 0.001f;
    //        }
    //        if (toUnit == inch)
    //        {
    //            return 39.37f;
    //        }
    //        if (toUnit == foot)
    //        {
    //            return 3.280839895f;
    //        }
    //        if (toUnit == yard)
    //        {
    //            return 3.280839895f / 3f;
    //        }
    //        if (toUnit == mile)
    //        {
    //            return 3.280839895f / 5280f;
    //        }
    //        return 1f;
    //    }
    //    //about to do something you shouldn't do, and create an interdependency
    //    public float FromInches(string toUnit)
    //    {
    //        //This is a bad idea performance wise but makes my life easier
    //        if (toUnit == mm)
    //        {
    //            return 1 / FromMillimeters(inch);
    //        }
    //        if (toUnit == cm)
    //        {
    //            return 1 / FromCentimeters(inch);
    //        }
    //        if (toUnit == m)
    //        {
    //            return 1 / FromMeters(inch);
    //        }
    //        if(toUnit == km)
    //        {
    //            return 1 / FromMeters(inch) * 1000;
    //        }
    //        if (toUnit == foot)
    //        {
    //            return 1 / 12f;
    //        }
    //        if (toUnit == yard)
    //        {
    //            return 1 / 36f;
    //        }
    //        if(toUnit == mile)
    //        {
    //            return 1 / (5280f * 12f);
    //        }


    //        return 1f;
    //    }
    //    public float FromFeet(string  toUnit)
    //    {
    //        switch(toUnit)
    //        {

    //        }



    //        return 1f;
    //    }
    //}


}
