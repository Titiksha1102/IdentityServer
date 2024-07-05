using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace AppIdentityServer.Services
{
    public class SeedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<IdentityUser> userManager)
        {
            // Check if there are any users in the database
            if (await userManager.FindByEmailAsync("test@example.com") == null)
            {
                // Create a new IdentityUser
                var user = new IdentityUser
                {
                    UserName = "test@example.com",
                    Email = "test@example.com",
                    EmailConfirmed = true // Ensure the Email is confirmed if required
                };

                // Use UserManager to create the user
                await userManager.CreateAsync(user, "P@ssw0rd"); // Replace with your desired Password

                // You can add additional logic here, such as assigning roles or claims to the user
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

}
