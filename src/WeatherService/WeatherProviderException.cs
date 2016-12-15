using System;

namespace WeatherService
{
    
    // Custom exception for the weather provider

    public class WeatherServiceException : Exception
    {
        // Initializes a new instance of the WeatherProviderException class.
        public WeatherServiceException() {}

        //  Initializes a new instance of the WeatherProviderException class with a specified error
        public WeatherServiceException(string message) : base(message) {}
    }
}