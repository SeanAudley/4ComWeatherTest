namespace WeatherService
{
    // Simple class to contain all the enumerated types for Wind and Temperature
    // I did toy with using inheritence of a base measurement type, then the solution would be more adaptable, this method
    // would be useful the future should SI units get implemented as there are a hell of a lot of measurement types!
    
    // define the enumerated measurement types available for the weather app
    public static class measurementTypes
    {
        // define the available temperature measurement types
        public enum TemperatureType
        {
            Celsius,
            Farenheit
        }
        // define the available wind measurement types 
        public enum WindType
        {
            MPH,
            KPH
        }
    }
}