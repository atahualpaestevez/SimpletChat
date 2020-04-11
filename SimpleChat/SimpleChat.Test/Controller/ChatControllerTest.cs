using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimpleChat.Test.Controller
{
    public class ChatControllerTest
    {
        public readonly Mock<Fakes.FakeSimpletChatDbContext> _context;
        public readonly Mock<Fakes.FakeUserManager> _userManager;

        public ChatControllerTest()
        {
            _context = new Mock<Fakes.FakeSimpletChatDbContext>();
            _userManager = new Mock<Fakes.FakeUserManager>();
        }

        [Fact]
        public void Index_Returns_View()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.ChatController(_context.Object, _userManager.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsAssignableFrom<Task<Microsoft.AspNetCore.Mvc.IActionResult>>(result);
            
        }

        [Fact]
        public void Create_Returns_JsonResult()
        {
            //Arrange
            var controller = new SimpleChat.Web.Controllers.ChatController(_context.Object, _userManager.Object);
            //Act
            var result = controller.Create("TEST");
            //Assert
            Assert.IsAssignableFrom<Task<Microsoft.AspNetCore.Mvc.JsonResult>>(result);
        }
    }
}
