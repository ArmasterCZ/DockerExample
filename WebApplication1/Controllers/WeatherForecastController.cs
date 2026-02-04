using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpPost(Name = "SaveUser")]
        public async Task SaveUser(UserModel user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CustomerDatabase");
            var collection = database.GetCollection<UserModel>("Users");

            await collection.InsertOneAsync(user);

            //TODO
            //docker-compose -f C:\Users\Armaster\Downloads\mongoDocker.yaml up
        }
    }
}
