using fastendpointpoc.web.Services;
using FastEndpoints;

namespace Weather.ForcastDays
{
    public class Endpoint : Endpoint<Request, Response, Mapper>
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

        public override Task HandleAsync(Request r, CancellationToken c)
        {
            var forecast = ForcastService.GenerateForcast(r.Days);
            Response = new Response(forecast);

            return SendAsync(Response,cancellation: c);
        }
    }
}