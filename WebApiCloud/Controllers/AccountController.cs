using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiCloud.Common;
using WebApiCloud.Models;
using WebApiCloud.Services;
using JWT;

namespace WebApiCloud.Controllers
{
    /// <summary>
    /// Account Controller for Users
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// AccountController Constructor
        /// </summary>
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get String for API Test
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/account/get")]
        public IHttpActionResult Get()
        {
            //var arr = ((Dictionary<string, dynamic>)JsonWebToken.DecodeToObject(auth.ToString(), string.Empty, false))?.First(k => k.Key == "Role").Value;
            return Ok("Welcome");
        }

        /// <summary>
        /// Get all users 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("api/account/getusers")]
        public IHttpActionResult GetAllUsers()
        {
            var users = _userService.GetUserList();
            return Ok(users);
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("api/account/getuserbyemail")]
        public IHttpActionResult GetUser(string email)
        {
            var user = _userService.GetUser(email);
            return Ok(user);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/account/createuser")]
        public IHttpActionResult CreateUser([FromBody]User user)
        {
            try
            {
                if(user == null)
                {
                    return BadRequest("User is not valid");
                }
                user.Password = Utility.EncryptData(user.Password);
                var userObj = _userService.CreateUser(user);

                return Ok(userObj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/account/updateuser")]
        public IHttpActionResult UpdateUser([FromBody]User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User is not valid");
                }

                var findUser = _userService.GetUser(user.Email);
                if(findUser.Id.Length <= 0)
                {
                    return BadRequest("User is not valid");
                }

                var userObj = _userService.UpdateUser(user);
                if(userObj == null)
                {
                    return BadRequest("User data not updated properly");
                }

                return Ok(userObj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
