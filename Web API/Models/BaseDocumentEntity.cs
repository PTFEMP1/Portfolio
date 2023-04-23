using MongoDB.Bson.Serialization.Attributes;

namespace Web_API.Models
{
    public abstract class BaseDocumentEntity
    {
        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonId]
        [BsonRequired]
        public string _id { get; set; } = Guid.NewGuid().ToString();
    }
}
