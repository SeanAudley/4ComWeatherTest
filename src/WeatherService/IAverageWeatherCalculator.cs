using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService
{
    // Average weather calculator interface
    public interface IAverageWeatherCalculator
    {
        // Get the weather service method
        Task<WeatherData> GetWeatherAsync(IEnumerable<IWeatherService> services, string location, measurementTypes.WindType windType, measurementTypes.TemperatureType temperatureType);
    }
}