using ApiTest.Helpers;
using ApiTest.Models;
using NUnit.Framework;
using System.Globalization;
using System.Threading.Tasks;

namespace ApiTest.Tests
{
    public class SearchCityTest
    {
        private SearchHelper _searchHelper;

        [SetUp]
        public void Setup()
        {
            _searchHelper = new SearchHelper();
        }

        [Test]
        public async Task SearchRequest_CompareObjects()
        {
            var dataCities = await _searchHelper.GetDataCity("min");

            var City = new CityModel { Title = "Minsk", Location_type = "City", Woeid = 834463, Latt_long = "53.90255,27.563101" };

            var citySearch = new CityModel();
            foreach (var dataCity in dataCities)
                if (dataCity.Title.Equals("Minsk"))
                    citySearch = dataCity;

            Assert.AreEqual(citySearch, City);
        }

        [Test]
        public async Task SearchRequest_ComparePosition()
        {
            var dataCities = await _searchHelper.GetDataCity("min");

            var position = new PositionModel { Lattitude = 53.90255f, Longitude = 27.563101f };

            var citySearch = new CityModel();
            foreach (var dataCity in dataCities)
                if (dataCity.Title.Equals("Minsk"))
                    citySearch = dataCity;

            var coordinates = citySearch.Latt_long.Split(",");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var positionSearch = new PositionModel
            {
                Lattitude = float.Parse(coordinates[0]),
                Longitude = float.Parse(coordinates[1])
            };

            Assert.AreEqual(positionSearch, position);
        }
    }
}