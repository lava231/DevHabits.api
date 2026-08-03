using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevHabits.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Handling GET /WeatherForecast request at {Time}", DateTime.UtcNow);

        var results = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        _logger.LogDebug("Generated {Count} weather forecasts", results.Length);

        foreach (var f in results)
        {
            _logger.LogTrace("Forecast: {Date} {TempC}C {Summary}", f.Date, f.TemperatureC, f.Summary);
        }

        return results;
    }
}
