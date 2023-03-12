using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Web_API.Models;

namespace Web_API.Data
{
    public class DatabaseClient<T>
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _config;
        private readonly ILogger<DatabaseClient<T>> _logger;
        private readonly IMongoCollection<T> _collection;
        public DatabaseClient(
            IConfiguration config, 
            ILogger<DatabaseClient<T>> logger) {
            _logger = logger;
            _config = config;
            _logger.LogInformation("Connecting to Database");
            _database = new MongoClient(_config.GetConnectionString(Constants.Database.ConnectionString)).GetDatabase(Constants.Database.DatabaseName);

            //Verify the type of T and determine Collection needed, for now not needed
            _collection = _database.GetCollection<T>(Constants.Database.UserCollection);

        }
        public List<T> GetAll(FilterDefinition<T> filter, int limit = 0)
        {
            return _collection.Find(filter).Limit(limit).ToList();
        }
    }
}
