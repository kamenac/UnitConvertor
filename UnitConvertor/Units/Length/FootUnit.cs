using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Length
{
    public class FootUnit : BaseUnit<ILengthUnit>
    {
        public FootUnit() : base("foot", 0.3048f) // 1 foot is 0.3048 meter (SI unit)
        {
        }
    }
}