using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WeatherAPI.DTOs;

namespace WeatherAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ServiceCollection services = new();
            services.AddHttpClient<WeatherService>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var weatherService = serviceProvider.GetService<WeatherService>();

            CurrentWeatherInformation tehranCurrentWeather =
                    await weatherService.GetCurrentWeatherByCity("Tehran");

            Console.WriteLine(tehranCurrentWeather.ToString());

        }
    }
}
