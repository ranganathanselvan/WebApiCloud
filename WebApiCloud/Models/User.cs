using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCloud.Models
{
    /// <summary>
    /// User Class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id for Users
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// User email id
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// User Mobile number
        /// </summary>
        public String Phone { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// List  of roles assigned to user
        /// </summary>
        public List<UserRole> UserRoles { get; set; }
    }
}