using Admin.NET.Application;
using Admin.NET.Web.Core;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault().ConfigureAppConfiguration((hostingContext, config) => {
    config.AddJsonFile("applicationsettings.json", optional: true, reloadOnChange: true);
});

// ������ע��
builder.Services.AddWorkflow(options =>
{
    options.UsePersistence(sp => sp.GetService<FurionPersistenceProvider>());
});
// ������JSONע��
builder.Services.AddWorkflowDSL();

var app = builder.Build();
// ������ע��
app.UseWorkflow();
app.Run();