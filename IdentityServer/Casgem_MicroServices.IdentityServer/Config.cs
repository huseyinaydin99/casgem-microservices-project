// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Casgem_MicroServices.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog")
            {
                Scopes =
                {
                    "catalog_fullpermission"
                }
            },
            new ApiResource("resource_photostock")
            {
                Scopes =
                {
                    "photostock_fullpermission"
                }
            },
            new ApiResource("resorce_basket")
            {
                Scopes =
                {
                    "basket_fullpermission"
                }
            },
            new ApiResource("resource_discount")
            {
                Scopes =
                {
                    "discount_fullpermission"
                }
            },
            new ApiResource("resource_order")
            {
                Scopes =
                {
                    "order_fullpermission"
                }
            },
            new ApiResource("resource_payment")
            {
                Scopes =
                {
                    "payment_fullpermission"
                }
            },
            new ApiResource("resource_gateway")
            {
                Scopes =
                {
                    "gateway_fullpermission"
                }
            }
            ,
            new ApiResource("resource_cargo")
            {
                Scopes =
                {
                    "cargo_fullpermission"
                }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResource()
                        {
                            Name = "roles",
                            DisplayName = "Roles",
                            Description = "Kullanıcı rolleri",
                            UserClaims = new []{"role"}
                        }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Ürünler ve kategoriler API için full erişim."),
                new ApiScope("photostock_fullpermission","Fotoğraf Deposu API için full erişim."),
                new ApiScope("basket_fullpermission","Sepet API için full erişim."),
                new ApiScope("discount_fullpermission","İndirim API için full erişim."),
                new ApiScope("order_fullpermission","Sipariş API için full erişim."),
                new ApiScope("payment_fullpermission","Ödeme API için full erişim."),
                new ApiScope("gateway_fullpermission","Geçiş kapısı API için full erişim."),
                new ApiScope("cargo_fullpermission","Kargo API için full erişim."),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
                /*new ApiScope("scope1"),
                new ApiScope("scope2"),*/
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client//sisteme giriş yaparken üye olmak zorunda olmayan!!! istemci.
                {
                    ClientName = "Casgem1",
                    ClientId = "CoreClient1",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "catalog_fullpermission", "photo_stock_fullpermission", IdentityServerConstants.LocalApi.ScopeName
                    }
                    /*
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "scope1" }
                    */
                },

                // interactive client using code flow + pkce
                new Client //sisteme giriş yaparken üye olmak zorunda olan istemci.
                {
                    ClientName = "Casgem2",
                    ClientId = "CoreClient2",
                    AllowOfflineAccess = true,
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = 
                    {
                        "basket_fullpermission",
                        "order_fullpermission",
                        "discount_fullpermission",
                        "cargo_fullpermission",
                        "payment_fullpermission",
                        "photo_stock_fullpermission",
                        "catalog_fullpermission", 
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName, "roles"
                    },
                    AccessTokenLifetime = 1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int) (DateTime.Now.AddDays(60) - DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                    /*
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                    */
                },
            };
    }
}