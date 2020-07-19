using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiCloud.Controllers;
using WebApiCloud.Services;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;

namespace WebApiCloudUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Set up Prerequisites 
            IUserService mockIUserService = new UserService();
            var mockAccountController = new AccountController(mockIUserService);

            // Act on Test  
            var response = mockAccountController.Get() as OkNegotiatedContentResult<string>;

            // Assert the result
            Assert.AreEqual("Welcome", response.Content);
        }
    }
}
