using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace Web_API.Data
{
    public class DatabaseClient
    {
        private readonly IMongoDatabase _database;
        public DatabaseClient() {
            _database = new MongoClient("mongodb+srv://admin:fb7yHKdM1tpnz2Lx@documents.iyvah.mongodb.net/").GetDatabase("Documents");
        }
    }
}
