// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace WpfIdentity.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new CustomIdentityResourcesProfile(), // New Line
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api", "The Api", new[] { JwtClaimTypes.Role }), // Modified Line
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "wpf",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = {"https://localhost:5001"},
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = {"https://notused"},
                    PostLogoutRedirectUris = {"https://notused"},
                    AllowedScopes = {"openid", "profile", "email", "api"},
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}