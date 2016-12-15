using WeatherService;
using WeatherService.Interfaces;

namespace WeatherApp
{
    public class WeatherService : IWeatherService
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public measurementTypes.WindType WindType { get; set; }
        public measurementTypes.TemperatureType TemperatureType { get; set; }
    }
}