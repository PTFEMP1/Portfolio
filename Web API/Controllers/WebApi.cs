using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebApi : ControllerBase
    {
        private readonly DatabaseClient<User> _database;
        private readonly ILogger<WebApi> _logger;
        public WebApi(DatabaseClient<User> database,
                      ILogger<WebApi> logger)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet("GetUser")]
        public List<User> Get()
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Empty;
            return _database.GetAll(filter);
        }
        [HttpGet("CreateUser")]
        public string Create(string id)
        {
            return "Não foi possivel criar " + id;
        }
    }
}