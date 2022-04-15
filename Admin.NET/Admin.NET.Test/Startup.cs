using Furion;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Hosting; 
using System.Net.Http;
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Admin.NET.Core;
using Admin.NET.Application;

// �������������ͣ���һ�������� Startup �������޶������ڶ��������ǵ�ǰ��Ŀ��������
[assembly: TestFramework("Admin.NET.Test.Startup", "Admin.NET.Test")]
namespace Admin.NET.Test
{
    /// <summary>
    /// ��Ԫ����������
    /// </summary>
    /// <remarks>���������ʹ�� Furion �������й���</remarks>
    public sealed class Startup : XunitTestFramework
    {
        public Startup(IMessageSink messageSink) : base(messageSink)
        {
            // ��ʼ�� IServiceCollection ����
            var services = Inject.Create();

            // ��������Ժ� .NET Core һ��ע������ˣ��������������������������� 

            services.AddScoped<IUserManager, TestUserManager>(); 

            // ���� ServiceProvider ����
            services.Build();
             
        }
    }
}