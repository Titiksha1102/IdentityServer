using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppIdentityServer.IdentityConfiguration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppIdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileService(ILogger<ProfileService> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;

            if (!string.IsNullOrEmpty(sub))
            {
                var user = await _userManager.FindByIdAsync(sub);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("name", user.UserName),
                        new Claim("Email", user.Email ?? ""),
                    };

                    var userClaims = await _userManager.GetClaimsAsync(user);

                    claims.AddRange(userClaims);

                    _logger.LogInformation($"Found {userClaims.Count} claims for user {sub}");

                    context.IssuedClaims.AddRange(claims);
                }
                else
                {
                    _logger.LogWarning($"User not found: {sub}");
                }
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.FindFirst("sub")?.Value;

            if (!string.IsNullOrEmpty(sub))
            {
                var user = await _userManager.FindByIdAsync(sub);
                context.IsActive = user != null;
            }
            else
            {
                context.IsActive = false;
            }
        }
    }
}
