using fastendpointpoc.web.Models;

namespace fastendpointpoc.web.Services
{
    public interface IForcastService
    {
        IEnumerable<WeatherForecast> GenerateForcast();
        IEnumerable<WeatherForecast> GenerateForcast(int days);
    }
}