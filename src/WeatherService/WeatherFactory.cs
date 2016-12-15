using System;
using System.Collections.Generic;
using WeatherService.Interfaces;

namespace WeatherService
{

    // Simple Factory class to contain a list of the available weather api services that the weather app uses

    public static class WeatherFactory
    {
        // create the dictionary with a mapped functions to the services/classes available, easy to maintain like this
        private static Dictionary<string, Func<IWeather>> ServiceMap = new Dictionary<string, Func<IWeather>>
        {
            {"BbcWeather", () => 
                {
                    return new BBCWeather();
                }
            },
            {"AccuWeather", () => 
                {
                    return new AccuWeather();
                }
            }
        };


        // Get the weather service
        public static IWeather GetService(string name)
        {
            // make sure that name is not null, white space and that the service map in our dictionary matches the name being passed
            if (!string.IsNullOrWhiteSpace(name) && ServiceMap.ContainsKey(name))
            {
                return ServiceMap[name]();
            }
            else
            {
                // service was not found in our list so return null to trigger errors
                return null;
            }
        }
    }
}