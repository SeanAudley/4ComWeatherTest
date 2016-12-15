using Newtonsoft.Json;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService
{
    // The implementation of the BBC Weather data parser
    public class BBCWeather : IWeather
    {
        /// Get the weather data
        public WeatherData GetWeather(string data, measurementTypes.TemperatureType temperatureType, measurementTypes.WindType windType)
        {
            //use JSON to deserialise and map values returned into new BBCWeatherModel object
            var result = JsonConvert.DeserializeObject<BBCWeatherModel>(data);

            return new WeatherData
            {
                Location = result.Location,
                //if temperaturetype was in C then just set tempertature otherwise convert to F
                Temperature = temperatureType == measurementTypes.TemperatureType.Celsius ? result.TemperatureCelsius : result.TemperatureCelsius.ToFahrenheit(),
                //if windtype was in kph then just set wind otherwise convert to to Mph
                WindSpeed = windType == measurementTypes.WindType.KPH ? result.WindSpeedKph : result.WindSpeedKph.ToMph()
            };
        }
    }
}