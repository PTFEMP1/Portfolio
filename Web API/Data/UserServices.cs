using MongoDB.Driver;
using Web_API.Models;

namespace Web_API.Data
{
    public class UserServices
    {
        private readonly IDatabaseClient<User> _database;
        public UserServices(IDatabaseClient<User> database)
        {
            _database = database;
        }
        /// <summary>
        /// Get All users in the database.
        /// </summary>
        /// <returns>A List of Users.</returns>
        public List<User> GetAll()
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Empty;
            return _database.GetAll(filter);
        }

        /// <summary>
        /// Gets the User that matches the ID provided.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>A User or null.</returns>
        public User GetUserById(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(user => user._id, id);
            return _database.GetAll(filter).FirstOrDefault();
        }

        /// <summary>
        /// Gets the User that matches the USERNAME provided.
        /// </summary>
        /// <param name="username">User username.</param>
        /// <returns>A User or null.</returns>
        public User GetUserByUserName(string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(user => user.username, username);
            return _database.GetAll(filter).FirstOrDefault();
        }

        /// <summary>
        /// Gets the User by its USERNAME and verifies if the PASSWORD provided matches the user password provided.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="pass">Password to be validated.</param>
        /// <returns>Returns true if user exist and password match.</returns>
        public bool ValidateUserPassword(string username, string pass)
        {
            bool match = false;
            User user = GetUserByUserName(username);
            if (user != null && user.password.Equals(pass))
            {
                match = true;
            }
            return match;
        }

        /// <summary>
        /// Creates a User in the database
        /// </summary>
        /// <param name="user">User entity to be created.</param>
        /// <returns>True if success</returns>
        public bool CreateUser(User user)
        {
            bool result = false;
            //if (GetUserByUserName(user.username) != null)
            //{
            //}
            result = _database.Create(user);
            return result;
        }

        /// <summary>
        /// Deletes a User in the database
        /// </summary>
        /// <param name="userId">User entity id to be deleted.</param>
        /// <returns>True if success</returns>
        public bool DeleteUserById(string userId)
        {
            return _database.Delete(userId);
        }

        /// <summary>
        /// Updates/Changes a User name in the database
        /// </summary>
        /// <param name="userId">User entity id to be updated.</param>
        /// <returns>True if success</returns>
        public bool UpdateUserName(string userId, string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(user => user._id, userId);
            UpdateDefinition<User> update = Builders<User>.Update.Set(user => user.username, username);
            _database.UpdateUser(filter, update);
            return true;
        }
    }
}
