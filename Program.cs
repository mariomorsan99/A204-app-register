using System;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;    
using Microsoft.Graph.Auth;


namespace GraphClient
{
    class Program
    {
        
        private const string _clientId = "8dc33278-c3c6-4d6a-8c55-5d6196215363";
        private const string _tenantId = "5b8083b7-67d6-450d-b4b1-f8a88959a63a";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IPublicClientApplication app;

            app = PublicClientApplicationBuilder    .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                    .WithRedirectUri("http://localhost")
                        .Build();

                        List<string> scopes = new List<string> 
                        { 
                            "user.read" 
                        };

            DeviceCodeProvider provider = new DeviceCodeProvider(app, scopes);

            GraphServiceClient client = new GraphServiceClient(provider);

            User myProfile = await client.Me.Request().GetAsync();

            Console.WriteLine($"Name:\t{myProfile.DisplayName}");
            Console.WriteLine($"AAD Id:\t{myProfile.Id}");

        }
    }
}
