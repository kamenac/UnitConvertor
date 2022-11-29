using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;

namespace UnitConvertor.Units.Data
{
    public class ByteUnit : BaseUnit<IDataUnit>
    {
        public ByteUnit() : base("byte", 8) // 1 byte is 8 bytes
        {
        }
    }
}