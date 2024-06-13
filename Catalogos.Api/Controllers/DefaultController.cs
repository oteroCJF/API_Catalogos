using Microsoft.AspNetCore.Mvc;

namespace Catalogos.Api.Controllers
{

    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "API Catalogos Online";
        }
    }
}
