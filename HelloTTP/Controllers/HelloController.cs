using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HelloApi.Controllers
{
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly IHostApplicationLifetime hostLifetime;

        public HelloController(IHostApplicationLifetime _applicationLifetime)
        {
            hostLifetime = _applicationLifetime;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult HandleHello()
        {
            return Ok("Hello from your container!");
        }

        [HttpGet]
        [Route("teapot"), Route("418")]
        public IActionResult HandleTeaPot()
        {
            string json = "{\r\n   \"message\":\"I'm a little teapot, short and stout :3\",\r\n   \"artist\":\"Hayley Jane Wakenshaw\",\r\n   \"teapot\":[\r\n      \"               ;,' \",\r\n      \"       _o_    ;:;' \",\r\n      \"   ,-.'---`.__ ;   \",\r\n      \"  ((j`=====',-'    \",\r\n      \"   `-\\\\     /       \",\r\n      \"      `-=-'        \"\r\n   ]\r\n}";
            JsonResult result = new JsonResult(json);
            result.StatusCode = 418;
            return result;
        }
    }
}
