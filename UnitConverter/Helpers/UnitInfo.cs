using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Helpers;

namespace UnitConverter
{
    //{
    //    public class UnitInfo
    //    {
    //        public string Abbreviation { get; set; }
    //        public string Description { get; set; }
    //        ConversionFactors.AreaUnit areaUnit { get; set; }
    //        public UnitInfo(string abbreviation, string description, ConversionFactors.AreaUnit areaUnit)
    //        {
    //            Abbreviation = abbreviation;
    //            Description = description;
    //            this.areaUnit = areaUnit;
    //        }
    //    }
    //}
    //public class UnitInfo : IUnitInfo
    //{
    //    public string Abbreviation { get; set; }
    //    public string Description { get; set; }
    //    public ConversionFactors.LengthUnit lengthUnit { get; set; }
    //    public ConversionFactors.AreaUnit areaUnit { get; set; }
    //    ConversionFactors.AreaUnit IUnitInfo.areaUnit { get; set; }

    //    public UnitInfo(string abbreviation, string description, ConversionFactors.AreaUnit AreaUnit)
    //    {
    //        Abbreviation = abbreviation;
    //        Description = description;
    //        areaUnit = AreaUnit;
    //    }
    //    public UnitInfo(string abbreviation, string description, ConversionFactors.LengthUnit LengthUnit)
    //    {
    //        Abbreviation = abbreviation;
    //        Description = description;
    //        lengthUnit = LengthUnit;
    //    }
    //}

    //genercize this stuff, so I don't have to keep adding code That is per case use
    public class UnitInfo<TUnit>
    {
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public TUnit Unit { get; set; }

        // Constructor
        public UnitInfo(string abbreviation, string description, TUnit unit)
        {
            Abbreviation = abbreviation;
            Description = description;
            Unit = unit;
        }
    }
}