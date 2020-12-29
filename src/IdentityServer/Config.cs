// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("myapi", "My API"),
                new ApiScope("myapi-2", "My API 2")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client> 
            { 
                new Client
                {
                    ClientId = "webapp",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("webapp-secret".Sha256())
                    },
                    AllowedScopes = {"myapi"}
                },
                new Client
                {
                    ClientId = "mobile",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("mobile-secret".Sha256())
                    },
                    AllowedScopes = {"myapi-2"}
                },
                new Client
                {
                     ClientId = "mvc",
                     AllowedGrantTypes = GrantTypes.Code,
                     ClientSecrets =
                     {
                         new Secret("mvc-secret".Sha256())
                     },
                     RedirectUris =
                     {
                        "https://localhost:44368/signin-oidc"
                     },
                     PostLogoutRedirectUris = { "https://localhost:44368/signout-callback-oidc" },
                     AllowedScopes = new List<string>
                     {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile
                     }
                }
            };
    }
}