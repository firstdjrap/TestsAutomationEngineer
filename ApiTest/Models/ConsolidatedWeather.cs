using System;

namespace ApiTest.Models
{
    public class ConsolidatedWeather
    {
        public long Id { get; set; }
        public string Weather_state_name { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Wind_direction_compass { get; set; }
        public DateTime Created { get; set; }
        public DateTime Applicable_date { get; set; }
        public float Min_temp { get; set; }
        public float Max_temp { get; set; }
        public float The_temp { get; set; }
        public float Wind_speed { get; set; }
        public float Wind_direction { get; set; }
        public float Air_pressure { get; set; }
        public float Humidity { get; set; }
        public float? Visibility { get; set; }
        public int Predictability { get; set; }
    }
}