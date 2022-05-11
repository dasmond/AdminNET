using Admin.NET.Application;
using Admin.NET.Web.Core;

var builder = WebApplication.CreateBuilder(args).Inject();
builder.Host.UseSerilogDefault();

// 工作流注册
builder.Services.AddWorkflow(options =>
{
    options.UsePersistence(sp => sp.GetService<FurionPersistenceProvider>());
});
// 工作流JSON注册
builder.Services.AddWorkflowDSL();

var app = builder.Build();
// 工作流注入
app.UseWorkflow();
app.Run();