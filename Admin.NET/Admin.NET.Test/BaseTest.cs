// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
// 
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
// 
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Admin.NET.Test;

/// <summary>
/// 测试基类
/// </summary>
public class BaseTest : IDisposable
{
    private readonly string _baseUrl = "http://localhost:8888";
    protected readonly EdgeDriver Driver = new ();

    protected BaseTest(string token = null)
    {
        var url = _baseUrl;
        if (!string.IsNullOrWhiteSpace(token)) url += $"/#/login?token={token}";
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="account"></param>
    /// <param name="password"></param>
    protected async Task Login(string account = "superadmin", string password = "123456")
    {
        await Driver.Navigate().RefreshAsync();
        await Task.Delay(6000);

        var inputList = Driver.FindElements(By.CssSelector("#pane-account input"));

        // 输入用户名
        var accountInput = inputList.First();
        accountInput.Clear();
        accountInput.SendKeys(account);

        // 输入密码
        var passwordInput = inputList.Skip(1).First();
        passwordInput.Clear();
        passwordInput.SendKeys(password);

        // 输入验证码
        var captchaInput = inputList.Skip(2).First();
        captchaInput.Clear();
        captchaInput.SendKeys("0");

        // 提交
        var button = Driver.FindElement(By.CssSelector("#pane-account button"));
        button.Click();
    }

    /// <summary>
    /// 打开指定页面
    /// </summary>
    /// <param name="url"></param>
    protected async Task GoToUrl(string url)
    {
        if (url.StartsWith("http")) await Driver.Navigate().GoToUrlAsync(url);
        else await Driver.Navigate().GoToUrlAsync(_baseUrl + "/" + url.TrimStart('/'));
    }

    /// <summary>
    /// 登录用户敲回车
    /// </summary>
    protected void WaitEnter()
    {
        Console.WriteLine("登录用户敲回车继续...");
        Console.ReadLine();
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}