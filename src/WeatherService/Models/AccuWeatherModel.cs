using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class AccuWeatherModel
    {
        // define JSON elements and propertynames for mapping

        [JsonProperty(PropertyName = "where")]
        public string Where { get; internal set; }

        [JsonProperty(PropertyName = "temperatureFahrenheit")]
        public double TemperatureFahrenheit { get; internal set; }

        [JsonProperty(PropertyName = "windSpeedMph")]
        public double WindSpeedMph { get; internal set; }
    }
}