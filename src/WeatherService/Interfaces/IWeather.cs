using WeatherService.Models;

namespace WeatherService.Interfaces
{
    // Interface for the weather provider factory

    public interface IWeather
    {
    
        // Get the weather data passing our data returned and what our measurement temp and wind have to be converted to as specified by the user
        WeatherData GetWeather(string data, measurementTypes.TemperatureType temperatureType, measurementTypes.WindType windType);
    }
}