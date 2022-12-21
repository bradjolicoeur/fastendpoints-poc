using fastendpointpoc.web.Models;

namespace fastendpointpoc.web.Services
{
    public class ForcastService : IForcastService
    {
        private string[] summaries => new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public IEnumerable<WeatherForecast> GenerateForcast()
        {
            return GenerateForcast(5);
        }

        public IEnumerable<WeatherForecast> GenerateForcast(int days)
        {
            var forecast = Enumerable.Range(1, days).Select(index =>
              new WeatherForecast
              (
                  DateTime.Now.AddDays(index),
                  Random.Shared.Next(-20, 55),
                  summaries[Random.Shared.Next(summaries.Length)]
              ))
              .ToArray();

            return forecast;
        }
    }
}
