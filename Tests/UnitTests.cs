using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;
using UnitConvertor.Units.Length;
using UnitConvertor.Units.Temperature;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCanConvertCompatibleUnits()
        {
            var meter = new MeterUnit();
            var foot = new FootUnit();

            meter.CanConvertTo(foot)
                .ShouldBeTrue();

            foot.CanConvertTo(meter)
                .ShouldBeTrue();
        }

        [TestMethod]
        public void TestCanNotConvertIncompatibleUnits()
        {
            var meter = new MeterUnit();
            var celsius = new CelsiusUnit();

            meter.CanConvertTo(celsius)
                .ShouldBeFalse();

            celsius.CanConvertTo(meter)
                .ShouldBeFalse();
        }
    }
}