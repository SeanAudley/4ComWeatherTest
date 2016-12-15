using Microsoft.AspNetCore.Mvc;
using WeatherTest.SampleApi.Bbc.Models;

/* Create a simple controller to simulate getting data from the BBC Weather service instead of using their API */

namespace WeatherTest.SampleApi.Bbc.Controllers
{
    public class WeatherController : Controller
    {
        private System.Random _rng = new System.Random();
        
        [HttpGet, Route("[controller]/{location}")]
        public BbcWeatherResult Get(string location)
        {
            return new BbcWeatherResult {
                Location = location,
                TemperatureCelsius = _rng.Next(0, 38),
                WindSpeedKph = _rng.Next(0, 32) };
        }
    }
}
