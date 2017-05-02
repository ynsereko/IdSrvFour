﻿using IdentityServer4;
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
                ClientId = "cc.client",
                ClientName = "Example Client Credentials Client Application",
                /*no interactive user, use the clientid/secret for authentication*/
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                /* secret for authentication*/
                ClientSecrets = new List<Secret> {
                    new Secret("superSecretPassword".Sha256())},
                /* scopes that client has access to*/
                AllowedScopes = new List<string> {"customAPI.read"}
            },
            new Client {
                        ClientId = "hybrid.client",
                        ClientName = "Example HybridClient Application",
                        AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                        AllowAccessTokensViaBrowser = false,
                        /* scopes that client has access to*/
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                             IdentityServerConstants.StandardScopes.OfflineAccess,
                            "role",
                            "customAPI.write"
                        },
                         /* secret for authentication*/
                        ClientSecrets = new List<Secret> {new Secret("superSecretPassword".Sha256())},
                        RedirectUris =           { "https://localhost:44393/signin-oidc" },
                        PostLogoutRedirectUris = { "http://localhost:44393/signout-callback-oidc" },
                        LogoutUri ="https://localhost:44393/signout-oidc",
                        AllowOfflineAccess = true

                    },
           
        new Client
        {
            /*The spec recommends using the resource owner password grant only for “trusted” (or legacy) applications. 
             * Generally speaking you are typically far better off using one of the interactive OpenID Connect flows 
             * when you want to authenticate a user and request access tokens*/
            ClientId = "ro.client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, /*resource owner password grant client*/
             /* secret for authentication*/
            ClientSecrets = {new Secret("superSecretPassword".Sha256())},
            /* scopes that client has access to*/
                AllowedScopes = new List<string> {"customAPI.read"}
        }

        };
        }
    }
}
