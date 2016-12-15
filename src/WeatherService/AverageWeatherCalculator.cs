using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService
{
    // IMPLEMENTATION of the interface class


    public class AverageWeatherCalculator : IAverageWeatherCalculator
    {
        
        // constructor
        public AverageWeatherCalculator() {}

        
        // Get the weather
        public async Task<WeatherData> GetWeatherAsync(IEnumerable<IWeatherService> services, string location, measurementTypes.WindType windType, measurementTypes.TemperatureType temperatureType)
        {
            if (services == null || string.IsNullOrWhiteSpace(location))
            {
                throw new WeatherServiceException("No Location Entered.");
            }

            // create a list to contain each weather service providers results
            var results = new List<WeatherData>();

            foreach (var service in services)
            {
                // setup httpclient, address and header
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"{service.Url}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // get response async from the weather service's api
                HttpResponseMessage response = client.GetAsync($"{service.Url}/{location}").Result;

                //success?
                if (response.IsSuccessStatusCode)
                {
                    //get the returned data
                    var returnedWeatherValue = response.Content.ReadAsStringAsync();
                    var item = await returnedWeatherValue.ConfigureAwait(false);

                    //using the current service, call it's GetWeather method and what to return the temp and wind type as
                    var data = WeatherFactory.GetService(service.Name);
                    results.Add(data.GetWeather(item, temperatureType, windType));
                }
            }
            // call GetAverageWeather passing results list to get the aggregated result and return the result
            return GetAverageWeather(results);
        }


        // private method to calculate the aggregated average weather result
        private WeatherData GetAverageWeather(IEnumerable<WeatherData> weather)
        {
            // using the weather list and LINQ, group by location and use LINQs Average 
            var summary = weather.GroupBy(g => g.Location).Select(x => new WeatherData
            {
                Location = x.Key,
                // round to 1 decimal places, useful if in the future SI units are used as they have to be rounded up to x amount of decimal places
                Temperature = Math.Round(x.Average(y => y.Temperature),1),
                //just normal round up value
                WindSpeed = Math.Truncate(x.Average(y => y.WindSpeed))
            });
            //return the first entry only with the aggregated average temp+wind
            return summary.First();
        }
    }
}