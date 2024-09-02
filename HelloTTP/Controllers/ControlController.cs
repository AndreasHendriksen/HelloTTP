using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HelloTTP.Controllers
{
    [Route("api/control/")]
    [ApiController]
    public class ControlController : ControllerBase
    {
        private readonly IHostApplicationLifetime hostLifetime;

        public ControlController(IHostApplicationLifetime _applicationLifetime)
        {
            hostLifetime = _applicationLifetime;
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
