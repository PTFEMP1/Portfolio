using Microsoft.AspNetCore.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApi : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WebApi> _logger;

        public WebApi(ILogger<WebApi> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetUser")]
        public string Get()
        {
            return "Users ainda não estão disponiveis";
        }
        [HttpGet("CreateUser")]
        public string Create(string id)
        {
            return "Não foi possivel criar " + id;
        }
    }
}