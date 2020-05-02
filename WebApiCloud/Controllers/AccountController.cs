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

namespace WebApiCloud.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private readonly UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/account/get")]
        public IHttpActionResult Get()
        {
            return Ok("Welcome");
        }

        [Authorize]
        [HttpGet]
        [Route("api/account/getusers")]
        public IHttpActionResult GetAllUsers()
        {
            var users = _userService.GetUserList();
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("api/account/getuserbyemail")]
        public IHttpActionResult GetUser(string email)
        {
            var user = _userService.GetUser(email);
            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/account/createuser")]
        public IHttpActionResult CreateUser([FromBody]User user)
        {
            user.Password = Utility.EncryptData(user.Password);
            var userObj = _userService.CreateUser(user);
            return Ok(userObj);
        }

    }
}
