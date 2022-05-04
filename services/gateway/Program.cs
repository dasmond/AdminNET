using Microsoft.OpenApi.Models;
using Dapr.Shared; 

const string DefaultCorsPolicyName = "Default";
var builder = WebApplication.CreateBuilder(args);
builder.AddCustomHealthChecks();
builder.Host.AddYarpJson() ; 
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
      .AddTransforms<DaprTransformProvider>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(DefaultCorsPolicyName, builder =>
    {
        builder
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    });
});

builder.Services.AddMvc();
builder.Services.AddSwaggerGen(options =>
 {
     options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Gateway", Version = "v1" });
     options.DocInclusionPredicate((docName, description) => true);
     options.CustomSchemaIds(type => type.FullName);
 });

var app = builder.Build();

app.UseCors(DefaultCorsPolicyName);
app.ConfigureSwaggerUIWithYarp();
app.MapReverseProxy();
app.MapGet("/", context => {
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();


