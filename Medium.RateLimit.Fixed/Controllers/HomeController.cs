using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Medium.RateLimit.Fixed.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    [EnableRateLimiting("fixed")]
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new {code = 200, message = "Ok"});
    }
}