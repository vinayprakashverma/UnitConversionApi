namespace UnitConversionApi.Constants
{
    public class UnitDefinitions
    {
        public static readonly Dictionary<string, double> Length =
       new()
       {
            { "meter", 1 },
            { "feet", 3.28084 },
            { "kilometer", 0.001 }
       };

        public static readonly Dictionary<string, double> Weight =
            new()
            {
            { "kilogram", 1 },
            { "pound", 2.20462 }
            };
    }
}
