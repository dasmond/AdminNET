using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Admin.NET.Application;
using Admin.NET.Core;
using Furion;
using Admin.NET.Core.Service;
using Admin.NET.Application.Serice;

namespace Admin.NET.Test
{
    public class SqlSugarTest
    {
        private TestService testService;
        public SqlSugarTest()
        {

            testService = App.GetService<TestService>();
        }
        [Fact]
        public async void Test1()
        {
            var page= await testService.GetTestList();
            Assert.True(page.Count > 0);
        }

        [Fact]
        public async void Test2()
        {
            var userManager= App.GetService<IUserManager>();
            var user = await userManager.CheckUserAsync(0);
            Assert.NotNull(user );
        }


    }
}
