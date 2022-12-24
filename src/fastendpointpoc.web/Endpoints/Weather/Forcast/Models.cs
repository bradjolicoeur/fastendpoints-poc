using fastendpointpoc.web.Models;
using FastEndpoints;

namespace Weather.Forcast
{
    public class Request
    {

    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }

    public record Response(IEnumerable<WeatherForecast> Forcasts);

}