using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApiCloud.Common;
using WebApiCloud.Models;

namespace WebApiCloud.Services
{
    /// <summary>
    /// UserService
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _Users;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserService()
        {
            var client = new MongoClient("mongodb+srv://tamran1988:1988-tamil@tamran0-ctnm5.mongodb.net/docmgnt?retryWrites=true&w=majority");
            var database = client.GetDatabase("docmgnt");

            _Users = database.GetCollection<User>("users");
        }

        /// <summary>
        /// CreateUser Method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CreateUser(User user)
        {
            _Users.InsertOne(user);
            return user;
        }

        /// <summary>
        /// UpdateUser Method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("Email", user.Email);
            var update = Builders<User>.Update.Set("UserRoles", user.UserRoles);

            var updatedResult = _Users.UpdateOne(filter, update);
            if(updatedResult.MatchedCount > 0 || updatedResult.ModifiedCount > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// GetUserList Method
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList() =>
            _Users.Find(user => true).ToList();

        /// <summary>
        /// ValidateUser Method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string email, string password)
        {
            var passwordEncrypted = Utility.EncryptData(password);
            var user1 = _Users.Find<User>(user => user.Email.Equals(email) && user.Password.Equals(passwordEncrypted)).FirstOrDefault();
            return user1;
        }

        /// <summary>
        /// GetUser Method
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUser(string email)
        {
            return _Users.Find<User>(user => user.Email == email).FirstOrDefault();
        }
    }

}