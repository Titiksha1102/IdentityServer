using System.Security.Claims;

namespace AppIdentityServer.Models
{
    public class SeedUserModel
    {
        public string Username;
        public string Password;
        public string Email;
        public List<Claim> Claims;
    }
}
