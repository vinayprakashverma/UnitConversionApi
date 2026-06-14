using UnitConversionApi.Constants;
using UnitConversionApi.Models;
using UnitConversionApi.Repositories;
using UnitConversionApi.Strategies;

namespace UnitConversionApi.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IEnumerable<IConversionStrategy> _strategies;
        private readonly IUnitRepository _repository;
        private readonly ILogger<ConversionService> _logger;

        public ConversionService(
            IEnumerable<IConversionStrategy> strategies,
            IUnitRepository repository,
            ILogger<ConversionService> logger)
        {
            _strategies = strategies;
            _repository = repository;
            _logger = logger;
        }

        public ConversionResponse Convert(
            ConversionRequest request)
        {
            _logger.LogInformation(
                "Converting {Value} from {FromUnit} to {ToUnit}",
                request.Value,
                request.FromUnit,
                request.ToUnit);

            var strategy = _strategies.FirstOrDefault(
                s => s.CanHandle(request.FromUnit,
                                 request.ToUnit));

            if (strategy is null)
            {
                throw new InvalidOperationException(
                    $"Conversion from {request.FromUnit} to {request.ToUnit} is not supported.");
            }

            var convertedValue =
                strategy.Convert(
                    request.Value,
                    request.FromUnit,
                    request.ToUnit);

            return new ConversionResponse
            {
                OriginalValue = request.Value,
                FromUnit = request.FromUnit,
                ConvertedValue = Math.Round(convertedValue, 4),
                ToUnit = request.ToUnit
            };
        }

        public IEnumerable<string> GetSupportedUnits()
        {
            return _repository.GetAll()
                .Select(x => x.Name)
                .OrderBy(x => x);
        }
    }
}
