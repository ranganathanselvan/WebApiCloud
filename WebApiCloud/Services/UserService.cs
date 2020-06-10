﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiCloud.Common;
using WebApiCloud.Models;

namespace WebApiCloud.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _Users;

        public UserService()
        {
            var client = new MongoClient("mongodb+srv://tamran1988:1988-tamil@tamran0-ctnm5.mongodb.net/docmgnt?retryWrites=true&w=majority");
            var database = client.GetDatabase("docmgnt");

            _Users = database.GetCollection<User>("users");
        }

        public User CreateUser(User user)
        {
            _Users.InsertOne(user);
            return user;
        }

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

        public List<User> GetUserList() =>
            _Users.Find(user => true).ToList();


        public User ValidateUser(string email, string password)
        {
            return _Users.Find<User>(user => user.Email == email && user.Password == Utility.EncryptData(password)).FirstOrDefault();
        }

        public User GetUser(string email)
        {
            return _Users.Find<User>(user => user.Email == email).FirstOrDefault();
        }
    }

    public interface IUserService
    {
        User ValidateUser(string email, string password);

        List<User> GetUserList();

        User CreateUser(User user);

        User UpdateUser(User user);

        User GetUser(string email);
    }
}