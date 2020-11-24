using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.DTOs
{
    public record CurrentWeatherInformation
    {
        public Location location { get; init; }
        public CurrentWeather current { get; init; }
    }
}
