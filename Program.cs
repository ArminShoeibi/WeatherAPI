using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WeatherAPI.DTOs;
using WeatherAPI.Services;



var weatherService = ServiceLocator.GetRequiredService<WeatherService>();

CurrentWeatherInformation tehranCurrentWeather =
        await weatherService.GetCurrentWeatherByCity("Tehran");

Console.WriteLine(tehranCurrentWeather.ToString());

