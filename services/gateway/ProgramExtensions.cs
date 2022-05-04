// Only use in this file to avoid conflicts with Microsoft.Extensions.Logging
using Dapr.Shared;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Events;
using System.Text;
using Yarp.ReverseProxy.Configuration;

public static class ProgramExtensions
{ 

    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        //读取环境变量 
        builder.Host.UseSerilog(delegate (HostBuilderContext context, LoggerConfiguration configuration)
        {
            var seqServerUrl = builder.Configuration["SeqServerUrl"];
            LoggerConfiguration loggerConfiguration = configuration.
                ReadFrom.
                Configuration(context.Configuration)
                .Enrich.WithProperty("AppName", builder.Configuration["AppName"]??"Gateway Api")
                .Enrich.FromLogContext();

            loggerConfiguration.WriteTo.Seq(seqServerUrl);
            if (context.Configuration["Serilog:WriteTo:0:Name"] == null)
            {
                loggerConfiguration.WriteTo.Console(LogEventLevel.Verbose, "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}").WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "application.log"), LogEventLevel.Information, "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", null, retainedFileCountLimit: null, encoding: Encoding.UTF8, fileSizeLimitBytes: 1073741824L, levelSwitch: null, buffered: false, shared: false, flushToDiskInterval: null, rollingInterval: RollingInterval.Day);
            }
        });
    }

    public static void AddCustomHealthChecks(this WebApplicationBuilder builder) =>
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDapr()
            .AddUrlGroup(new Uri(builder.Configuration["SysHC"]), name: "sysapi-check", tags: new string[] { "sysapi" })
            .AddUrlGroup(new Uri(builder.Configuration["demoHC"]), name: "demoapi-check", tags: new string[] { "demoapi" });


    public static IApplicationBuilder ConfigureSwaggerUIWithYarp(this IApplicationBuilder app)
    {


        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
            var proxyConfigProvider = app.ApplicationServices.GetRequiredService<IProxyConfigProvider>();
            var yarpConfig = proxyConfigProvider.GetConfig();

            var routedClusters = yarpConfig.Clusters
                .SelectMany(t => t.Destinations,
                    (clusterId, destination) => new { clusterId.ClusterId, destination.Value });

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
                    Log.Logger.Error($"Swagger UI: Couldn't find route configuration for {clusterGroup.ClusterId}...");
                    continue;
                }

                options.SwaggerEndpoint($"{clusterGroup.Value.Address}/swagger/Default/swagger.json", $"{routeConfig.RouteId} API");
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            }
        });

        return app;
    }

    public const string AppYarpJsonPath = "yarp.json";

    public static IHostBuilder AddYarpJson(
        this IHostBuilder hostBuilder,
        bool optional = true,
        bool reloadOnChange = true,
        string path = AppYarpJsonPath)
    {
        return hostBuilder.ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddJsonFile(
                    path: AppYarpJsonPath,
                    optional: optional,
                    reloadOnChange: reloadOnChange
                )
                .AddEnvironmentVariables();
        });
    }
}


 