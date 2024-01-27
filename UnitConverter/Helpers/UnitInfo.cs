using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitInfo
    {
        public string Abbreviation { get; set; }
        public string Description { get; set; }

        public UnitInfo(string abbreviation, string description)
        {
            Abbreviation = abbreviation;
            Description = description;
            
        }
    }
}
