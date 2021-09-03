using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Presentation;
using Presentation.Controllers;

namespace Presentation.Tests
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Login() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SignupTest()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Signup() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
