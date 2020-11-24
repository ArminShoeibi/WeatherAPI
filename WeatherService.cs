using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.DTOs;

namespace WeatherAPI
{

    public class WeatherService
    {
        private readonly string APIKey = "4c8aa095e62b406eb71211822202311";
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {

            _httpClient = httpClient;
            _httpClient.BaseAddress =
             new Uri("http://api.weatherapi.com/v1/current.json");

        }

        public async Task<CurrentWeatherInformation> GetCurrentWeatherByCity(string cityName)
        {
            string url = $"?key={APIKey}&q={cityName}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            Stream responseBody = await response.Content.ReadAsStreamAsync();

            var weatherApiDto = 
                await JsonSerializer.DeserializeAsync<CurrentWeatherInformation>(responseBody);

            return weatherApiDto;
        }

    }
}
