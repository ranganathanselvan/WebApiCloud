using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WebApiCloud.Models
{
    /// <summary>
    /// Portfolio
    /// </summary>
    public class Portfolio
    {
        /// <summary>
        /// Id for Users
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mobile
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// ShortDiscription
        /// </summary>
        public string ShortDiscription { get; set; }
        /// <summary>
        /// LongDiscription
        /// </summary>
        public string LongDiscription { get; set; }
        /// <summary>
        /// Skills
        /// </summary>
        public List<Skills> Skills { get; set; }
        /// <summary>
        /// WorkInfo
        /// </summary>
        public List<WorkInfo> WorkInfo { get; set; }
        /// <summary>
        /// Certifications
        /// </summary>
        public List<Certifications> Certifications { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime? CreatedOn { get; set; }

    }
}