

using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;

namespace MyIdentityServer.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "manisha",
                    Password = "efcrf",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "support@procodeguide.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim("Userid","1")
                    }
                },
                new TestUser
                {
                    SubjectId = "5",
                    Username = "raj",
                    Password = "rwferfrfe",
                    Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, "support@procodeguide.com"),
                        new Claim(ClaimTypes.Role, "admin"),
                        new Claim(ClaimTypes.Name,"5")
                    }
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "vishwanathan",
                    Password = "wrrrfrf",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "support@procodeguide.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim("Userid","3")
                    }
                }
            };
        }
    }
}
