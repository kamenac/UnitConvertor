using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;
using UnitConvetor;

namespace UnitConvertor
{
    public class UnitConvertor : IUnitConvertor
    {
        public string Convert(string inputString, string outputUnitName)
        {
            var outputUnit = UnitConvertorRepository.ParseUnit(outputUnitName);
            Prefix outputPrefix;

            if (outputUnitName != outputUnit.Name) // the input has a prefix
            {
                outputPrefix = Prefix.Parse(outputUnitName);
            }
            else
            {
                outputPrefix = Prefix.NoPrefix;
            }

            IScalar inputScalar = Scalar.Parse(inputString);

            var outputScalar = inputScalar.ConvertTo(outputUnit, outputPrefix);

            return outputScalar.ToStringValue();
        }
    }
}