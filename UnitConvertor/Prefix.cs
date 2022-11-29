using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace UnitConvetor
{
    public class Prefix
    {
        static Prefix()
        {
            NoPrefix = new Prefix("", 1);

            SiPrefixes.Add(new Prefix("quetta", 1E+30));
            SiPrefixes.Add(new Prefix("ronna", 1E+27));
            SiPrefixes.Add(new Prefix("yotta", 1E+24));
            SiPrefixes.Add(new Prefix("zetta", 1E+21));
            SiPrefixes.Add(new Prefix("exa", 1E+18));
            SiPrefixes.Add(new Prefix("peta", 1E+15));
            SiPrefixes.Add(new Prefix("tera", 1E+12));
            SiPrefixes.Add(new Prefix("giga", 1E+9));
            SiPrefixes.Add(new Prefix("mega", 1E+6));
            SiPrefixes.Add(new Prefix("kilo", 1E+3));
            SiPrefixes.Add(new Prefix("hecto", 1E+2));
            SiPrefixes.Add(new Prefix("deca", 10));

            // fractions
            SiPrefixes.Add(new Prefix("deci", 0.1));
            SiPrefixes.Add(new Prefix("centi", 0.01));
            SiPrefixes.Add(new Prefix("milli", 0.001));
            SiPrefixes.Add(new Prefix("micro", 0.000001));
            SiPrefixes.Add(new Prefix("nano", 0.000000001));
            SiPrefixes.Add(new Prefix("pico", 0.000000000001));
            SiPrefixes.Add(new Prefix("femto", 0.000000000000001));
            SiPrefixes.Add(new Prefix("atto", 0.000000000000000001));
            SiPrefixes.Add(new Prefix("zepto", 0.000000000000000000001));
            SiPrefixes.Add(new Prefix("yocto", 0.000000000000000000000001));
            SiPrefixes.Add(new Prefix("ronto", 0.000000000000000000000000001));
            SiPrefixes.Add(new Prefix("quecto", 0.000000000000000000000000000001));
        }

        public Prefix(string prefixName, double size)
        {
            PrefixName = prefixName;
            Size = size;
        }

        /// <summary>
        /// special case of prefix - no prefix
        /// </summary>
        public static Prefix NoPrefix { get; private set; }

        public static List<Prefix> SiPrefixes { get; set; } = new();

        public string PrefixName { get; private set; }

        public double Size { get; private set; }

        public static Prefix Parse(string input)
        {
            foreach (var prefix in SiPrefixes)
            {
                if (prefix.IsMatch(input))
                {
                    return prefix;
                }
            }

            return NoPrefix;
        }

        public bool IsMatch(string input)
        {
            return input.StartsWith(this.PrefixName);
        }
    }
}