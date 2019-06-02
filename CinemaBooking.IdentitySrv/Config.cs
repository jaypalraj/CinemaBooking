using CinemaBooking.Infrastructure;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace CinemaBooking.IdentitySrv
{
    public class Config
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Jaypal",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Bill",
                    Password = "passowrd"
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("CinemaBookingAPI","Cinema Booking Main APIs")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "CinemaBookingAPI" }
                },
                new Client
                {
                    ClientId = "resourceowner.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "CinemaBookingAPI",
                        IdentityServerConstants.StandardScopes.Profile

                    }
                },
                new Client
                {
                    ClientId = "cinemabooking.ui",
                    ClientName = "CinemaBooking UI",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { $"{CinemaBookingConstants.WebUIUrl}signin-oidc" },
                    PostLogoutRedirectUris = { $"{CinemaBookingConstants.WebUIUrl}signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId = "swagger.api.ui",
                    ClientName = "Swagger API UI",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { $"{CinemaBookingConstants.WebAPIsUrl}swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{CinemaBookingConstants.WebAPIsUrl}swagger" },

                    AllowedScopes = { "CinemaBookingAPI" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}