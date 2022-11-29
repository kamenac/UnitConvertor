using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor.Interfaces;
using System.Reflection;

namespace UnitConvertor
{
    public class UnitConvertorRepository
    {
        private static List<IUnit> convertableUnits = new();

        // todo: load all units and unit types from assembly on start

        public static IReadOnlyList<IUnit> AvailableUnits
        {
            get
            {
                return convertableUnits;
            }
        }

        public static void AddConvertableUnit(IUnit unit)
        {
            if (!convertableUnits.Any(x => x.Name == unit.Name))
            {
                convertableUnits.Add(unit);
            }
        }

        public static IUnit ParseUnit(string inputUnit)
        {
            foreach (var unit in AvailableUnits)
            {
                if (unit.IsMatch(inputUnit))
                {
                    return unit;
                }
            }

            return null;
        }

        public static void RegisterAllUnits()
        {
            var units = Assembly.GetAssembly(typeof(IUnit))?.GetTypes() // load all available unit types
                .Where(type => typeof(IUnit).IsAssignableFrom(type)
                        && !type.IsInterface
                        && !type.IsAbstract)
                ;

            if (units == null)
            {
                throw new ApplicationException(Messages.NoUnitFoundToRegister);
            }

            foreach (var unit in units)
            {
                var instance = (IUnit)Activator.CreateInstance(unit);

                if (!convertableUnits.Any(x => x.Name == instance.Name))
                {
                    convertableUnits.Add(instance);
                }

            }
        }
    }
}