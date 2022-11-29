using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Length
{
    public class MeterUnit : BaseUnit<ILengthUnit>
    {
        public MeterUnit() : base("meter", 1) // 1 meter is 1 meter (the common SI unit)
        {
        }
    }
}