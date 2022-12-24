using fastendpointpoc.web.Services;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddResponseCaching();
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "Weather Forcast API";
    settings.Version = "v1";
    
});

builder.Services.AddScoped<IForcastService, ForcastService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();


app.Run();

