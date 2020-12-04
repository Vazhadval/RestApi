using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Options;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Installers
{
    public class FacebookAuthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var facebookAuthSettings = new FaceBookAuthSettings();
            configuration.Bind(nameof(facebookAuthSettings), facebookAuthSettings);
            services.AddSingleton(facebookAuthSettings);

            services.AddHttpClient();
            services.AddSingleton<IFacebookAuthService, FacebookAuthService>();
        }
    }
}
