using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HomeSite.Models
{
    [JsonObject]
    public class WeatherDate
    {
        [JsonProperty("weather")]
        public List<weather> Weather { get; set; }
        [JsonProperty("main")]
        public main Main { get; set; }
        [JsonProperty("wind")]
        public wind Wind { get; set; }
        [JsonProperty("clouds")]
        public clouds Clouds { get; set; }
        [JsonProperty("rain")]
        public rain Rain { get; set; }
        [JsonProperty("snow")]
        public snow Snow { get; set; }
        [JsonProperty("dt")]
        public int Dt { set; get; }
        [JsonProperty("sys")]
        public sys Sys { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cod")]
        public int Cod { get; set; }
        public string _lastUpdate { get; set; }
    }
    [JsonObject]
    public class weather
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
    [JsonObject]
    public class main
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }
        [JsonProperty("pressure")]
        public string Pressure { get; set; }
        [JsonProperty("humidity")]
        public string Humidity { get; set; }
    }
    [JsonObject]
    public class wind
    {
        [JsonProperty("speed")]
        public string Speed { get; set; }
        [JsonProperty("deg")]
        public string Deg { get; set; }
    }
    [JsonObject]
    public class clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
    [JsonObject]
    public class rain
    {
        [JsonProperty("3h")]
        public string Rain { get; set; }
    }
    [JsonObject]
    public class snow
    {
        [JsonProperty("3h")]
        public string Snow { get; set; }
    }
    [JsonObject]
    public class sys
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public float Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }

    }

}