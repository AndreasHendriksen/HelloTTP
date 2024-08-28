using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private static string textData = "Hello World!";

        private readonly IHostApplicationLifetime hostLifetime;

        public DataController(IHostApplicationLifetime _applicationLifetime)
        {
            hostLifetime = _applicationLifetime;
        }

        [HttpGet]
        public IActionResult HandleGetString()
        {
            return Content(textData);
        }

        [HttpPost]
        public IActionResult HandlePostString([FromBody] string _data)
        {
            if (_data == null || _data == "")
                return BadRequest();

            textData = _data;

            return Ok();
        }
    }
}
