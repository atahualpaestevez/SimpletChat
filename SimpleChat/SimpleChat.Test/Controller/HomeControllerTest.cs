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
        private   Mock< Fakes.FakeUserManager> _userManager;
        private   Mock<Fakes.FakeSignInManager> _signInManager;

        public HomeControllerTest( )
        {
            _userManager = new Mock<Fakes.FakeUserManager>();
            _signInManager = new Mock<Fakes.FakeSignInManager>();
        }

        [Fact]
        public void Index_Returns_View()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ActionResult>(result);
        }

        [Fact]
        public void Login_Returns_View()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            //Act
            var result = controller.Login();
            //Assert
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ActionResult>(result);
        }

        [Fact]
        public void Login_Authenticate_And_Returns_View()
        {
            
            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            _userManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new IdentityUser("rgarcia"));
            _signInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<IdentityUser>(), It.IsAny<string>(), false, false)).ReturnsAsync(new SignInResult());
            //Act
            var result = controller.Login("rgarcia","123414");
            //Assert
            Assert.IsAssignableFrom< System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>>(result);
        }

        [Fact]
        public void Register_Returns_View()
        {

            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            //Act
            var result = controller.Register();
            //Assert
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ActionResult>(result);
        }

        [Fact]
        public void Logout_Returns_View()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.HomeController(_userManager.Object, _signInManager.Object);
            //Act
            var result = controller.LogOut();
            //Assert
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ActionResult>(result.Result);
        }
    }
}
