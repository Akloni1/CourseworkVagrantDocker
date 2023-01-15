using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Net.Http.Headers;

namespace car.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomCar : ControllerBase
    {
        private static readonly string[] Cars = new[]
       {
        "БМВ", "Мерседес", "Рено", "Мазда"
    };
        private HttpClient _client;
        public RandomCar()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://Color:80/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        [Route("Default")]
        public IActionResult GetDefaultCar()
        {
            var car = Cars[Random.Shared.Next(Cars.Length)];
           
            return Ok(car);
        }

        [HttpGet]
        [Route("Random")]
        public IActionResult GetRandomCar()
        {
            var response = _client.GetAsync("Color").Result;
            var car = Cars[Random.Shared.Next(Cars.Length)];
            return Ok(car + response.Content.ReadAsStringAsync().Result + "цвета");
        }

    }
}
