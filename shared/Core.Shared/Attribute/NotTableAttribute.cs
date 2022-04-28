using Furion.DependencyInjection;
using System;


namespace Admin.NET.Core.Shared
{
    /// <summary>
    /// 非实体表继承该特性
    /// </summary>
    [SuppressSniffer, AttributeUsage(AttributeTargets.Class)]
    public class NotTableAttribute : Attribute
    {

    }
}