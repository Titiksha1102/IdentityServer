using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace AppIdentityServer.Data
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlServer
                ("Data Source=(localdb)\\MSSQLLocalDB;Database=AuthDB;Integrated Security=True;Connect Timeout=30;Encrypt=false;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}
