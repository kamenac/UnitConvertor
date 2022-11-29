using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Data
{
    public class BitUnit : BaseUnit<IDataUnit>
    {
        public BitUnit() : base("bit", 1) // 1 bit is 1 bit (the common SI unit)
        {
        }
    }
}