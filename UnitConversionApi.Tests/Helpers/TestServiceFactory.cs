using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitConversionApi.Repositories;
using UnitConversionApi.Services;
using UnitConversionApi.Strategies;

namespace UnitConversionApi.Tests.Helpers
{
    public static class TestServiceFactory
    {
        public static ConversionService Create()
        {
            var repository =
                new InMemoryUnitRepository();

            var strategies =
                new List<IConversionStrategy>
                {
                new LengthConversionStrategy(repository),
                new WeightConversionStrategy(repository),
                new TemperatureConversionStrategy()
                };

            var logger =
                Mock.Of<ILogger<ConversionService>>();

            return new ConversionService(
                strategies,
                repository,
                logger);
        }
    }
}
