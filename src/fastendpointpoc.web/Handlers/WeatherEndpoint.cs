using fastendpointpoc.web.Models;
using fastendpointpoc.web.Services;
using FastEndpoints;

namespace fastendpointpoc.web.Handlers
{
    public class WeatherEndpoint : EndpointWithoutRequest<WeatherForcastResponse>
    {
        
        public IForcastService ForcastService { get;  init; }

        public override void Configure()
        {
            Get("/weather/forecasts");
            Summary(s =>
            {
                s.Summary = "Weather Forcast";
            });
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var forecast = ForcastService.GenerateForcast();
            
            await SendAsync(new WeatherForcastResponse(forecast), cancellation: ct);
        }

    }

    public record WeatherForcastResponse(IEnumerable<WeatherForecast> Forcasts)
    { }


    
}
