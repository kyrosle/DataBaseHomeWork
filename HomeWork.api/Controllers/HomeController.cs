using HomeWork.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.api.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public Person Index()
        {
            return new Person { Id = 0, Name = "Man" };
        }
    }
}
