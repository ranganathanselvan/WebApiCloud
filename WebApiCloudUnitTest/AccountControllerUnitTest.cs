using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiCloud.Controllers;
using WebApiCloud.Services;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using WebApiCloud.Models;

namespace WebApiCloudUnitTest
{
    [TestClass]
    public class AccountControllerUnitTest
    {
        [TestMethod]
        public void Get_ShouldReturnCorrectString()
        {
            // Set up Prerequisites 
            IUserService mockIUserService = new UserService();
            var mockAccountController = new AccountController(mockIUserService);

            // Act on Test  
            var response = mockAccountController.Get() as OkNegotiatedContentResult<string>;

            // Assert the result
            Assert.AreEqual("Welcome", response.Content);
        }

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange            
            var mockIUserService = new Mock<IUserService>();
            mockIUserService.Setup(x => x.GetUserList())
                .Returns(ReturnUsersList());

            var controller = new AccountController(mockIUserService.Object);

            // Act
            IHttpActionResult actionResult = controller.GetAllUsers();
            var contentResult = actionResult as OkNegotiatedContentResult<List<User>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(ReturnUsersList().Count, contentResult.Content.Count);
        }

        [TestMethod]
        public void GetUser_ShouldReturnUserByEmail()
        {
            // Arrange            
            var mockIUserService = new Mock<IUserService>();
            mockIUserService.Setup(x => x.GetUser("AA@AA.com"))
                .Returns(new User() {
                    Id = "1",
                    FirstName = "AA",
                    LastName = "AA",
                    Email = "AA@AA.com",
                    Phone = "1234567890",
                    Password = "123456"
        });

            var controller = new AccountController(mockIUserService.Object);

            // Act
            IHttpActionResult actionResult = controller.GetUser("AA@AA.com");
            var contentResult = actionResult as OkNegotiatedContentResult<User>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("AA@AA.com", contentResult.Content.Email);
        }

        [TestMethod]
        public void CreateUser_ShouldCreateUser()
        {
            // Arrange
            var mockIUserService = new Mock<IUserService>();
            var controller = new AccountController(mockIUserService.Object);

            // Act
            IHttpActionResult actionResult = controller.CreateUser(new User { Id = "3", FirstName = "CC", LastName = "CC", Email="CC@CC.com", Phone="123131313", Password ="123456" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<User>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(3, createdResult.RouteValues["Id"]);
        }

        private List<User> ReturnUsersList()
        {
            List<User> users = new List<User>();

            User user1 = new User();
            user1.Id = "1";
            user1.FirstName = "AA";
            user1.LastName = "AA";
            user1.Email = "AA@AA.com";
            user1.Phone = "1234567890";
            user1.Password = "123456";

            User user2 = new User();
            user2.Id = "2";
            user2.FirstName = "BB";
            user2.LastName = "BB";
            user2.Email = "BB@BB.com";
            user2.Phone = "0987654321";
            user2.Password = "123456";

            return users;
        }
    }
}
