using API_Key_Auth.Data.Config;
using Microsoft.AspNetCore.Mvc;

namespace ApiKeyAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : Controller
    {

        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        //[ApiKeyAuthFilter]
        public IActionResult Get()
        {
            return Ok("Successful");
        }


        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Deleted");
        }
    }
}
