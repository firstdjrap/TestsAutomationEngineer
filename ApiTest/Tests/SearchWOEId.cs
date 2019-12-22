using ApiTest.Helpers;
using ApiTest.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ApiTest.Tests
{
    public class SearchWOEId
    {
        private SearchHelper _searchHelper;

        [SetUp]
        public void Setup()
        {
            _searchHelper = new SearchHelper();
        }

        [Test]
        public async Task SearchRequestCurrent()
        {
            var dataCities = await _searchHelper.GetDataCity("min");

            var citySearch = new CityModel();
            foreach (var dataCity in dataCities)
                if (dataCity.Title.Equals("Minsk"))
                    citySearch = dataCity;

            var dataWOEId = await _searchHelper.GetDataWOEIdCurrent(citySearch.Woeid);

            Console.WriteLine("\"consolidated_weather\": [");
            foreach (var consolidWeath in dataWOEId.Consolidated_weather)
            {
                Console.WriteLine("\t{{\n\t\t\"id\": {0}\n\t\t\"weather_state_name\": \"{1}\"\n\t\t\"weather_state_abbr\": \"{2}\"\n\t\t\"wind_direction_compass\": " +
                    "\"{3}\"\n\t\t\"created\": \"{4}\"\n\t\t\"applicable_date\": \"{5}\"\n\t\t\"min_temp\": {6}\n\t\t\"max_temp\": {7}\n\t\t\"the_temp\": " +
                    "{8}\n\t\t\"wind_speed\": {9}\n\t\t\"wind_direction\": {10}\n\t\t\"air_pressure\": {11}\n\t\t\"humidity\": {12}\n\t\t\"visibility\": " +
                    "{13}\n\t\t\"predictability\": {14}\n\t}}", consolidWeath.Id, consolidWeath.Weather_state_name, consolidWeath.Weather_state_abbr,
                    consolidWeath.Wind_direction_compass, consolidWeath.Created, consolidWeath.Applicable_date, consolidWeath.Min_temp, consolidWeath.Max_temp,
                    consolidWeath.The_temp, consolidWeath.Wind_speed, consolidWeath.Wind_direction, consolidWeath.Air_pressure, consolidWeath.Humidity,
                    consolidWeath.Visibility, consolidWeath.Predictability);
            }
            Console.WriteLine("]\n\"time\": \"{0}\"\n\"sun_rise\": \"{1}\"\n\"sun_set\": \"{2}\"\n\"timezone_name\": \"{3}\"\n\"parent\": {{\n\t\"title\": " +
                "\"{4}\"\n\t\"location_type\": \"{5}\"\n\t\"woeid\": \"{6}\"\n\t\"latt_long\": \"{7}\"\n}}",
                dataWOEId.Time, dataWOEId.Sun_rise, dataWOEId.Sun_set, dataWOEId.Timezone_name, dataWOEId.Parent.Title, dataWOEId.Parent.Location_type,
                dataWOEId.Parent.Woeid, dataWOEId.Parent.Latt_long);
            Console.WriteLine("\"sources\": [");
            foreach (var source in dataWOEId.Sources)
            {
                Console.WriteLine("\t{{\n\t\t\"title\": \"{0}\"\n\t\t\"slug\": \"{1}\"\n\t\t\"url\": \"{2}\"\n\t\t\"crawl_rate\": \"{3}\"\n\t}}", source.Title, source.Slug,
                    source.Url, source.Crawl_rate);
            }
            Console.WriteLine("]");
            Console.WriteLine("\"title\": \"{0}\"\n\"location_type\": \"{1}\"\n\"woeid\": \"{2}\"\n\"latt_long\": \"{3}\"\n\"timezone\": \"{4}\"",
                dataWOEId.Title, dataWOEId.Location_type, dataWOEId.Woeid, dataWOEId.Latt_long, dataWOEId.Timezone);

            var consolidatedWeather = new ConsolidatedWeather();
            var dateNow = DateTime.Now;

            foreach (var consolidWeath in dataWOEId.Consolidated_weather)
                if (consolidWeath.Applicable_date.Month == dateNow.Month && consolidWeath.Applicable_date.Day == dateNow.Day)
                    consolidatedWeather = consolidWeath;

            Console.WriteLine("\"id\": {0}\n\"weather_state_name\": \"{1}\"\n\"weather_state_abbr\": \"{2}\"\n\"wind_direction_compass\": " +
                    "\"{3}\"\n\"created\": \"{4}\"\n\"applicable_date\": \"{5}\"\n\"min_temp\": {6}\n\"max_temp\": {7}\n\"the_temp\": " +
                    "{8}\n\"wind_speed\": {9}\n\"wind_direction\": {10}\n\"air_pressure\": {11}\n\"humidity\": {12}\n\"visibility\": " +
                    "{13}\n\"predictability\": {14}", consolidatedWeather.Id, consolidatedWeather.Weather_state_name, consolidatedWeather.Weather_state_abbr,
                    consolidatedWeather.Wind_direction_compass, consolidatedWeather.Created, consolidatedWeather.Applicable_date, consolidatedWeather.Min_temp, consolidatedWeather.Max_temp,
                    consolidatedWeather.The_temp, consolidatedWeather.Wind_speed, consolidatedWeather.Wind_direction, consolidatedWeather.Air_pressure, consolidatedWeather.Humidity,
                    consolidatedWeather.Visibility, consolidatedWeather.Predictability);
        }

        [Test]
        public async Task CompareTemperature()
        {
            var dataWOEId = await _searchHelper.GetDataWOEIdCurrent(834463);

            foreach (var consolidWeath in dataWOEId.Consolidated_weather)
            {
                if (consolidWeath.The_temp > 0)
                    Console.WriteLine("{0} - {1} - больше нуля", consolidWeath.Applicable_date, consolidWeath.The_temp);
                else if (consolidWeath.The_temp < 0)
                    Console.WriteLine("{0} - {1} - меньше нуля", consolidWeath.Applicable_date, consolidWeath.The_temp);

                if (consolidWeath.The_temp <= 0)
                    Console.WriteLine("{0} - {1} - предположительно зима", consolidWeath.Applicable_date, consolidWeath.The_temp);
                else if (consolidWeath.The_temp > 0 && consolidWeath.The_temp <= 14)
                    Console.WriteLine("{0} - {1} - предположительно весна/осень", consolidWeath.Applicable_date, consolidWeath.The_temp);
                else if (consolidWeath.The_temp > 14)
                    Console.WriteLine("{0} - {1} - предположительно лето", consolidWeath.Applicable_date, consolidWeath.The_temp);
            }
        }

        [Test]
        public async Task CompareStateWeather()
        {
            var timeNow = DateTime.Now;
            int threeYearsAgo = timeNow.Year - 3;
            var dataWOEIdThreeYearsAgos = await _searchHelper.GetDataWOEId(834463, threeYearsAgo, timeNow.Month, timeNow.Day);
            var dataWOEIds = await _searchHelper.GetDataWOEId(834463, timeNow.Year, timeNow.Month, timeNow.Day);

            bool flagFound = false;
            foreach (var dataWOEIdThreeYearsAgo in dataWOEIdThreeYearsAgos)
                if (dataWOEIdThreeYearsAgo.Applicable_date.Day == timeNow.Day)
                    foreach (var dataWOEId in dataWOEIds)
                        if (dataWOEIdThreeYearsAgo.Applicable_date.Day == dataWOEId.Applicable_date.Day)
                            if (dataWOEIdThreeYearsAgo.Weather_state_name == dataWOEId.Weather_state_name)
                                flagFound = true;

            if (!flagFound)
                Console.WriteLine("Совпадений не найдено");
            else
                Console.WriteLine("Совпадения найдены");
        }
    }
}