using UnitConversionApi.Models;

namespace UnitConversionApi.Repositories
{
    public interface IUnitRepository
    {
        IEnumerable<UnitDefinition> GetAll();
    }
}
