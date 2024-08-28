using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class HelloController : ControllerBase
    {
        private readonly IHostApplicationLifetime hostLifetime;

        public HelloController(IHostApplicationLifetime _applicationLifetime)
        {
            hostLifetime = _applicationLifetime;
        }

        [HttpGet]
        public IActionResult HandleHello()
        {
            return Ok("Hello from your container!");
        }

        [HttpGet]
        [Route("teapot"), Route("418")]
        public IActionResult HandleTeaPot()
        {
            string json =
                "[{\"teapot\":[" +
                "             ;,'" +
                "     _o_    ;:;'" +
                " ,-.'---`.__ ;" +
                "((j`=====',-'" +
                " `-\\     /" +
                "    `-=-'     " +
                "By Hayley Jane Wakenshaw" +
                "]}]";
            JsonResult result = new JsonResult(json);
            result.StatusCode = 418;
            return result;
        }

        [HttpGet("stop")]
        public IActionResult HandleStop()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                hostLifetime.StopApplication();
            });
            thread.IsBackground = true;
            thread.Start();

            return Accepted();
        }
    }
}
