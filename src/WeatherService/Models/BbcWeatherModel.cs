using Newtonsoft.Json;

namespace WeatherService.Models
{
    public class BBCWeatherModel
    {

        // define JSON elements and propertynames for mapping

        [JsonProperty(PropertyName = "location")]
        public string Location { get; internal set; }

        [JsonProperty(PropertyName = "temperatureCelsius")]
        public double TemperatureCelsius { get; internal set; }

        [JsonProperty(PropertyName = "windSpeedKph")]
        public double WindSpeedKph { get; internal set; }
    }
}