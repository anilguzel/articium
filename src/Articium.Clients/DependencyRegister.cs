using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articium.Clients
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            var clientConfigurations = new ClientConfigurations();
            configuration.GetSection("ClientConfigurations").Bind(clientConfigurations);
            if (clientConfigurations is null) throw new ArgumentNullException();

            services.AddHttpClient<IVarnishClient, VarnishClient>(client =>
            {
                client.BaseAddress = new Uri(clientConfigurations.VarnishClient.Url);
                client.Timeout = TimeSpan.FromMilliseconds(clientConfigurations.VarnishClient.Timeout);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IArticleClient, ArticleClient>(client =>
            {
                client.BaseAddress = new Uri(clientConfigurations.ArticleClient.Url);
                client.Timeout = TimeSpan.FromMilliseconds(clientConfigurations.ArticleClient.Timeout);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}

