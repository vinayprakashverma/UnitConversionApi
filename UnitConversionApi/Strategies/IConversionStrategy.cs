namespace UnitConversionApi.Strategies
{
    public interface IConversionStrategy
    {
        bool CanHandle(string fromUnit, string toUnit);

        double Convert(double value,
                       string fromUnit,
                       string toUnit);
    }
}
