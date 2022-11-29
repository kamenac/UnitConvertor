using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvetor;

namespace UnitConvertor.Interfaces
{
    /// <summary>
    /// used for the units that can't use the default simple coeficient multiplication algorithm
    /// </summary>
    public interface IComplexConvertUnit
    {
        /// <summary>
        /// return value of the source unit in the new unit
        /// </summary>
        /// <param name="sourceUnit"></param>
        /// <param name="quantity"></param>
        /// <param name="prefix"></param>
        /// <returns>value of the source unit in the new unit</returns>
        double ConvertFrom(IUnit sourceUnit, double quantity, Prefix prefix);
    }
}