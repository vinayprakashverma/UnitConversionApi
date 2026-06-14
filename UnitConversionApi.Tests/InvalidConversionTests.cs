using UnitConversionApi.Models;
using UnitConversionApi.Services;
using UnitConversionApi.Tests.Helpers;

namespace UnitConversionApi.Tests
{
    [TestClass]
    public class InvalidConversionTests
    {
        private ConversionService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _service = TestServiceFactory.Create();
        }

        [TestMethod]
        public void Invalid_Conversion_Should_Throw()
        {
            var request = new ConversionRequest
            {
                Value = 10,
                FromUnit = "meter",
                ToUnit = "kilogram"
            };

            try
            {
                _service.Convert(request);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                // expected
            }
        }

        [TestMethod]
        public void Unknown_Unit_Should_Throw()
        {
            var request = new ConversionRequest
            {
                Value = 10,
                FromUnit = "abc",
                ToUnit = "xyz"
            };

            try
            {
                _service.Convert(request);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException)
            {
                // expected
            }
        }
    }
}
