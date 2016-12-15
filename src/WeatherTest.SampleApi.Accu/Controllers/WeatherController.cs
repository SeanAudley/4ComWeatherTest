using Microsoft.AspNetCore.Mvc;
using WeatherTest.SampleApi.Accu.Models;


/* Simple Controller to simulate getting data from the AccuWeather service instead of using their API */

namespace WeatherTest.SampleApi.Accu.Controllers
{
    public class WeatherController : Controller
    {
        private System.Random _rng = new System.Random();

        [HttpGet, Route("{where}")]
        public AccWeatherResult Get(string where)
        {
            return new AccWeatherResult {
                    Where = where,
                    TemperatureFahrenheit = _rng.Next(32, 100),
                    WindSpeedMph = _rng.Next(0, 20)
            };
        }
    }
}
