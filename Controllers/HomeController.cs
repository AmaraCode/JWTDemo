using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ApiJwtDemo.Controllers
{

    
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class HomeController : Controller
    {


        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("this is a test");
        }

       
    }
}