using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HelloApi.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult HandleHello()
        {
            return Ok("Hello from your container!");
        }

        [HttpGet]
        [Route("teapot"), Route("418")]
        public ActionResult HandleTeaPot()
        {
            JsonResult result = new JsonResult(
                new
                {
                    message = "I'm a little teapot, short and stout :3",
                    teapot = new[]
                    {
                        "             ;,'",
                        "     _o_    ;:;'",
                        " ,-.'---`.__ ;  ",
                        "((j`=====',-'   ",
                        " `-\\     /     ",
                        "    `-=-'       ",
                    },
                    artist = "Hayley Jane Wakenshaw"
                });
            result.StatusCode = 418;
            return result;
        }
    }
}
