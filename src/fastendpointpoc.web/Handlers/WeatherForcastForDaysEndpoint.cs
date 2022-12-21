using fastendpointpoc.web.Models;
using fastendpointpoc.web.Services;
using FastEndpoints;
using FluentValidation;

namespace fastendpointpoc.web.Handlers
{
    public class WeatherForcastForDaysEndpoint : Endpoint<ForcastForDaysCommand, ForcastForDaysResponse>
    {
        //Injected
        public IForcastService ForcastService { private get; init; }

        public override void Configure()
        {
            Get("/weather/forecasts/{Days}");
            Summary(s =>
            {
                s.Summary = "Weather Forcast";
            });
            AllowAnonymous();
        }

        public override async Task HandleAsync(ForcastForDaysCommand req, CancellationToken ct)
        {
            var forecast = ForcastService.GenerateForcast(req.Days);

            await SendAsync(new ForcastForDaysResponse(forecast), cancellation: ct);
        }

        
    }

    public class ForcastForDaysCommandValidator : Validator<ForcastForDaysCommand>
    {
        public ForcastForDaysCommandValidator()
        {
            RuleFor(x => x.Days)
                .GreaterThan(0)
                .WithMessage("Kind of silly to request a forcast for no days")
                .LessThanOrEqualTo(10)
                .WithMessage("Forcast can be generated for a maximum of 10 days");
        }
    }

    public class ForcastForDaysCommand
    {
        public int Days { get; init; }
    }
    public record ForcastForDaysResponse(IEnumerable<WeatherForecast> Data);

}
