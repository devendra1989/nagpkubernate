using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevendraNagpDocker2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecastEntity>> Get()
        {
            if (!_context.WeatherForecast.Any())
            {
                for (var i = 1; i < 6; i++)
                {
                    var weatherForecast = new WeatherForecastEntity()
                    {
                        Date = DateTime.Now,
                        Summary = "test-"+ i,
                        TemperatureC = 32
                    };

                    _context.WeatherForecast.Add(weatherForecast);
                   await _context.SaveChangesAsync();
                }
                
            }
            var data = _context.WeatherForecast.ToList();

            return data.ToArray();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
