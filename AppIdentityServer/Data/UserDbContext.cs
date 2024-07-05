using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppIdentityServer.Data
{
    public class UserDbContext:IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
        {
        }
    }
}
