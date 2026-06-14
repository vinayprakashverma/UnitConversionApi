namespace UnitConversionApi.Strategies
{
    public class TemperatureConversionStrategy : IConversionStrategy
    {
        private readonly string[] _units =
        {
        "celsius",
        "fahrenheit",
        "kelvin"
    };

        public bool CanHandle(string fromUnit,
                              string toUnit)
        {
            return _units.Contains(fromUnit.ToLower()) &&
                   _units.Contains(toUnit.ToLower());
        }

        public double Convert(double value,
                              string fromUnit,
                              string toUnit)
        {
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            if (fromUnit == toUnit)
                return value;

            if (fromUnit == "celsius" &&
                toUnit == "fahrenheit")
                return value * 9 / 5 + 32;

            if (fromUnit == "fahrenheit" &&
                toUnit == "celsius")
                return (value - 32) * 5 / 9;

            if (fromUnit == "celsius" &&
                toUnit == "kelvin")
                return value + 273.15;

            if (fromUnit == "kelvin" &&
                toUnit == "celsius")
                return value - 273.15;

            throw new InvalidOperationException(
                "Unsupported temperature conversion.");
        }
    }
}
