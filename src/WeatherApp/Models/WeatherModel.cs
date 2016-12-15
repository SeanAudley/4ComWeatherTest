using System.ComponentModel.DataAnnotations;
using WeatherService;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Select Wind measurement")]
        public measurementTypes.WindType WindType { get; set; }

        [Required]
        [Display(Name = "Select Temperature measurement")]
        public measurementTypes.TemperatureType TemperatureType { get; set; }

        // simple fields used for displaying the aggregated results

        [Display(Name = "The Average Wind Speed")]
        public string DisplayWind { get; set; }

        [Display(Name = "The Average Temperature")]
        public string DisplayTemperature { get; set; }
    }
}