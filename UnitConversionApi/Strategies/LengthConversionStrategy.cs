using UnitConversionApi.Repositories;

namespace UnitConversionApi.Strategies
{
    public class LengthConversionStrategy : IConversionStrategy
    {
        private readonly IUnitRepository _repository;

        public LengthConversionStrategy(IUnitRepository repository)
        {
            _repository = repository;
        }

        public bool CanHandle(string fromUnit,
                              string toUnit)
        {
            var units = _repository.GetAll();

            var from = units.FirstOrDefault(x =>
                x.Name.Equals(fromUnit,
                StringComparison.OrdinalIgnoreCase));

            var to = units.FirstOrDefault(x =>
                x.Name.Equals(toUnit,
                StringComparison.OrdinalIgnoreCase));

            return from?.Category == "Length"
                   && to?.Category == "Length";
        }

        public double Convert(double value,
                              string fromUnit,
                              string toUnit)
        {
            var units = _repository.GetAll();

            var from = units.First(x =>
                x.Name.Equals(fromUnit,
                StringComparison.OrdinalIgnoreCase));

            var to = units.First(x =>
                x.Name.Equals(toUnit,
                StringComparison.OrdinalIgnoreCase));

            var baseValue = value * from.FactorToBaseUnit;

            return baseValue / to.FactorToBaseUnit;
        }
    }
}
