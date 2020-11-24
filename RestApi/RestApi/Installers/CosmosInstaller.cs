using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Installers
{
    public class CosmosInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
                configuration["CosmosSettings:DatabaseName"],
                configuration["CosmosSettings:AccountUri"],
                configuration["CosmosSettings:AccountKey"],
                new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp });

            services.AddCosmosStore<CosmosPostDto>(cosmosStoreSettings);
        }
    }
}
