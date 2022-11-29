using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvetor;

namespace UnitConvertor.Interfaces
{
    public interface IUnit
    {
        /// <summary>
        /// Unit name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// quantity of the unit in SI unit
        /// </summary>
        double QuantityInSiUnit { get; }

        Type UnitType { get; }

        /// <summary>
        /// is the destination unit of the same type (length, time, etc.)?
        /// </summary>
        /// <param name="destinationUnit"></param>
        /// <returns>TRUE if the unit can be converted to the destionation type,
        /// FALSE if it can't be converted (eg. length to time)</returns>
        /// <exception cref="ArgumentNullException"></exception>
        bool CanConvertTo(IUnit destinationUnit);

        double ConvertTo(IUnit destination, double quantity, Prefix prefix);

        bool IsMatch(string input);
    }
}