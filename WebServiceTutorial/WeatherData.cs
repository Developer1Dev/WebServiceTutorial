using Newtonsoft.Json;

namespace WebServiceTutorial
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get ; set; }

        //public double TemperatureDegres { return ((5.0 / 9.0) * (this.Temperature() - 32.) ;} 

        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string Description { set; get; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}