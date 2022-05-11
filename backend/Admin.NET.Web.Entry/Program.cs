using Admin.NET.Application;
using Admin.NET.Web.Core;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault();

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