using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;
using UnitConvetor;

namespace UnitConvertor
{
    public abstract class BaseUnit<TUnitType> : IUnit where TUnitType : IUnitType
    {
        public BaseUnit(string name, double sizeInSiUnit)
        {
            Name = name;
            QuantityInSiUnit = sizeInSiUnit;
            UnitType = typeof(TUnitType);
        }

        public string Name { get; private set; }

        /// <summary>
        /// quantity of the unit in SI unit
        /// </summary>
        public double QuantityInSiUnit { get; private set; }

        public Type UnitType { get; private set; }

        /// <summary>
        /// is the destionation unit of the same type?
        /// </summary>
        /// <param name="destinationUnit"></param>
        /// <returns>true if the unit can be converted to the destionation type,
        /// false if can't (eg. length to time)</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool CanConvertTo(IUnit destinationUnit)
        {
            if (destinationUnit == null)
            {
                throw new ArgumentNullException(nameof(destinationUnit) + " is null");
            }

            return (destinationUnit.UnitType == UnitType);
        }

        public virtual double ConvertTo(IUnit destination, double quantity, Prefix prefix)
        {
            if (!CanConvertTo(destination))
            {
                throw new ArgumentException("Cannot convert to " + destination.Name);
            }

            // execute the destination unit's complex convert algorithm, if any
            var complexConvert = destination as IComplexConvertUnit;
            if (complexConvert != null)
            {
                return complexConvert.ConvertFrom(this, quantity, prefix);
            }

            return (QuantityInSiUnit / destination.QuantityInSiUnit) * quantity / prefix.Size;
        }

        public bool IsMatch(string input)
        {
            return input.EndsWith(Name);
        }
    }
}