using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConvertor;
using UnitConvertor.Units.Length;

namespace Tests
{
    [TestClass]
    public class ScalarTests
    {
        [TestInitialize]
        public void Setup()
        {
            UnitConvertorRepository.AddConvertableUnit(new MeterUnit());
        }

        [TestMethod]
        public void TestScalarWithPrefix()
        {
            var milliMeter = Scalar.Parse("1 millimeter");
        }
    }
}