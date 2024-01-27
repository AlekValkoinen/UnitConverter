using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Helpers;

namespace UnitConverter
{
    public interface IUnitInfo
    {
        string Abbreviation { get; set; }
        string Description { get; set; }
        ConversionFactors.AreaUnit areaUnit { get; set; }
    }
}
