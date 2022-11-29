using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvetor;

namespace UnitConvertor.Interfaces
{
    /// <summary>
    /// unit with dimension and optional prefix
    /// </summary>
    public interface IScalar
    {
        public Prefix Prefix { get; }

        public double Quantity { get; set; }

        public IUnit Unit { get; }

        /// <summary>
        /// converts the scalar to new scalar with a specified unit
        /// </summary>
        /// <param name="outputUnit">type of the output</param>
        /// <param name="outputPrefix">output prefix</param>
        /// <returns>scalar with specified unit and prefix</returns>
        public IScalar ConvertTo(IUnit outputUnit, Prefix outputPrefix);

        /// <summary>
        /// returns string description of the scalar
        /// </summary>
        /// <returns></returns>
        public string ToStringValue();
    }
}