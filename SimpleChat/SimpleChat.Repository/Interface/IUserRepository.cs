using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Repository.Interface
{
    public interface IUserRepository
    {
        IdentityUser GetCurrentUser();
    }
}
