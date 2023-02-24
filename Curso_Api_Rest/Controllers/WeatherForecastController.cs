using Microsoft.AspNetCore.Mvc;

namespace Curso_Api_Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private static List<WeatherForecast> listweatherForecasts = new List<WeatherForecast>();


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (listweatherForecasts == null || !listweatherForecasts.Any())
        {
            listweatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return listweatherForecasts;
    
    }
    [HttpPost]

    public IActionResult Post(WeatherForecast weatherForecast) {


        listweatherForecasts.Add(weatherForecast);


        return Ok(); 
    
    
    }
    [HttpDelete("{index}")]


    public IActionResult Delete(int index) {
        try
        {
            listweatherForecasts.RemoveAt(index);
        }
        catch (ArgumentOutOfRangeException) {
            return BadRequest();
        
        }
        return Ok();
    }
   
}
