using Furion.DependencyInjection;
using System;

namespace ServiceCore.Shared
{
    /// <summary>
    /// 非实体表特性
    /// </summary>
    [SuppressSniffer, AttributeUsage(AttributeTargets.Class)]
    public class NotTableAttribute : Attribute
    {
    }
}