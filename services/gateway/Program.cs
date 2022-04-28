using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args).Inject() ;
builder.Host.AddYarpJson().UseSerilogDefault() ; 
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddMvc();
builder.Services.AddSwaggerGen(options =>
 {
     options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Gateway", Version = "v1" });
     options.DocInclusionPredicate((docName, description) => true);
     options.CustomSchemaIds(type => type.FullName);
 });

var app = builder.Build();
app.ConfigureSwaggerUIWithYarp();
app.MapReverseProxy();
app.Run();


