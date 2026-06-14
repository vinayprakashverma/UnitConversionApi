using UnitConversionApi.Models;

namespace UnitConversionApi.Repositories
{
    public class InMemoryUnitRepository: IUnitRepository
    {
        private readonly List<UnitDefinition> _units =
    [
        new()
        {
            Name = "meter",
            Category = "Length",
            FactorToBaseUnit = 1
        },

        new()
        {
            Name = "kilometer",
            Category = "Length",
            FactorToBaseUnit = 1000
        },

        new()
        {
            Name = "feet",
            Category = "Length",
            FactorToBaseUnit = 0.3048
        },

        new()
        {
            Name = "kilogram",
            Category = "Weight",
            FactorToBaseUnit = 1
        },

        new()
        {
            Name = "gram",
            Category = "Weight",
            FactorToBaseUnit = 0.001
        },

        new()
        {
            Name = "pound",
            Category = "Weight",
            FactorToBaseUnit = 0.453592
        }
    ];

        public IEnumerable<UnitDefinition> GetAll()
        {
            return _units;
        }
    }
}
