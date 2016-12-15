using System;

namespace WeatherService
{
    // Simple class to contain all the various measurement conversions.
    // I did toy with the idea of letting each weather service do this, but then this was more useful as a common class
    // In the future should SI units get implemented then I would recommend making this into a simple API itself

    public static class MeansurementConversions
    {
        // Convert fahrenheit to celsius
        public static double ToCelsius(this double fahrenheit)
        {
            var celsius = 5.0 / 9.0 * (fahrenheit - 32);
            //round up to 1 decimal place and return
            return Math.Round(celsius, 1);
        }

        // Convert celsius to fahrenheit
        public static double ToFahrenheit(this double celsius)
        {
            var fahrenheit = ((9.0 / 5.0) * celsius ) + 32 ;
            //round up to 1 decimal place and return
            return Math.Round(fahrenheit, 1);
        }
        
        // Convert MPH to Kph
        public static double ToKph(this double mph)
        {
            var kph = mph * 1.60934400061;
            //round up to 2 decimal places and return
            return Math.Round(kph, 2);
        }

        // Convert Kph to MPH
        public static double ToMph(this double kph)
        {
            var mph = kph / 1.60934400061;
            //round up to 2 decimal places and return
            return Math.Round(mph, 2);
        }

    }
}