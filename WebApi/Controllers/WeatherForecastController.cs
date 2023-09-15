using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var netCoreVer = System.Environment.Version;
            var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file)
        {
            return Ok(new
            {
                fileName = file.FileName,
                length = file.Length
            });
        }

        [HttpPost("maxsizelimit")]
        [RequestSizeLimit(2000000)]
        public IActionResult MaxSizeLimit(IFormFile file)
        {
            return Ok(new
            {
                fileName = file.FileName,
                length = file.Length
            });
        }
    }
}