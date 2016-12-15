using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeatherApp.Models;
using WeatherService;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IAverageWeatherCalculator _WeatherService;
        private readonly WeatherSettings _settings;

        public HomeController(IOptions<WeatherSettings> settings, IAverageWeatherCalculator averageWeatherCalculator)
        {
            _WeatherService = averageWeatherCalculator;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return View(new WeatherModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(WeatherModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // call async task to get the weather data
            var data = await _WeatherService.GetWeatherAsync(_settings.WeatherServices, model.Location, model.WindType, model.TemperatureType).ConfigureAwait(false);

            //update model with aggregated data
            model.Location = data.Location;
            //build displaytemperature, if model temperaturetype was celsius selected add a 'C' otherwise add an 'F'
            model.DisplayTemperature = data.Temperature.ToString() + (model.TemperatureType == measurementTypes.TemperatureType.Celsius ? "C" : "F").ToString();
            //build displaytemperature, if model windtype was mph selected add 'mph' otherwise add 'K/PH' 
            model.DisplayWind = data.WindSpeed.ToString() + (model.WindType == measurementTypes.WindType.MPH ? " MPH" : " K/PH").ToString();
            
            //return view
            return View("Results", model);
        }      

        public IActionResult Error()
        {
            return View();
        }
        
    }
}
