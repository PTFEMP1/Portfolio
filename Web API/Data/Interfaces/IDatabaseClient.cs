using MongoDB.Driver;

namespace Web_API.Data
{
    public interface IDatabaseClient<T>
    {

        /// <summary>
        /// Gets all entities based on the filter provided, results can be limited.
        /// </summary>
        /// <param name="filter">Filter Definition.</param>
        /// <param name="limit">Optional limit to limit the amount of results.</param>
        /// <returns>List of entities</returns>
        List<T> GetAll(FilterDefinition<T> filter, int limit = 0);

        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="entity">The entity object to be created in database.</param>
        /// <returns></returns>
        public bool Create(T entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The entity id to be deleted in database.</param>
        /// <returns></returns>
        public bool Delete(string id);

        /// <summary>
        /// Updates entity based on the filter provided.
        /// </summary>
        /// <param name="filter">Filter Definition.</param>
        /// <param name="update">Update Definition.</param>
        /// <returns>List of entities</returns>
        public void UpdateUser(FilterDefinition<T> filter, UpdateDefinition<T> update);
    }
}