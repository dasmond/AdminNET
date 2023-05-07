
namespace Admin.NET.Core;

/// <summary>
/// 标记控制器或方法不需要转换为REFSTful风格
/// </summary>
[SuppressSniffer]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class NotRESTfulApiAttribute : Attribute
{
}