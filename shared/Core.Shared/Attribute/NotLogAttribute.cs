using Furion.DependencyInjection;
using System;


namespace ServiceCore.Shared
{
    /// <summary>
    /// 禁用日志
    /// </summary>
    [SuppressSniffer, AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class NotLogAttribute : Attribute
    {

    }
}