using ApiTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTest.Helpers
{
    public class SearchHelper
    {
        private HttpClient _httpClient;

        public SearchHelper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CityModel>> GetDataCity(string city)
        {
            var uri = "https://www.metaweather.com/api/location/search/?query=" + city;
            var response = await _httpClient.GetAsync(uri);

            var responseData = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CityModel>>(responseData.Result);
        }

        public async Task<List<ConsolidatedWeather>> GetDataWOEId(int woeid, int year, int month, int day)
        {
            var uri = "https://www.metaweather.com/api/location/" + woeid + "/" + year + "/" + month + "/" + day + "/";
            var response = await _httpClient.GetAsync(uri);

            var responseData = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ConsolidatedWeather>>(responseData.Result);
        }

        public async Task<WOEIdModel> GetDataWOEIdCurrent(int woeid)
        {
            var uri = "https://www.metaweather.com/api/location/" + woeid + "/";
            var response = await _httpClient.GetAsync(uri);

            var responseData = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WOEIdModel>(responseData.Result);
        }
    }
}