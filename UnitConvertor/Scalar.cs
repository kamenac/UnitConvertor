using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;
using UnitConvetor;

namespace UnitConvertor
{
    /// <summary>
    /// unit with dimension and optional prefix
    /// </summary>
    public class Scalar : IScalar
    {
        public Scalar(IUnit unit, double quantity, Prefix? prefix = null) : this(unit)
        {
            if (prefix != null)
            {
                Prefix = prefix;
            }

            Quantity = quantity;
        }

        public Scalar(IUnit unit)
        {
            Prefix = Prefix.NoPrefix;
            Unit = unit;
        }

        public Prefix Prefix { get; set; }

        public double Quantity { get; set; }

        public IUnit Unit { get; private set; }

        public static IScalar Parse(string input)
        {
            var strings = input.ToLower().Split(' ');

            if (strings.Length != 2)
            {
                throw new FormatException(Messages.InvalidScalarFormat);
            }

            var inputUnit = UnitConvertorRepository.ParseUnit(strings[1]);

            if (inputUnit is null)
            {
                throw new FormatException(Messages.NoUnitFound);
            }

            var inputSize = double.Parse(strings[0]);

            var prefix = Prefix.NoPrefix;

            if (strings[1] != inputUnit.Name) // the input has a prefix
            {
                prefix = Prefix.Parse(strings[1]);
            }

            var inputScalar = new Scalar(inputUnit, inputSize * prefix.Size);

            return inputScalar;
        }

        public IScalar ConvertTo(IUnit outputUnit, Prefix prefix)
        {
            var retVal = new Scalar(outputUnit);
            retVal.Prefix = prefix;
            retVal.Quantity = Unit.ConvertTo(outputUnit, Quantity, prefix);

            return retVal;
        }

        public string ToStringValue()
        {
            string nameWithPrefix = Unit.Name;

            if (Prefix != Prefix.NoPrefix)
            {
                nameWithPrefix = Prefix.PrefixName + Unit.Name;
            }

            return $"{Quantity:0.00} {nameWithPrefix}";
        }
    }
}