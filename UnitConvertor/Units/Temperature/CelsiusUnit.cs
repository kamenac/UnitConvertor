using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Temperature
{
    public class CelsiusUnit : BaseUnit<ITemperatureUnit>
    {
        public CelsiusUnit() : base("celsius", 1) // one celsius is one celsius (the common SI unit)
        {
        }
    }
}