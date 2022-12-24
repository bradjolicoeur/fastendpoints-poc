using fastendpointpoc.web.Services;
using FastEndpoints;

namespace Weather.Forcast
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
    {

        //Injected
        public IForcastService ForcastService { private get; init; }

        public override void Configure()
        {
            Get("/weather/forecasts");
            Summary(s =>
            {
                s.Summary = "Weather Forcast";
            });
            AllowAnonymous();
            ResponseCache(10);
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var forecast = ForcastService.GenerateForcast();
            Response = new Response(forecast);

            await SendAsync(Response, cancellation: c);
        }
    }
}