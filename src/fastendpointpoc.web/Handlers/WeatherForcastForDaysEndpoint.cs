using fastendpointpoc.web.Models;
using fastendpointpoc.web.Services;
using FastEndpoints;

namespace fastendpointpoc.web.Handlers
{
    public class WeatherForcastForDaysEndpoint : Endpoint<ForcastForDaysCommand, ForcastForDaysResponse>
    {

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

    public class ForcastForDaysCommand
    {
        public int Days { get; init; }
    }
    public record ForcastForDaysResponse(IEnumerable<WeatherForecast> Data);

}
