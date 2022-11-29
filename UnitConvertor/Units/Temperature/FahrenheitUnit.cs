using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;
using UnitConvetor;

namespace UnitConvertor.Units.Temperature
{
    public class FahrenheitUnit : BaseUnit<ITemperatureUnit>, IComplexConvertUnit
    {
        public FahrenheitUnit() : base("fahrenheit", 1) // SI unit is meaningless here, uses complex convertion algorithm
        {
        }

        public double ConvertFrom(IUnit sourceUnit, double quantity, Prefix prefix)
        {
            // F = (C*1.8)+32

            return (sourceUnit.QuantityInSiUnit * quantity * 1.8) + 32.00;
        }

        public override double ConvertTo(IUnit destination, double quantity, Prefix prefix)
        {
            if (!CanConvertTo(destination))
            {
                throw new ArgumentException("Cannot convert to " + destination.Name);
            }

            // C = (F-32)/1.8
            var quantityInCelsius = (quantity - 32) / 1.8;

            return (quantityInCelsius / destination.QuantityInSiUnit) / prefix.Size;
        }
    }
}