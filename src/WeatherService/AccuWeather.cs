using Newtonsoft.Json;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService
{
    // The implementation of the AccuWeather data parser
    public class AccuWeather : IWeather
    {
        // Get the weather data
        public WeatherData GetWeather(string data, measurementTypes.TemperatureType temperatureType, measurementTypes.WindType windType)
        {
            //use JSON to deserialise and map values returned into new AccuWeatherModel object
            var result = JsonConvert.DeserializeObject<AccuWeatherModel>(data);

            return new WeatherData
            {
                Location = result.Where,
                //if temperaturetype was in F then just set tempertature otherwise convert to C
                Temperature = temperatureType == measurementTypes.TemperatureType.Farenheit ? result.TemperatureFahrenheit : result.TemperatureFahrenheit.ToCelsius(),
                //if windtype was in mph then just set wind otherwise convert to to kph
                WindSpeed = windType == measurementTypes.WindType.MPH ? result.WindSpeedMph : result.WindSpeedMph.ToKph()
            };

        }
    }
}