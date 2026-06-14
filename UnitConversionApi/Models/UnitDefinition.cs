namespace UnitConversionApi.Models
{
    public class UnitDefinition
    {
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public double FactorToBaseUnit { get; set; }
    }
}
