﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace dis_identityserver
{
    public static class SD
    {
        public const string Admin = "admin";
        public const string User = "user";

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("ms_general")
            {
                Scopes = new List<string> { "ms_general.read", "ms_general.write", "ms_general.delete" },
                ApiSecrets = new List<Secret> { new Secret("secret".Sha256())}
            }
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(name: "ms_general.read",   displayName: "Read your data."),
                new ApiScope(name: "ms_general.write",  displayName: "Write your data."),
                new ApiScope(name: "ms_general.delete", displayName: "Delete your data.")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "ms_general.read", IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email},
                    RedirectUris={ "https://localhost:3000/callback" },
                    PostLogoutRedirectUris={ "https://localhost:3000/" }

                }
            };  
    }
}
