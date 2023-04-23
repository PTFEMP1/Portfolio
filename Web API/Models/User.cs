using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class User : BaseDocumentEntity
    {

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonRequired]
        [BsonElement("username")]
        [MaxLength(12)]
        [MinLength(4)]
        public string username { get; set; }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonRequired]
        [BsonElement("password")]
        [MaxLength(12)]
        [MinLength(6)]
        public string password { get; set; }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonElement("NPosts")]
        public int nPosts { get; set; } = 0;

        public User(string user, string pass)
        {
            _id = Guid.NewGuid().ToString();
            nPosts = 0;
            username = user;
            password = pass;
        }
        public User()
        {
            //
        }
    }
}
