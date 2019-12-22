using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class WOEIdModel
    {
        public List<ConsolidatedWeather> Consolidated_weather { get; set; }
        public DateTime Time { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public string Timezone_name { get; set; }
        public int MyProperty { get; set; }
        public CityModel Parent { get; set; }
        public List<SourcesModel> Sources { get; set; }
        public string Title { get; set; }
        public string Location_type { get; set; }
        public int Woeid { get; set; }
        public string Latt_long { get; set; }
        public string Timezone { get; set; }
    }
}