
namespace WeatherService.Interfaces
{
    // Interface for the weather service information

    public interface IWeatherService
    {
        // Will contain the name of the service
        string Name { get; set; }

        // Will contain the url of the service
        string Url { get; set; }

        // Will contain the temperature type of the returning data
        measurementTypes.TemperatureType TemperatureType { get; set; }

        // Will contain the wind type of the returning data
        measurementTypes.WindType WindType { get; set; }
    }
}