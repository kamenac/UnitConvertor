using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConvertor
{
    public class Messages
    {
        public static string InvalidScalarFormat = "Invalid scalar format. Please specify both quantity and unit. eg. '1 meter', '1 millimeter' ";

        public static string NoUnitFound = "Could not find a convertable unit";

        public static string NoUnitFoundToRegister = "Could not find any units to register";
    }
}