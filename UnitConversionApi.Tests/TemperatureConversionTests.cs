using System;
using System.Collections.Generic;
using System.Text;
using UnitConversionApi.Models;
using UnitConversionApi.Services;
using UnitConversionApi.Tests.Helpers;

namespace UnitConversionApi.Tests
{
    [TestClass]
    public class TemperatureConversionTests
    {
        private ConversionService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _service = TestServiceFactory.Create();
        }

        [TestMethod]
        public void Celsius_To_Fahrenheit()
        {
            var request = new ConversionRequest
            {
                Value = 100,
                FromUnit = "celsius",
                ToUnit = "fahrenheit"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                212,
                result.ConvertedValue,
                0.01);
        }

        [TestMethod]
        public void Fahrenheit_To_Celsius()
        {
            var request = new ConversionRequest
            {
                Value = 212,
                FromUnit = "fahrenheit",
                ToUnit = "celsius"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                100,
                result.ConvertedValue,
                0.01);
        }

        [TestMethod]
        public void Celsius_To_Kelvin()
        {
            var request = new ConversionRequest
            {
                Value = 0,
                FromUnit = "celsius",
                ToUnit = "kelvin"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                273.15,
                result.ConvertedValue,
                0.01);
        }
    }
}
