using Microsoft.AspNetCore.Mvc;
using RedisCache.Helpers;
using Microsoft.Extensions.Caching.Distributed;

namespace RedisCache.Controllers
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

        private string loadLocation = "";
        private string isCacheData = "";
        IDistributedCache _cache;
        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<WeatherForecast[]> Get()
        {

            loadLocation = null;
            string recordKey = "Record_" + DateTime.Now.ToString("yyyyMMdd_hhmm");


            var forecast = await _cache.GetRecordAsync<WeatherForecast[]>(recordKey);
            if(forecast is null)
            {
                forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
                loadLocation = $"Loaded from api at {DateTime.Now}";
            } else
            {
                loadLocation = $"Loaded from Redis Cache at {DateTime.Now}";
                isCacheData = "text-danger";
            }
            await _cache.SetRecordAsync(recordKey, forecast);
            return forecast;
        }
    }
}