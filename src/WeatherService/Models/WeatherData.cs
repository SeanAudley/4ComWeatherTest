namespace WeatherService.Models
{
    
    // The weather data model to return
    
    public class WeatherData
    {
        // The location
        public string Location { get; set; }

        // The temperature
        public double Temperature { get; set; }

        // The wind speed
        public double WindSpeed { get; set; }
    }
}