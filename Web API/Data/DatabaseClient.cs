using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Web_API.Models;

namespace Web_API.Data
{
    public class DatabaseClient<T> : IDatabaseClient<T>
        where T : BaseDocumentEntity
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _config;
        private readonly ILogger<DatabaseClient<T>> _logger;
        private readonly IMongoCollection<T> _collection;
        public DatabaseClient(
            IConfiguration config,
            ILogger<DatabaseClient<T>> logger)
        {
            _logger = logger;
            _config = config;
            _logger.LogInformation("Connecting to Database");
            _database = new MongoClient(_config.GetConnectionString(Constants.Database.ConnectionString)).GetDatabase(Constants.Database.DatabaseName);

            // Verify the type of T and determine Collection needed, for now not needed
            _collection = _database.GetCollection<T>(Constants.Database.UserCollection);

        }

        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="entity">The entity object to be created in database.</param>
        /// <returns></returns>
        public bool Create(T entity)
        {
            bool result = false;
            try
            {
                _collection.InsertOne(entity);
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Gets all entities based on the filter provided, results can be limited.
        /// </summary>
        /// <param name="filter">Filter Definition.</param>
        /// <param name="limit">Optional limit to limit the amount of results.</param>
        /// <returns>List of entities</returns>
        public List<T> GetAll(FilterDefinition<T> filter, int limit = 0)
        {
            List<T> result = new List<T>();
            try
            {                
                result = _collection.Find(filter).Limit(limit).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Updates entity based on the filter provided.
        /// </summary>
        /// <param name="filter">Filter Definition.</param>
        /// <param name="update">Update Definition.</param>
        /// <returns>List of entities</returns>
        public void UpdateUser(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                _collection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The entity id to be deleted in database.</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            bool result = false;
            try
            {
                _collection.DeleteOne(entity => entity._id.Equals(id));
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }
    }
}
