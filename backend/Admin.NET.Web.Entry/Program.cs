
try
{
    var builder = WebApplication.CreateBuilder(args).Inject();
    builder.Host.UseSerilogDefault();
    var app = builder.Build();
    app.Run();
}
catch (Exception ex)
{
    throw new Exception(ex.Message.ToString());
}