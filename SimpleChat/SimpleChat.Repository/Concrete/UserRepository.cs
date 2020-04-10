
using Microsoft.AspNetCore.Identity;
using SimpleChat.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Repository.Concrete
{
    public class UserRepository : IUserRepository
    {
        private IdentityUser _currentUser;
        private readonly UserManager<IdentityUser> _userManager;
         

    }
}
