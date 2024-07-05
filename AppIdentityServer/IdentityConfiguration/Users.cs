

using AppIdentityServer.Models;
using IdentityModel;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AppIdentityServer.IdentityConfiguration
{
    public class Users
    {
        public static List<SeedUserModel> Get()
        {
            return new List<SeedUserModel>
            {

                new SeedUserModel
                {
                    
                    Username = "manisha",
                    Password = "Manisha@2000",
                    Email="manisha2000@gmail.com",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim("CustomClaim","CustomValue")
                    }
                },

                new SeedUserModel
                {
                    
                    Username = "raj",
                    Password = "Raj@115",
                    Email="raj115@gmail.com",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "stduser")
                    }
                },
                new SeedUserModel
                {
                    
                    Username = "vishwanathan",
                    Password = "Vish@1970",
                    Email="vishwanathan1970@gmail.com",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
