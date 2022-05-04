using Serilog;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault(config => {
    //读取环境变量
    var seqServerUrl = builder.Configuration["SeqServerUrl"];
    config.Enrich.WithProperty("AppName", builder.Configuration["AppName"] ?? "Demo Api");
    config.WriteTo.Seq(seqServerUrl ?? "http://localhost:5380");
});

var app = builder.Build();
app.Run();