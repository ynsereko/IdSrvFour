using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerFour.Configuration
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
            new Client {
                ClientId = "oauthClient",
                ClientName = "Example Client Credentials Client Application",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {
                    new Secret("superSecretPassword".Sha256())},
                AllowedScopes = new List<string> {"customAPI.read"}
            },
            new Client {
                        ClientId = "openIdConnectClient",
                        ClientName = "Example Implicit Client Application",
                        AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "role",
                            "customAPI.write"
                        }, 
                        ClientSecrets = new List<Secret> {new Secret("superSecretPassword".Sha256())},
                        RedirectUris =           { "http://localhost:44393/signin-oidc" },
                        PostLogoutRedirectUris = { "http://localhost:44393/" },
                        LogoutUri ="http://localhost:44393/signout-oidc",
                    },
            new Client
            {

            }
        };
        }
    }
}
