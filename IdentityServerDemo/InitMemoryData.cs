using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerDemo
{
    public class InitMemoryData
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
           {
               new ApiResource("inventoryapi", "this is inventory api"),
               new ApiResource("orderapi", "this is order api"),
               new ApiResource("productapi", "this is product api")
           };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
           {
               new Client
               {
                   ClientId = "inventory",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,

                   ClientSecrets =
                   {
                       new Secret("inventorysecret".Sha256())
                   },

                   AllowedScopes = { "inventoryapi" }
               },
                new Client
               {
                   ClientId = "order",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,

                   ClientSecrets =
                   {
                       new Secret("ordersecret".Sha256())
                   },

                   AllowedScopes = { "orderapi" }
               },
                new Client
               {
                   ClientId = "product",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,

                   ClientSecrets =
                   {
                       new Secret("productsecret".Sha256())
                   },

                   AllowedScopes = { "productapi" }
               }
           };
        }
        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "10001",
                    Username = "test1@hotmail.com",
                    Password = "test1password"
                },
                new TestUser
                {
                    SubjectId = "10002",
                    Username = "test2@hotmail.com",
                    Password = "test2password"
                },
                new TestUser
                {
                    SubjectId = "10003",
                    Username = "test3@hotmail.com",
                    Password = "test3password"
                }
            };
        }
    }
}
