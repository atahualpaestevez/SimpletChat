 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleChat.Entities;
using SimpleChat.Web.Data;
using SimpleChat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChat.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public readonly SimpleChatDBContext _context;
        public readonly UserManager<IdentityUser> _userManager;

        public ChatController(SimpleChatDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var msgViewModel = new List<MessageModel>();
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            var messages = await _context.MessageEntities.ToListAsync();
            foreach (var msg in messages.Take(50).OrderBy(x => x.When))
            {
                msgViewModel.Add(new MessageModel()
                {
                    Text = msg.Text,
                    UserName = msg.UserName,
                    Id = msg.Id,
                    When = msg.When
                });
            }
            return View(msgViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Create(string text)
        {
            if (ModelState.IsValid)
            {
                var sender = await _userManager.GetUserAsync(User);

                var message = new MessageEntity()
                {
                    UserName = User.Identity.Name,
                    UserId = sender.Id.ToString(),
                    Text = text,
                    When = DateTime.Now
                };
                
                await _context.MessageEntities.AddAsync(message);
                await _context.SaveChangesAsync();
                return new JsonResult("Ok");

            }
            return new JsonResult("Invalid");
        }
    }
}