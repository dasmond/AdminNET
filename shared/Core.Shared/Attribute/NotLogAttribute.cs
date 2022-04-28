using Furion.DependencyInjection;
using System;


namespace Admin.NET.Core.Shared
{
    /// <summary>
    /// 禁用日志
    /// </summary>
    [SuppressSniffer, AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class NotLogAttribute : Attribute
    {

    }
}