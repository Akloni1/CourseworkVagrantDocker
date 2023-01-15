using Microsoft.AspNetCore.Mvc;

namespace color.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : Controller
    {
        private static readonly string[] Colors = new[]
       {
        "Зеленый", "Красный", "Черный", "Белый"
    };
        [HttpGet]
        public string GetRandomColor()
        {
            return Colors[Random.Shared.Next(Colors.Length)];
        }
    }
}
