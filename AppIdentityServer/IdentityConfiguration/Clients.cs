


using IdentityServer4;
using IdentityServer4.Models;

namespace AppIdentityServer.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "weatherApi",
                ClientName = " ASP.NET Core NET Core Weather Api",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                AllowedScopes = new List<string> {"weatherApi.read"}
            },
            new Client
            {
                ClientId = "oidcMVCApp",
                ClientName = "Sample  ASP.NET Core NET Core MVC Web App",
                ClientSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string> {"https://localhost:7011/signin-oidc"},
                PostLogoutRedirectUris = { "https://localhost:7011/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    "openid",
                    "profile",
                    "Email",
                    "role",
                    "weatherApi.read",
                    "CustomClaim"
                },
                RequirePkce = true,
                AllowPlainTextPkce = false
            }
        };
        }
    }
}
