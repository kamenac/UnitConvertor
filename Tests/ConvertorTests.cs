using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;
using UnitConvertor.Units.Data;
using UnitConvertor.Units.Length;
using UnitConvertor.Units.Temperature;

namespace Tests
{
    [TestClass]
    public class ConvertorTests
    {
        [TestInitialize]
        public void Setup()
        {
            //// todo: solve auto registering
            //UnitConvertorRepository.AddConvertableUnit(new MeterUnit());
            //UnitConvertorRepository.AddConvertableUnit(new FootUnit());
            //UnitConvertorRepository.AddConvertableUnit(new InchUnit());

            //UnitConvertorRepository.AddConvertableUnit(new ByteUnit());
            //UnitConvertorRepository.AddConvertableUnit(new BitUnit());

            //UnitConvertorRepository.AddConvertableUnit(new CelsiusUnit());
            //UnitConvertorRepository.AddConvertableUnit(new FahrenheitUnit());

            UnitConvertorRepository.RegisterAllUnits();
        }

        [TestMethod]
        public void TestConvertDataUnits()
        {
            var convertor = new UnitConvertor.UnitConvertor();

            var convertedByte = convertor.Convert("1 kilobyte", "byte");
            convertedByte.ShouldBe("1000.00 byte"); // todo: deal with the traditional power of 2: 1024?

            var convertedBits = convertor.Convert("8 bit", "byte");
            convertedBits.ShouldBe("1.00 byte");
        }

        [TestMethod]
        public void TestConvertToOutputWithPrefix()
        {
            var convertor = new UnitConvertor.UnitConvertor();

            var convertedMeter = convertor.Convert("1 meter", "millimeter");
            convertedMeter.ShouldBe("1000.00 millimeter");

            var convertedInch = convertor.Convert("1 inch", "centimeter");
            convertedInch.ShouldBe("2.54 centimeter");
        }

        [TestMethod]
        public void TestLengthConvertors()
        {
            var convertor = new UnitConvertor.UnitConvertor();

            var result = convertor.Convert("1 meter", "foot");

            result.ShouldBe("3.28 foot");

            result = convertor.Convert("3 kilometer", "meter");
            result.ShouldBe("3000.00 meter");
        }

        [TestMethod]
        public void TestTemperatureConvertor()
        {
            var convertor = new UnitConvertor.UnitConvertor();

            var zeroFToC = convertor.Convert("0 fahrenheit", "celsius");
            zeroFToC.ShouldBe("-17.78 celsius");

            var fortyFToC = convertor.Convert("-40 fahrenheit", "celsius");
            fortyFToC.ShouldBe("-40.00 celsius");
        }

        [TestMethod]
        public void TestTemperatureConvertorToFahrenheit()
        {
            var convertor = new UnitConvertor.UnitConvertor();

            var zeroCToF = convertor.Convert("0 celsius", "fahrenheit");
            zeroCToF.ShouldBe("32.00 fahrenheit");

            var oneCtoF = convertor.Convert("1 celsius", "fahrenheit");
            oneCtoF.ShouldBe("33.80 fahrenheit");
        }


    }
}