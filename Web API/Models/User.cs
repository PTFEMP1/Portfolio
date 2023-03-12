﻿using MongoDB.Bson.Serialization.Attributes;

namespace Web_API.Models
{
    public class User : BaseDocumentEntity
    {

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonElement("username")]
        public string username { get; set; }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonElement("password")]
        public string password { get; set; }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        [BsonElement("NPosts")]
        public int nPosts { get; set; }
    }
}
