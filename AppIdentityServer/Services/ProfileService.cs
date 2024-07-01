using AppIdentityServer.IdentityConfiguration;
using IdentityServer4.Models;
using IdentityServer4.Services;

using System.Security.Claims;

namespace AppIdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(ILogger<ProfileService> logger)
        {
            _logger = logger;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;

            if (!string.IsNullOrEmpty(sub))
            {
               
                var user = Users.Get().Single(u => u.SubjectId == sub);
                var roleClaim = user.Claims.FirstOrDefault(c => c.Type == "role");
                if (roleClaim != null)
                {
                    _logger.LogInformation($"Role claim found for user {sub}: {roleClaim.Value}");
                }
                else
                {
                    _logger.LogWarning($"Role claim not found for user {sub}");
                }
                var claims = new List<Claim>
            {
                new Claim("name", user.Username),
                new Claim("email", user.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? ""),
                new Claim("role", user.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? ""),
                new Claim("CustomClaim", user.Claims.FirstOrDefault(c => c.Type == "CustomClaim")?.Value ?? "")
                // Add more claims here
            };

                context.IssuedClaims.AddRange(claims);
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }

}
