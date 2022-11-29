using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Length
{
    public class InchUnit : BaseUnit<ILengthUnit>
    {
        public InchUnit() : base("inch", 0.0254f) // 1 inch == 0.0254 meter (SI unit)
        {
        }
    }
}