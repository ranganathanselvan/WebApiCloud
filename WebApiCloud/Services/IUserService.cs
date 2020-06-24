using System.Collections.Generic;
using WebApiCloud.Models;

namespace WebApiCloud.Services
{
    /// <summary>
    /// IUserService Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// ValidateUser Method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User ValidateUser(string email, string password);

        /// <summary>
        /// GetUserList Method
        /// </summary>
        /// <returns></returns>
        List<User> GetUserList();

        /// <summary>
        /// CreateUser Method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User CreateUser(User user);

        /// <summary>
        /// UpdateUser Method
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User UpdateUser(User user);

        /// <summary>
        /// GetUser Method
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUser(string email);
    }
}
