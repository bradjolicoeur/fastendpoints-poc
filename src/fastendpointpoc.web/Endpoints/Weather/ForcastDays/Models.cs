using fastendpointpoc.web.Models;
using FastEndpoints;
using FluentValidation;

namespace Weather.ForcastDays
{
    public class Request
    {
        public int Days { get; init; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Days)
                .GreaterThan(0)
                .WithMessage("Kind of silly to request a forcast for no days")
                .LessThanOrEqualTo(10)
                .WithMessage("Forcast can be generated for a maximum of 10 days");
        }
    }

    public record Response(IEnumerable<WeatherForecast> Forcasts);
}