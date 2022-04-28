using System.Linq;
using Furion.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; 
using Yarp.ReverseProxy.Configuration;
 

public static class YarpSwaggerUIBuilderExtensions
{
    public static IApplicationBuilder ConfigureSwaggerUIWithYarp(this IApplicationBuilder app )
    { 


        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {  
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
            var proxyConfigProvider = app.ApplicationServices.GetRequiredService<IProxyConfigProvider>();
            var yarpConfig = proxyConfigProvider.GetConfig();

            var routedClusters = yarpConfig.Clusters
                .SelectMany(t => t.Destinations,
                    (clusterId, destination) => new {clusterId.ClusterId, destination.Value});

            var groupedClusters = routedClusters
                .GroupBy(q => q.Value.Address)
                .Select(t => t.First())
                .Distinct()
                .ToList();

            foreach (var clusterGroup in groupedClusters)
            {
                var routeConfig = yarpConfig.Routes.FirstOrDefault(q =>
                    q.ClusterId == clusterGroup.ClusterId);
                if (routeConfig == null)
                {
                    StringLoggingPart.Default.SetMessage($"Swagger UI: Couldn't find route configuration for {clusterGroup.ClusterId}...").LogWarning();
                    continue;
                }

                options.SwaggerEndpoint($"{clusterGroup.Value.Address}/swagger/Default/swagger.json", $"{routeConfig.RouteId} API");
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            }
        });
        
        return app;
    }
}