using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Test.Fakes
{
    public class FakeSimpletChatDbContext : SimpleChat.Web.Data.SimpleChatDBContext
    {
        public FakeSimpletChatDbContext() : base(new DbContextOptions<SimpleChatDBContext>() )
        {

        }
    }
}
