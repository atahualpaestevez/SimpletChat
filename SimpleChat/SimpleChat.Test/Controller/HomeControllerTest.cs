using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Identity;

namespace SimpleChat.Test.Controller
{
    public class HomeControllerTest
    {
        private   Mock<UserManager<IdentityUser>> _userManager;
        private   Mock<SignInManager<IdentityUser>> _signInManager;

        public HomeControllerTest( )
        {
            _userManager = new Mock<UserManager<IdentityUser>>();
            _signInManager = new Mock<SignInManager<IdentityUser>>();
        }

        [Fact]
        public void Index_When_User_IsNull_Returns_View()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ActionResult>(result);
        }

        [Fact]
        public void Index_When_User_IsAuthenticated_Returns_View()
        {

        }

        [Fact]
        public void Login_Returns_View()
        {

        }

        [Fact]
        public void Register_Returns_View()
        {
            
        }

        [Fact]
        public void Logout_Returns_View()
        {

        }
    }
}
