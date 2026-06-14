using System;
using System.Collections.Generic;
using System.Text;
using UnitConversionApi.Models;
using UnitConversionApi.Services;
using UnitConversionApi.Tests.Helpers;

namespace UnitConversionApi.Tests
{
    [TestClass]
    public class ConversionServiceTests
    {
        private ConversionService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            _service = TestServiceFactory.Create();
        }

        [TestMethod]
        public void Meter_To_Feet_Should_Convert()
        {
            var request = new ConversionRequest
            {
                Value = 1,
                FromUnit = "meter",
                ToUnit = "feet"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                3.2808,
                result.ConvertedValue,
                0.01);
        }

        [TestMethod]
        public void Feet_To_Meter_Should_Convert()
        {
            var request = new ConversionRequest
            {
                Value = 3.28084,
                FromUnit = "feet",
                ToUnit = "meter"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                1,
                result.ConvertedValue,
                0.01);
        }

        [TestMethod]
        public void Kilogram_To_Pound_Should_Convert()
        {
            var request = new ConversionRequest
            {
                Value = 1,
                FromUnit = "kilogram",
                ToUnit = "pound"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                2.2046,
                result.ConvertedValue,
                0.01);
        }

        [TestMethod]
        public void Pound_To_Kilogram_Should_Convert()
        {
            var request = new ConversionRequest
            {
                Value = 2.20462,
                FromUnit = "pound",
                ToUnit = "kilogram"
            };

            var result = _service.Convert(request);

            Assert.AreEqual(
                1,
                result.ConvertedValue,
                0.01);
        }
    }
}
