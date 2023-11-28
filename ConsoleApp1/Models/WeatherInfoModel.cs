using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class WeatherInfoModelRoot
    {
        public WeatherInfoModel Fact { get; set; }
    }

    public class WeatherInfoModel
    {
        [JsonProperty("obs_time")]
        public long ObservationTime { get; set; }
        public long Uptime { get; set; }
        public int Temp { get; set; }
        [JsonProperty("feels_like")]
        public int FeelsLike { get; set; }
        public string Icon { get; set; }
        public string Condition { get; set; }
        public int Cloudiness { get; set; }
        [JsonProperty("prec_type")]
        public int PrecipitationType { get; set; }
        [JsonProperty("prec_prob")]
        public int PrecipitationProbability { get; set; }
        [JsonProperty("prec_strength")]
        public double PrecipitationStrength { get; set; }
        [JsonProperty("is_thunder")]
        public bool IsThunder { get; set; }
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }
        [JsonProperty("pressure_mm")]
        public int PressureMm { get; set; }
        [JsonProperty("pressure_pa")]
        public int PressurePa { get; set; }
        public int Humidity { get; set; }
        public string Daytime { get; set; }
        public bool Polar { get; set; }
        public string Season { get; set; }
        public string Source { get; set; }
        [JsonProperty("accum_prec")]
        public AccumulatedPrecipitation AccumPrec { get; set; }
        [JsonProperty("soil_moisture")]
        public double SoilMoisture { get; set; }
        [JsonProperty("soil_temp")]
        public int SoilTemperature { get; set; }
        [JsonProperty("uv_index")]
        public int UVIndex { get; set; }
        [JsonProperty("wind_gust")]
        public double WindGust { get; set; }
    }

    public class AccumulatedPrecipitation
    {
        public double _1 { get; set; }
        public double _3 { get; set; }
        public double _7 { get; set; }
    }
}
