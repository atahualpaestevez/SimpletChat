using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleChat.Entities;

namespace SimpleChat.Web.Data
{
    public class SimpleChatDBContext : IdentityDbContext
    {
        public SimpleChatDBContext( DbContextOptions<SimpleChatDBContext> options): base(options)
        {

        }
      
        public DbSet<MessageEntity> MessageEntities { get; set; }
    }
}
