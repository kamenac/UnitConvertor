using UnitConvetor;
using Shouldly;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class PrefixTests
    {
        [TestMethod]
        public void NoPrefixMatchTest()
        {
            var noPrefix = Prefix.NoPrefix;

            noPrefix.IsMatch("meter")
                .ShouldBeTrue();
        }

        [TestMethod]
        public void PrefixIsMatchTest()
        {
            var kilo = Prefix.SiPrefixes.First(x => x.PrefixName == "kilo");

            kilo.IsMatch("kilometer")
                .ShouldBeTrue();

            var milliPrefix = Prefix.SiPrefixes.First(x => x.PrefixName == "milli");

            milliPrefix.IsMatch("millimeter")
                .ShouldBeTrue();
        }

        [TestMethod]
        public void TestPrefixSizeDeci()
        {
            var deci = Prefix.SiPrefixes.First(x => x.PrefixName == "deci");

            deci.Size
                .ShouldBe(0.1);
        }

        [TestMethod]
        public void TestPrefixSizeKilo()
        {
            var kilo = Prefix.SiPrefixes.First(x => x.PrefixName == "kilo");

            kilo.Size
                .ShouldBe(1000);
        }
    }
}