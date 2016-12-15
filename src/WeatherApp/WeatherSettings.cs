using System.Collections.Generic;
using WeatherService.Interfaces;

namespace WeatherApp
{
    public class WeatherSettings
    {       
        public string DefaultTemperatureType { get; set; }
        public string DefaultWindType { get; set; }

        public List<WeatherService> WeatherServices { get; set; }
    }
}